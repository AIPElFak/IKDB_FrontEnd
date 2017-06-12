using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToNodeInfo : MonoBehaviour {

	public GameObject panelHolder;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void backToNodeInfo() {
		panelHolder.GetComponent<NodeInfoPanelHolderScript> ().nodeInfoPanel.SetActive (true);
		panelHolder.GetComponent<NodeInfoPanelHolderScript> ().addRelationshipPanel.SetActive (false);
	}
}
