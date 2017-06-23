using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour {

	public GameObject textHolder;
 	TextMesh textMesh;
	// Use this for initialization
	void Start () {
		textMesh = textHolder.GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
