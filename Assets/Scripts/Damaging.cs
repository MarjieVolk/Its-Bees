using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 
    Damaging : MonoBehaviour {

    // The amount of damage this bullet will do.
    [SerializeField] private float damage = 1;
    [SerializeField] private bool selfDestruct = true;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name + " on layer " + collision.gameObject.layer + " colliding with " + gameObject.name + " on layer " + gameObject.layer);
        HasHealth other = collision.gameObject.GetComponent<HasHealth>();
        if (other != null)
        {
            other.TakeDamage(damage);
            if (selfDestruct)
            {
                Destroy(gameObject);
            }
        }
    }
}
