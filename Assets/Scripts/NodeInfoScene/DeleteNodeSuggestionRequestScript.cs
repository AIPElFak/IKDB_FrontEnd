using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeleteNodeSuggestionRequestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void deleteNodeSuggestionRequest(String node_id,
		Action<String> deleteNodeSuggestionCallback)
	{
		string data = "{\"author\":\"" + DataHandler.UserId + "\",\"suggestion_type\":\"DELETE\",\"node_id\":\"" +
			node_id + "\"}";

		Debug.Log(data);
		Dictionary<string, string> header = new Dictionary<string, string>();
		header.Add("Content-Type", "application/json");
		header.Add("token", DataHandler.Token);
		var byteData = System.Text.UTF8Encoding.UTF8.GetBytes(data);
		WWW www = new WWW(DataHandler.serverIP + ": 3000 /secure/createnodesuggestion", byteData, header);
		StartCoroutine(waitForDeleteNodeSuggestionRequest(www, deleteNodeSuggestionCallback));
	}

	IEnumerator waitForDeleteNodeSuggestionRequest(WWW www, Action<String> deleteNodeSuggestionCallback)
	{
		yield return www;
		deleteNodeSuggestionCallback(www.error);
	}

}
