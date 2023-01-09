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

    [SerializeField] private List<GameObject> objectsInContactUp;
    [SerializeField] private List<GameObject> objectsInContactDown;
    [SerializeField] private List<GameObject> objectsInContactLeft;
    [SerializeField] private List<GameObject> objectsInContactRight;

    [SerializeField] private SpriteRenderer spriteRenderer;

    public Sprite happy;
    public Sprite neutral;
    public Sprite sad;

    private int notesHit = 0;
    private int notes = 0;

    private float percent = 0;


    private void Start()
    {
        objectsInContactUp = new List<GameObject>();
        objectsInContactDown = new List<GameObject>();
        objectsInContactLeft = new List<GameObject>();
        objectsInContactRight = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && objectsInContactUp[0])
        {
        Debug.Log("UP PRESS");
        KeyUpPressed();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && objectsInContactDown[0])
        {
        Debug.Log("Down PRESS");
        KeyDownPressed();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && objectsInContactLeft[0])
        {
        KeyLeftPressed();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && objectsInContactRight[0])
        {
        KeyRightPressed();
        }
        
        percent = notesHit/notes*100;
        if (percent == 0 || percent <= 80)
        {
            ChangeSpriteNeutral();
        }
        if (percent >= 80)
        {
            ChangeSprite();
        }
        if (percent <= 50)
        {
            ChangeSpriteSad();
        }

    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll != null)
        {
            if (coll.gameObject.CompareTag(keyUpTag))
            {//Debug.Log(coll);
             objectsInContactUp.Add(coll.gameObject);
            }
            if (coll.gameObject.CompareTag(keyDownTag))
            {//Debug.Log(coll);
             objectsInContactDown.Add(coll.gameObject);}
            if (coll.gameObject.CompareTag(keyLeftTag))
            {//Debug.Log(coll);
             objectsInContactLeft.Add(coll.gameObject);}
            if (coll.gameObject.CompareTag(keyRightTag))
            {//Debug.Log(coll);
             objectsInContactRight.Add(coll.gameObject);
            }
        }


    }


    private void OnTriggerExit2D(Collider2D coll)
    {
        
        if (coll != null)
        {
            if (coll.gameObject.CompareTag(keyUpTag))
            {//Debug.Log(coll);
             objectsInContactUp.Remove(coll.gameObject);
             notes++;
            }
            if (coll.gameObject.CompareTag(keyDownTag))
            {//Debug.Log(coll);
             objectsInContactDown.Remove(coll.gameObject);
             notes++;}
            if (coll.gameObject.CompareTag(keyLeftTag))
            {//Debug.Log(coll);
             objectsInContactLeft.Remove(coll.gameObject);
             notes++;}
            if (coll.gameObject.CompareTag(keyRightTag))
            {//Debug.Log(coll);
             objectsInContactRight.Remove(coll.gameObject);
             notes++;
            }
        }



    }

    private void KeyUpPressed()
    {
        if (objectsInContactUp[0])
        {
            Debug.Log("Up is pressed upon collision");
            float overlap = CalculateOverlap(GetComponent<BoxCollider2D>(), objectsInContactUp[0].GetComponent<BoxCollider2D>());
            Debug.Log(overlap);
            if(correctParticleSys)
            {Instantiate(correctParticleSys, objectsInContactUp[0].transform.position, this.transform.rotation);}
            score = score + (scoreInceasePerKey * overlap / 50);
            ChangeSprite();
            Destroy(objectsInContactUp[0]);
            //objectsInContactUp.Remove(objectsInContactUp[0]);
            notesHit++;
        }

    }
    private void KeyDownPressed()
    {

        if (objectsInContactDown[0])
        {
            Debug.Log("Down is pressed upon collision");
            float overlap = CalculateOverlap(GetComponent<BoxCollider2D>(), objectsInContactDown[0].GetComponent<BoxCollider2D>());
            Debug.Log(overlap);
            if(correctParticleSys)
                {Instantiate(correctParticleSys, objectsInContactDown[0].transform.position, this.transform.rotation);}
            score = score + (scoreInceasePerKey * overlap / 50);
            Destroy(objectsInContactDown[0]);
            //objectsInContactDown.Remove(objectsInContactDown[0]);
            notesHit++;
        }


    }
    private void KeyLeftPressed()
    {

        if (objectsInContactLeft[0])
        {
            Debug.Log("Left is pressed upon collision");
            float overlap = CalculateOverlap(GetComponent<BoxCollider2D>(), objectsInContactLeft[0].GetComponent<BoxCollider2D>());
            Debug.Log(overlap);
            if(correctParticleSys)
                {Instantiate(correctParticleSys, objectsInContactLeft[0].transform.position, this.transform.rotation);}
            score = score + (scoreInceasePerKey * overlap / 50);
            Destroy(objectsInContactLeft[0]);
            //objectsInContactLeft.Remove(objectsInContactLeft[0]);
            notesHit++;
        }

        
    }
    private void KeyRightPressed()
    {

        if (objectsInContactRight[0])
        {
            Debug.Log("Right is pressed upon collision");
            float overlap = CalculateOverlap(GetComponent<BoxCollider2D>(), objectsInContactRight[0].GetComponent<BoxCollider2D>());
            Debug.Log(overlap);
            if(correctParticleSys)
                {Instantiate(correctParticleSys, objectsInContactRight[0].transform.position, this.transform.rotation);}
            score = score + (scoreInceasePerKey * overlap / 50);
            Destroy(objectsInContactRight[0]);
            //objectsInContactRight.Remove(objectsInContactRight[0]);
            notesHit++;
        }

        
    }

    public void ChangeSprite() 
    {
        spriteRenderer.sprite = happy;
    }
    public void ChangeSpriteNeutral() 
    {
        spriteRenderer.sprite = neutral;
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
