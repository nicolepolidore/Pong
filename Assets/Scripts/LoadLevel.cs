using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public AudioSource buttonSound;
    public void startGame()
    {
        buttonSound.Play();
        SceneManager.LoadScene("SampleScene");
    }

    
  
}
