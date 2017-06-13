using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using LitJson;
using UnityEngine.SceneManagement;

public class SampleRelationshipButtonScript : MonoBehaviour {
	
	public Button button;
	public Text nameLabel;
	public Text nodeToLabel;
	public bool buttonClicked;
	public GameObject serverRequest;
	public RelationshipInfoRequestScript serverRequestScript;
	public Node nodeTo;
	public Relationship relationship;



	// Use this for initialization
	void Start () {
	//	serverRequest = GameObject.Find("ServerRequest");

	}

	// Update is called once per frame
	void Update () {

	}

	public void onClick()
	{
		//serverRequestScript = serverRequest.GetComponent<RelationshipInfoRequestScript>();
		DataHandler.SelectedRelationship = relationship;
		relationshipInformationRequest(relationship._id, onClickCallBack);
	}

	public void onClickCallBack(Relationship r)
	{
		//nova scena se otvori (ili panel)
		DataHandler.SelectedRelationship = r;
		SceneManager.LoadScene("RelationshipInfoScene");
	}
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
