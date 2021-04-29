using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class MusicPlayer : MonoBehaviour
{
    //Directory of folder to be searched anywhere on the computer
    public string FileDirectory;

    //Audio source
    public AudioSource Source;
    //Current sound playing
    public AudioClip Clip;

    //List of all valid directories
    List<string> Files = new List<string>();
    //List of all AudioClips
    List<AudioClip> Clips = new List<AudioClip>();

    string[] files;

    public void Start()
    {
        //Checks for existing files
        CheckFile();
    }

    public void PlaySong(int _listIndex)
    {
        //Checks if the song is playing
        if (!Source.isPlaying)
        {
            Clip = Clips[_listIndex];
            Source.clip = Clip;
            Source.Play();
            CheckFile();
        }
    }

    void Update()
    {
        //Selects the songs randomly
        var musicSelector = UnityEngine.Random.Range(0, files.Length);

        //Plays song with whatever number musicSelector has
        PlaySong(musicSelector);
    }

    public void CheckFile()
    {
        //File Location for .MP3
        FileDirectory = Application.persistentDataPath;

        //Grabs all files from FileDirectory
        files = Directory.GetFiles(FileDirectory);

        //Checks all files and stores all WAV files into the Files list.
        for (int i = 0; i < files.Length; i++)
        {
            if (files[i].EndsWith(".mp3"))
            {
                Files.Add(files[i]);
                Clips.Add(new WWW(files[i]).GetAudioClip(false, true, AudioType.MPEG));
            }
        }
    }
}