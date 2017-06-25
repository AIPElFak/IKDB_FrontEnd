using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchByCategoriesScript : MonoBehaviour {

	public static List<Node> nodes;
	GetNodesServerRequestScript getNodesServerRequestScript;
	public GameObject nodesScrollListController;
	public GameObject serverRequester;
	public GameObject panelHolder;
	public Button addCategoryButton;
	public Button deleteCategoryButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void onClickSearch()
	{
		// Debug.Log("Click");
		getNodesServerRequestScript = serverRequester.GetComponent<GetNodesServerRequestScript>();
		getNodesServerRequestScript.categoriesNodeRequest(DataHandler.SelectedSubjects, clickCallback);

	//	createScrollList.clearNodeList();

	}

	public void clickCallback(List<Node> array)
	{
		//nodes = array;
		SelectedNodesClass.SelectedNodes = array;

		if(array==null)
		{
			Debug.Log("Nema cvorova za prikaz");
			return;
		}
		panelHolder.GetComponent<PanelHolderScript2> ().nodesPanel.SetActive (true);
		NodesScrollList createScrollList = nodesScrollListController.GetComponent<NodesScrollList>();

		createScrollList.clearNodeList ();
		createScrollList.nodeList = array;
		createScrollList.populateNodeList();

		deleteCategoryButton.gameObject.SetActive (false);
		addCategoryButton.gameObject.SetActive (false);
	}
}
