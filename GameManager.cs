using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static int score = 0;
	public static int lives = 10;

	public GameObject overlay;

	public float gameLength = 60;
	public static Vector2 mapSize = new Vector2(50, 50);

	public Text scoreText;
	public Text livesText;
	public Text finalScoreText;
	public Text finalScore;

	private bool isGameOver;
	private float time;

	private string keepText;

	// Use this for initialization
	void Start () {

		isGameOver = false;
		score = 0;
		lives = 10;
		GameObject background = GameObject.Find("Background");
		background.transform.localScale = new Vector3(mapSize.x/6, mapSize.y/6, 1);
		overlay.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 0.0f);
		keepText = finalScoreText.text;
		finalScore.text = "";
		finalScoreText.text = "";

	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD

		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			lives -= 1;
		}


		scoreText.text = score.ToString ();
		livesText.text = lives.ToString ();

		if (lives <= 0 && !isGameOver) { // game over
=======

		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			lives -= 1;
		}


		scoreText.text = score.ToString ();
		livesText.text = lives.ToString ();

		if (lives <= 0 && !isGameOver) { // game over

>>>>>>> 656d77208a79554d79007f00efbef2f63123e4e0
			isGameOver = true;
			scoreText.text = "";
			livesText.text = "";
			finalScore.text = score.ToString();
			finalScoreText.text = keepText;
			overlay.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 0.5f);
<<<<<<< HEAD
			PlayerPrefs.SetInt ("Last Score", score);
=======
>>>>>>> 656d77208a79554d79007f00efbef2f63123e4e0

		}

		if (isGameOver) {
			if (Input.GetButtonDown ("Snap")) {
				SceneManager.LoadScene ("main");
			}
			if (Input.GetButtonDown ("RT")) {
				SceneManager.LoadScene ("menu");
			}
		} 
			


	}
}
