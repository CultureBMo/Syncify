# Syncify
An application to process MP3 files so that they can be played in order in Ford cars equipped with the Sync audio system.

Unlike pretty much every other MP3 player on the planet, the Ford Sync audio system does not play MP3s in Track or Filename order - it orders by Title instead.

This means that, even if you have a carefully catalogued music collection, it will not play album tracks in order.

For instance Purple Rain will be played alphabetically, like so:

Baby I'm a Star<br/>
Computer Blue<br/>
Darling Nikki<br/>
I Would Die 4 U<br/>
Let's Go Crazy<br/>
Purple Rain<br/>
Take Me With U<br/>
The Beautiful Ones<br/>
When Doves Cry

Syncify is a simple application that re-writes the title of MP3 files, by adding the track number to the beginning.

You can now listen to Purple Rain in the sequence Prince intended:

01 Let's Go Crazy<br/>
02 Take Me With U<br/>
03 The Beautiful Ones<br/>
04 Computer Blue<br/>
05 Darling Nikki<br/>
06 When Doves Cry<br/>
07 I Would Die 4 U<br/>
08 Baby I'm a Star<br/>
09 Purple Rain

Syncify also includes an option to remove images from files and folders. They are not displayed in earlier versions of Ford Sync and this option may help to save space.

## Pre-requisites
In order to run Syncify you need
- Windows 10 or later
- [.NET 8 Desktop Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) - you may have this already, but if not, you will be prompted to download it, see below

## Install Instructions
1) Download the [Zip file for the latest release of Syncify](https://github.com/CultureBMo/Syncify/releases/download/v3.0/Syncify.3.0.0.0.zip)
2) In your Downloads folder right-click the Zip file and choose Extract All..
3) Choose a folder to extract into, e.g. C:\Program Files\Syncify (NB - you will need local administrator permissions to extract to Program Files)
4) Double click Syncify.exe to run the program. If you don't have the latest version of .NET you will be prompted to [download it](https://dotnet.microsoft.com/download/dotnet/5.0/runtime). On the download page, under Run desktop apps, click Download x64
5) Optionally - create a shortcut to the program on your desktop

## Technical Details
Syncify was created using .NET 8 and calls to the Windows API. StyleCop Analyzers are used to enforce coding standards. GitHub Copilot was used to optimize some of the code.
