using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoteOnNodeScript : MonoBehaviour {
	
	GameObject serverRequest;
	VoteNodeServerRequests voteNodeServerRequest;
	// Use this for initialization
	void Start () {
		voteNodeServerRequest = serverRequest.GetComponent<VoteNodeServerRequests> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void voteForNodeClick()
	{

		voteNodeServerRequest.nodeVoteRequest(DataHandler.SelectedNrds.node._id.ToString(), "POSITIVE", voteForNodeCallback);
	}

	public void voteForNodeCallback(string s)
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
	public void voteAgainstNodeClick()
	{
		voteNodeServerRequest.nodeVoteRequest(DataHandler.SelectedNrds.node._id.ToString(), "NEGATIVE", voteAgainstNodeCallback);
	}

	public void voteAgainstNodeCallback(string s)
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
