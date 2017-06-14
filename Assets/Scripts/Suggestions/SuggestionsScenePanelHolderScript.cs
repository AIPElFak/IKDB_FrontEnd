using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuggestionsScenePanelHolderScript : MonoBehaviour {

	public static GameObject listWithSuggestionsPanel;
	public static GameObject suggestionsPanel;
	public static GameObject linkSuggestionInfoPanel;
	public static GameObject nodeSuggestionInfoPanel;

	// Use this for initialization
	void Start () {
		listWithSuggestionsPanel = GameObject.Find ("ListWithSuggestionsPanel");
		suggestionsPanel = GameObject.Find ("SuggestionsPanel");
		linkSuggestionInfoPanel = GameObject.Find("linkSuggestionInfoPanel");
		nodeSuggestionInfoPanel = GameObject.Find ("nodeSuggestionInfoPanel");

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
