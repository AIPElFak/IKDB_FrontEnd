﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Graphics : MonoBehaviour {

	public GameObject sphere;

	// Use this for initialization
	void Start () {
		
		//GameObject mainNode = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		GameObject mainNode = Instantiate(sphere) as GameObject;
		SphereScript mainSphereScript = mainNode.GetComponent<SphereScript> ();
		mainSphereScript.textHolder.GetComponent<TextMesh> ().text = DataHandler.SelectedNrds.node.name;
		Vector3 v3Start = new Vector3 (0, 0, -4);
		Vector3 v3End;
		mainNode.transform.position = new Vector3 (0, 0, -4);
//		mainNode.tag = DataHandler.SelectedNrds.node.name;
		// Camera.main.ScreenToWorldPoint( Vector3(Screen.width/2, Screen.height/2, Camera.main.nearClipPlane) );
		//mainNode.transform.localScale += new  Vector3 (1.0f, 1.0f, 1.0f);

		GameObject s;
		GameObject link;
		//Debug.Log(relationship.Length);
		int circleCount = DataHandler.SelectedNrds.relationships.Count;
		float r = mainNode.GetComponent<SphereCollider> ().radius;
		float largeCircleR = 4 * r;
		int circlesDone = 0;
		float offset = 0;
		int level = 0;

		while (circlesDone < circleCount) {
			float toDrawHere = Mathf.Round(largeCircleR * 3.1416F / (2 * r));
			if (toDrawHere > circleCount - circlesDone)
				toDrawHere = circleCount - circlesDone;

			for (int i = 0; i < toDrawHere; i++) {
				float circleX = largeCircleR * Mathf.Cos (offset + 2 * Mathf.PI * i / toDrawHere);
				float circleY = largeCircleR * Mathf.Sin (offset + 2 * Mathf.PI * i / toDrawHere);
				s = Instantiate(sphere) as GameObject;
				SphereScript nodeSphereScript = s.GetComponent<SphereScript> ();
				nodeSphereScript.textHolder.GetComponent<TextMesh> ().text = DataHandler.SelectedNrds.relationships[circlesDone].end_name;
				v3End = new Vector3 (circleX,circleY,4*level);
				s.transform.position = v3End;
				//Gizmos.color = Color.blue;
				//Gizmos.DrawLine(startVector, endVector);
				GameObject line = new GameObject ();
				line.AddComponent<LineRenderer> ();
				LineRenderer lineRenderer = line.GetComponent<LineRenderer> ();
				lineRenderer.SetPosition (0, v3Start);
				lineRenderer.SetPosition (1, v3End);
				lineRenderer.SetWidth (0.1f, 0.1f);

				circlesDone++;

			}
			level++;
			largeCircleR += 5 * r;
			offset += Mathf.Asin ((3F * r) / largeCircleR);
		}
		

	
	}
	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Physics.Raycast (ray, out hit);
			if (hit.collider!=null) {
				Debug.Log (hit.transform.name);

			}
			else
				Debug.Log ("You haven't clicked on node");

		}

	}

	public void onClick() {
		

	}
}