using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSuggestionVotes : MonoBehaviour {

	public GameObject serverRequest;
	NodeSuggestionVotesRequest serverRequestScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void voteForNodeSuggestionClick()
	{
		serverRequestScript = serverRequest.GetComponent<NodeSuggestionVotesRequest> ();
		serverRequestScript.nodeSuggestionVoteRequest(DataHandler.SelectedNodeSuggestion._id, "POSITIVE", voteForNodeSuggestionCallback);
	}
	public void voteForNodeSuggestionCallback(string s)
	{
		if (s != null)
		{
			//EditorUtility.DisplayDialog("Error", "An error occurred", "Ok");
			Debug.Log ("Error");
			Debug.Log (s);
		}
		else
		{
			Debug.Log ("Success");
			//EditorUtility.DisplayDialog("Success", "Success", "Ok");
		}
	}
	public void voteAgainstNodeSuggestionClick()
	{
		serverRequestScript = serverRequest.GetComponent<NodeSuggestionVotesRequest> ();
		serverRequestScript.nodeSuggestionVoteRequest(DataHandler.SelectedNodeSuggestion._id, "NEGATIVE", voteAgainstNodeSuggestionCallback);
	}

	public void voteAgainstNodeSuggestionCallback(string s)
	{
		if (s != null)
		{
			//EditorUtility.DisplayDialog("Error", "An error occurred", "Ok");
			Debug.Log ("Error");
			Debug.Log (s);

		}
		else
		{
			Debug.Log ("Success");
			//EditorUtility.DisplayDialog("Success", "Success", "Ok");
		}
	}
}
