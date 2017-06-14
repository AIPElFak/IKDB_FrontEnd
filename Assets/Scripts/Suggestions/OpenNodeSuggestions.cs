using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNodeSuggestions : MonoBehaviour {

	public GameObject serverRequest;
	GetAllNodeSuggestionsRequest serverRequestScript;
	public GameObject listControler;
	NodeSuggestionsList nodeSuggestionListScript;

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
		if(!SuggestionsScenePanelHolderScript.listWithSuggestionsPanel.activeSelf)
		SuggestionsScenePanelHolderScript.listWithSuggestionsPanel.SetActive (true);
	}
}
