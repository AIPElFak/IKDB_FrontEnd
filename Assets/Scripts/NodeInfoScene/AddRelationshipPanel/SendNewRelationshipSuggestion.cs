using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SendNewRelationshipSuggestion : MonoBehaviour {

	public Text nodeFrom;
	public static Node nodeTo;
	public GameObject serverRequest;
	public Dropdown nodeToDropdown;
	public InputField type;
	public CreateRelationshipSuggestionRequestScript serverReqScript;
	public InputField description;
	public GameObject panelHolder;


	// Use this for initialization
	void Start () {
		
		//    PanelHolderScript.nodeInfoPanel.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update () {

	}




	public void createLinkSuggestion()
	{
		serverReqScript = serverRequest.GetComponent<CreateRelationshipSuggestionRequestScript>();
		Node nodeTo = null; 
		for(int i = 0;i<DataHandler.AllNodes.Count;i++)
		{
			if(nodeToDropdown.options[nodeToDropdown.value].text.Equals(DataHandler.AllNodes[i].name))
			{
				nodeTo = DataHandler.AllNodes[i];
				break;
			}
		}

		serverReqScript.createLinkSuggestionRequest(DataHandler.SelectedNrds.node._id.ToString(), nodeTo._id.ToString(), description.text, type.text, createLinkSuggestionCallback);
	}

	public void createLinkSuggestionCallback(string s)
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
			panelHolder.GetComponent<NodeInfoPanelHolderScript> ().nodeInfoPanel.SetActive (true);
			panelHolder.GetComponent<NodeInfoPanelHolderScript> ().addRelationshipPanel.SetActive (false);


		}

	}
}
