using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static int score = 0;
	public static int lives = 10;
	public float gameLength = 60;

	public Text scoreText;
	public Text livesText;

	private float time;

	// Use this for initialization
	void Start () {

		score = 0;
		lives = 10;

	}
	
	// Update is called once per frame
	void Update () { 

		scoreText.text = score.ToString ();
		livesText.text = lives.ToString ();

		if (lives <= 0) {



		}

	}
}
