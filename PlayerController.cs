using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public float speed = 5;

	private Vector2 size;

	private Animator animator;
	private SpriteRenderer sr;
	private bool isFlipped;

	// Use this for initialization
	void Start () {
		transform.position = new Vector2 (0, 0);
		animator = this.GetComponent<Animator> ();
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

			animator.SetBool ("isMoving", false);

		} else {
			
			animator.SetBool ("isMoving", true);

			// Check if moving horizontally more than moving vertically
			if (Mathf.Abs (moveHorz) - Mathf.Abs (moveVert) >= 0.1f) {

				if (moveHorz > 0) { // face right

					sr.flipX = true;

				}
				animator.SetBool ("isBackWalking", false);
				animator.SetBool ("isSideWalking", true);

			} else if (moveVert > 0) {
				
				sr.flipX = false;
				animator.SetBool ("isBackWalking", true);

			} else {

				sr.flipX = false;
				animator.SetBool ("isBackWalking", false);
				animator.SetBool ("isSideWalking", false);

			}
				
		}


		Vector2 movement = new Vector2 (moveHorz, moveVert);

		if (Input.GetButton("Snap")) { // taking photo
			
			sr.flipX = false;
			animator.SetBool ("isSnapping", true);

		} else {

			animator.SetBool ("isSnapping", false);
			transform.Translate (movement * speed * Time.deltaTime);
		}

	}


	// Animator related methods

	bool AnimatorIsPlaying(){
		return ( animator.GetCurrentAnimatorClipInfo (0).Length > animator.GetCurrentAnimatorStateInfo (0).normalizedTime ) ;
	}

	bool AnimatorIsPlaying(string stateName){
		return AnimatorIsPlaying() && animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
	}

	void playCameraClick() {

		SoundManager.instance.playCameraClick ();

	}

}
