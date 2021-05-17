using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.VO
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Gender { None, Masculine, Feminine, Other };

}
