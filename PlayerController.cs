using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5;

	private Vector2 size;

	private Animator anim;
	private SpriteRenderer sr;
	private bool isFlipped;

	// Use this for initialization
	void Start () {
		transform.position = new Vector2 (0, 0);

		anim = this.GetComponent<Animator> ();
		size = new Vector2 (gameObject.transform.localScale.x, gameObject.transform.localScale.y);
		sr = this.GetComponent<SpriteRenderer> ();
		sr.flipX = false;

	}

	// Update is called once per frame
	void Update () {

		sr.flipX = false;

		float moveHorz = Input.GetAxis ("Horizontal");
		float moveVert = Input.GetAxis ("Vertical");

		if (moveHorz == 0 && moveVert == 0) {

			anim.SetBool ("isMoving", false);

		} else {
			

			anim.SetBool ("isMoving", true);


			if (Mathf.Abs (moveHorz) - Mathf.Abs (moveVert) >= 0.1f) {

				if (moveHorz > 0) { // face right

					sr.flipX = true;

				}
				anim.SetBool ("isSideWalking", true);

				sr.flipX = false;
				anim.SetBool ("isSideWalking", false);

			}
				
		}


		Vector2 movement = new Vector2 (moveHorz, moveVert);
		Debug.Log (movement);

		if (Input.GetAxis ("Snap") == 1) { // taking photo


			sr.flipX = false;
			anim.SetBool ("isSnapping", true);

		} else {

			anim.SetBool ("isSnapping", false);
			transform.Translate (movement * speed * Time.deltaTime);
		}

	}

}
