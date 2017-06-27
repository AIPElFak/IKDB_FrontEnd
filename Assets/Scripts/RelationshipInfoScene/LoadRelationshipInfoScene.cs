using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SocketIO;

public class LoadRelationshipInfoScene : MonoBehaviour {

	public Text relationshipDescText;
	public Text nodeFromText;
	public Text nodeToText;
	public Text relationshipTypeText;
	public string relationshipDescString;
	public string relationshipTypeString;
	public string relationshipNodeToString;
	public string relationshipNodeFromString;
	public bool start = true;
	public Text votesForText;
	public Text votesAgainstText;
	//public Relationship r;
	public GameObject serverRequest;
	//public ServerRequestScript serverRequestScript;
	public InputField inputFieldRelationshipDescription;
	SocketIOComponent socketIO;


	// Use this for initialization
	void Start () {
		socketIO = GameObject.Find ("SocketIO").GetComponent<SocketIOComponent> ();
		socketIO.On ("link-"+DataHandler.SelectedRelationship._id,onRelationshipEvent);
		populateRelationshipInfo ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void populateRelationshipInfo() {
		nodeFromText.text = DataHandler.SelectedRelationship.start_name.ToString ();
		nodeToText.text = DataHandler.SelectedRelationship.end_name.ToString ();
		relationshipTypeText.text = DataHandler.SelectedRelationship._type.ToString ();
		votesForText.text = DataHandler.SelectedRelationship.votes_for.Count.ToString ();
		votesAgainstText.text = DataHandler.SelectedRelationship.votes_against.Count.ToString ();
		relationshipDescText.text = DataHandler.SelectedRelationship.description;
	}

	public void onRelationshipEvent(SocketIOEvent sockerIOEvent) {
		RelationshipInfoRequestScript serverRequestScript = serverRequest.GetComponent<RelationshipInfoRequestScript> ();
		serverRequestScript.relationshipInformationRequest (DataHandler.SelectedRelationship._id, onRelationshipInfoCallback);
	}
	public void onRelationshipInfoCallback(Relationship r)
	{
		//nova scena se otvori (ili panel)
		DataHandler.SelectedRelationship = r;
		populateRelationshipInfo ();
	}
}
