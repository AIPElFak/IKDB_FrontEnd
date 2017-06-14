using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System;

public class GetAllNodeSuggestionsRequest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void nodeSuggestionsRequest( Action<List<NodeSuggestion>> nodeSuggestionsCallback)
	{
		Dictionary<string, string> header = new Dictionary<string, string>();
		header.Add("token", DataHandler.Token);
		WWW www = new WWW(DataHandler.serverIP + ": 3000 /secure/getnodesuggestions/", null, header);
		StartCoroutine(waitForNodeSuggestions(www, nodeSuggestionsCallback));
	}

	IEnumerator waitForNodeSuggestions(WWW www, Action<List<NodeSuggestion>> nodeSuggestionsCallback)
	{
		yield return www;
		List<NodeSuggestion> nodeSuggestions = JsonMapper.ToObject<List<NodeSuggestion>>(www.text);
		nodeSuggestionsCallback(nodeSuggestions);
	}

}
