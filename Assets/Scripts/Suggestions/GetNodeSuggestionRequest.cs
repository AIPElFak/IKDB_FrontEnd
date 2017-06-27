using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LitJson;

public class GetNodeSuggestionRequest : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void nodekSuggestionsRequest(string id,Action<NodeSuggestion> nodeSuggestionCallback)
	{
		Debug.Log ("saljem req");
		Dictionary<string, string> header = new Dictionary<string, string>();
		header.Add("token", DataHandler.Token);
		WWW www = new WWW(DataHandler.serverIP + ":3000/secure/getnodesuggestions/"+id, null, header);
		StartCoroutine(waitForNodeSuggestion(www, nodeSuggestionCallback));
	}

	IEnumerator waitForNodeSuggestion(WWW www, Action<NodeSuggestion> nodeSuggestionCallback)
	{
		yield return www;
		NodeSuggestion nodeSuggestion = JsonMapper.ToObject<NodeSuggestion>(www.text);
		Debug.Log (www.text);
		nodeSuggestionCallback(nodeSuggestion);
	}
}
