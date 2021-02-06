# SoundtrackSummary
A tool for displaying a summary of the soundtrack you're listening to in your browser.

<img src="https://i.imgur.com/EZI3Wiw.png"/>

## How to Run

1. Download Zip
2. Unzip locally
3. Copy contents of <i>"BrowserSoundDisplay/bin/Release/"</i> to where you want to store it
4. Click <i>BrowserSoundDisplay.exe</i> to run

## How it Works
This application reads from the <u>active tab in the active window</u> in your specified browser (by default its set to chrome).<br>
  It then then tries to match the url in that tab to the list of URLs in the file <i>settings.json</i><br>
    If it matches, it will take the Display Name and Image file and display them in the application<br>
    If it doesn't match, it will take the title of the webpage you are on as the Display Name, and use the defaultImage.png as the image shown in the application<br>
    
## Adding Your Own Playlist
 
 You can add your own playlists, images and titles to the application as well. You do this by editing the settings.json file and appending your information to the PlaylistInfo array

```json
{
  "Url": "The url of your playlist/song", 
  "DisplayName": "What you want the title to display as (optional - will use the webpage title if not set)",
  "ImageName": "The Image file you want to display with this Url (optional - will use defaultImage.png if not set)"
},
```
Make sure you add any custom Image files to the Images folder.

## Other Settings

You can change other settings, such as Default Browser, font, Background Color etc in the <i>settings.json</i> as well.
