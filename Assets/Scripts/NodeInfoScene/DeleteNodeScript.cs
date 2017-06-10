using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteNodeScript : MonoBehaviour {

	public GameObject serverReq;
	public DeleteNodeSuggestionRequestScript serverRequestScript;
	// Use this for initialization
	void Start()
	{
		serverRequestScript = serverReq.GetComponent<DeleteNodeSuggestionRequestScript>();
	}

	// Update is called once per frame
	void Update()
	{

	}
	public void deleteNodeClick()
	{

		serverRequestScript.deleteNodeSuggestionRequest(DataHandler.SelectedNrds.node._id.ToString(), deleteNodeCallback);
	}
	public void deleteNodeCallback(string s)
	{
		if (s != null)
		{
			//EditorUtility.DisplayDialog("Error", "An error occurred", "Ok");
			Debug.Log("An error occurred");
		}
		else
		{
			//EditorUtility.DisplayDialog("Success", "Success", "Ok");
			Debug.Log("Node delete suggestion send successfully");
		}
	}
}
