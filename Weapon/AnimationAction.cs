using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///
/// <summary>

public class AnimationAction
{
    private Animation anim;
    public void Play(string animName)
    {
        anim.CrossFade(animName);
    }
    public void PlayQueued(string animName)
    {
        anim.PlayQueued(animName);
    }
    public AnimationAction (Animation anim)
    {
        this.anim = anim;
    }
    public bool IsPlaying(string name)
    {
        return anim.IsPlaying(name);
    }
}
