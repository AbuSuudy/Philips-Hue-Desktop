using PhilipsHueService.Model;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace PhilipsHueService
{
    public static class PhilipsHueService
    {
        private static readonly Serilog.Core.Logger log = new LoggerConfiguration().WriteTo.File("D:\\Logs\\PhilipsHue\\log.txt").CreateLogger();

        //Can be found using this url when the bridge is conencted to the local network https://discovery.meethue.com/
        private static string philipsHueBrigeIp = "";

        //Can generate username by using the playgroud https://192.168.0.159/debug/clip.html 
        //Steps how to https://developers.meethue.com/develop/get-started-2/ 
        private static string generatedUsername = "";

        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri($"http://{philipsHueBrigeIp}/api/{generatedUsername}/")
        };

        #region Lights

        public static  async Task<Dictionary<string, Light>> Lights()
        {
            var scenes = new Dictionary<string, Light>();

            try
            {
                HttpResponseMessage response = await _client.GetAsync("light");

                response.EnsureSuccessStatusCode();

                if (response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    //data already exists as bytes in a Stream  no need to access via a string ReadAsStringAsync();

                    var contentStream = response.Content.ReadAsStreamAsync().Result;

                    scenes = JsonSerializer.Deserialize<Dictionary<string, Light>>(contentStream, new System.Text.Json.JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });

                }

            }
            catch (Exception ex)
            {
                // seri log 

                log.Error(String.Format("Message: {0} \n Stack Trace: ", ex.Message, ex.StackTrace));

                throw;
            }

            return scenes;
        }


        public static async Task<Light> Light(int id)
        {

            var light = new Light();

            try
            {

                HttpResponseMessage response = await _client.GetAsync($"lights/{id}");

                response.EnsureSuccessStatusCode();

                if (response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    //data already exists as bytes in a Stream  no need to access via a string ReadAsStringAsync();

                    var contentStream = response.Content.ReadAsStreamAsync().Result;

                    light = JsonSerializer.Deserialize<Light>(contentStream, new System.Text.Json.JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });

                }

            }
            catch (Exception ex)
            {
                log.Error(String.Format("Message: {0} \n Stack Trace: ", ex.Message, ex.StackTrace));
                throw;
            }

            return light;

        }

        public static bool LightState(int lightId, bool on, int colourTemp, int brightness)
        {
            try
            {
                //This is being called from the setters in of the model used for the MVVM patten. So need to be synchronous
               HttpResponseMessage response = _client.PutAsync($"lights/{lightId}/state", JsonContent.Create(new { on = on, ct = 1000000 / colourTemp, bri = 254 * brightness / 100 })).Result;

                response.EnsureSuccessStatusCode();

                return response.IsSuccessStatusCode;


            }
            catch (Exception ex)
            {
                log.Error(String.Format("Message: {0} \n Stack Trace: ", ex.Message, ex.StackTrace));
                throw;
            }
        }

        #endregion


        #region Scenes

        public static async Task<Dictionary<string, Scene>> Scenes()
        {
            var scenes = new Dictionary<string, Scene>();

            try
            {

                HttpResponseMessage response = await _client.GetAsync("scenes");

                response.EnsureSuccessStatusCode();

                if (response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    //data already exists as bytes in a Stream  no need to access via a string ReadAsStringAsync();

                    var contentStream = await response.Content.ReadAsStreamAsync();

                    scenes = JsonSerializer.Deserialize<Dictionary<string, Scene>>(contentStream, new System.Text.Json.JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });

                }

            }
            catch (Exception ex)
            {
                log.Error(String.Format("Message: {0} \n Stack Trace: ", ex.Message, ex.StackTrace));
                throw;
            }

            return scenes;
        }

        #endregion


        #region group


        public static async Task<Dictionary<string, Group>> Groups()
        {
            var group = new Dictionary<string, Group>();

            try
            {

                HttpResponseMessage response = await _client.GetAsync("groups");

                response.EnsureSuccessStatusCode();

                if (response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
                {

                    var contentString = response.Content.ReadAsStringAsync().Result;


                    var contentStream = response.Content.ReadAsStreamAsync().Result;

                    group = JsonSerializer.Deserialize<Dictionary<string, Group>>(contentStream, new System.Text.Json.JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });

                }

            }
            catch (Exception ex)
            {
                log.Error(String.Format("Message: {0} \n Stack Trace: ", ex.Message, ex.StackTrace));
                throw;
            }

            return group;
        }

        public static async Task<bool> GroupScene(int groupId, string scene)
        {

            try
            {
                HttpResponseMessage response =  await _client.PutAsync($"groups/{groupId}/action",  JsonContent.Create(new { scene = scene }));

                response.EnsureSuccessStatusCode();

                return response.IsSuccessStatusCode;

            }
            catch (Exception ex)
            {
                log.Error(String.Format("Message: {0} \n Stack Trace: ", ex.Message, ex.StackTrace));

                throw;

            }

        }

        #endregion

    }

}
