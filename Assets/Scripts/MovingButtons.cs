using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingButtons : MonoBehaviour
{
    private float spawnTime = 1444;
    [SerializeField] private RectTransform rect;
    
    // Start is called before the first frame update
    void Awake()
    {
        //spawntime = timeline time
        rect = this.GetComponent<RectTransform>();
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
        float re = spawnTime - (Conductor.songPositionStatic*777);
        //Debug.Log(re);
        // var pos = rect.localPosition;
        // rect.localPosition = new Vector3(re,pos.y,pos.z);
        //this.position.x = re;
        //this.anchoredPosition = new Vector2(re, 0);

        Vector2 anchoredPosition = rect.anchoredPosition;
        anchoredPosition.x = re;
        Debug.Log(anchoredPosition);
        rect.anchoredPosition = anchoredPosition;
    }
}
