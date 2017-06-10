using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VoteNodeServerRequests : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void nodeVoteRequest(String node_id, String vote ,
		Action<String> voteNodeCallback)
	{
		string data = "{\"user_id\":\"" + DataHandler.UserId + "\",\"vote\":\"" + vote + "\",\"node_id\":\"" +
			node_id + "\"}";

		//   Debug.Log(data);
		Dictionary<string, string> header = new Dictionary<string, string>();
		header.Add("Content-Type", "application/json");
		header.Add("token", DataHandler.Token);
		var byteData = System.Text.UTF8Encoding.UTF8.GetBytes(data);
		WWW www = new WWW(DataHandler.serverIP + ": 3000 /secure/voteonnode", byteData, header);
		StartCoroutine(waitForVoteNodeRequest(www, voteNodeCallback));
	}

	IEnumerator waitForVoteNodeRequest(WWW www, Action<String> voteNodeCallback)
	{
		yield return www;
		voteNodeCallback(www.error);
	}

}
