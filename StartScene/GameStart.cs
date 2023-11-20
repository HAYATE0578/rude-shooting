using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
///
/// <summary>

public class GameStart : MonoBehaviour
{
    public void Update()
    {
        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene("50zombies");
        }    
    }
}
