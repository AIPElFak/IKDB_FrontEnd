using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleButtonScript : MonoBehaviour {

	public Text nameLabel;
	private bool buttonClicked = false;
	public GameObject selectedSubjectsTextController;
	public SelectedSubjectsTextController selectedSubjectsTextControllerScript;
	// Use this for initialization
	void Start () {
		selectedSubjectsTextController = GameObject.Find ("SelectedSubjectsTextController");
		selectedSubjectsTextControllerScript = selectedSubjectsTextController.GetComponent<SelectedSubjectsTextController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick() {

		if (buttonClicked)
		{
			buttonClicked = false;
			selectedSubjectsTextControllerScript.removeFromList(nameLabel.text);
			//  nameLabel.text = nameLabel.text.ToLower();

			// Debug.Log("true->false");
		}
		else
		{
			buttonClicked = true;
			selectedSubjectsTextControllerScript.addToList(nameLabel.text);

			// Debug.Log("false->true");
		}
	}

}
