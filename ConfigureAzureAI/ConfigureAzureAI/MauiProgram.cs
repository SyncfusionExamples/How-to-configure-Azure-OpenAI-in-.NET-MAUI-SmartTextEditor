using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.SmartComponents.Hosting;
using System.ClientModel;

namespace ConfigureAzureAI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.ConfigureSyncfusionCore();
            string azureOpenAIKey = "AZURE_OPENAI_KEY";
            string azureOpenAIEndpoint = "AZURE_OPENAI_ENDPOINT";
            string azureOpenAIModel = "AZURE_OPENAI_MODEL";
            AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
                 new Uri(azureOpenAIEndpoint),
                 new ApiKeyCredential(azureOpenAIKey)
            );
            IChatClient azureOpenAIChatClient = azureOpenAIClient.GetChatClient(azureOpenAIModel).AsIChatClient();
            builder.Services.AddChatClient(azureOpenAIChatClient);

            builder.ConfigureSyncfusionAIServices();

            return builder.Build();
        }
    }
}
