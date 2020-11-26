using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveBehaviour))]
public abstract class Bullet : HitBehaviour
{
    public Weapon Owner { get; set; }
    private MoveBehaviour _moveBehaviour;

    public void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
    }

    public void FixedUpdate()
    {
        _moveBehaviour.MoveForward();
    }
    
    protected override void OnTriggerEnter(Collider other)
    {
        Debug.Log("bala colisiona");
        base.OnTriggerEnter(other);
        Owner.GetBackBullet(this);
    }
}
