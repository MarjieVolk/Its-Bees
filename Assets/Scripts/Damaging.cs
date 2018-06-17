using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 
    Damaging : MonoBehaviour {

    // The amount of damage this bullet will do.
    [SerializeField] public float damage = 600;

    void OnTriggerEnter2D(Collider2D collision)
    {
        HasHealth other = collision.gameObject.GetComponent<HasHealth>();
        if (other != null)
        {
            other.TakeDamage(damage);
        }
    }
}
