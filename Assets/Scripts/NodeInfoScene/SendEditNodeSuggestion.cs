using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SendEditNodeSuggestion : MonoBehaviour {

	public InputField definitionInputField;
	public InputField descriptionInputField;
	public static int node_id;
	public GameObject serverReq;
	EditNodeSuggestionRequestScript serverRequestScript;
	public Dropdown typesDropdown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void onSendClick()
	{
		string definition = null, description = null; 
		if(!definitionInputField.text.Equals(DataHandler.SelectedNrds.node.definition))
		{
			definition = definitionInputField.text;
		}
		if(!descriptionInputField.text.Equals(DataHandler.SelectedNrds.node.description))
		{
			description = descriptionInputField.text;
		}
		List<string> list = new List<string>();
		for (int i = 0; i < typesDropdown.options.Count;i++)
		{
			list.Add(typesDropdown.options[i].text);
		}
		serverRequestScript.editNodeSuggestionRequest(node_id, definition, description, list, onSendClickCallback);
	}
	public void onSendClickCallback(String error)
	{
		if(error!=null)
		{
			//EditorUtility.DisplayDialog("An error occured", error, "Ok");
			Debug.Log("An error occured");
		}
		else
		{
			//EditorUtility.DisplayDialog("Success"," Your suggestion has been successfully submitted", "Ok");
			Debug.Log("Your suggestion has been successfully submitted");
		}
	}
}
