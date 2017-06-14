using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void populateFields()
	{
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
}
