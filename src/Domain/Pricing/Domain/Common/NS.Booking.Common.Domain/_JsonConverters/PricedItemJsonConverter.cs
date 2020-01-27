using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using NS.Booking.Common.Domain.PricedItem.Models;

namespace NS.Booking.Common.Domain._JsonConverters
{
    public class PricedItemJsonConverter : JsonConverter
    {
        private readonly CamelCasePropertyNamesContractResolver camelCaseConverter = new CamelCasePropertyNamesContractResolver();

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var objectType = value.GetType();
            var fieldList = new List<string>();
            foreach (var fieldInfo in objectType.GetProperties())
            {
                var attribute = fieldInfo.GetCustomAttribute<JsonConverterAttribute>();
                if (attribute != null)
                {
                    var converter = (JsonConverter)Activator.CreateInstance(attribute.ConverterType);
                    fieldList.Add($"\"{camelCaseConverter.GetResolvedPropertyName(fieldInfo.Name)}\":{JsonConvert.SerializeObject(fieldInfo.GetValue(value), converter)}");
                }
                else
                {
                    fieldList.Add($"\"{camelCaseConverter.GetResolvedPropertyName(fieldInfo.Name)}\":{JsonConvert.SerializeObject(fieldInfo.GetValue(value), new JsonSerializerSettings { ContractResolver = this.camelCaseConverter })}");
                }

            }

            var serialized = "{" + $"{string.Join(",", fieldList)}" + "}";
            var t = JToken.FromObject(JsonConvert.DeserializeObject<dynamic>(serialized));
            t.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var tokenValue = JToken.Load(reader);
            var value = tokenValue.ToObject<dynamic>();
            var serializedDyn = JsonConvert.SerializeObject(value);
            if (value.journeyId != null && value.paxId != null)
            {
                return new JavaScriptSerializer().Deserialize<PerPaxJourneyPricedItem>(serializedDyn);
            }

            if (value.segmentId != null && value.paxId != null)
            {
                return new JavaScriptSerializer().Deserialize<PerPaxSegmentPricedItem>(serializedDyn);
            }

            if (value.segmentId != null)
            {
                return new JavaScriptSerializer().Deserialize<PerSegmentPricedItem>(serializedDyn);
            }

            if (value.paxId != null)
            {
                return new JavaScriptSerializer().Deserialize<PerPaxPricedItem>(serializedDyn);
            }

            return new JavaScriptSerializer().Deserialize<PerBookingPricedItem>(serializedDyn);
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}