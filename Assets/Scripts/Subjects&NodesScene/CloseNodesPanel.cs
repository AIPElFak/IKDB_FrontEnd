using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseNodesPanel : MonoBehaviour {

	public GameObject panelHolder;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void closeNodesPanel() {
		panelHolder.GetComponent<PanelHolderScript2> ().nodesPanel.SetActive (false);
	}
}
