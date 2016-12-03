using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {

	public GameObject[] buttons;
	public Sprite[] sprites;
	public GameObject polaroid;

	public GameObject creditsText, helpText, dismissText;

	private AudioSource audS;
	private float time;

	private Color pcolor;
	private int selected;

	private bool polaroidActive;


	void Start () {
	
		pcolor = polaroid.GetComponent<SpriteRenderer>().color;
		hidePolaroid ();
		audS = GetComponent<AudioSource> ();
		selected = 1;

	}
	
	void Update () {

		if (polaroidActive) {

			if (Input.GetButtonDown("RT")) {

				hidePolaroid();

			}


		} else {
			if (time > 0.2) {
			
				time = 0;

				if (Input.GetAxis ("UI Horz") > 0 && selected < 3) {
					audS.Play ();
					selected++;
				}
				if (Input.GetAxis ("UI Horz") < 0 && selected > 0) {
					audS.Play ();
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

			if (Input.GetButtonDown ("Select") || Input.GetButtonDown("Snap")) {

				switch (selected) {

				case 0: // credits
					showPolaroid ();
					creditsText.SetActive (true);
					break;

				case 1: // start
					SceneManager.LoadScene ("main");
					break;

				case 2: // help
					showPolaroid ();
					helpText.SetActive (true);
					break;

				default:
					SceneManager.LoadScene ("main");
					break;


				}

			}
		}

	}

	void showPolaroid() {

		polaroid.GetComponent<SpriteRenderer> ().color = pcolor;
		dismissText.SetActive (true);
		polaroidActive = true;

	}

	void hidePolaroid() {

		polaroid.GetComponent<SpriteRenderer> ().color = new Color (pcolor.r, pcolor.g, pcolor.b, 0.0f);
		creditsText.SetActive (false);
		helpText.SetActive (false);
		dismissText.SetActive (false);
		polaroidActive = false;

	}



}
