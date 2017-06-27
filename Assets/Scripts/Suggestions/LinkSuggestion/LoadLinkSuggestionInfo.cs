using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

public class LoadLinkSuggestionInfo : MonoBehaviour {

	public Text startNode;
	public Text endNode;
	public Text suggType;
	public Text votesFor;
	public Text votesAgainst;
	public Text description;
	public Text linkType;
	public Button voteForButton;
	public Button voteAgainstButton;
	public Button backButton;
	public GameObject serverRequest;
	public GetLinkSuggestionRequest serverRequestScript;
	SocketIOComponent socketIO;

	// Use this for initialization
	void Start () {
		socketIO = GameObject.Find ("SocketIO").GetComponent<SocketIOComponent>();
		//socketIO.On ("linksuggestion-" + DataHandler.SelectedLinkSuggestion._id,OnLinkSuggestionEvent);
	}

	// Update is called once per frame
	void Update () {

	}

	public void populateFields()
	{
		socketIO.On ("linksuggestion-" + DataHandler.SelectedLinkSuggestion._id,OnLinkSuggestionEvent);
		startNode.text = DataHandler.SelectedLinkSuggestion.start_name;
		endNode.text = DataHandler.SelectedLinkSuggestion.end_name;
		suggType.text = DataHandler.SelectedLinkSuggestion.suggestion_type;
		votesFor.text = DataHandler.SelectedLinkSuggestion.votes_for.Count.ToString();
		votesAgainst.text = DataHandler.SelectedLinkSuggestion.votes_against.Count.ToString();
		description.text = DataHandler.SelectedLinkSuggestion.description;
		linkType.text = DataHandler.SelectedLinkSuggestion.type;
	}

	public void OnLinkSuggestionEvent(SocketIOEvent socketIOEvent) {
		serverRequestScript = serverRequest.GetComponent<GetLinkSuggestionRequest> ();
		serverRequestScript.linkSuggestionsRequest (DataHandler.SelectedLinkSuggestion._id, nodeSuggestionReqCallback);
	}

	public void nodeSuggestionReqCallback(LinkSuggestion ls) {
		DataHandler.SelectedLinkSuggestion = ls;
		populateFields ();
	}
}
