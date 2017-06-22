using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseEditNodePanel : MonoBehaviour {
	
	public InputField inputFieldNodeInformation;
	public InputField inputFieldNodeDescription;
	public Button saveChanges;
	public Dropdown typeDropdown;
	public Dropdown allTypesDropdown;
	public static Node node;
	public List<string> selectedTypes;
	public Button backoToNodeInfoButton;
	public Button select;
	public Button deselect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void closeEditNodePanel() {
		inputFieldNodeInformation.gameObject.SetActive(false);
		inputFieldNodeDescription.gameObject.SetActive(false);
		saveChanges.gameObject.SetActive(false);
		allTypesDropdown.gameObject.SetActive(false);
		select.gameObject.SetActive(false);
		deselect.gameObject.SetActive (false);

		backoToNodeInfoButton.gameObject.SetActive(false);
	}
}
