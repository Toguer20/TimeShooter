using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    void Update()
    {
    if (GameManager.gm.Timer > 0)
        {
            GameManager.gm.SetTimer(Time.deltaTime);
        }
        else
        {
            GameManager.gm.GameOver();
        }
    }
}
