using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFactory : MonoBehaviour {

	public float spawnInterval;        // The amount of time between each spawn.
	public float spawnDelay;       // The amount of time before spawning starts.
	public float difficultyRate;
	public float difficultyUpdateInterval;
	public float maxSpeed;
	public float maxSpawnInterval;
	private float lastDifficultyUpdate = 0;

	public GameObject normghost;
	//public GameObject wheelghost;
	// Use this for initialization
	void Start () {
		Invoke("Spawn", spawnDelay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Spawn()
	{
//		if (Time.time - lastDifficultyUpdate >= difficultyUpdateInterval)
//		{
//			difficultyUpdateInterval = Time.time;
//			if (spawnInterval < maxSpawnInterval)
//			{
//				spawnInterval = spawnInterval / difficultyRate;
//			}
//
//		}

		GhostController ghostie = Instantiate(normghost) //Random.value < 0.5 ? normghost : wheelghost)
			.GetComponent<GhostController>();
		ghostie.timeInDirection = Random.Range (1, 8);
		
		Invoke("Spawn", spawnInterval);
	}
}
