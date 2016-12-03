using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	public float goodZoneTime = 3.0f;

	public float goodZoneInitOpacity = 0.274f;
	public float goodZoneEndOpacity = 0.6f;
	public float cameraSkills = 17 / (12 * 1.3f);
	private float snapshotTime = 0;
	private float timeInGoodZone = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Snap") == true) {
			snapshotTime += Time.deltaTime;
		}
		if (Input.GetButtonUp ("Snap") == true || Input.GetButtonDown("Snap") == true) {
			snapshotTime = 0;
		}
	}


	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "Bad Zone") {

			timeInGoodZone = 0;
			GhostController ghost = other.gameObject.transform.parent.gameObject.GetComponent<GhostController>();
			ghost.goAway ();
			GameManager.lives -= 1;
		}


	}

	void OnTriggerStay2D(Collider2D other) {

		if (other.gameObject.tag == "Good Zone") {
			if (snapshotTime >= cameraSkills) {
				timeInGoodZone += Time.deltaTime; 
				GhostController ghost = other.gameObject.transform.parent.gameObject.GetComponent<GhostController> ();
				ghost.timesSnapped += 1;
				GameManager.score += (int)(ghost.getDifficulty() * 50);
				Debug.Log ("YAY!                     " + ghost.timesSnapped);
				snapshotTime = 0;
			}

		}

		if (timeInGoodZone >= goodZoneTime) {

			GhostController ghost = other.gameObject.transform.parent.gameObject.GetComponent<GhostController>();
			ghost.goAway ();		}


	}

	void OnTriggerExit2D(Collider2D other) {

		if (other.gameObject.tag == "Good Zone") {
			snapshotTime = 0;
			timeInGoodZone = 0;

		}

	}

}
