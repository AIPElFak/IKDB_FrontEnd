using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleButtonScript : MonoBehaviour {

	public Text nameLabel;
	private bool buttonClicked = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick() {

		if (buttonClicked)
		{
			buttonClicked = false;
			SelectedSubjectsClass.removeFromList(nameLabel.text);
			//  nameLabel.text = nameLabel.text.ToLower();

			// Debug.Log("true->false");
		}
		else
		{
			buttonClicked = true;
			SelectedSubjectsClass.addToList(nameLabel.text);

			// Debug.Log("false->true");
		}
	}

}
