using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Next_SceneLoad : MonoBehaviour
{
    public GameObject loadeer;
    public void OnTriggerEnter2D(Collider2D loader)
    {
        loadeer.SetActive(true);
    }
    
}
