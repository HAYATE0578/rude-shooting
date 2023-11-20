using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///
/// <summary>

public class esc : MonoBehaviour
{
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
