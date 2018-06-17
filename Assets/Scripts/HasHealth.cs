﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasHealth : MonoBehaviour {

    float health = 200;

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
