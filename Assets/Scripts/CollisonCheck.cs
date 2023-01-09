using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonCheck : MonoBehaviour
{
    public string keyTag = "Key";
    public float score = 0f;
    public float scoreInceasePerKey = 5f;

    [SerializeField] private List<GameObject> objectsInContact;

    [SerializeField] private SpriteRenderer spriteRenderer;

    public Sprite happy;
    public Sprite neutral;
    public Sprite sad;


    private void Start()
    {
        objectsInContact = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player pressed the "space" key
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(objectsInContact[0])
            {Debug.Log("Up is pressed upon collision");
            float overlap = CalculateOverlap(GetComponent<BoxCollider2D>(), objectsInContact[0].GetComponent<BoxCollider2D>());
            Debug.Log(overlap);
            score = score + (scoreInceasePerKey*overlap);
            ChangeSprite();
            Destroy(objectsInContact[0]);
            objectsInContact.Remove(objectsInContact[0]);}

        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll != null)
        {
            if (coll.gameObject.CompareTag(keyTag))
            {
                //Debug.Log(coll);
                objectsInContact.Add(coll.gameObject);
            }
        }


    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        
        if (coll != null)
        {
            if (coll.gameObject.CompareTag(keyTag))
            {
                Debug.Log(coll);
                objectsInContact.Remove(coll.gameObject);
            }
        }
        ///RUN A MISS EVENT
        ChangeSpriteSad();


    }

    public void ChangeSprite() 
    {
        spriteRenderer.sprite = happy;
    }
    public void ChangeSpriteSad() 
    {
        spriteRenderer.sprite = sad;
    }

    float CalculateOverlap(Collider2D collider1, Collider2D collider2) 
    {
        Bounds bounds1 = collider1.bounds;
        Bounds bounds2 = collider2.bounds;

        float xOverlap = Mathf.Max(0, Mathf.Min(bounds1.max.x, bounds2.max.x) - Mathf.Max(bounds1.min.x, bounds2.min.x));
        float yOverlap = Mathf.Max(0, Mathf.Min(bounds1.max.y, bounds2.max.y) - Mathf.Max(bounds1.min.y, bounds2.min.y));

        return xOverlap * yOverlap;
    }
}
