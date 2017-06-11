using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SendCreateNodeSuggestionScript : MonoBehaviour {

	public Dropdown typeDropdown;
	public Dropdown selectedTypeDropDown;
	public InputField definition;
	public InputField description;
	public InputField nodeName;
	public GameObject serverRequest;
	public CreateNodeSuggestionRequestScript serverRequestScript;

	// public Text selectedTypesText;
	public List<string> selectedTypes;
	// Use this for initialization
	void Start () {
		
		serverRequestScript = serverRequest.GetComponent<CreateNodeSuggestionRequestScript>();
		List<string> types = new List<string>();
		for(int i = 0;i<DataHandler.Subjects.Length;i++)
		{
			types.Add(DataHandler.Subjects[i]);
		}
		typeDropdown.ClearOptions();
		selectedTypeDropDown.ClearOptions();
		typeDropdown.AddOptions(types);

	}

	// Update is called once per frame
	void Update () {

	}
		

	public void onSendSuggestionClick()
	{
		List<string> link = new List<string>();
		for (int i = 0; i < selectedTypeDropDown.options.Count; i++)
		{

			link.Add(selectedTypeDropDown.options[i].text);
			//   Debug.Log(selectedTypeDropDown.options[i].text);
		}
		serverRequestScript.createNodeSuggestionRequest(nodeName.text, definition.text, description.text, link, onSendSuggestionCallback);
	}

	public void onSendSuggestionCallback(string s)
	{
		if (s != null)
		{
			//EditorUtility.DisplayDialog("Error", "An error occurred", "Ok");
			Debug.Log("Create node suggestion error");
		}
		else
		{
			//EditorUtility.DisplayDialog("Success", "Success", "Ok");
			Debug.Log("Success");
		}
	}



}
