using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditRelationshipButton : MonoBehaviour {

	public InputField inputFieldRelationshipDescription;
	public Button sendSuggestion;
	public Button backToRelationshipInfo;

	// Use this for initialization
	void Start () {
		inputFieldRelationshipDescription.gameObject.SetActive (false);
		sendSuggestion.gameObject.SetActive (false);
		backToRelationshipInfo.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void click() {
		inputFieldRelationshipDescription.gameObject.SetActive (true);
		sendSuggestion.gameObject.SetActive (true);
		backToRelationshipInfo.gameObject.SetActive (true);
	}
}
