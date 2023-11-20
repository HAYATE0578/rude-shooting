using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///
/// <summary>

public class LookAtPlayer : MonoBehaviour
{
    public void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
