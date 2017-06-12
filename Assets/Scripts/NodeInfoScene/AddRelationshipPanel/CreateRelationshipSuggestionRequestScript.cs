using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CreateRelationshipSuggestionRequestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
	public void createLinkSuggestionRequest(String node_from, String node_to, String description,
		String type, Action<String> createLinkSuggestionCallback)
	{
		string data = "{\"author\":\"" + DataHandler.UserId + "\",\"suggestion_type\":\"CREATE\",\"node_from\":\"" +
			node_from + "\",\"node_to\":\"" + node_to + "\"";
		if (type != null)
		{
			data += ",\"type\":\"" + type + "\"";
		}
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
		StartCoroutine(waitForCreateLinkSuggestionRequest(www, createLinkSuggestionCallback));
	}

	IEnumerator waitForCreateLinkSuggestionRequest(WWW www, Action<String> createLinkSuggestionCallback)
	{
		yield return www;
		createLinkSuggestionCallback(www.error);
	}
}
