using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LitJson;

public class GetAllLinkSuggestionsRequest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void linkSuggestionsRequest(Action<List<LinkSuggestion>> linkSuggestionsCallback)
	{
		Dictionary<string, string> header = new Dictionary<string, string>();
		header.Add("token", DataHandler.Token);
		WWW www = new WWW(DataHandler.serverIP + ": 3000 /secure/getlinksuggestions/", null, header);
		StartCoroutine(waitForLinkSuggestions(www, linkSuggestionsCallback));
	}

	IEnumerator waitForLinkSuggestions(WWW www, Action<List<LinkSuggestion>> linkSuggestionsCallback)
	{
		yield return www;
		List<LinkSuggestion> linkSuggestions = JsonMapper.ToObject<List<LinkSuggestion>>(www.text);
		linkSuggestionsCallback(linkSuggestions);
	}
}
