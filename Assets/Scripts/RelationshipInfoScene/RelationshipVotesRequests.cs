using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RelationshipVotesRequests : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void linkVoteRequest(String link_id, String vote,
		Action<String> voteLinkCallback)
	{
		string data = "{\"user_id\":\"" + DataHandler.UserId + "\",\"vote\":\"" + vote + "\",\"link_id\":\"" +
			link_id + "\"}";

		//   Debug.Log(data);
		Dictionary<string, string> header = new Dictionary<string, string>();
		header.Add("Content-Type", "application/json");
		header.Add("token", DataHandler.Token);
		var byteData = System.Text.UTF8Encoding.UTF8.GetBytes(data);
		WWW www = new WWW(DataHandler.serverIP + ": 3000 /secure/voteonlink", byteData, header);
		StartCoroutine(waitForVoteLinkRequest(www, voteLinkCallback));
	}

	IEnumerator waitForVoteLinkRequest(WWW www, Action<String> voteLinkCallback)
	{
		yield return www;
		voteLinkCallback(www.error);
	}
}
