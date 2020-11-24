using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class MoveBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed;
    public float Speed { get; set; }

    private Rigidbody _rb;
    public void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void MoveForward()
    {
        _rb.velocity = transform.forward * _speed;
    }
    public void MoveForward(Vector2 inputDir)
    {
        _rb.velocity = (transform.forward * (inputDir.y * _speed)) + (transform.right * (inputDir.x * _speed) + (transform.up * _rb.velocity.y));
    }
    

    public void Move(Vector3 newDir)
    {
        _rb.MovePosition((transform.position + newDir) * _speed);
    }

}
