using OpenAI.Audio;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var OPENAIAPIKEY = builder.Configuration["OPENAI_API_KEY"] ?? ""; // <--- change your key here

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/audiotranscribe", async (IFormFile file) =>
{
    if (file == null || file.Length == 0)
    {
        return Results.BadRequest("Audio file not provided or empty.");
    }

    try
    {
        var model = "whisper-1";
        // options for audio transcription
        var audioTranscriptionOptions = new AudioTranscriptionOptions
        {
            ResponseFormat = AudioTranscriptionFormat.Srt,
        };

        var audioClient = new AudioClient(model, OPENAIAPIKEY);

        using var stream = file.OpenReadStream();
        var response = await audioClient.TranscribeAudioAsync(stream, file.FileName, audioTranscriptionOptions);
        return Results.Ok(response.Value.Text);
    }
    catch (ArgumentNullException ex) // Should be caught by the initial check, but good for defense
    {
        return Results.BadRequest($"Argument null: {ex.Message}");
    }
    catch (Exception ex)
    {
        // Log the exception ex here if logging is set up
        return Results.Problem($"An error occurred during transcription: {ex.Message}");
    }
})
.WithName("AudioTranscribe")
.WithOpenApi();

app.MapPost("/audiotranslation", async (IFormFile file) =>
{
    if (file == null || file.Length == 0)
    {
        return Results.BadRequest("Audio file not provided or empty.");
    }

    try
    {
        var model = "whisper-1";

        var audioTranslationOptions = new AudioTranslationOptions
        {
            ResponseFormat = AudioTranslationFormat.Srt,
        };
        var audioClient = new AudioClient(model, OPENAIAPIKEY);

        using var stream = file.OpenReadStream();
        var response = await audioClient.TranslateAudioAsync(stream, file.FileName, audioTranslationOptions);
        return Results.Ok(response.Value.Text);
    }
    catch (ArgumentNullException ex) // Should be caught by the initial check, but good for defense
    {
        return Results.BadRequest($"Argument null: {ex.Message}");
    }
    catch (Exception ex)
    {
        // Log the exception ex here if logging is set up
        return Results.Problem($"An error occurred during translation: {ex.Message}");
    }
})
.WithName("AudioTranslation")
.WithOpenApi();

app.Run();
