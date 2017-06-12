using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;

public class GetAllNodesRequestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//get all nodes req and response
	public void getAllNodesRequest(Action<List<Node>> getAllNodesCallbaack)
	{
		Dictionary<string, string> header = new Dictionary<string, string>();
		header.Add("token", DataHandler.Token);
		WWW www = new WWW(DataHandler.serverIP + ": 3000 /secure/getallnodes/", null, header);
		StartCoroutine(waitForAllNodesRequest(www, getAllNodesCallbaack));
	}

	IEnumerator waitForAllNodesRequest(WWW www,Action<List<Node>> getAllNodesCallbaack)
	{
		yield return www;
		List<Node> allNodes = JsonMapper.ToObject<List<Node>>(www.text);
		Debug.Log("waitForAllNodesRequest");
		getAllNodesCallbaack(allNodes);
	}
}
