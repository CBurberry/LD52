using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonCheck : MonoBehaviour
{
    public BoxCollider2D coll;
    public string keyTag = "Key";
    public float score = 0f;
    public float scoreInceasePerKey = 5f;
    private void Start()
    {
        coll = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
            OnTriggerEnter2D();
    }

    private void OnTriggerEnter2D()
    {
        if (coll != null)
        {
            if (coll.gameObject.CompareTag(keyTag))
            {
                Debug.Log("This gameObject has collided with a key");
                score = score + scoreInceasePerKey;
                Destroy(coll.gameObject);
            }
        }


    }
}
