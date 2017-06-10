using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SearchBarScript : MonoBehaviour {


	public InputField mainInputField;
	public GameObject nodesScrollListController;
	// Use this for initialization
	void Start () {

		//  mainInputField.onValueChange.AddListener(delegate { ValueChangeCheck(); });
	}

	// Update is called once per frame
	void Update () {

	}

	public void ValueChangeCheck()
	{
		NodesScrollList createScrollList = nodesScrollListController.GetComponent<NodesScrollList>();
		createScrollList.clearNodeList();
		List<Node> selectedNodesList = new List<Node>();
		foreach (Node n in SelectedNodesClass.SelectedNodes)
		{
			if (n.name.Contains(mainInputField.text))
			{
				selectedNodesList.Add(n);
			}
		}
		createScrollList.nodeList = selectedNodesList;
		if (selectedNodesList.Count > 0)
		{
			createScrollList.populateNodeList();
		}
		else
		{
			createScrollList.clearNodeList();
			Debug.Log("Search bar : Nema cvorova za prikaz");

		}
	}
}
