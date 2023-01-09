using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonCheck : MonoBehaviour
{

    public GameObject correctParticleSys;
    public Transform rowTransform;
    public string keyUpTag = "KeyUp";
    public string keyDownTag = "KeyDown";
    public string keyLeftTag = "KeyLeft";
    public string keyRightTag = "KeyRight";
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
        KeyUpPressed();
        KeyDownPressed();
        KeyLeftPressed();
        KeyRightPressed();
        
        // Check if the player pressed the "space" key
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll != null)
        {
            if (coll.gameObject.CompareTag(keyUpTag))
            {//Debug.Log(coll);
             objectsInContact.Add(coll.gameObject);
            }
            if (coll.gameObject.CompareTag(keyDownTag))
            {//Debug.Log(coll);
             objectsInContact.Add(coll.gameObject);}
            if (coll.gameObject.CompareTag(keyLeftTag))
            {//Debug.Log(coll);
             objectsInContact.Add(coll.gameObject);}
            if (coll.gameObject.CompareTag(keyRightTag))
            {//Debug.Log(coll);
             objectsInContact.Add(coll.gameObject);
            }
        }


    }


    private void OnTriggerExit2D(Collider2D coll)
    {
        
        if (coll != null)
        {
            
            if (coll.gameObject.CompareTag(keyUpTag))
            {
                Debug.Log(coll);
                objectsInContact.Remove(coll.gameObject);
            }
        }
        ///RUN A MISS EVENT
        ChangeSpriteSad();


    }

    private void KeyUpPressed()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (objectsInContact[0])
            {
                Debug.Log("Up is pressed upon collision");
                float overlap = CalculateOverlap(GetComponent<BoxCollider2D>(), objectsInContact[0].GetComponent<BoxCollider2D>());
                Debug.Log(overlap);
                Instantiate(correctParticleSys, objectsInContact[0].transform.position, this.transform.rotation);
                score = score + (scoreInceasePerKey * overlap / 50);
                ChangeSprite();
                Destroy(objectsInContact[0]);
                objectsInContact.Remove(objectsInContact[0]);
            }

        }
    }
    private void KeyDownPressed()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (objectsInContact[0])
            {
                Debug.Log("Down is pressed upon collision");
                float overlap = CalculateOverlap(GetComponent<BoxCollider2D>(), objectsInContact[0].GetComponent<BoxCollider2D>());
                Debug.Log(overlap);
                Instantiate(correctParticleSys, objectsInContact[0].transform.position, this.transform.rotation);
                score = score + (scoreInceasePerKey * overlap / 50);
                ChangeSprite();
                Destroy(objectsInContact[0]);
                objectsInContact.Remove(objectsInContact[0]);
            }

        }
    }
    private void KeyLeftPressed()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (objectsInContact[0])
            {
                Debug.Log("Left is pressed upon collision");
                float overlap = CalculateOverlap(GetComponent<BoxCollider2D>(), objectsInContact[0].GetComponent<BoxCollider2D>());
                Debug.Log(overlap);
                Instantiate(correctParticleSys, objectsInContact[0].transform.position, this.transform.rotation);
                score = score + (scoreInceasePerKey * overlap / 50);
                ChangeSprite();
                Destroy(objectsInContact[0]);
                objectsInContact.Remove(objectsInContact[0]);
            }

        }
    }
    private void KeyRightPressed()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (objectsInContact[0])
            {
                Debug.Log("Right is pressed upon collision");
                float overlap = CalculateOverlap(GetComponent<BoxCollider2D>(), objectsInContact[0].GetComponent<BoxCollider2D>());
                Debug.Log(overlap);
                Instantiate(correctParticleSys, objectsInContact[0].transform.position, this.transform.rotation);
                score = score + (scoreInceasePerKey * overlap / 50);
                ChangeSprite();
                Destroy(objectsInContact[0]);
                objectsInContact.Remove(objectsInContact[0]);
            }

        }
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
