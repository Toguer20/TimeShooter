using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Target : MonoBehaviour, IHittable
{
    public static event Action<GameObject> Deleted = delegate { };
    protected int lifePoints = 1;
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
        lifePoints = 1;
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
    public virtual void GetHit(int damage)
    {
        lifePoints = (lifePoints - damage) < 0 ? 0 : (lifePoints - damage);
        if (lifePoints == 0)
        {
            animator.SetTrigger("destroy");
            particleeSystem.SetActive(true);
            GetComponent<AudioSource>().Play();
        }
    }
    public virtual void Destroyed()
    {
        particleeSystem.SetActive(false);
        Deleted.Invoke(this.gameObject);
    }
}
