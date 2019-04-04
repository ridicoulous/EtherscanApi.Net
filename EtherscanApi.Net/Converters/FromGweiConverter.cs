using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace EtherscanApi.Net.Converters
{
    public class FromGweiConverter : JsonConverter
    {
       
        public FromGweiConverter()
        {
            
        }

        public override bool CanConvert(Type objectType)
        {
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;
            BigInteger val = BigInteger.Parse(reader.Value.ToString());
            var decin = UnitConversion.Convert.FromWei(val,18);            
            return decin;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
