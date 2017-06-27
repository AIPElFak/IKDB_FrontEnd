using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using SocketIO;

public class NodesScrollList : MonoBehaviour {

	public Transform nodeContentPanel;
	public GameObject sampleNodeButton;
	public  List<Node> nodeList;
	public GameObject serverRequest;
	GetNodesServerRequestScript getNodesServerRequestScript;
	SocketIOComponent socketIO;
	// Use this for initialization
	void Start () {
		socketIO = GameObject.Find ("SocketIO").GetComponent<SocketIOComponent> ();
		socketIO.On ("globalupdate", OnGlobalUpdateEvent);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void populateNodeList()
	{
		this.nodeList = SelectedNodesClass.SelectedNodes;
		if (nodeList != null)
		{
			foreach (Node n in nodeList)
			{
				GameObject newNodeButton = Instantiate(sampleNodeButton) as GameObject;
				NodeSampleButtonScript buttonScript = newNodeButton.GetComponent<NodeSampleButtonScript>();
				buttonScript.nameLabel.text = n.name;
				buttonScript.node = n;
				newNodeButton.transform.SetParent(nodeContentPanel);
			}
		}
		else
		{
//			EditorUtility.DisplayDialog("No nodes ", "No nodes match selected subject(s)", "Ok");
			Debug.Log("No nodes match selected subject(s)");
		}
	}

	public void clearNodeList()
	{
		for (var i = nodeContentPanel.transform.childCount - 1; i >= 0;i--)
		{
			var child = nodeContentPanel.transform.GetChild(i);
			child.transform.parent = null;
			Destroy(child.gameObject);
		}
		nodeList = null;
		//  populateNodeList();
	}

	public void OnGlobalUpdateEvent(SocketIOEvent e) {
		getNodesServerRequestScript = serverRequest.GetComponent<GetNodesServerRequestScript> ();
		getNodesServerRequestScript.categoriesNodeRequest(DataHandler.SelectedSubjects, clickCallback);

	}


	public void clickCallback(List<Node> array)
	{
		//nodes = array;
		SelectedNodesClass.SelectedNodes = array;

		if(array==null)
		{
			Debug.Log("Nema cvorova za prikaz");
			return;
		}
		clearNodeList ();
		nodeList = array;
		populateNodeList();
	}
}
