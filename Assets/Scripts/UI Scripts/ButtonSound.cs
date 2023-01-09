using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseEnter()
    {
        audioSource.Play();
    }

    void OnMouseExit()
    {
        audioSource.Stop();
    }
}