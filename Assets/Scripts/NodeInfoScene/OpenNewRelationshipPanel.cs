using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenNewRelationshipPanel : MonoBehaviour {

	public GameObject serverRequest;
	public Dropdown nodeToDropdown;
	GetAllNodesRequestScript serverRequestScript;
	public GameObject panelHolder;
	public Text nodeFromText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void onClick()
	{
		panelHolder.GetComponent<NodeInfoPanelHolderScript> ().addRelationshipPanel.SetActive (true);
		panelHolder.GetComponent<NodeInfoPanelHolderScript> ().nodeInfoPanel.SetActive (false);
		serverRequestScript = serverRequest.GetComponent<GetAllNodesRequestScript> ();
		serverRequestScript.getAllNodesRequest(onClickCallback);
		// Debug.Log("pozvao callback");
	}

	public void onClickCallback(List<Node> allNodes)
	{
		DataHandler.AllNodes = allNodes;
		// NodeToDropdownScript.populateInitial();
		List<string> stringNodes = new List<string>();
		foreach (Node n in allNodes)
		{
			stringNodes.Add(n.name);
		}
		nodeToDropdown.ClearOptions();
		nodeToDropdown.AddOptions(stringNodes);
		nodeFromText.text = DataHandler.SelectedNrds.node.name;

	}
}
