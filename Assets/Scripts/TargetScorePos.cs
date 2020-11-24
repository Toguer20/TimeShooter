using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScorePos : Target 
{
    public int score = 5;
    private int coins = 10;
    public override void GetHit(int damage)
    {
        GetComponent<AudioSource>().clip = AudioManager.Instance.scoreTarget;
        base.GetHit(damage); //does what father does in GetHti(x)
        GameManager.gm.UpdateScore(score);
        GameManager.gm.updateCoins(coins);
    }
}
