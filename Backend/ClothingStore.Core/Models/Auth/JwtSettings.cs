using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Models.Auth
{
    public class JwtSettings
    {
        public string SecurityKey { get; set; } = string.Empty;
        public string ValidIssuer { get; set; } = string.Empty;
        public string ValidAudience { get; set; } = string.Empty;
        public int ExpireInMinutes { get; set; } = 30;
    }
}
