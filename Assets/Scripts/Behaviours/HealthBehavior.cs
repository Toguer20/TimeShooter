using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthBehavior : MonoBehaviour, IHittable
{
    [SerializeField]protected int initialHP;
    protected int HP;

    public virtual void Start()
    {
        initialHP = HP;
    }
    public virtual void GetHit(int damage)
    {
        HP = HP - damage;
    }

}
