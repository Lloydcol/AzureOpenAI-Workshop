using Microsoft.Extensions.Configuration;

// Add Azure OpenAI Package


// Build a config
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
string? oaiEndpoint = config["AzureOAIEndpoint"];
string? oaiKey = config["AzureOAIKey"];
string? oaiModelName = config["AzureOAIModelName"];

// Read sample text file into a string
string textToSummarize = System.IO.File.ReadAllText(@"../text-files/sample-text.txt");
string callToJson = System.IO.File.ReadAllText(@"../text-files/call.txt");


// Generate summary from Azure OpenAI
GetSummaryFromOpenAI(textToSummarize);

// Generate Json from Azure OpenAI
GetJsonFromACall(callToJson);



//Summary function

void GetSummaryFromOpenAI(string text){
 
    // Initialize the client

    // Get the prompt

    // Build the completion

    //Send request to Azure OpenAI Model
}


//Json function

void GetJsonFromACall (string mycall){

    // Initialize the client

    // Get the prompt

    // Build the completion

    //Send request to Azure OpenAI Model
}