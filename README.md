# Web API for Audio Transcription and Translation

## Overview
This project is a .NET Web API designed to facilitate audio transcription and translation using OpenAI's Whisper API. It provides endpoints for uploading audio files, transcribing them into text, and translating the transcriptions into different languages.

## Features
- Audio Transcription: Convert audio files into text using OpenAI's Whisper API.
- Audio Translation: Translate transcriptions into different languages.
## Setup Instructions
1. Clone the repository
2. Add Your OpenAI API Key
   You can configure your OpenAI API key in one of two ways:
   - **Using `appsettings.json`**:
     Add or update the `OPENAI_API_KEY` value in your `appsettings.json` file (or `appsettings.Development.json` for development environment):
     ```json
     {
       "OPENAI_API_KEY": "your_actual_openai_api_key"
     }
     ```
   - **Using an Environment Variable**:
     Set an environment variable named `OPENAI_API_KEY` to your actual OpenAI API key.

     The application will prioritize the environment variable if both are set.
