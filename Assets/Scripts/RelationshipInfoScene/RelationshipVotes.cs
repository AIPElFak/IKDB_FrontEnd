using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipVotes : MonoBehaviour {

	public GameObject serverRequest;
	RelationshipVotesRequests serverRequestScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void voteForLinkClick()
	{

		serverRequestScript.linkVoteRequest(DataHandler.SelectedRelationship._id.ToString(), "POSITIVE", voteForLinkCallback);
	}

	public void voteForLinkCallback(string s)
	{
		if (s != null)
		{
			//EditorUtility.DisplayDialog("Error", "An error occurred", "Ok");
			Debug.Log("Error");
		}
		else
		{
			//EditorUtility.DisplayDialog("Success", "Success", "Ok");
			Debug.Log("Success");
		}
	}
	public void voteAgainstLinkClick()
	{
		serverRequestScript.linkVoteRequest(DataHandler.SelectedRelationship._id.ToString(), "NEGATIVE", voteAgainstLinkCallback);
	}

	public void voteAgainstLinkCallback(string s)
	{
		if (s != null)
		{
			//EditorUtility.DisplayDialog("Error", "An error occurred", "Ok");
			Debug.Log("Error");
		}
		else
		{
			//EditorUtility.DisplayDialog("Success", "Success", "Ok");
			Debug.Log("Success");
		}
	}
}
