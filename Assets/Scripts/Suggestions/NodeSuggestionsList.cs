using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class NodeSuggestionsList : MonoBehaviour {

	public GameObject sampleNodeSuggestion;
	public Transform nodeSuggestionsContentPanel;
	SocketIOComponent socketIO;
	bool toListen = true;
	public GameObject serverRequest;
	GetAllNodeSuggestionsRequest getAllNodeSuggestionsRequest;

	// Use this for initialization
	void Start () {
		toListen = true;
		socketIO = GameObject.Find ("SocketIO").GetComponent<SocketIOComponent> ();
		socketIO.On ("globalupdate", OnNodeSuggestionEvent);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void populateNodeSuggestionsList()
	{
		if (toListen) {
			socketIO.On ("nodesuggestion", OnNodeSuggestionEvent);
			toListen = false;
		}
		if (DataHandler.AllNodeSuggestions.Count>0)
		{
			foreach (NodeSuggestion ns in DataHandler.AllNodeSuggestions)
			{
				GameObject newNodeSuggestion = Instantiate(sampleNodeSuggestion) as GameObject;
				NodeSuggestionSampleScript nodeSuggestionSampleScript = newNodeSuggestion.GetComponent<NodeSuggestionSampleScript>();
				nodeSuggestionSampleScript.nameLabel.text = ns.name;
				nodeSuggestionSampleScript.typeLabel.text = ns.suggestion_type;
				newNodeSuggestion.transform.SetParent(nodeSuggestionsContentPanel);
				nodeSuggestionSampleScript.nodeSuggestion = ns;
			}
		}
		else
		{
			//EditorUtility.DisplayDialog("No node suggestions ", "There is currently no node suggestions", "Ok");
			Debug.Log("No node suggestions");

		}
	}
	public void clearNodeSuggestionsList()
	{
		for (var i = nodeSuggestionsContentPanel.transform.childCount - 1; i >= 0; i--)
		{
			var child = nodeSuggestionsContentPanel.transform.GetChild(i);
			child.transform.parent = null;
			Destroy(child.gameObject);
		}
		//nodeSuggestions = null;
		//  populateNodeList();
	}

	public void OnNodeSuggestionEvent(SocketIOEvent socketIOEvent) { 
		getAllNodeSuggestionsRequest = serverRequest.GetComponent<GetAllNodeSuggestionsRequest> ();
		getAllNodeSuggestionsRequest.nodeSuggestionsRequest (nodeSuggestionRequestsCallback);
	}
	public void nodeSuggestionRequestsCallback(List<NodeSuggestion> nodeSuggestions)
	{
		DataHandler.AllNodeSuggestions = nodeSuggestions;
		clearNodeSuggestionsList ();
		populateNodeSuggestionsList ();

	}
}
