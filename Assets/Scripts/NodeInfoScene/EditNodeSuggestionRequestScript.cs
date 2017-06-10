using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class EditNodeSuggestionRequestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void editNodeSuggestionRequest(int node_id, String definition, String description,
		List<string> types, Action<String> editNodeSuggestionCallback)
	{
		string data = "{\"author\":\"" + DataHandler.UserId + "\",\"suggestion_type\":\"EDIT\",\"node_id\":\"" +
			node_id + "\"";
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
		StartCoroutine(waitForEditNodeSuggestionRequest(www, editNodeSuggestionCallback));
	}

	IEnumerator waitForEditNodeSuggestionRequest(WWW www, Action<String> editNodeSuggestionCallback)
	{
		yield return www;
		editNodeSuggestionCallback(www.error);
	}

}
