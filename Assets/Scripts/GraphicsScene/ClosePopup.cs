using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePopup : MonoBehaviour {

	private GameObject popup;
	public GameObject Popup {
		get {
			return popup;
		}
		set {
			popup = value;
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick()
	{
		DataHandler.SelectedPopup.SetActive (false);
	}
}
