using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterButtonScript : MonoBehaviour {

	//public PanelHolderScript panelHolderScript;
	public GameObject panelHolder;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void openRegisterForm() {
		PanelHolderScript phs = panelHolder.GetComponent<PanelHolderScript> ();
		phs.signupPanel.gameObject.SetActive (true);
		phs.loginPanel.gameObject.SetActive (false);
	}
}
