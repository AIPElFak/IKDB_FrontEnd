using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeSuggestionSampleScript : MonoBehaviour {

	public Button button;
	public Text nameLabel;
	public Text typeLabel;
	public NodeSuggestion nodeSuggestion;
	public GameObject panel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void onClick()
	{
		DataHandler.SelectedNodeSuggestion = nodeSuggestion;
		/* SuggestionsScenePanelHolderScript.suggestionsPanel.gameObject.SetActive(false);
		SuggestionsScenePanelHolderScript.listWithSuggestionsPanel.gameObject.SetActive(false);
		SuggestionsScenePanelHolderScript.nodeSuggestionInfoPanel.gameObject.SetActive(true); */
		GameObject panelHolder = GameObject.Find ("SuggestionScenePanelHolder");
		SuggestionsScenePanelHolderScript phs = panelHolder.GetComponent<SuggestionsScenePanelHolderScript>();
		phs.suggestionsPanel.SetActive (false);
		phs.listWithSuggestionsPanel.SetActive (false);
		phs.nodeSuggestionInfoPanel.SetActive (true);
		GameObject infoLoader = GameObject.Find ("InfoLoaderObject");
		LoadNodeSuggestionInfo lnsi = infoLoader.GetComponent<LoadNodeSuggestionInfo> ();
		lnsi.populateFields ();
	}
}
