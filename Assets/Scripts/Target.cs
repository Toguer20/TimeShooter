﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Target : HealthBehavior
{
    public static event Action<GameObject> Deleted = delegate { };
    protected Animator animator;
    protected Vector3 originalPos;
    protected Vector3 trajectory;
    protected float velocity;
    public GameObject particleeSystem;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void OnEnable()
    {
        animator.SetTrigger("spawn");
        HP = initialHP;
        GameManager.PlayAgain += Desactivate;
    }
    void OnDisable()
    {
        GameManager.PlayAgain -= Desactivate;
    }
    public void Desactivate()
    {
        this.gameObject.SetActive(false);
    }
    public override void GetHit(int damage)
    {
        HP = (HP - damage) < 0 ? 0 : (HP - damage);
        if (HP <= 0)
        {
            Debug.Log("destroyed");
            animator.SetTrigger("destroy");
            particleeSystem.SetActive(true);
            //Destroyed();
            //GetComponent<AudioSource>().Play();
        }
    }
    public virtual void Destroyed()
    {
        particleeSystem.SetActive(false);
        Deleted.Invoke(this.gameObject);
    }
}
