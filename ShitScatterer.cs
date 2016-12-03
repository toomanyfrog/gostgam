using UnityEngine;
using System.Collections;

public class ShitScatterer : MonoBehaviour {

	public Sprite[] things;
	public int maximumThings = 10;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < maximumThings; i++) {

			int index = Mathf.RoundToInt (Random.value);

		}

	
	}

	// Update is called once per frame
	void Update () {


	
	}
}
