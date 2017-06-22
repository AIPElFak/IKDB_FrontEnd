using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToRelationshipInfo : MonoBehaviour {

	public InputField inputFieldRelationshipDescription;
	public Button sendSuggestion;
	public Button backToRelationshipInfo;

	// Use this for initialization
	void Start () {
		

	}

	// Update is called once per frame
	void Update () {

	}

	public void click() {
		inputFieldRelationshipDescription.gameObject.SetActive (false);
		sendSuggestion.gameObject.SetActive (false);
		backToRelationshipInfo.gameObject.SetActive (false);
	}
}
