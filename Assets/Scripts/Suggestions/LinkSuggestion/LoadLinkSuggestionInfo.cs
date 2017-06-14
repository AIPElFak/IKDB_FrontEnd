using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void populateFields()
	{
		startNode.text = DataHandler.SelectedLinkSuggestion.start_name;
		endNode.text = DataHandler.SelectedLinkSuggestion.end_name;
		suggType.text = DataHandler.SelectedLinkSuggestion.suggestion_type;
		votesFor.text = DataHandler.SelectedLinkSuggestion.votes_for.Count.ToString();
		votesAgainst.text = DataHandler.SelectedLinkSuggestion.votes_against.Count.ToString();
		description.text = DataHandler.SelectedLinkSuggestion.description;
		linkType.text = DataHandler.SelectedLinkSuggestion.type;
	}
}
