using NJsonSchema.CodeGeneration.TypeScript;
using NSwag.CodeGeneration.TypeScript;
using OpenApiDocument = NSwag.OpenApiDocument;

namespace FamilyBudget.Client;

internal class Program {
    private static void Main(string[] args) {
        string url = "http://localhost:4001/swagger/v1/swagger.json";
        string generatePath = Path.Combine(Directory.GetCurrentDirectory(), "./familybudget.react/src/services");

        GenerateTypeScriptClient(url, generatePath);
    }

    private static async Task GenerateTypeScriptClient(string url, string generatePath) =>
        await GenerateClient(
            document: await OpenApiDocument.FromUrlAsync(url),
            generatePath: generatePath,
            generateCode: (OpenApiDocument document) => {
                var settings = new TypeScriptClientGeneratorSettings();

                settings.TypeScriptGeneratorSettings.TypeStyle = TypeScriptTypeStyle.Interface;
                settings.TypeScriptGeneratorSettings.TypeScriptVersion = 3.5M;
                settings.TypeScriptGeneratorSettings.DateTimeType = TypeScriptDateTimeType.String;

                var generator = new TypeScriptClientGenerator(document, settings);
                var code = generator.GenerateFile();

                return code;
            }
        );

    //private static async Task GenerateCSharpClient(string url, string generatePath) =>
    //    await GenerateClient(
    //        document: await OpenApiDocument.FromUrlAsync(url),
    //        generatePath: generatePath,
    //        generateCode: (OpenApiDocument document) => {
    //            var settings = new CSharpClientGeneratorSettings {
    //                UseBaseUrl = false
    //            };

    //            var generator = new CSharpClientGenerator(document, settings);
    //            var code = generator.GenerateFile();
    //            return code;
    //        }
    //    );

    private static async Task GenerateClient(OpenApiDocument document, string generatePath, Func<OpenApiDocument, string> generateCode) {
        Console.WriteLine($"Generating {generatePath}...");

        var code = generateCode(document);

        await File.WriteAllTextAsync(generatePath, code);
    }
}