using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMesh : MonoBehaviour {
	public float width = 20;
	public float height = 40;

	public float angle = 2*Mathf.PI/3;
	public float divisions = 80;
	public float innerRadius = 5;
	public float outerRadius = 10;
	public Vector3 center = new Vector3 (0, 0, 0);

	public float z = 10;


	void Start() {
		Vector3[] newVertices =  new Vector3[] {
			new Vector3(0, 0, 10.01f),
			new Vector3(width, 0, 10.01f),
			new Vector3(0, height, 10.01f),
			new Vector3(width, height, 10.01f)
		};
			
		Vector2[] newUV = new Vector2[] {
			new Vector2 (0, 0),
			new Vector2 (1, 0),
			new Vector2(0, 1),
			new Vector2 (1, 1)
		};
		int[] newTriangles =  new int[] { 0, 2, 1, 2, 3, 1}; // must be clockwise triangles

		List<Vector2> verts2d = new List<Vector2>();
		List<int> triangles = new List<int> ();
		float meter = 0;
		int vertcount = 0;
		while (meter < angle) {
			float increment = angle / divisions;
			Vector2 ov = new Vector2 (center.x + outerRadius*Mathf.Sin(increment), center.y + outerRadius*Mathf.Cos(increment));
			Vector2 iv = new Vector2 (center.x + innerRadius*Mathf.Sin(increment), center.y + innerRadius*Mathf.Cos(increment));

			verts2d.Add(ov);
			verts2d.Add(iv);
			if (vertcount % 2 == 0 && vertcount > 0) {
				triangles.Add (vertcount - 2);
				triangles.Add (vertcount);
				triangles.Add (vertcount - 1);
			} else if (vertcount % 2 == 1 && vertcount > 1) {
				triangles.Add (vertcount - 2);
				triangles.Add (vertcount - 1);
				triangles.Add (vertcount);
			}
			meter += increment;
			vertcount += 1;
		}
		Vector2[] verts2 = new Vector2[verts2d.Count];
		Vector3[] verts3 = new Vector3[verts2d.Count];
		for (int i =0 ; i < verts2d.Count; i++) {
			verts2 [i] = new Vector2 (verts2d [i].x, verts2d [i].y);
			verts3 [i] = new Vector3 (verts2d [i].x, verts2d [i].y, z);
		}
		int[] triangs = new int[triangles.Count];
		for (int j = 0; j < triangles.Count; j++) {
			triangs [j] = triangles [j];
		}

		Triangulator tr = new Triangulator(verts2);
		int[] indices = tr.Triangulate();
	

		Mesh mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		Debug.Log (verts3.Length);
		Debug.Log (triangs.Length);
		mesh.vertices = verts3;
		mesh.triangles = triangs;

	}
	// Update is called once per frame
	void Update () {
		
	}
}


