using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5;


	private Animator anim;
	private SpriteRenderer sr;
	private bool isFlipped;

	// Use this for initialization
	void Start () {

		anim = this.GetComponent<Animator> ();
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



			} else {

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
