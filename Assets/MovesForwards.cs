using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesForwards : MonoBehaviour
{
    [SerializeField] private float speed;
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position += (Vector3) (transform.right * speed);
	}
}
