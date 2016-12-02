using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	public float goodZoneTime = 3.0f;

	public float goodZoneInitOpacity = 0.274f;
	public float goodZoneEndOpacity = 0.6f;

	private float timeInGoodZone = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "Bad Zone") {

			timeInGoodZone = 0;
			other.gameObject.transform.parent.transform.position = new Vector3 (Random.Range(-10, 10), Random.Range(-10, 10));

		}


	}

	void OnTriggerStay2D(Collider2D other) {

		if (other.gameObject.tag == "Good Zone" && Input.GetButtonDown ("Snap") == true) {
			
			timeInGoodZone += Time.deltaTime;
			GhostController ghost = other.gameObject.transform.parent.gameObject.GetComponent<GhostController>();
			ghost.timesSnapped += 1;

		}

		if (timeInGoodZone >= goodZoneTime) {

			other.gameObject.transform.parent.transform.position = new Vector3 (Random.Range(-10, 10), Random.Range(-10, 10));
		}


	}

	void OnTriggerExit2D(Collider2D other) {

		if (other.gameObject.tag == "Good Zone") {

			timeInGoodZone = 0;

		}

	}

}
