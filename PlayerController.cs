using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5;


	private Animator anim;

	// Use this for initialization
	void Start () {

		anim = this.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		float moveHorz = Input.GetAxis ("Horizontal");
		float moveVert = Input.GetAxis ("Vertical");


		if (Mathf.Abs (moveHorz) > Mathf.Abs (moveVert)) {

			anim.SetBool ("isSideWalking", true);

			if (moveHorz > 0) { // face right

				transform.localScale = new Vector2 (-1, 1);
				moveHorz = -moveHorz;

			} else { // face left
				
				transform.localScale = new Vector2 (1, 1);

			}

		} else {

			transform.localScale = new Vector2 (1, 1);
			anim.SetBool ("isSideWalking", false);

		}


		Vector2 movement = new Vector2 (moveHorz, moveVert);



		if (Input.GetAxis ("Snap") == 1) { // taking photo
		} else {
			transform.Translate (movement * speed * Time.deltaTime);
		}


	}


}
