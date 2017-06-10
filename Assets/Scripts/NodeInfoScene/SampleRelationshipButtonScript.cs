using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleRelationshipButtonScript : MonoBehaviour {
	
	public Button button;
	public Text nameLabel;
	public Text nodeToLabel;
	public bool buttonClicked;
	//public GameObject serverRequest;
//	public ServerRequestScript serverRequestScript;
	public Node nodeTo;
	public Relationship relationship;



	// Use this for initialization
	void Start () {
	//	serverRequest = GameObject.Find("ServerRequest");
	//	serverRequestScript = serverRequest.GetComponent<ServerRequestScript>();

	}

	// Update is called once per frame
	void Update () {

	}

	public void onClick()
	{
		//serverRequestScript.relationshipInformationRequest(relationship._id, onClickCallBack);
	}

	public void onClickCallBack(Relationship r)
	{
		
	}
}
