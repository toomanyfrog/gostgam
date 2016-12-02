using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static int score = 0;
	public static int lives = 10;
	public float gameLength = 60;
	public static Vector2 mapSize = new Vector2(18, 18);

	public Text scoreText;

	private float time;

	// Use this for initialization
	void Start () {

		score = 0;
		lives = 10;
		GameObject background = GameObject.Find("Background");
		background.transform.localScale = new Vector3(mapSize.x/6, mapSize.y/6, 1);
	}
	
	// Update is called once per frame
	void Update () {

		scoreText.text = score.ToString();

	}
}
