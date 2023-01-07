using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMovement : MonoBehaviour
{
    public AudioSource song; // drag the audio source component that plays the song to this field in the inspector
    public float beatTempo; // the number of beats per minute of the song
    public float beatDuration; // the length of each beat in seconds, calculated as 60 / beatTempo
    public float beatBuffer; // the amount of time in seconds before the beat that the player can press the space bar
    public float moveSpeed; // the speed at which the player moves left and right

    private bool canMove; // whether or not the player can currently move

    void Start()
    {
        // calculate the beat duration in seconds
        beatDuration = 60f / beatTempo;

        // start the song
        song.Play();

        // start the coroutine that waits for the beat and allows the player to move
        StartCoroutine(WaitForBeat());
    }

    void Update()
    {
        // check if the player can move
        if (canMove)
        {
            // check if the player is pressing the A key
            if (Input.GetKey(KeyCode.A))
            {
                // move the player to the left
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }

            // check if the player is pressing the D key
            if (Input.GetKey(KeyCode.D))
            {
                // move the player to the right
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }
    }

    // coroutine that waits for the beat and allows the player to move
    IEnumerator WaitForBeat()
    {
        // get the time until the next beat
        float timeUntilNextBeat = GetTimeUntilNextBeat();

        // wait until the beat buffer time has passed
        yield return new WaitForSeconds(timeUntilNextBeat - beatBuffer);

        // set canMove to true
        canMove = true;

        // wait until the beat duration has passed
        yield return new WaitForSeconds(beatDuration);

        // set canMove to false
        canMove = false;

        // start the coroutine again
        StartCoroutine(WaitForBeat());
    }

    // function that gets the time until the next beat in seconds
    float GetTimeUntilNextBeat()
    {
        // get the current time in the song in seconds
        float currentTime = song.time;

        // calculate the time until the next beat in seconds
        float timeUntilNextBeat = beatDuration - (currentTime % beatDuration);

        return timeUntilNextBeat;
    }
}
