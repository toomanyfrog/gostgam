using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5;

	private float speedMult = 10;


	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {

		float moveHorz = Input.GetAxis ("Horizontal");
		float moveVert = Input.GetAxis ("Vertical");


		Vector2 movement = new Vector2 (moveHorz, moveVert);

		transform.Translate (movement * speed * Time.deltaTime);

		Debug.Log (moveHorz + ", " + moveVert);

		

	}
}
