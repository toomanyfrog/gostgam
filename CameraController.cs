 using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float xMin, xMax, yMin, yMax;

	private Vector3 offset;


	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (0, 0, -10);
		xMin = 9 - GameManager.mapSize.x / 2;
		xMax = GameManager.mapSize.x / 2 - 9;
		yMin = 9 - GameManager.mapSize.y / 2;
		yMax = GameManager.mapSize.y / 2 - 9;
		offset = transform.position - player.transform.position;
	}

	void LateUpdate () {

		Vector3 newPos = player.transform.position + offset;

		this.transform.position = new Vector3 (Mathf.Clamp(newPos.x, xMin, xMax),
			Mathf.Clamp(newPos.y, yMin, yMax),
			newPos.z);

	}
}
