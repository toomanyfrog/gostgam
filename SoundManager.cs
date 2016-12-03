using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;
	public AudioClip cameraClick;

	private AudioSource audSource;

	// Use this for initialization
	void Start () {
		instance = this;
		audSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playCameraClick() {

		audSource.clip = cameraClick;
		audSource.Play ();

	}

}
