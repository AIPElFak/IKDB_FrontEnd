using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkSuggestionVotes : MonoBehaviour {

	public GameObject serverRequest;
	LinkSuggestionVotesRequest serverRequestScript;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void voteForLinkSuggestionClick()
	{
		serverRequestScript = serverRequest.GetComponent<LinkSuggestionVotesRequest> ();
		serverRequestScript.linkSuggestionVoteRequest(DataHandler.SelectedLinkSuggestion._id, "POSITIVE", voteForLinkSuggestionCallback);
	}
	public void voteForLinkSuggestionCallback(string s)
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
	public void voteAgainstLinkSuggestionClick()
	{
		serverRequestScript = serverRequest.GetComponent<LinkSuggestionVotesRequest> ();
		serverRequestScript.linkSuggestionVoteRequest(DataHandler.SelectedLinkSuggestion._id, "NEGATIVE", voteAgainstLinkSuggestionCallback);
	}

	public void voteAgainstLinkSuggestionCallback(string s)
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
