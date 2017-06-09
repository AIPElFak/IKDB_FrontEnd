using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchByCategoriesScript : MonoBehaviour {

	public List<Node> nodes;
	GetNodesServerRequestScript getNodesServerRequestScript;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void onClickSearch()
	{
		// Debug.Log("Click");
		getNodesServerRequestScript.categoriesNodeRequest(SelectedSubjectsClass.SelectedSubjects, clickCallback);

	//	createScrollList.clearNodeList();

	}

	public void clickCallback(List<Node> array)
	{
		nodes = array;
		if(array==null)
		{
			Debug.Log("Nema cvorova za prikaz");
			return;
		}
		//CreateScrollList createScrollList = scrollListController.GetComponent<CreateScrollList>();

//		createScrollList.nodeList = array;
//		createScrollList.populateNodeList();
	}
}
