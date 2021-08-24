using CitizenArcadis.Client.UI.Models.Response;
using CitizenArcadis.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CitizenArcadis.Client.UI.Service
{
    public class AzureDemoFunction : IAzureDemoFunction
    {

        public AppSettings AppSettings { get; set; }
        public AzureDemoFunction(IOptions<AppSettings> appSettings)
        {
            this.AppSettings = appSettings.Value;
        }
        private static HttpContent CreateHttpContent(object content)
        {
            HttpContent httpContent = null;

            if (content != null)
            {
                var ms = new MemoryStream();
                SerializeJsonIntoStream(content, ms);
                ms.Seek(0, SeekOrigin.Begin);
                httpContent = new StreamContent(ms);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return httpContent;
        }
        public static void SerializeJsonIntoStream(object value, Stream stream)
        {
            using (var sw = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
            using (var jtw = new JsonTextWriter(sw) { Formatting = Newtonsoft.Json.Formatting.None })
            {
                var js = new Newtonsoft.Json.JsonSerializer();
                js.Serialize(jtw, value);
                jtw.Flush();
            }
        }


        public async Task<FunctionResponse<T>> OnPostAsync<T>(T employee)
        {
            var Url = AppSettings.AzureFunctionURL;

            dynamic content = employee;

            CancellationToken cancellationToken = new CancellationToken();


            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, Url))
            using (var httpContent = CreateHttpContent(content))
            {
                request.Content = httpContent;

                using (var response = await client
                    .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(false))
                {


                    var requestBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(requestBody);
                    FunctionResponse<T> data = JsonConvert.DeserializeObject<FunctionResponse<T>>(requestBody);

                    return data;
                }
            }

        }
    }
}
