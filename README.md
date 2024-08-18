# Web API for Audio Transcription and Translation

## Overview
This project is a .NET Web API designed to facilitate audio transcription and translation using OpenAI's Whisper API. It provides endpoints for uploading audio files, transcribing them into text, and translating the transcriptions into different languages.

## Features
- Audio Transcription: Convert audio files into text using OpenAI's Whisper API.
- Audio Translation: Translate transcriptions into different languages.
## Setup Instructions
1. Clone the repository
2. Add Your OpenAI API Key
. Open the `Constants.cs`
. Replace the placeholder Constants.OPENAIAPIKEY with your actual OpenAI API key
``` c#
public static class Constants
{
    public const string OPENAIAPIKEY = "your-api-key-here";
}
```
