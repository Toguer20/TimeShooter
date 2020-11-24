using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBehaviour : MonoBehaviour
{
    [SerializeField] private int _damage;
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IHittable>(out IHittable target))
            target.GetHit(_damage);
    }
}
