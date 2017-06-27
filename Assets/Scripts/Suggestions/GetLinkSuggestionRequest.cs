using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LitJson;

public class GetLinkSuggestionRequest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void linkSuggestionsRequest(string id,Action<LinkSuggestion> linkSuggestionCallback)
	{
		Dictionary<string, string> header = new Dictionary<string, string>();
		header.Add("token", DataHandler.Token);
		WWW www = new WWW(DataHandler.serverIP + ": 3000 /secure/getlinksuggestions/"+id, null, header);
		StartCoroutine(waitForLinkSuggestion(www, linkSuggestionCallback));
	}

	IEnumerator waitForLinkSuggestion(WWW www, Action<LinkSuggestion> linkSuggestionCallback)
	{
		yield return www;
		LinkSuggestion linkSuggestion = JsonMapper.ToObject<LinkSuggestion>(www.text);
		linkSuggestionCallback(linkSuggestion);
	}
}
