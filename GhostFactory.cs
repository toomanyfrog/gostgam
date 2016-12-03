using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFactory : MonoBehaviour {

	public float spawnInterval;        // The amount of time between each spawn.
	public float spawnDelay;       // The amount of time before spawning starts.
	public float difficultyRate;
	public float difficultyUpdateInterval;
	public float maxSpawnInterval;
	private float lastDifficultyUpdate = 0;

	public GameObject normghost;
	//public GameObject wheelghost;
	// Use this for initialization
	void Start () {
		Invoke("firstSpawn", spawnDelay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Spawn()
	{
		if (Time.time - lastDifficultyUpdate >= difficultyUpdateInterval)
		{
			difficultyUpdateInterval = Time.time;
			if (spawnInterval < maxSpawnInterval)
			{
				Debug.Log (spawnInterval);
				Debug.Log (difficultyRate);

				spawnInterval = spawnInterval / difficultyRate;
			}

		}

		GhostController ghostie = Instantiate(normghost) //Random.value < 0.5 ? normghost : wheelghost)
			.GetComponent<GhostController>();
		ghostie.timeInDirection = Random.Range (1, 8);
		ghostie.baseSpeed += 0.1f;
		ghostie.basePoseTime -= 0.1f;
		ghostie.baseOuter -= 0.05f;
		ghostie.baseInner += 0.05f;

		Invoke("Spawn", spawnInterval);
	}
	void firstSpawn()
	{
		Instantiate (normghost); //Random.value < 0.5 ? normghost : wheelghost)
		Instantiate(normghost); //Random.value < 0.5 ? normghost : wheelghost)
		Instantiate(normghost); //Random.value < 0.5 ? normghost : wheelghost)
		Instantiate(normghost); //Random.value < 0.5 ? normghost : wheelghost)
		Instantiate(normghost); //Random.value < 0.5 ? normghost : wheelghost)

		Invoke("Spawn", spawnInterval);
	}
}
