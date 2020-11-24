using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unparent : MonoBehaviour
{
    void Start()
    {
        this.gameObject.transform.parent = null;
    }
}
