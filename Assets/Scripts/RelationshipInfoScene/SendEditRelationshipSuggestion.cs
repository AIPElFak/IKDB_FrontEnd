using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SendEditRelationshipSuggestion : MonoBehaviour {

	public GameObject serverRequest;
	EditRelationshipSuggestionRequest serverRequestScript;
	public Text relationshipDescText;
	public Text nodeFromText;
	public Text nodeToText;
	public Text relationshipTypeText;
	public Text votesForText;
	public Text votesAgainstText;
	public InputField inputFieldRelationshipDescription;
	public Button sendSuggestionButton;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void sendSuggestion() {
		if (!DataHandler.SelectedRelationship.description.Equals (this.inputFieldRelationshipDescription.text)) {
			serverRequestScript = serverRequest.GetComponent<EditRelationshipSuggestionRequest> ();
			serverRequestScript.editLinkSuggestionRequest (DataHandler.SelectedRelationship._id.ToString (), inputFieldRelationshipDescription.text, onEditLinkSuggestionClickCallback);
		} else {
			Debug.Log ("You haven't changed anything");
		}
			
		}

	public void onEditLinkSuggestionClickCallback(String s)
	{
		Debug.Log(s);
		if (s != null)
		{
			//EditorUtility.DisplayDialog("An error occured", s, "Ok");
			Debug.Log("Error");
		}
		else
		{
			//EditorUtility.DisplayDialog("Request successfully submitted", "Success!", "Ok");
			inputFieldRelationshipDescription.gameObject.SetActive (false);
			sendSuggestionButton.gameObject.SetActive (false);
			Debug.Log("Success");
		}
	}
}
