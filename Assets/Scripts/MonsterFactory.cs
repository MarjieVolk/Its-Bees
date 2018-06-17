using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    [SerializeField] private float secondsPerMonster;
    [SerializeField] private float secondsPerMonsterJitter;
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
	        spawnedMonster.transform.position += (Vector3) Vector2.up * Random.Range(bounds.center.y - bounds.extents.y, bounds.center.y + bounds.extents.y);
	    }
	}

    private void UpdateSpawnTime()
    {
        nextSpawnTime = Time.time + secondsPerMonster + Random.Range(-secondsPerMonsterJitter, secondsPerMonsterJitter);
    }
}
