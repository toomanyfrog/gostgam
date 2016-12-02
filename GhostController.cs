using UnityEngine;
using System.Collections;

public class GhostController : MonoBehaviour {

	public float speed = 1;
	public float timeInDirection = 2;
	public int timesSnapped = 0;

	private float time = 0;
	private Vector2 dir;

	// Use this for initialization
	void Start () {

		pickDir (); 

	}
	
	// Update is called once per frame
	void Update () {

		if (time < timeInDirection) {
			transform.Translate (dir * speed * Time.deltaTime);
		} else {
			pickDir ();
			time = 0;
		}

		Debug.Log (timesSnapped);

		time += Time.deltaTime;

	}

	void pickDir() {
		dir = new Vector2 (Random.Range (-1, 1), Random.Range (-1, 1));
		Debug.Log (time);
	}




}
