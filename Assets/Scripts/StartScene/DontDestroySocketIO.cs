using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroySocketIO : MonoBehaviour {

	public GameObject socetIOObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Awake() {
		DontDestroyOnLoad (socetIOObject);
	}
}
