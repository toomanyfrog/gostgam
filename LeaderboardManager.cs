using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LeaderboardManager : MonoBehaviour {

	public GameObject input;
	public Text inputText;
	public GameObject leaderboardText;

	private int lastScore, playerPlace;
	private bool promptName;
	// Use this for initialization
	void Start () {

		playerPlace = -1;
		promptName = false;

		lastScore = PlayerPrefs.GetInt ("lastScore");

		for (int i = 0; i < 5; i++) { // 0 - top score; 4- 5th highest

			if (lastScore > PlayerPrefs.GetInt ("score" + i)) {

				Debug.Log ("Player is now top " + (i+1).ToString());

				playerPlace = i;
				promptName = true;

				string oldName = PlayerPrefs.GetString ("name" + i);
				int oldScore = PlayerPrefs.GetInt ("score" + i);

				PlayerPrefs.SetInt ("score"+i, lastScore);

				for (int j = i+1; j < 5; j++) {

					string tempOldName = PlayerPrefs.GetString ("name" + j);
					int tempOldScore = PlayerPrefs.GetInt("score" + j);

					PlayerPrefs.SetString ("name" + j, oldName);
					PlayerPrefs.SetInt ("score" + j, oldScore);

					oldName = tempOldName;
					oldScore = tempOldScore;

				}

				break;

			}
		}

		PlayerPrefs.SetInt ("lastScore", 0);

		if (promptName) {

			input.SetActive (true);
			leaderboardText.SetActive (false);

		}

	}

	void Update () {
	
		if (input.activeSelf && inputText.text != "" && Input.GetButtonDown ("Snap")) {

			input.SetActive (false);
			PlayerPrefs.SetString ("name" + playerPlace, inputText.text.ToUpper());

		}

		if (Input.GetButtonDown ("RT")) {

			SceneManager.LoadScene ("menu");

		}

		updateLeaderboardText ();
	
	}

	void updateLeaderboardText() {

		leaderboardText.SetActive (true);

		string baseString = "1. {0} ---------- {1}\n2. {2} ---------- {3}\n3. {4} ---------- {5}\n4. {6} ---------- {7}\n5. {8} ---------- {9}";

		string formattedBase = string.Format(baseString,
			PlayerPrefs.GetString("name" + (int) 0),
			PlayerPrefs.GetInt("score0"),
			PlayerPrefs.GetString("name" + (int) 1),
			PlayerPrefs.GetInt("score1"),
			PlayerPrefs.GetString("name" + (int) 2),
			PlayerPrefs.GetInt("score2"),
			PlayerPrefs.GetString("name" + (int) 3),
			PlayerPrefs.GetInt("score3"),
			PlayerPrefs.GetString("name" + (int) 4),
			PlayerPrefs.GetInt("score4")
		);

		leaderboardText.GetComponent<Text> ().text = formattedBase;

	}

	void printTop5() {
		for (int i = 0; i < 5; i++) {

			Debug.Log (PlayerPrefs.GetString ("name" + i) + "    " + PlayerPrefs.GetInt ("score" + i));

		}
	}

	void overwriteTop5() {

		for (int i = 0; i < 5; i++) {

			PlayerPrefs.SetString ("name"+i, "AAA");
			PlayerPrefs.SetInt ("score"+i, 0);


		}

	}

}
