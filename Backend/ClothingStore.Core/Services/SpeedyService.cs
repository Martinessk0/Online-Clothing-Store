using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Speedy;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace ClothingStore.Core.Services
{
    public class SpeedyService : ISpeedyService
    {
        private readonly HttpClient _http;
        private readonly SpeedyOptions _opt;

        public SpeedyService(HttpClient http, IOptions<SpeedyOptions> opt)
        {
            _http = http;
            _opt = opt.Value;
        }

        public async Task<SpeedyOfficeDto?> GetOfficeByIdAsync(int officeId)
        {
            // Speedy: POST /v1/location/office/{id} с userName/password в body
            var url = $"location/office/{officeId}";

            var req = new
            {
                userName = _opt.UserName,
                password = _opt.Password,
                language = _opt.Language
            };

            using var resp = await _http.PostAsJsonAsync(url, req);
            if (!resp.IsSuccessStatusCode) return null;

            var json = await resp.Content.ReadFromJsonAsync<System.Text.Json.JsonElement>();

            // Очаквана структура: { office: { id, name, address: { fullAddressString... }, site: { name... } } }
            var officeEl = json.TryGetProperty("office", out var o) ? o : json;

            int id = officeEl.TryGetProperty("id", out var idEl) ? idEl.GetInt32() : officeId;
            string name = officeEl.TryGetProperty("name", out var nameEl) ? nameEl.GetString() ?? "" : "";

            string addressFull = "";
            if (officeEl.TryGetProperty("address", out var addrEl))
            {
                if (addrEl.TryGetProperty("fullAddressString", out var fullEl))
                    addressFull = fullEl.GetString() ?? "";
                else if (addrEl.TryGetProperty("address1", out var a1))
                    addressFull = a1.GetString() ?? "";
            }

            string siteName = "";
            if (officeEl.TryGetProperty("site", out var siteEl) && siteEl.TryGetProperty("name", out var sname))
                siteName = sname.GetString() ?? "";

            return new SpeedyOfficeDto
            {
                Id = id,
                Name = name,
                AddressFull = addressFull,
                SiteName = siteName
            };
        }
    }
}
