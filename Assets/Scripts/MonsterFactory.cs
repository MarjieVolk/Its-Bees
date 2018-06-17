using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : MonoBehaviour
{
    [SerializeField] private HasLane monster;
    [SerializeField] private float secondsPerMonster;
    [SerializeField] private float secondsPerMonsterJitter;
    [SerializeField] private float lanePositionJitter;
    private float nextSpawnTime;
    private Lanes lanes;

	// Use this for initialization
	void Start () {
		UpdateSpawnTime();
	    lanes = GetComponentInParent<Lanes>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.time >= nextSpawnTime)
	    {
	        UpdateSpawnTime();
	        HasLane spawnedMonster = Instantiate(monster, transform.position, transform.rotation, lanes.transform);
	        spawnedMonster.Lane = lanes.RandomLane();
	        float yPosition = lanes.CenterOfLane(spawnedMonster.Lane) + Random.Range(-lanePositionJitter, lanePositionJitter) * lanes.LaneHeight;
            spawnedMonster.transform.position += new Vector3(0, yPosition, 0);
	    }
	}

    private void UpdateSpawnTime()
    {
        nextSpawnTime = Time.time + secondsPerMonster + Random.Range(-secondsPerMonsterJitter, secondsPerMonsterJitter);
    }
}
