using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkSuggestionsList : MonoBehaviour {

	public GameObject sampleLinkSuggestion;
	public Transform linkSuggestionsPanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void populateLinkSuggestionsList()
	{
		if (DataHandler.AllLinkSuggestions.Count > 0)
		{
			foreach (LinkSuggestion ls in DataHandler.AllLinkSuggestions)
			{
				GameObject newLinkSuggestion = Instantiate(sampleLinkSuggestion) as GameObject;
				LinkSuggestionSampleScript linkSuggestionSampleScript = newLinkSuggestion.GetComponent<LinkSuggestionSampleScript>();
				linkSuggestionSampleScript.startNodeLabel.text = ls.start_name;
				linkSuggestionSampleScript.endNodeLabel.text = ls.end_name;
				linkSuggestionSampleScript.typeLabel.text = ls.suggestion_type;
				newLinkSuggestion.transform.SetParent(linkSuggestionsPanel);
				linkSuggestionSampleScript.linkSuggestion = ls;
			}
		}
		else
		{
			//EditorUtility.DisplayDialog("No relationships suggestions ", "There is currently no relationships suggestions", "Ok");
			Debug.Log("no relationship suggestions");
		}
	}
	public void clearLinkSuggestionsList()
	{
		for (var i = linkSuggestionsPanel.transform.childCount - 1; i >= 0; i--)
		{
			var child = linkSuggestionsPanel.transform.GetChild(i);
			child.transform.parent = null;
			Destroy(child.gameObject);
		}
		//linkSuggestions = null;
		//  populateNodeList();
	}
}
