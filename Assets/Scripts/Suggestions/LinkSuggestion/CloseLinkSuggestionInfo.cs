using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseLinkSuggestionInfo : MonoBehaviour {

	public GameObject panelHolder;
	SuggestionsScenePanelHolderScript script;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick() {
		script = panelHolder.GetComponent<SuggestionsScenePanelHolderScript> ();
		script.linkSuggestionInfoPanel.SetActive (false);
		script.suggestionsPanel.SetActive (true);
		script.listWithSuggestionsPanel.SetActive (true);
	}
}
