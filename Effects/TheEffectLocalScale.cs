using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// effect´ó¤­¤µ¤ò¥³¥ó¥È¥í©`¥ë
/// <summary>

public class TheEffectLocalScale : MonoBehaviour
{
    ParticleSystem[] effect;
    public float scaleNumber = 0.5f;
    public void Update()
    {
        effect = this.GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i < effect.Length; i++)
        {
            var main = item.main;
            main.scalingMode = ParticleSystemScalingMode.Local;
            item.transform.localScale = new Vector3(scaleNumber, scaleNumber, scaleNumber);
        }
    }
    public void Reset()
    {
        effect = this.GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i < effect.Length; i++)
        {
            var main = item.main;
            main.scalingMode = ParticleSystemScalingMode.Local;
            item.transform.localScale = new Vector3(scaleNumber, scaleNumber, scaleNumber);
        }
    }
}
