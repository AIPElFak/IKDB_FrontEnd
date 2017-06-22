using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAddNodePanel : MonoBehaviour {

	public GameObject panelHolder;
	PanelHolderScript2 panelHolderScript;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick() {
		panelHolderScript = panelHolder.GetComponent<PanelHolderScript2> ();
		panelHolderScript.addNodePanel.SetActive (true);
		panelHolderScript.subjectsPanel.SetActive (false);
		panelHolderScript.nodesPanel.SetActive (false);
	}
}
