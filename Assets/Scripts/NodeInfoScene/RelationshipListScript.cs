using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class RelationshipListScript : MonoBehaviour {

	List<Relationship> relationshipsList;
	public Transform relationshipContentPanel;
	public GameObject sampleRelationshipButton;
	public GameObject serverRequest;
	GetNodeInforServerRequestScript getNodeInforServerRequestScript;
	SocketIOComponent socketIO;
	// Use this for initialization
	void Start () {
		socketIO = GameObject.Find ("SocketIO").GetComponent<SocketIOComponent> ();
		socketIO.On ("globalupdate", OnGlobalUpdateEvent);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void populateRelationshipList()
	{
		relationshipsList = DataHandler.SelectedNrds.relationships;
		if (relationshipsList != null)
		{
			foreach (Relationship r in relationshipsList)
			{
				GameObject newRelationshipButton = Instantiate(sampleRelationshipButton) as GameObject;
				SampleRelationshipButtonScript relationshipButtonScript = newRelationshipButton.GetComponent<SampleRelationshipButtonScript>();
				relationshipButtonScript.nameLabel.text = r._type;
				relationshipButtonScript.nodeToLabel.text = r.end_name;
				relationshipButtonScript.relationship = r;
				newRelationshipButton.transform.SetParent(relationshipContentPanel);
			}
		}
		else
		{
			//EditorUtility.DisplayDialog("No relationships ", "No relationships for selected node", "Ok");
		}
	}
	public void clearRelationshipsList()
	{
		for (var i = relationshipContentPanel.transform.childCount - 1; i >= 0; i--)
		{
			var child = relationshipContentPanel.transform.GetChild(i);
			child.transform.parent = null;
			Destroy(child.gameObject);
		}
		relationshipsList = null;

	}

	public void OnGlobalUpdateEvent(SocketIOEvent e) {
		GetNodeInforServerRequestScript getNodeInforServerRequestScript = serverRequest.GetComponent<GetNodeInforServerRequestScript> ();
		getNodeInforServerRequestScript.nodeInformationRequest (DataHandler.SelectedNrds.node._id, onNodeClickCallback);
	}


	public void onNodeClickCallback(NodeRelationshipDataSet nrds)
	{
		// za ovo napravi u DataHandler script jedan Node(singleton moze) koji ce da cuva selektovani Node i
		// i sve info za njega

		DataHandler.SelectedNrds=nrds;
		clearRelationshipsList ();
		populateRelationshipList ();
	}

}
