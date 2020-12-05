using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTimePos : Target
{
    private float time = -3f;
    public override void GetHit(int damage)
    {
     //GetComponent<AudioSource>().clip = AudioManager.Instance.timeAddTarget;
      base.GetHit(damage);
      GameManager.gm.SetTimer(time);
    }
}
