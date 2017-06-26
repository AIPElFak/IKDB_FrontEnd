using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GetNodeByNameButton : MonoBehaviour {

	public GameObject serverRequester;
	GetNodeByNameServerRequest getNodeByNameServerRequest;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onNodeClick()
	{
		getNodeByNameServerRequest = serverRequester.GetComponent<GetNodeByNameServerRequest> ();
		getNodeByNameServerRequest.nodeInformationRequest ("nodeName", onNodeClickCallback);
	}

	public void onNodeClickCallback(NodeRelationshipDataSet nrds)
	{
		// za ovo napravi u DataHandler script jedan Node(singleton moze) koji ce da cuva selektovani Node i
		// i sve info za njega
		DataHandler.SelectedNrds=nrds;
		SceneManager.LoadScene ("NodeInfoScene");

	}
}
