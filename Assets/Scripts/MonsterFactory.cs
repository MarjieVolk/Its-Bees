using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    [SerializeField] private float secondsPerMonster;
    [SerializeField] private float secondsPerMonsterJitter;
    [SerializeField] private int numLanes;
    private float nextSpawnTime;

	// Use this for initialization
	void Start () {
		UpdateSpawnTime();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.time >= nextSpawnTime)
	    {
	        UpdateSpawnTime();
	        GameObject spawnedMonster = Instantiate(monster, transform.position, transform.rotation);
	        Bounds bounds = this.GetComponent<Collider2D>().bounds;
	        int lane = Random.Range(0, numLanes);
	        spawnedMonster.transform.position += new Vector3(0, bounds.min.y + bounds.size.y * (lane + 0.5f) / numLanes, 0);
	    }
	}

    private void UpdateSpawnTime()
    {
        nextSpawnTime = Time.time + secondsPerMonster + Random.Range(-secondsPerMonsterJitter, secondsPerMonsterJitter);
    }
}
