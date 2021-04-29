using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MusicDownloader : MonoBehaviour
{
    public InputField songIDInputField;
    public Text downloadStatusText;

    string[] Songs;

    public string songID;
    public string finalURL;

    bool fileExisting = false;

    string filePath;

    public string url;

    //Downloads the song with Newgrounds
    public void DownloadSong()
    {
        SongExistCheck();

        //C:\Users\{NAME}\AppData\LocalLow\DefaultCompany\{ProjectName}
        string path = Application.persistentDataPath;

        //URL for host website
        url = "https://www.newgrounds.com/audio/download/";

        //Takes song ID from an input field
        songID = songIDInputField.text;

        //Combines the URL and song ID together in 1 string
        finalURL = (url + songID);

        WebClient client = new WebClient();

        //Downloads the file using the URL (finalURL). @path is where the file is downloading to. The rest is what the file is called, in this case it's /{songID}.mp3
        client.DownloadFile(finalURL, @path + "/" + songID + ".mp3");

        //Gets the MP3 file
        Songs = Directory.GetFiles(Application.persistentDataPath, ".mp3");
        
        //Gets the file path and is stored in filePath
        filePath = Application.persistentDataPath + "  " + Songs;

        SongExistCheck();
    }

    //Looks to see if the download was successful and outputs it to a text field
    public void SongExistCheck()
    {
        fileExisting = false;
        songID = songIDInputField.text;
        string path = Application.persistentDataPath;
        string curFile = (@path + "/" + songID + ".mp3");
        Debug.Log(curFile);
        Debug.Log(File.Exists(curFile) ? fileExisting = true : fileExisting = false);

        if (fileExisting == true)
        {
            downloadStatusText.text = ("Download Success!");
            downloadStatusText.color = new Color(0.2f, 1f, 0.2f, 1f);
        }

        else if (fileExisting == false)
        {
            downloadStatusText.text = ("Download Failed!");
            downloadStatusText.color = new Color(1f, 0.2f, 0.2f, 1f);
        }
    }
}
