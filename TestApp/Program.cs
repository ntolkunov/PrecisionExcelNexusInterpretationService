using PrecisionExcelNexusInterpretationService;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var text = "Денис - педик";
var textList = new List<string>()
{
    "Денис - первый педик",
    "Денис - средний педик",
    "Денис - последний педик"
};

Console.WriteLine($"Translate sync. {text} : {PENIS.Translate(text, "ru", "en")}");
Console.WriteLine($"Translate async. {text} : {await PENIS.TranslateAsync(text)}");

var translatedList = PENIS.Translate(textList);

for(int i = 0; i < textList.Count; i++)
{
    Console.WriteLine($"Translate list sync. Item {i}. {textList[i]} : {translatedList[i]}");
}

translatedList = await PENIS.TranslateAsync(textList);

for (int i = 0; i < textList.Count; i++)
{
    Console.WriteLine($"Translate list async. Item {i}. {textList[i]} : {translatedList[i]}");
}

Console.ReadKey();