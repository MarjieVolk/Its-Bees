using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBG : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 renderSize = GetComponent<Collider>().bounds.size;
        transform.Translate (- Time.deltaTime * Variables.TerrainSpeedPerSecond / 2, 0, 0);
		if (transform.position.x < - renderSize.x / 4)
        {
            transform.Translate(renderSize.x / 2, 0, 0);
        }
	}
}
