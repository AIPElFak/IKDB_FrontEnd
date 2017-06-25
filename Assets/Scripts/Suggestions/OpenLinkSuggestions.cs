using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLinkSuggestions : MonoBehaviour {

	public GameObject serverRequest;
	GetAllLinkSuggestionsRequest serverRequestScript;
	public GameObject listControler;
	LinkSuggestionsList linkSuggestionListScript;
	public GameObject panelHolder;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick()
	{
		//  serverRequest = GameObject.Find("ServerRequest");
		serverRequestScript = serverRequest.GetComponent<GetAllLinkSuggestionsRequest>();
		//PanelHolderScript.suggestionsListPanel.gameObject.SetActive(true);
		// scrollListControl = GameObject.Find("ScrollListControl");
		serverRequestScript.linkSuggestionsRequest(onClickCallback);

	}

	public void onClickCallback(List<LinkSuggestion> linkSuggestions)
	{
		DataHandler.AllLinkSuggestions = linkSuggestions;
		linkSuggestionListScript = listControler.GetComponent<LinkSuggestionsList> ();
		linkSuggestionListScript.clearLinkSuggestionsList ();
		linkSuggestionListScript.populateLinkSuggestionsList ();
//		SuggestionsScenePanelHolderScript.listWithSuggestionsPanel.SetActive (true);
		SuggestionsScenePanelHolderScript phs = panelHolder.GetComponent<SuggestionsScenePanelHolderScript>();
		phs.listWithSuggestionsPanel.SetActive (true);

	}
}
