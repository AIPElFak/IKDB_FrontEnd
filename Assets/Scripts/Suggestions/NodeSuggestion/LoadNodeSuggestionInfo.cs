using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

public class LoadNodeSuggestionInfo : MonoBehaviour {
	public Text name;
	public Text suggType;
	public Text votesFor;
	public Text votesAgainst;
	public Text definition;
	public Text description;
	public Text nodeTypes;
	public Button voteForButton;
	public Button voteAgainstButton;
	SocketIOComponent socketIO;
	public GameObject serverRequest;
	GetNodeSuggestionRequest serverRequestScript;
	bool toListen = true;

	// Use this for initialization
	void Start()
	{
		socketIO = GameObject.Find ("SocketIO").GetComponent<SocketIOComponent>();
		toListen = true;
		//socketIO.On ("nodesuggestion-" + DataHandler.SelectedNodeSuggestion._id, NodeSuggestionEvent);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void populateFields()
	{
		Debug.Log (DataHandler.SelectedNodeSuggestion._id);
		if (toListen) {
			Debug.Log ("nodesuggestion-" + DataHandler.SelectedNodeSuggestion._id);
			socketIO.On ("nodesuggestion-" + DataHandler.SelectedNodeSuggestion._id, NodeSuggestionEvent);
			toListen = false;
		}
		name.text = DataHandler.SelectedNodeSuggestion.name;
		suggType.text = DataHandler.SelectedNodeSuggestion.suggestion_type;
		votesFor.text = DataHandler.SelectedNodeSuggestion.votes_for.Count.ToString();
		votesAgainst.text = DataHandler.SelectedNodeSuggestion.votes_against.Count.ToString();
		definition.text = DataHandler.SelectedNodeSuggestion.definition;
		description.text = DataHandler.SelectedNodeSuggestion.description;
		if (DataHandler.SelectedNodeSuggestion!=null)
		{
			nodeTypes.text = DataHandler.SelectedNodeSuggestion.types[0];
			for (int i = 1; i < DataHandler.SelectedNodeSuggestion.types.Count; i++)
			{
				nodeTypes.text += ", " + DataHandler.SelectedNodeSuggestion.types[i];
			}
		}
	}

	public void NodeSuggestionEvent(SocketIOEvent socketIOEvent) {
		Debug.Log ("Ovde se desavaju lepe stvari");
		serverRequestScript = serverRequest.GetComponent<GetNodeSuggestionRequest> ();
		serverRequestScript.nodekSuggestionsRequest (DataHandler.SelectedNodeSuggestion._id, nodeSuggestionReqCallback);
	}

	public void nodeSuggestionReqCallback(NodeSuggestion ns) {
		Debug.Log ("Upao u callback");
		DataHandler.SelectedNodeSuggestion = ns;
		populateFields ();
	}
}
