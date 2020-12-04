using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string auxescena;
    public void CargarScene(string escena)
    {
        SceneManager.LoadScene("Loading");
        auxescena=escena;
        DontDestroyOnLoad(this.gameObject);
    }
    public void OnTriggerEnter2D(Collider2D loader)
    {
        SceneManager.LoadScene(auxescena);
    }
}
