using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour {

	public GameObject[] buttons;
	public Sprite[] sprites;

	private float time;

	private int selected;

	void Start () {
	
		selected = 1;

	}
	
	void Update () {

		if (time > 0.2) {
			
			time = 0;

			if (Input.GetAxis ("UI Horz") > 0 && selected < 3) {
				selected++;
			}
			if (Input.GetAxis ("UI Horz") < 0 && selected > 0) {
				selected--;
			}

			for (int i = 0; i < 4; i++) {
				if (i == selected) {
					buttons [i].GetComponent<SpriteRenderer> ().sprite = sprites [i * 2 + 1];
				} else {
					buttons [i].GetComponent<SpriteRenderer> ().sprite = sprites [i * 2];
				}
			}

		} else {
			
		}
		time += Time.deltaTime;

		if (Input.GetButtonDown("Select")) {

			switch (selected) {


			default:
				SceneManager.LoadScene ("main");


			}

		}

	}
}
