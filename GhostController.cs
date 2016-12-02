using UnityEngine;
using System.Collections;

public class GhostController : MonoBehaviour {

	public float speed = 1;
	public float timeInDirection = 4;
	public int timesSnapped = 0;
	public int snapsAllowed = 3;
	public float outer = 3.5f;
	public float inner = 1.5f;

	private float time = 0;
	private Vector2 dir;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (Random.value * GameManager.mapSize.x - GameManager.mapSize.x / 2, Random.value * GameManager.mapSize.y - GameManager.mapSize.y / 2);
		pickDir (); 
		outer = (float)Random.value + 3f;
		inner = (float)Random.value + 1f;
		GameObject green = transform.Find ("green").gameObject;
		GameObject red = transform.Find ("red").gameObject;
		green.transform.localScale = new Vector3 (outer, outer, 1);
		red.transform.localScale = new Vector3 (inner, inner, 1);

	}
	
	// Update is called once per frame
	void Update () {

		if (time < timeInDirection) {
			transform.Translate (dir * speed * Time.deltaTime);
		} else {
			pickDir ();
			transform.Translate (dir * speed * Time.deltaTime);
			time = 0;
			//timeInDirection = Random.Range (1, 8);
		}
//		if (transform.position.x < (-1 * GameManager.mapSize.x / 2 - outer)) {
//			Vector2 pos = transform.position;
//			transform.position = new Vector2 (GameManager.mapSize.x + pos.x + outer, pos.y);
//		} else if (transform.position.x > GameManager.mapSize.x / 2 + outer) {
//			Vector2 pos = transform.position;
//			transform.position = new Vector2 (pos.x - GameManager.mapSize.x - outer, pos.y);
//		}
//		if (transform.position.y < (-1 * GameManager.mapSize.y / 2 - outer)) {
//			Vector2 pos = transform.position;
//			transform.position = new Vector2 (pos.x, GameManager.mapSize.y + pos.y + outer);
//		} else if (transform.position.y > GameManager.mapSize.y / 2 + outer) {
//			Vector2 pos = transform.position;
//			transform.position = new Vector2 (pos.x, pos.y - GameManager.mapSize.y - outer);
//		}
		if (transform.position.x < (-1 * GameManager.mapSize.x / 2 - outer) || transform.position.x > GameManager.mapSize.x / 2 + outer) {
			Vector2 pos = transform.position;
			transform.position = new Vector2 (-pos.x, pos.y);
		}if (transform.position.y < (-1 * GameManager.mapSize.y / 2 - outer) || transform.position.y > GameManager.mapSize.y / 2 + outer) {
			Vector2 pos = transform.position;
			transform.position = new Vector2 (pos.x, -pos.y);
		}
	
		if (timesSnapped >= snapsAllowed) {
			goAway ();
			timesSnapped = 0;

		}
		time += Time.deltaTime;

	}

	void pickDir() {
		dir = new Vector2 (Mathf.Round(Random.value) * 2 - 1, Mathf.Round(Random.value) * 2 - 1);
		//Debug.Log (time);
	}
	public void goAway() {
		gameObject.transform.position = new Vector3 ((Random.Range (0, 1) * 2 - 1) * GameManager.mapSize.x / 2, (Random.Range (0, 1) * 2 - 1) * GameManager.mapSize.y / 2);
	}




}
