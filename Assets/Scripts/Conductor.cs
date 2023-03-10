using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Conductor : MonoBehaviour
{

    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public float songBpm;

    //The number of seconds for each song beat
    public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;
    public static float songPositionStatic;

    //Current song position, in beats
    public float songPositionInBeats;
    public static float songPositionInBeatsStatic;

    //How many seconds have passed since the song started
    public float dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    [SerializeField] private Slider songprogress;

    public static float timer;

    // 
    



    void Start()
    {
        
        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        //musicSource.Play();

        songprogress.maxValue = musicSource.clip.length;
    }

    void Update()
    {
        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;

        songprogress.value = songPosition;
        songPositionStatic = songPosition;
        songPositionInBeatsStatic = songPositionInBeats;
        
        float currentBeat = Mathf.Floor(songPositionInBeats);

        timer = 2*(songPositionInBeats - currentBeat) - 1;

        if (currentBeat%2==0)
        {
            timer = 1- 2*(songPositionInBeats - currentBeat);
        }


        if ((musicSource.clip.length + 4) <= songPosition)
        {
            Debug.Log("End");
            SceneManager.LoadScene("Ending");
        }
        

    }
    


}
