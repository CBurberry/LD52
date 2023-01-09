using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Application.loadedLevelName != "Title")
        {
            audioSource.Stop();
            Destroy(gameObject);
        }
    }
}