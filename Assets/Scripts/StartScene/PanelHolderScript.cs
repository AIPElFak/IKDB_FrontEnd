using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHolderScript : MonoBehaviour {

	public GameObject loginPanel;
	public GameObject signupPanel;
	// Use this for initialization
	void Start () {
		signupPanel.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
