using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSignUpPanelScript : MonoBehaviour {

	public GameObject panelHolder;
	PanelHolderScript panelHolderScript;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void closeSignupPanel() {
		panelHolderScript = panelHolder.GetComponent<PanelHolderScript> ();
		panelHolderScript.signupPanel.SetActive (false);
		panelHolderScript.loginPanel.SetActive (true);
	}
}
