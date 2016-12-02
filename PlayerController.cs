using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5;
	public float goodZoneTime = 3;

	public float goodZoneInitOpacity = 0.274f;
	public float goodZoneEndOpacity = 0.6f;

	private float timeInGoodZone = 0;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {


		float moveHorz = Input.GetAxis ("Horizontal");
		float moveVert = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorz, moveVert);

		transform.Translate (movement * speed * Time.deltaTime);

	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "Bad Zone") {

			timeInGoodZone = 0;
			other.gameObject.transform.parent.transform.position = new Vector3 (Random.Range(-10, 10), Random.Range(-10, 10));

		}


	}

	void OnTriggerStay2D(Collider2D other) {

		if (other.gameObject.tag == "Good Zone") {

			StartCoroutine (MakeOpaque(other.gameObject.GetComponent<SpriteRenderer>(), goodZoneTime));
			timeInGoodZone += Time.deltaTime;

		}

		if (timeInGoodZone >= goodZoneTime) {

			other.gameObject.transform.parent.transform.position = new Vector3 (Random.Range(-10, 10), Random.Range(-10, 10));
			SpriteRenderer sr = other.gameObject.GetComponent<SpriteRenderer> ();
			sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, goodZoneInitOpacity);
		
		}


	}

	void OnTriggerExit2D(Collider2D other) {

		if (other.gameObject.tag == "Good Zone") {

			StopCoroutine ("MakeOpaque");
			SpriteRenderer sr = other.gameObject.GetComponent<SpriteRenderer> ();
			sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, goodZoneInitOpacity);
			timeInGoodZone = 0;

		}

	}

	IEnumerator MakeOpaque(SpriteRenderer sr, float duration) {
		

		for (float t = 0.0f; t < 1.0f; t+= Time.deltaTime/duration) {

			Debug.Log (1);

			sr.color = new Color (sr.color.r, sr.color.g, sr.color.b, Mathf.Lerp(0, 1, duration));
			yield return null;
		}
		
	}
		

}
