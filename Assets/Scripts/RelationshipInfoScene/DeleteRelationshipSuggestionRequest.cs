using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeleteRelationshipSuggestionRequest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void deleteLinkSuggestionRequest(String link_id,
		Action<String> deleteLinkSuggestionCallback)
	{
		string data = "{\"author\":\"" + DataHandler.UserId + "\",\"suggestion_type\":\"DELETE\",\"link_id\":\"" +
			link_id + "\"}";

		Debug.Log(data);
		Dictionary<string, string> header = new Dictionary<string, string>();
		header.Add("Content-Type", "application/json");
		header.Add("token", DataHandler.Token);
		var byteData = System.Text.UTF8Encoding.UTF8.GetBytes(data);
		WWW www = new WWW(DataHandler.serverIP + ": 3000 /secure/createlinksuggestion", byteData, header);
		StartCoroutine(waitForDeleteLinkSuggestionRequest(www, deleteLinkSuggestionCallback));
	}

	IEnumerator waitForDeleteLinkSuggestionRequest(WWW www, Action<String> deleteLinkSuggestionCallback)
	{
		yield return www;
		deleteLinkSuggestionCallback(www.error);
	}
}
