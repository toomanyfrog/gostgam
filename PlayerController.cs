using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5;

	private Vector2 size;

	private Animator anim;

	// Use this for initialization
	void Start () {
		transform.position = new Vector2 (0, 0);

		anim = this.GetComponent<Animator> ();
		size = new Vector2 (gameObject.transform.localScale.x, gameObject.transform.localScale.y);

	}

	// Update is called once per frame
	void Update () {

		float moveHorz = Input.GetAxis ("Horizontal");
		float moveVert = Input.GetAxis ("Vertical");


		if (Mathf.Abs (moveHorz) > Mathf.Abs (moveVert)) {

			anim.SetBool ("isSideWalking", true);

			if (moveHorz > 0) { // face right

				transform.localScale = new Vector2 (-1*size.x, size.y);
				//moveHorz = -moveHorz;

			} else { // face left
				transform.localScale = new Vector2 (size.x, size.y);

			}

		} else {

			transform.localScale = new Vector2 (size.x, size.y);
			anim.SetBool ("isSideWalking", false);

		}


		Vector2 movement = new Vector2 (moveHorz, moveVert);

		if (Input.GetAxis ("Snap") == 1) { // taking photo
		} else {
			transform.Translate (movement * speed * Time.deltaTime);
		}

	}


}
