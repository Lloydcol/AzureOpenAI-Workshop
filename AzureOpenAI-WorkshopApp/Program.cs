using Microsoft.Extensions.Configuration;

// Add Azure OpenAI Package
using Azure.AI.OpenAI;
using Azure;

// Build a config
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
string? oaiEndpoint = config["AzureOAIEndpoint"];
string? oaiKey = config["AzureOAIKey"];
string? oaiModelName = config["AzureOAIModelName"];

// Read sample text file into a string
string textToSummarize = System.IO.File.ReadAllText(@"./text-files/sample-text.txt");
string callToJson = System.IO.File.ReadAllText(@"./text-files/call.txt");


// Generate summary from Azure OpenAI
GetSummaryFromOpenAI(textToSummarize);

// Generate Json from Azure OpenAI
GetJsonFromACall(callToJson);



//Summary function

void GetSummaryFromOpenAI(string text){
 
    // Initialize the client
    OpenAIClient client = new OpenAIClient(new Uri(oaiEndpoint), new AzureKeyCredential(oaiKey));

    // Build the completion
    ChatCompletionsOptions chatCompletionsOptions = new ChatCompletionsOptions()
    {
        Messages =
        {
        new ChatMessage(ChatRole.System, "You are a helpful assistant. Summarize the following text in 20 words or less and talk like a pirate"),
        new ChatMessage(ChatRole.User, text),
        },
        MaxTokens = 120,
        Temperature = 0.7f,
    };

    //Send request to Azure OpenAI Model
    ChatCompletions response = client.GetChatCompletions(
        deploymentOrModelName: oaiModelName, 
        chatCompletionsOptions);
    string completion = response.Choices[0].Message.Content;

    // Get the result

    Console.WriteLine("Summary: " + completion + "\n");
}


//Json function

void GetJsonFromACall (string mycall){

    // Initialize the client
    OpenAIClient client = new OpenAIClient(new Uri(oaiEndpoint), new AzureKeyCredential(oaiKey));

    // Get the prompt
    string promptToJson = System.IO.File.ReadAllText(@"./text-files/promptToJson.txt");

    // Build the completion
    ChatCompletionsOptions chatCompletionsOptions = new ChatCompletionsOptions()
    {
        Messages =
        {
        new ChatMessage(ChatRole.System, promptToJson),
        new ChatMessage(ChatRole.User, mycall),
        },
        Temperature = 0.7f,
    };

    //Send request to Azure OpenAI Model
    ChatCompletions response = client.GetChatCompletions(
        deploymentOrModelName: oaiModelName, 
        chatCompletionsOptions);
    string completion = response.Choices[0].Message.Content;

    Console.WriteLine(completion + "\n");
}