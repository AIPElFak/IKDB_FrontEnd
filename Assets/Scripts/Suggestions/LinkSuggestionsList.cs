using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class LinkSuggestionsList : MonoBehaviour {

	public GameObject sampleLinkSuggestion;
	public Transform linkSuggestionsPanel;
	public bool toListen = true;
	SocketIOComponent socketIO;
	public GameObject serverRequest;
	GetAllLinkSuggestionsRequest getAllLinkSuggestionsRequest;
	// Use this for initialization
	void Start () {
		toListen = true;
		socketIO = GameObject.Find ("SocketIO").GetComponent<SocketIOComponent> ();
		socketIO.On ("globalupdate", OnLinkSuggestionEvent);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void populateLinkSuggestionsList()
	{
		if (toListen) {
			socketIO.On ("linksuggestion", OnLinkSuggestionEvent);
			toListen = false;
		}
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
	public void OnLinkSuggestionEvent(SocketIOEvent e) {
		getAllLinkSuggestionsRequest = serverRequest.GetComponent<GetAllLinkSuggestionsRequest> ();
		getAllLinkSuggestionsRequest.linkSuggestionsRequest (linkSuggestionsRequestCallback);
	}
	public void linkSuggestionsRequestCallback(List<LinkSuggestion> linkSuggestions)
	{
		
		DataHandler.AllLinkSuggestions = linkSuggestions;
		clearLinkSuggestionsList ();
		populateLinkSuggestionsList ();
	}


}
