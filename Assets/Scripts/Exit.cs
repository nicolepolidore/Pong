using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{

    public AudioSource buttonSound;
   
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
            Debug.Log("quit");
        }
    }

    //for button
   public void exitGame()
    {
        buttonSound.Play();
        Application.Quit();
        Debug.Log("quit");

    }
}
