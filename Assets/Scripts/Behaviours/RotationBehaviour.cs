using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBehaviour : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private void Awake()
    {
        int rand = Random.Range(0, 3);
        this.enabled = rand == 0 ? true : false; // 1/3 of the targets will rotate randomly
    }
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
