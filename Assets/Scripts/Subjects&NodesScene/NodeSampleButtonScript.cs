using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeSampleButtonScript : MonoBehaviour {

	public Text nameLabel;
	public Node node;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onNodeClick()
	{

		//  string[] relationship = { "1", "2", "3", "4" };
		GameObject serverRequester = GameObject.Find("ServerRequester");
		GetNodeInforServerRequestScript getNodeInforServerRequestScript = serverRequester.GetComponent<GetNodeInforServerRequestScript> ();
		getNodeInforServerRequestScript.nodeInformationRequest (node._id, onNodeClickCallback);
//		serverRequestScript.nodeInformationRequest(node._id, onNodeClickCallback);
		//GameObject canvas = GameObject.Find("Canvas");
		//canvas.gameObject.SetActive(false);
		//GameObject mainNode = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		//Vector3 v3Start = new Vector3(0, 0, 0);
		//Vector3 v3End;
		//mainNode.transform.position = new Vector3(0, 0, -4);
		//// Camera.main.ScreenToWorldPoint( Vector3(Screen.width/2, Screen.height/2, Camera.main.nearClipPlane) );
		//mainNode.transform.localScale += new  Vector3(1.0f,1.0f,1.0f);
		//GameObject s;
		//GameObject link;
		//Debug.Log(relationship.Length);
		//for(int i = 0;i<relationship.Length;i++)
		//{

		//   s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		//   v3End = new Vector3((Random.value * 18) - 9, (Random.value * 10) - 5, (Random.value * 7) - 3.5f);
		//   s.transform.position = v3End;
		//   //Gizmos.color = Color.blue;
		//   //Gizmos.DrawLine(startVector, endVector);
		//   GameObject line = new GameObject();
		//   line.AddComponent<LineRenderer>();
		//   LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
		//   lineRenderer.SetPosition(0, v3Start);
		//   lineRenderer.SetPosition(1, v3End);
		//   lineRenderer.SetWidth(0.2f, 0.2f);

		//}

	}

	public void onNodeClickCallback(NodeRelationshipDataSet nrds)
	{
		// za ovo napravi u DataHandler script jedan Node(singleton moze) koji ce da cuva selektovani Node i
		// i sve info za njega
		DataHandler.SelectedNrds=nrds;

	/*	Text nodeNameText = GameObject.Find("nodeNameText").GetComponent<Text>();
		nodeNameText.text = node.name;
		Text nodeDefinitonText = GameObject.Find("nodeDefinitionText").GetComponent<Text>();
		nodeDefinitonText.text = node.definition;
		Text nodeDescriptionText = GameObject.Find("nodeDescriptionText").GetComponent<Text>();
		nodeDescriptionText.text = node.description;
		Text votesForText = GameObject.Find("votesForNodeLabel").GetComponent<Text>();
		if (node.votes_for!=null)
			votesForText.text = node.votes_for.Count.ToString() ;
		Text votesAgainstText = GameObject.Find("votesAgainstNodeLabel").GetComponent<Text>();
		if(node.votes_against !=null)
			votesAgainstText.text = node.votes_against.Count.ToString();
		Dropdown typesDropdown = GameObject.Find("nodeInfoPanelTypesDropdown").GetComponent<Dropdown>();
		typesDropdown.ClearOptions();
		typesDropdown.AddOptions(node.labels);

		CreateScrollList createSL = scrollListController.GetComponent<CreateScrollList>();
		createSL.relationshipsList = relatioships;
		createSL.populateRelationshipList();
		NodeVotesScript.node = node;
		DeleteNode.node = node;
		AddNewRelationshipScript.node = node;
		EditNodeButtonScript.node = node;    */

	}

}
