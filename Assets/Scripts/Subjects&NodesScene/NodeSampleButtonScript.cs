using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NodeSampleButtonScript : MonoBehaviour {

	public Text nameLabel;
	public Node node;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onNodeClick()
	{

		//  string[] relationship = { "1", "2", "3", "4" };
		GameObject serverRequester = GameObject.Find("ServerRequester");
		GetNodeInforServerRequestScript getNodeInforServerRequestScript = serverRequester.GetComponent<GetNodeInforServerRequestScript> ();
		getNodeInforServerRequestScript.nodeInformationRequest (node._id, onNodeClickCallback);
//		serverRequestScript.nodeInformationRequest(node._id, onNodeClickCallback);

	}

	public void onNodeClickCallback(NodeRelationshipDataSet nrds)
	{
		// za ovo napravi u DataHandler script jedan Node(singleton moze) koji ce da cuva selektovani Node i
		// i sve info za njega
		DataHandler.SelectedNrds=nrds;
		SceneManager.LoadScene ("NodeInfoScene");

	/*	Text nodeNameText = GameObject.Find("nodeNameText").GetComponent<Text>();
		nodeNameText.text = node.name;
		Text nodeDefinitonText = GameObject.Find("nodeDefinitionText").GetComponent<Text>();
		nodeDefinitonText.text = node.definition;
		Text nodeDescriptionText = GameObject.Find("nodeDescriptionText").GetComponent<Text>();
		nodeDescriptionText.text = node.description;
		Text votesForText = GameObject.Find("votesForNodeLabel").GetComponent<Text>();
		if (node.votes_for!=null)
			votesForText.text = node.votes_for.Count.ToString() ;
		Text votesAgainstText = GameObject.Find("votesAgainstNodeLabel").GetComponent<Text>();
		if(node.votes_against !=null)
			votesAgainstText.text = node.votes_against.Count.ToString();
		Dropdown typesDropdown = GameObject.Find("nodeInfoPanelTypesDropdown").GetComponent<Dropdown>();
		typesDropdown.ClearOptions();
		typesDropdown.AddOptions(node.labels);

		CreateScrollList createSL = scrollListController.GetComponent<CreateScrollList>();
		createSL.relationshipsList = relatioships;
		createSL.populateRelationshipList();
		NodeVotesScript.node = node;
		DeleteNode.node = node;
		AddNewRelationshipScript.node = node;
		EditNodeButtonScript.node = node;    */

	}

}
