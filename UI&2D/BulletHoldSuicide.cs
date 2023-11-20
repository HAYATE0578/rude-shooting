using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///
/// <summary>

public class bulletHoldSuicide : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 5);
    }
}
