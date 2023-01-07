using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class ButtonSpawner : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline;
    private static float timelineTime;

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
}
