using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using NS.Booking.Domain.Payment.Models;

namespace NS.Booking.Domain._JsonConverters
{
    public class PaymentJsonConverter : JsonConverter
    {
        private readonly CamelCasePropertyNamesContractResolver _camelCaseConverter = new CamelCasePropertyNamesContractResolver();

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var objectType = value.GetType();
            var fieldList = new List<string>();
            foreach (var fieldInfo in objectType.GetProperties())
            {
                var attribute = fieldInfo.GetCustomAttribute<JsonConverterAttribute>();
                if (attribute != null)
                {
                    var converter = (JsonConverter) Activator.CreateInstance(attribute.ConverterType);
                    fieldList.Add($"\"{_camelCaseConverter.GetResolvedPropertyName(fieldInfo.Name)}\":{JsonConvert.SerializeObject(fieldInfo.GetValue(value), converter)}");
                }
                else
                {
                    fieldList.Add(
                        $"\"{_camelCaseConverter.GetResolvedPropertyName(fieldInfo.Name)}\":{JsonConvert.SerializeObject(fieldInfo.GetValue(value), new JsonSerializerSettings {ContractResolver = _camelCaseConverter})}");
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

            if (value.cardHolder != null)
            {
                return new JavaScriptSerializer().Deserialize<CreditCardPayment>(serializedDyn);
            }

            if (value.credit != null)
            {
                return new JavaScriptSerializer().Deserialize<CreditPayment>(serializedDyn);
            }

            if (value.points != null)
            {
                return new JavaScriptSerializer().Deserialize<LoyaltyPayment>(serializedDyn);
            }

            if (value.voucherId != null)
            {
                return new JavaScriptSerializer().Deserialize<VoucherPayment>(serializedDyn);
            }

            return new JavaScriptSerializer().Deserialize<PrePaidPayment>(serializedDyn);
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
