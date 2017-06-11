using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToNodesList : MonoBehaviour {

	public GameObject panelHolder;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick() {
		panelHolder.GetComponent<PanelHolderScript2> ().addNodePanel.SetActive (false);
	}
}
