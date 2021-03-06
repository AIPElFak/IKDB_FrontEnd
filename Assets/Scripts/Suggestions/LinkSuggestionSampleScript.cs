﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkSuggestionSampleScript : MonoBehaviour {

	public Button button;
	public Text startNodeLabel;
	public Text endNodeLabel;
	public Text typeLabel;
	public GameObject panel;
	public LinkSuggestion linkSuggestion;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void onClick()
	{
		DataHandler.SelectedLinkSuggestion = linkSuggestion;
		/* SuggestionsScenePanelHolderScript.suggestionsPanel.gameObject.SetActive(false);
		SuggestionsScenePanelHolderScript.listWithSuggestionsPanel.gameObject.SetActive(false);
		SuggestionsScenePanelHolderScript.linkSuggestionInfoPanel.gameObject.SetActive(true); */
		GameObject panelHolder = GameObject.Find ("SuggestionScenePanelHolder");
		SuggestionsScenePanelHolderScript phs = panelHolder.GetComponent<SuggestionsScenePanelHolderScript>();
		phs.suggestionsPanel.SetActive (false);
		phs.listWithSuggestionsPanel.SetActive (false);
		phs.linkSuggestionInfoPanel.SetActive (true);
		GameObject infoLoader = GameObject.Find ("InfoLoaderObject");
		LoadLinkSuggestionInfo llsi = infoLoader.GetComponent<LoadLinkSuggestionInfo> ();
		llsi.populateFields ();
	}

}
