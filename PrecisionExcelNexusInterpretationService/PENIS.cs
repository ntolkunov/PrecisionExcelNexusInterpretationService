using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System;
using System.Web;
using Newtonsoft.Json.Linq;

namespace PrecisionExcelNexusInterpretationService
{
    public class PENIS
    {
        private static string TranslateInternal(string text, string langFrom = "auto", string langTo = "auto", int retryLimit = 3)
        {
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={langFrom}&tl={langTo}&dt=t&q={HttpUtility.UrlEncode(text)}";
            using (var client = new HttpClient())
            {
                int retryCount = 0;
                while (retryCount < retryLimit)
                {
                    try
                    {
                        var json = client.GetStringAsync(url).GetAwaiter().GetResult();
                        var translation = JArray.Parse(json)?.First?.First?.First?.ToString();
                        return translation ?? string.Empty;
                    }
                    catch (Exception ex)
                    {
                        retryCount++;
                    }
                }

                if (retryCount == retryLimit)
                    throw new Exception("Retry limit exceeded");
            }

            return string.Empty;
        }

        private static async Task<string> TranslateInternalAsync(string text, string langFrom = "auto", string langTo = "auto", int retryLimit = 3)
        {
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={langFrom}&tl={langTo}&dt=t&q={HttpUtility.UrlEncode(text)}";
            using (var client = new HttpClient())
            {
                int retryCount = 0;
                while (retryCount < retryLimit)
                {
                    try
                    {
                        var json = await client.GetStringAsync(url);
                        var translation = JArray.Parse(json)?.First?.First?.First?.ToString();
                        return translation ?? string.Empty;
                    }
                    catch (Exception ex)
                    {
                        retryCount++;
                    }
                }

                if (retryCount == retryLimit)
                    throw new Exception("Retry limit exceeded");
            }

            return string.Empty;
        }

        public static string Translate(string text, string langFrom = "auto", string langTo = "auto", int retryLimit = 3)
        {  
            return TranslateInternal(text, langFrom, langTo, retryLimit);
        }

        public static List<string> Translate(List<string> textList, string langFrom = "auto", string langTo = "auto", int retryLimit = 3)
        {
            var result = new List<string>();

            foreach (var text in textList)
            {
                result.Add(TranslateInternal(text, langFrom, langTo, retryLimit));
            }
            
            return result;
        }

        public static async Task<string> TranslateAsync(string text, string langFrom= "auto", string langTo = "auto", int retryLimit = 3)
        {
            return await TranslateInternalAsync(text, langFrom, langTo, retryLimit);
        }

        public static async Task<List<string>> TranslateAsync(List<string> textList, string langFrom = "auto", string langTo = "auto", int retryLimit = 3)
        {
            var result = new List<string>();

            foreach (var text in textList)
            {
                result.Add(await TranslateInternalAsync(text, langFrom, langTo, retryLimit));
            }

            return result;
        }
    }
}

