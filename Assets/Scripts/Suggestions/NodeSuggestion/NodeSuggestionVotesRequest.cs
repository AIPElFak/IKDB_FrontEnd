using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NodeSuggestionVotesRequest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void nodeSuggestionVoteRequest(String node_id, String vote,
		Action<String> voteNodeSuggestionCallback)
	{
		string data = "{\"user_id\":\"" + DataHandler.UserId + "\",\"suggestion_type\":\"NODE\",\"vote\":\"" + vote + "\",\"suggestion_id\":\"" +
			node_id + "\"}";

		Debug.Log(data);
		Dictionary<string, string> header = new Dictionary<string, string>();
		header.Add("Content-Type", "application/json");
		header.Add("token", DataHandler.Token);
		var byteData = System.Text.UTF8Encoding.UTF8.GetBytes(data);
		WWW www = new WWW(DataHandler.serverIP + ": 3000 /secure/voteonsuggestion", byteData, header);
		StartCoroutine(waitForVoteNodeSuggestionRequest(www, voteNodeSuggestionCallback));
	}

	IEnumerator waitForVoteNodeSuggestionRequest(WWW www, Action<String> voteNodeSuggestionCallback)
	{
		yield return www;
		voteNodeSuggestionCallback(www.error);
	}
}
