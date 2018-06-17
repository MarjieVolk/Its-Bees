using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float secondsPerShot;
    private float nextShotTime;

	// Use this for initialization
	void Start ()
	{
	    nextShotTime = Time.time + secondsPerShot;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.time >= nextShotTime)
	    {
	        nextShotTime = Time.time + secondsPerShot;
	        Instantiate(bullet, transform.position, transform.rotation);
	    }
	}
}
