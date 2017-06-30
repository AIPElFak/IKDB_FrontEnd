using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManagerScript : MonoBehaviour {

	public GameObject listController;
	SubjectsScrollList subjectsScrollList;
	//public GameObject panelHolder;
	//PanelHolderScript2 panelHolderScript;
	public Button addCategoryButton;
	public Button deleteCategoryButton;
	// Use this for initialization
	void Start () {
		subjectsScrollList = listController.GetComponent<SubjectsScrollList> ();
		subjectsScrollList.PopulateSubjectsList ();
		//panelHolderScript = panelHolder.GetComponent<PanelHolderScript2> ();
		//panelHolderScript.nodesPanel.SetActive (false);
//		deleteCategoryButton.gameObject.SetActive (true);
//		addCategoryButton.gameObject.SetActive (true);
		if (DataHandler.SelectedSubjects.Count > 0) {
			deleteCategoryButton.gameObject.SetActive (false);
			addCategoryButton.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
