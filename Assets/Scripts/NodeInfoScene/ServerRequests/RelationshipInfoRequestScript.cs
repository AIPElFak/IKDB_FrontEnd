using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LitJson;

public class RelationshipInfoRequestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//get realtionship by id req and response 
	public void relationshipInformationRequest(int _id, Action<Relationship> relationshipInfoCallback)
	{
		Dictionary<string, string> header = new Dictionary<string, string>();
		header.Add("token", DataHandler.Token);
		WWW www = new WWW(DataHandler.serverIP + ": 3000 /secure/getrelationshipbyid/" + _id, null, header);
		StartCoroutine(waitForRelationshipInformationRequest(www, relationshipInfoCallback));
	}

	IEnumerator waitForRelationshipInformationRequest(WWW www, Action<Relationship> relationshipInfoCallback)
	{
		yield return www;
		Relationship relationship = JsonMapper.ToObject<Relationship>(www.text);
		relationshipInfoCallback(relationship);
	}
}
