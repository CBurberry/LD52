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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(beatManager.songPositionInBeats >= lastBeat*0.5)
        {
            
            Debug.Log(lastBeat);
            ///// add one to the beat iteration
            lastBeat++;
            CalcFreq();
            /////spawn//////
            Spawn();
        }
        
    }

    void Spawn()
    {
        //CalcFreq();
        ////if freq a certain amp, spawn relative to 5 - 10 
        Debug.Log(limiter);
        limiter --;
        bool resetLimiter = false;
        
        if(freqBand[2] > (spawnFactor*0.5 / bassRate) && freqBand[2] >= limiter && freqBand[1] >= limiter) //blockers
        {////spawn the thing/////
        Debug.Log("Spawn");
        //ADD A SPAWN IN HERE FOR DOWN
        //limiter = Mathf.Max(limiter, freqBand[2]);
        buttonSpawner.Instantiate1();
        resetLimiter = true;
        }
        if( freqBand[7] >= (spawnFactor*0.3) && freqBand[7] >= limiter)
        {        
        ////spawn the thing/////
        //ADD A SPAWN IN HERE FOR UP
        buttonSpawner.Instantiate0();
        resetLimiter = true;
        }

        if( freqBand[6] >= (spawnFactor*0.5) && freqBand[6] >= limiter)
        {        
        ////spawn the thing/////
        //ADD A SPAWN IN HERE FOR RIGHT
        buttonSpawner.Instantiate3();
        resetLimiter = true;
        }

        if(freqBand[4] > (spawnFactor*0.4) && freqBand[4] >= limiter) //blockers
        {////spawn the thing/////
        //ADD A SPAWN IN HERE FOR LEFT
        buttonSpawner.Instantiate2();
        resetLimiter = true;
        }
        
        if (resetLimiter)
        {
            limiter = Mathf.Max(limiter, freqBand[7]);
            limiter = Mathf.Max(limiter, freqBand[4]);
            limiter = Mathf.Max(limiter, freqBand[6]);
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
