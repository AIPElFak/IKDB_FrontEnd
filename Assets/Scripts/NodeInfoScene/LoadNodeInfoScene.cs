using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

public class LoadNodeInfoScene : MonoBehaviour {

	public GameObject nodeName;
	public GameObject nodeDefiniton;
	public GameObject nodeDescription;
	public GameObject votesForNodeLabel;
	public GameObject votesAgainstNodeLabel;
	public GameObject types;
	private Node node;
	public GameObject panelHolder;
	public GameObject listController;
	public SocketIOComponent socketIO;
	public GameObject serverRequster;
	GetNodeInforServerRequestScript serverRequestScript;

	// Use this for initialization
	void Start() {
		
		populateNodeInfo ();
		socketIO = GameObject.Find ("SocketIO").GetComponent<SocketIOComponent>();
		socketIO.On ("node-" + DataHandler.SelectedNrds.node._id, OnNodeEvent);
		//CreateScrollList createSL = scrollListController.GetComponent<CreateScrollList>();
		//createSL.relationshipsList = relatioships;
		//createSL.populateRelationshipList();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void populateNodeInfo() {
		node = DataHandler.SelectedNrds.node;
		//node=DataHandler.SelctedNode;
		Text nodeNameText = nodeName.GetComponent<Text>();
		nodeNameText.text = node.name;
		Text nodeDefinitonText = nodeDefiniton.GetComponent<Text>();
		nodeDefinitonText.text = node.definition;
		Text nodeDescriptionText = nodeDescription.GetComponent<Text>();
		nodeDescriptionText.text = node.description;
		Text votesForText = votesForNodeLabel.GetComponent<Text>();
		if (node.votes_for!=null)
			votesForText.text = node.votes_for.Count.ToString() ;
		Text votesAgainstText = votesAgainstNodeLabel.GetComponent<Text>();
		if(node.votes_against !=null)
			votesAgainstText.text = node.votes_against.Count.ToString();
		Dropdown typesDropdown = types.GetComponent<Dropdown>();
		typesDropdown.ClearOptions();
		typesDropdown.AddOptions(node.labels);
		panelHolder.GetComponent<NodeInfoPanelHolderScript> ().nodeInfoPanel.SetActive (true);
		panelHolder.GetComponent<NodeInfoPanelHolderScript> ().addRelationshipPanel.SetActive (false);
		RelationshipListScript relationshipLisScript = listController.GetComponent<RelationshipListScript> ();
		relationshipLisScript.clearRelationshipsList ();
		relationshipLisScript.populateRelationshipList ();
	}

	public void OnNodeEvent(SocketIOEvent socketIOEvent) {
		Debug.Log ("onNodeEvent");
		serverRequestScript = serverRequster.GetComponent<GetNodeInforServerRequestScript> ();
		serverRequestScript.nodeInformationRequest (DataHandler.SelectedNrds.node._id, nodeInfoCallback);
	}

	public void nodeInfoCallback(NodeRelationshipDataSet nrds)
	{
		Debug.Log ("upao");
		DataHandler.SelectedNrds=nrds;
		populateNodeInfo ();
	}

}
