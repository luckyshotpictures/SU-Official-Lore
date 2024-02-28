# Overview

This repository contains the code for the lore page for Sector Umbra, a private Space Station 14 community. It is a ASP.Net Web Application using Web Assembly.

# Setup

The setup is just like any other ASP.Net Web Application. 

## Prerequisites

Ensure you have the .NET 8 SDK installed.

## Instructions

1. Clone the repository: Clone the repo to your local machine using Git.
2. Restore Dependencies: Navigate to the project folder and run `dotnet restore`.
3. Run the application: Using `dotnet run` you can run the application. Once it starts it will be available at `https://localhost:7500`.

## Contributing

Contributions to the lore page are welcome! To add a lore entry please refer to the section below. Be advised when adding new lore entries: Unless you are in our private discord server, so are part of the group that uses this page, the changed files wont be accepted.

### Format

The format of the files is simple, each file must start with `#TERMINAL_FILE`. This is done so the code can tell that it is trying to load a valid file.
Following that, you can add headers.
Headers are simple. `HEADER=VALUE`
Here are the headers that are available:
```
  TITLE - This sets the title of the page
  BACKLINK - true, false - If true, users will be able to use the back button to navigate one entry up
  SCROLL_DOWN - true, false - If true, the page will automaticly scroll down when new text is added
  AUDIO_REQUIRED - Comma seperated list - This sets the audio required for this page. Every entry here will recieve an entry in the DOM as an audio element. See below on how to play it.
```

After the headers, you can put the content of the page in a codeblock. Everything inside the codeblock will be displayed, everything else ignored.
Within the content, you can use tags to change color, play audio, change render speed etc.
Here are the available tags:
```
[color=<colorName>]content[/color] - This changes the color of the text. The following colors can be used: cc, warn, sys, white, red & info
[block=<colorName>]content[/block] - This wraps the text in a block, meaning it will stand out a bit. You can use the following colors: warn & info

[button=destination;Name] - Anchor tag
[speed=<newSpeed>] - Changes the render speed. You can use [speed=default] to return the speed to normal.
[delay=<ms>] - Pretty much just sleep()
[play=<audio>] - Plays audio by name. Audio must be present in AUDIO_REQUIRED
[load=<name>] - Loads a new page based on the file path provided.
```

You can view the existing templates for some examples.
