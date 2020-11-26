using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthBehavior : MonoBehaviour, IHittable
{
    [SerializeField]protected int healthPoints;

    public virtual void GetHit(int damage)
    {
        healthPoints = healthPoints - damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
