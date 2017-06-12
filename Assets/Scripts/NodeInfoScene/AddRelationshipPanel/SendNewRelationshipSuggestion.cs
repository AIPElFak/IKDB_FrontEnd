using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SendNewRelationshipSuggestion : MonoBehaviour {

	public Text nodeFrom;
	public GameObject nodeButton;
	public SampleButtonScript sampleButtonScript;
	public static Node nodeTo;
	public static List<Node> allNodesList;
	public GameObject serverRequest;
	public Dropdown nodeToDropdown;
	public InputField type;
	public CreateRelationshipSuggestionRequestScript serverReqScript;
	public InputField description;


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
		for(int i = 0;i<allNodesList.Count;i++)
		{
			if(nodeToDropdown.options[nodeToDropdown.value].text.Equals(allNodesList[i].name))
			{
				nodeTo = allNodesList[i];
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
		}

	}
}
