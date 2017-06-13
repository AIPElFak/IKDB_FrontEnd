using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteRelationshipButton : MonoBehaviour {

	public GameObject serverRequest;
	DeleteRelationshipSuggestionRequest serverRequestScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void deleteRelationshipClick()
	{

		serverRequestScript.deleteLinkSuggestionRequest(DataHandler.SelectedRelationship._id.ToString(), deleteRelationshipCallback);
	}
	public void deleteRelationshipCallback(string s)
	{
		if (s != null)
		{
			//EditorUtility.DisplayDialog("Error", "An error occurred", "Ok");
			Debug.Log("Error");
		}
		else
		{
			//EditorUtility.DisplayDialog("Success", "Success", "Ok");
			Debug.Log("Success");
		}
	}
}
