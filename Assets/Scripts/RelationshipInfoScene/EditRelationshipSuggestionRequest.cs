using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EditRelationshipSuggestionRequest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void editLinkSuggestionRequest(String link_id, String description,
		Action<String> editLinkSuggestionCallback)
	{
		string data = "{\"author\":\"" + DataHandler.UserId + "\",\"suggestion_type\":\"EDIT\",\"link_id\":\"" +
			link_id + "\"";
		if (description != null)
		{
			data += ",\"description\":\"" + description + "\"";
		}

		data += "}";

		Debug.Log(data);
		Dictionary<string, string> header = new Dictionary<string, string>();
		header.Add("Content-Type", "application/json");
		header.Add("token", DataHandler.Token);
		var byteData = System.Text.UTF8Encoding.UTF8.GetBytes(data);
		WWW www = new WWW(DataHandler.serverIP + ": 3000 /secure/createlinksuggestion", byteData, header);
		StartCoroutine(waitForEditLinkSuggestionRequest(www, editLinkSuggestionCallback));
	}

	IEnumerator waitForEditLinkSuggestionRequest(WWW www, Action<String> editLinkSuggestionCallback)
	{
		yield return www;
		editLinkSuggestionCallback(www.error);
	}
}
