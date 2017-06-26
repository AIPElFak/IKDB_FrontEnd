using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;

public class GetNodeByNameServerRequest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//node information request and response
	public void nodeInformationRequest(string nodeName, Action<NodeRelationshipDataSet> nodeInfoCallback)
	{
		//   string data = "{\"username\":\"" + user + "\",\"password\":\"" + password + "\"}";
		Dictionary<string, string> header = new Dictionary<string, string>();
		//   header.Add("Content-Type", "application/json");
		header.Add("token", DataHandler.Token);
		//   var byteData = System.Text.UTF8Encoding.UTF8.GetBytes(data);
		WWW www = new WWW(DataHandler.serverIP + ": 3000 /secure/getnodebyname/"+nodeName,null,header);
		StartCoroutine(waitForNodeInformationRequest(www, nodeInfoCallback));
	}

	IEnumerator waitForNodeInformationRequest(WWW www, Action<NodeRelationshipDataSet> nodeInfoCallback)
	{
		yield return www;

		NodeRelationshipDataSet nrds = JsonMapper.ToObject<NodeRelationshipDataSet>(www.text);
		nrds.node.labels = nrds.labels;

		nodeInfoCallback(nrds);

	}
}
