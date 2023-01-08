using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Events;
using System;

public class ButtonSpawner : MonoBehaviour
{
    //Singleton
    public static ButtonSpawner Instance { get; private set; }

    [SerializeField] private PlayableDirector timeline;
    public static float timelineTime;

    // Declare the event

    public GameObject prefabToInstantiate;
    public GameObject button0;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;


    public GameObject row0;
    public GameObject row1;
    public GameObject row2;
    public GameObject row3;

    // Subscribe to the event
    void OnEnable()
    {

    }

    // Unsubscribe from the event
    void OnDisable()
    {

    }

    void Awake()
    {
        timeline = GetComponent<PlayableDirector>();

    }


    void Start()
    {

        timeline.Play();
    }

    void Update()
    {
        timelineTime = (float)timeline.time;
    }


    // This method will be called when the event is invoked
    public void InstantiateThePrefab()
    {
        Debug.Log("RWHJIAORHWIAORHWIA");
        Instantiate(prefabToInstantiate);
    }
        // This method will be called when the event is invoked
    public void Instantiate0()
    {
        Debug.Log("RWHJIAORHWIAORHWIA2");

        Instantiate(button0, row0.transform);
    }

    public void Instantiate1()
    {
        Debug.Log("RWHJIAORHWIAORHWIA2");

        Instantiate(button1, row1.transform);
    }

    public void Instantiate2()
    {
        Debug.Log("RWHJIAORHWIAORHWIA2");

        Instantiate(button2, row2.transform);
    }

    public void Instantiate3()
    {
        Debug.Log("RWHJIAORHWIAORHWIA2");

        Instantiate(button3, row3.transform);
    }
}
