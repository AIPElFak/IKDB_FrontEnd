using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManagerScript : MonoBehaviour {

	public GameObject listController;
	SubjectsScrollList subjectsScrollList;
	//public GameObject panelHolder;
	//PanelHolderScript2 panelHolderScript;
	// Use this for initialization
	void Start () {
		subjectsScrollList = listController.GetComponent<SubjectsScrollList> ();
		subjectsScrollList.PopulateSubjectsList ();
		//panelHolderScript = panelHolder.GetComponent<PanelHolderScript2> ();
		//panelHolderScript.nodesPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
