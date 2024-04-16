using PrecisionExcelNexusInterpretationService;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var text = "Коля - педик";
Console.WriteLine($"Translate sync. {text} : {PENIS.Translate(text, "ru", "en")}");
Console.WriteLine($"Translate async. {text} : {await PENIS.TranslateAsync(text)}");

Console.ReadKey();
