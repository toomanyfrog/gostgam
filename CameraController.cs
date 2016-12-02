using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float xMin, xMax, yMin, yMax;

	private Vector3 offset;


	// Use this for initialization
	void Start () {

		offset = transform.position - player.transform.position;
	
	}

	void LateUpdate () {

		Vector3 newPos = player.transform.position + offset;

		this.transform.position = new Vector3 (Mathf.Clamp(newPos.x, xMin, xMax),
			Mathf.Clamp(newPos.y, yMin, yMax),
			newPos.z);

	}
}
