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
        public static string Translate(string text, string langFrom = "auto", string langTo = "auto")
        {  
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={
                langFrom}&tl={langTo}&dt=t&q={
                HttpUtility.UrlEncode(text)}";

            using (var client = new HttpClient())
            {
                var json = client.GetStringAsync(url).GetAwaiter().GetResult();
                var translation = JArray.Parse(json)?.First?.First?.First?.ToString(); 
                return translation ?? string.Empty;
            }
        }

        public static async Task<string> TranslateAsync(string text, string langFrom= "auto", string langTo = "auto")
        {
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={
                langFrom}&tl={langTo}&dt=t&q={
                HttpUtility.UrlEncode(text)}";

            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                var translation = JArray.Parse(json)?.First?.First?.First?.ToString();
                return translation ?? string.Empty;
            }
        }
    }
}

