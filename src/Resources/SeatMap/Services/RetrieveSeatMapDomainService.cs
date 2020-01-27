namespace NS.Booking.Infrastructure.Fake.Resources.SeatMap.Services
{
    using Newshore.Core.Storage.Interfaces;
    using NS.Booking.Infrastructure.Fake.Resources.SeatMap.Models.Configuration;
    using NS.Booking.Resources.Domain.SeatMap.Enums;
    using NS.Booking.Resources.Domain.SeatMap.Models;
    using NS.Booking.Resources.Domain.SeatMap.Services;
    using NS.Core.Storage.Cache.Distributed;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class RetrieveSeatMapDomainService : IRetrieveSeatMapDomainService
    {
        private readonly IDistributedCacheStrategy _distributedCache;
        private readonly IStoreInSessionStrategy _sessionStorage;
        private readonly ConfigTransports _configTransports;

        public RetrieveSeatMapDomainService(
            IDistributedCacheStrategy distributedCache,
            IStoreInSessionStrategy sessionStorage,
            ConfigTransports transportsConfiguration)
        {
            this._distributedCache = distributedCache;
            this._sessionStorage = sessionStorage;
            this._configTransports = transportsConfiguration;
        }

        public Transport Retrieve(string segmentId)
        {
            var transport = this._distributedCache.Get<Transport>($"SeatMap_{segmentId}");

            if (transport != null)
            {
                //SetUnavailableSeats(transport, segmentId);
                return transport;
            }

            var configTransport = _configTransports.Transports.FirstOrDefault(x => x.Suffix == "NS" && x.Type == "333");

            //Fake to create data
            transport = CreateTransport(configTransport, segmentId);

            // Save seatmap in cache for 15 days
            this._distributedCache.Add($"SeatMap_{segmentId}", transport, 21600);

            return transport;
        }

        #region Data Generator

        private CabinElement CreateSeat(int m, string letter)
        {
            int row = m + 1;
            var isExtraLeg = row < 6;
            return new CabinElement
            {
                Spaces = 1,
                Type = CabinElementType.Seat,
                SeatInfo = new SeatInfo
                {
                    Row = row,
                    Column = letter.ToString(),
                    Availability = SeatAvailability.Available,
                    SeatNumber = $"{row.ToString()}{letter.ToString()}",
                    Category = !isExtraLeg ? (row > 15 ? "Standard" : "UpFront") : "ExtraLeg",
                    Properties = new List<SeatProperty>{
                        new SeatProperty { Type = SeatPropertyType.IsExtraLeg, Value = isExtraLeg },
                        new SeatProperty { Type = SeatPropertyType.IsExitRow, Value = (row % 6) == 0 },
                        new SeatProperty { Type = SeatPropertyType.IsInfantAllowed, Value = !isExtraLeg && (row % 6) != 0 },
                        new SeatProperty { Type = SeatPropertyType.IsChildAllowed, Value = (row % 6) != 0 },
                        new SeatProperty { Type = SeatPropertyType.IsPrmAllowed, Value = (row % 6) != 0 }
                    }
                }
            };
        }

        private Transport CreateTransport(ConfigTransport configTransport, string segmentId)
        {
            var transport = new Transport
            {
                Sufix = configTransport.Suffix,
                Type = configTransport.Type,
                Segment = new Segment { SegmentId = segmentId }
            };
            var decks = new List<Deck>();

            configTransport.Decks.ForEach(x =>
            {
                var deck = new Deck
                {
                    Number = x.Number
                };

                //deck.Cabins = x.Cabin
                var cabins = new List<Cabin>();
                x.Cabins.ForEach(y =>
                {
                    var cabin = new Cabin
                    {
                        ClassType = y.ClassType,
                        Distributions = CreateDistributions(y.Distributions)
                    };
                    cabins.Add(cabin);
                });
                deck.Cabins = cabins;
                decks.Add(deck);
            });
            transport.Decks = decks;

            return transport;
        }

        public List<CabinDistribution> CreateDistributions(List<ConfigCabinDistribution> configCabinDistributions)
        {
            var result = new List<CabinDistribution>();

            configCabinDistributions.ForEach(x =>
            {

                var distribution = new CabinDistribution();
                var cabinSectors = new List<CabinSector>();
                var columnSectors = x.Sectors.Split(' ', '\t');
                for (int i = 0; i < columnSectors.Count(); i++)
                {
                    var sector = new CabinSector { Number = i };
                    var columnsArray = columnSectors[i].ToCharArray();
                    sector.Columns = columnsArray.Select(c => c.ToString()).ToList();
                    cabinSectors.Add(sector);
                }
                distribution.Sectors = cabinSectors;
                distribution.SeatMap = new CabinElement[(x.RowTo - x.RowFrom) + 1, Regex.Replace(x.Sectors, @"\s+", "").Count()];
                x.Positions.ForEach(p =>
                    {
                        distribution.SeatMap[p.Row, p.Column] = new CabinElement
                        {
                            Spaces = p.Spaces,
                            Type = p.Type
                        };
                    });
                CompleteDistributionSeatMap(distribution.SeatMap, Regex.Replace(x.Sectors, @"\s+", ""));

                result.Add(distribution);
            });

            return result;
        }

        public void CompleteDistributionSeatMap(CabinElement[,] cabinElements, string columns)
        {
            for (var m = 0; m < cabinElements.GetLength(0); m++)
            {
                for (var n = 0; n < cabinElements.GetLength(1); n++)
                {
                    if (cabinElements[m, n] == null)
                    {
                        cabinElements[m, n] = CreateSeat(m, columns[n].ToString());
                    }
                }
            }
        }

        #endregion
    }
}
