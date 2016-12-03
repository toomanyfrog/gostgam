using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static int score = 0;
	public static int lives = 10;

	public GameObject overlay;

	public float gameLength = 60;
	public static Vector2 mapSize = new Vector2(30, 30);

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
		GameObject background = GameObject.Find("Plane");
		background.transform.localScale = new Vector3(mapSize.x/6, 1, mapSize.y/6);
		overlay.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 0.0f);
		keepText = finalScoreText.text;
		finalScore.text = "";
		finalScoreText.text = "";

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			lives -= 1;
		}

		if (!isGameOver) {
			scoreText.text = score.ToString ();
			livesText.text = lives.ToString ();
		}

		if (lives <= 0 && !isGameOver) { // game over

			isGameOver = true;
			scoreText.text = "";
			livesText.text = "";
			finalScore.text = score.ToString();
			finalScoreText.text = keepText;
			overlay.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 0.5f);


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
