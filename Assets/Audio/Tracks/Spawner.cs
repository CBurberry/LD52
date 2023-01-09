using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    [SerializeField] Conductor beatManager;
    private int lastBeat = 0;
    public float spawnFactor;
    
    public float bassRate;

    [SerializeField] float[] spectrum = new float[512];
    [SerializeField] float[] freqBand = new float[8];
    [SerializeField] GameObject[] audioVis;
    [SerializeField] bool visualizer;

    private float limiter = 0;

    public ButtonSpawner buttonSpawner;

    public int maxButtons = 1;
    public int doubleHitVolume = 6;
    float volumeAverage;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if(beatManager.songPositionInBeats >= lastBeat*0.5)
        {
            
            //Debug.Log(lastBeat);
            ///// add one to the beat iteration
            lastBeat++;
            CalcFreq();
            /////spawn//////
            Spawn();
        }

        
        
    }

    void Spawn()
    {
        
        //Volume limiter for how many notes in one row
        foreach (float freq in freqBand)
        {
            volumeAverage = volumeAverage + freq;
        }
        volumeAverage = volumeAverage / 8;
        //Debug.Log("Volume =" + volumeAverage);
        if (volumeAverage >= doubleHitVolume)
        {
            maxButtons = 2;
            
        }

        //CalcFreq();
        ////if freq a certain amp, spawn relative to 5 - 10 
        //Debug.Log(limiter);
        limiter --;
        //limiter --;
        bool resetLimiter = false;
        
        if(freqBand[2] > (spawnFactor*0.5 / bassRate) && freqBand[2] >= limiter && freqBand[1] >= limiter && maxButtons > 0) //blockers
        {////spawn the thing/////
        //Debug.Log("Spawn");
        //ADD A SPAWN IN HERE FOR DOWN
        //limiter = Mathf.Max(limiter, freqBand[2]);
        buttonSpawner.Instantiate1();
        resetLimiter = true;
        maxButtons--;
        }
        if( freqBand[7] >= (spawnFactor*0.18) && freqBand[7] >= (limiter*0.7) && maxButtons > 0)
        {        
        ////spawn the thing/////
        //ADD A SPAWN IN HERE FOR UP
        buttonSpawner.Instantiate0();
        resetLimiter = true;
        maxButtons--;
        }



        if(freqBand[3] > (spawnFactor*0.32) && freqBand[3] >= (limiter*1) && maxButtons > 0) //blockers
        {////spawn the thing/////
        //ADD A SPAWN IN HERE FOR LEFT
        buttonSpawner.Instantiate2();
        resetLimiter = true;
        maxButtons--;
        }
        
        if( freqBand[5] >= (spawnFactor*0.55) && freqBand[5] >= limiter && maxButtons > 0)
        {        
        ////spawn the thing/////
        //ADD A SPAWN IN HERE FOR RIGHT
        buttonSpawner.Instantiate3();
        resetLimiter = true;
        maxButtons--;
        }

        Debug.Log("Max Buttons =" + maxButtons);
        if (resetLimiter)
        {
            limiter = Mathf.Max(limiter, freqBand[7]);
            limiter = Mathf.Max(limiter, freqBand[3]);
            limiter = Mathf.Max(limiter, freqBand[5]);
            maxButtons = 1;
        }

        
    }


    void CalcFreq()
    {
        ////check getspectrum data////
        beatManager.musicSource.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        //Debug.Log(spectrum[0]);
        // for (int i = 1; i < spectrum.Length - 1; i++)
        // {
        //     Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
        //     Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
        //     Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);        ////this one is the consistent one
        //     Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
        // }

        ////MAKE INTO LESS BANDS////
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2,i) *2;

            if (i == 7)
            {sampleCount += 2;}

            for (int j = 0; j < sampleCount; j++)
            {
                average += spectrum[count] * (count + 1); //https://youtu.be/mHk3ZiKNH48
                    count++;
            }
            average /= count;

            freqBand[i] = average *10;
            //audioVis[i].transform.localScale = new Vector3(0.1f,freqBand[i]*1,1);
        }
        
    }
}
