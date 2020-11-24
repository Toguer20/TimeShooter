using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveBehaviour))]
public class Bullet : HitBehaviour
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
        base.OnTriggerEnter(other);
        Owner.GetBackBullet(this);
    }
}
