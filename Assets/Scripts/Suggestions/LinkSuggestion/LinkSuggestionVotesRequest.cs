using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LinkSuggestionVotesRequest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void linkSuggestionVoteRequest(String link_id, String vote,
		Action<String> voteLinkSuggestionCallback)
	{
		string data = "{\"user_id\":\"" + DataHandler.UserId + "\",\"suggestion_type\":\"LINK\",\"vote\":\"" + vote + "\",\"suggestion_id\":\"" +
			link_id + "\"}";

		//   Debug.Log(data);
		Dictionary<string, string> header = new Dictionary<string, string>();
		header.Add("Content-Type", "application/json");
		header.Add("token", DataHandler.Token);
		var byteData = System.Text.UTF8Encoding.UTF8.GetBytes(data);
		WWW www = new WWW(DataHandler.serverIP + ": 3000 /secure/voteonsuggestion", byteData, header);
		StartCoroutine(waitForVoteLinkSuggestionRequest(www, voteLinkSuggestionCallback));
	}

	IEnumerator waitForVoteLinkSuggestionRequest(WWW www, Action<String> voteLinkSuggestionCallback)
	{
		yield return www;
		voteLinkSuggestionCallback(www.error);
	}
}
