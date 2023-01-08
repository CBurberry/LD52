using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingButtons : MonoBehaviour
{
    [SerializeField] private float spawnTime;
    private RectTransform rect;
    
    // Start is called before the first frame update
    void Awake()
    {
        //spawntime = timeline time
        rect = this.GetComponent<RectTransform>();
        spawnTime = ButtonSpawner.timelineTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        rect = this.GetComponent<RectTransform>();
        //rect = uiComponent.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform = spawntime - current song timestamp
        // Every beat it should move one and this is in seconds so first convert to beats, each beat, the next row should reach the hitbox
        float re = (spawnTime - Conductor.songPositionStatic)*(120/60)*(1444/8) + 1444; //1444 is the width of the UI element, 120 is the BPM, 60 is bpm -> bps, 8 is the beats in a whole screens distance, +X is the relative starting position
        //Debug.Log(re);
        // var pos = rect.localPosition;
        // rect.localPosition = new Vector3(re,pos.y,pos.z);
        //this.position.x = re;
        //this.anchoredPosition = new Vector2(re, 0);

        Vector2 anchoredPosition = rect.anchoredPosition;
        anchoredPosition.x = re;
        //Debug.Log(anchoredPosition);
        rect.anchoredPosition = anchoredPosition;
    }
}
