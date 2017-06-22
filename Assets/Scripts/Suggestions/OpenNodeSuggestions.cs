using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNodeSuggestions : MonoBehaviour {

	public GameObject serverRequest;
	GetAllNodeSuggestionsRequest serverRequestScript;
	public GameObject listControler;
	NodeSuggestionsList nodeSuggestionListScript;
	public GameObject panelHolder;
	SuggestionsScenePanelHolderScript phs;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void onClick()
	{
		//  serverRequest = GameObject.Find("ServerRequest");
		serverRequestScript = serverRequest.GetComponent<GetAllNodeSuggestionsRequest>();
		//PanelHolderScript.suggestionsListPanel.gameObject.SetActive(true);
		// scrollListControl = GameObject.Find("ScrollListControl");
		serverRequestScript.nodeSuggestionsRequest(onClickCallback);

	}

	public void onClickCallback(List<NodeSuggestion> nodeSuggestions)
	{
		DataHandler.AllNodeSuggestions = nodeSuggestions;
		nodeSuggestionListScript = listControler.GetComponent<NodeSuggestionsList> ();
		nodeSuggestionListScript.populateNodeSuggestionsList ();
//		SuggestionsScenePanelHolderScript.listWithSuggestionsPanel.SetActive (true);
		phs = panelHolder.GetComponent<SuggestionsScenePanelHolderScript>();
		phs.listWithSuggestionsPanel.SetActive (true);
	}
}
