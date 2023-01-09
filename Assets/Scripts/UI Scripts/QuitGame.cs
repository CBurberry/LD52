using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Game has been Quit");
        // Quit the game
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) { Application.Quit(); }
    }
}