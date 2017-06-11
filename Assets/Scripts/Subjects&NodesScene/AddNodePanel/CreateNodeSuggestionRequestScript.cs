using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CreateNodeSuggestionRequestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void createNodeSuggestionRequest(String name, String definition, String description,
		List<string> types, Action<String> createNodeSuggestionCallback)
	{
		Debug.Log("upao");
		Debug.Log(types[1]);
		string data = "{\"author\":\"" + DataHandler.UserId + "\",\"suggestion_type\":\"CREATE\",\"name\":\"" +
			name + "\"";
		if (definition != null)
		{
			data += ",\"definition\":\"" + definition + "\"";
		}
		if (description != null)
		{
			data += ",\"description\":\"" + description + "\"";
		}
		if (types != null && types.Count > 0)
		{
			data += ",\"types\":[";
			for (int i = 0; i <= types.Count - 1; i++)
			{
				if (i == 0)
				{
					data += "\"" + types[i] + "\"";
				}
				else
				{
					data += ",\"" + types[i] + "\"";
				}
			}
			data += "]";
		}
		data += "}";

		Debug.Log(data);
		Dictionary<string, string> header = new Dictionary<string, string>();
		header.Add("Content-Type", "application/json");
		header.Add("token", DataHandler.Token);
		var byteData = System.Text.UTF8Encoding.UTF8.GetBytes(data);
		WWW www = new WWW(DataHandler.serverIP + ": 3000 /secure/createnodesuggestion", byteData, header);
		StartCoroutine(waitForCreateNodeSuggestionRequest(www, createNodeSuggestionCallback));
	}

	IEnumerator waitForCreateNodeSuggestionRequest(WWW www, Action<String> createNodeSuggestionCallback)
	{
		yield return www;
		createNodeSuggestionCallback(www.error);
	}
}
