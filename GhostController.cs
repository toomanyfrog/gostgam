using UnityEngine;
using System.Collections;

public class GhostController : MonoBehaviour {

	public float baseSpeed = 2;
	public float basePoseTime = 3;
	public float baseWalkTime = 6;
	public float baseOuter = 12.5f;
	public float baseInner = 4.5f;

	public int timesSnapped = 0;
	public int snapsAllowed = 1;

	private float speed;
	private float poseTime;
	private float walkTime;
	private float outer;
	private float inner;

	private float time = 0;
	private float pause = 0;
	private Vector2 dir;
	private SpriteRenderer sr;

	public Animator animator;
	private GameObject green;


	// Use this for initialization
	void Start () {
		green = transform.Find ("green").gameObject;
		green.SetActive (false);
		reincarnate ();


	}

	void Awake() {

		sr = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (time < walkTime) {
			transform.Translate (dir * speed * Time.deltaTime);
		} else {
			if (pause < poseTime) {
				green.SetActive (true);
				sr.flipX = false;
				animator.SetBool ("isPosing", true);
				animator.SetInteger ("poseIndex", Mathf.RoundToInt (Random.value));
				pause += Time.deltaTime;
			} else {
				green.SetActive (false);
				animator.SetBool ("isPosing", false);
				transform.Translate (dir * speed * Time.deltaTime);
				time = 0;
				pause = 0;
			}
		}
			//timeInDirection = Random.Range (1, 8);
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
//			Vector2 pos = transform.position;
//			transform.position = new Vector2 (-pos.x, pos.y);
			dir.x = -dir.x;
			sr.flipX = !sr.flipX;
			transform.Translate (dir * speed * Time.deltaTime * 2);

		}if (transform.position.y < (-1 * GameManager.mapSize.y / 2 - outer) || transform.position.y > GameManager.mapSize.y / 2 + outer) {
//			Vector2 pos = transform.position;
//			transform.position = new Vector2 (pos.x, -pos.y);
			dir.y = -dir.y;
			transform.Translate (dir * speed * Time.deltaTime * 2);

		}
	
		if (timesSnapped >= snapsAllowed) {
			animator.SetBool ("isDisappearing", true);
			//GameManager.score += (int)(getDifficulty() * 50);
		}
		time += Time.deltaTime;

	}

	void pickDir() {
		dir = new Vector2 (Mathf.Round(Random.value) * 2 - 1, Mathf.Round(Random.value) * 2 - 1);
		if (dir.x < 0) {
			sr.flipX = true;
		} else {
			sr.flipX = false;
		}
		//Debug.Log (time);
	}
	public void goAway() {
		animator.SetBool ("isDisappearing2", true);
	}
	public void actuallyGoAway() {
		gameObject.transform.position = new Vector3 ((Random.Range (0, 1) * 2 - 1) * GameManager.mapSize.x / 2, (Random.Range (0, 1) * 2 - 1) * GameManager.mapSize.y / 2);
		animator.SetBool ("isDisappearing2", false);
	}
	public float getDifficulty() {
		float donutsize = outer - inner;
		return (speed > 0.75 ? 1 : 0) + (speed > 1 ? 1 : 0) + (speed > 1.25 ? 1 : 0) + (donutsize < 2.5 ? 1 : 0) + (donutsize < 2 ? 1 : 0) + (donutsize < 1.5 ? 1 : 0)
			+ (poseTime < 2.25 ? 1 : 0) + (poseTime < 2 ? 1 : 0) + (poseTime < 1.75 ? 1 : 0);
	}
	private void reincarnate() {
		transform.position = new Vector3 (Random.value * GameManager.mapSize.x - GameManager.mapSize.x / 2, Random.value * GameManager.mapSize.y - GameManager.mapSize.y / 2);
		float scale = (Random.value/1.5f - 0.33f) + 0.5f;
		transform.localScale = new Vector3 (scale, scale, 1);
		pickDir (); 
		outer = (float)Random.value + baseOuter - 0.5f;
		inner = (float)Random.value + baseInner - 0.5f;
		GameObject red = transform.Find ("red").gameObject;
		green.transform.localScale = new Vector3 (outer, outer, 1);
		red.transform.localScale = new Vector3 (inner, inner, 1);
		speed = (float)Random.value + baseSpeed - 0.5f;
		poseTime = (float)Random.value + basePoseTime - 0.5f;
		timesSnapped = 0;
		walkTime = (float)Random.value*4 + baseWalkTime - 2f;
		animator.SetBool ("isDisappearing2", false);
		animator.SetBool ("isPosing", false);
		animator.SetBool ("isDisappearing", false);
	}



	void playPoof() {
		
		SoundManager.instance.playPoof ();

	}
}
