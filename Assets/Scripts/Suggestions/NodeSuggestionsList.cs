using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSuggestionsList : MonoBehaviour {

	public GameObject sampleNodeSuggestion;
	public Transform nodeSuggestionsContentPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void populateNodeSuggestionsList()
	{
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
}
