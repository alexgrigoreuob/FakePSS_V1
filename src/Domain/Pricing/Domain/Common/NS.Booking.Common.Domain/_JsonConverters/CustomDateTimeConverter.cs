namespace NS.Booking.Common.Domain._JsonConverters
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;

    public class CustomDateTimeConverter : JsonConverter
    {
        private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

        private string _dateTimeFormat { get; set; }

        public CustomDateTimeConverter()
        {
            this._dateTimeFormat = DefaultDateTimeFormat;
        }

        public CustomDateTimeConverter(string dateTimeFormat)
        {
            this._dateTimeFormat = string.IsNullOrEmpty(dateTimeFormat) ? DefaultDateTimeFormat : dateTimeFormat;
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(DateTime) || objectType == typeof(DateTime?))
            {
                return true;
            }

            return false;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DateTime dateTimeValue = (DateTime)value;
            if (dateTimeValue == DateTime.MinValue)
            {
                writer.WriteNull();
                return;
            }

            writer.WriteValue(dateTimeValue.ToString(this._dateTimeFormat));
        }

        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return DateTime.MinValue;
            }

            return DateTime.ParseExact(reader.Value.ToString(), this._dateTimeFormat, CultureInfo.CurrentCulture);
        }
    }
}