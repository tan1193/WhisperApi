using Microsoft.AspNetCore.Http.HttpResults;
using OpenAI.Audio;
using System.ClientModel;
using WhisperApi;

var builder = WebApplication.CreateBuilder(args);
var openApiKey = "";
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/audiotranscribe", async () =>
{
    var model = "whisper-1";
    // options for audio transcription
    var audioTranscriptionOptions = new AudioTranscriptionOptions
    {
        ResponseFormat = AudioTranscriptionFormat.Srt,

    };
    var audioClient = new AudioClient(model, Constants.OPENAIAPIKEY);

    var response = await audioClient.TranscribeAudioAsync("audio.mp3", audioTranscriptionOptions);
    return response.Value.Text;
})
.WithName("AudioTranscribe")
.WithOpenApi();

app.MapPost("/audiotranslation", async () =>
{
    var model = "whisper-1";
    
    var audioTranscriptionOptions = new AudioTranslationOptions
    {
        ResponseFormat = AudioTranslationFormat.Srt,

    };
    var audioClient = new AudioClient(model, Constants.OPENAIAPIKEY);

    var response = await audioClient.TranslateAudioAsync("audio.mp3", audioTranscriptionOptions);
    return response.Value.Text;
})
.WithName("AudioTranslation")
.WithOpenApi();

app.Run();
