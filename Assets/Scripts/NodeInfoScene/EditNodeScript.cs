using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditNodeScript : MonoBehaviour {


	public InputField inputFieldNodeInformation;
	public InputField inputFieldNodeDescription;
	public Button saveChanges;
	public Dropdown typeDropdown;
	public Dropdown allTypesDropdown;
	public static Node node;
	public List<string> selectedTypes;
	public Button backButton;
	public Button backoToNodeInfoButton;
	public Button select;
	public Button deselect;
	public GameObject listControl;
	private bool edit = false;

	void Start () 
	{
		inputFieldNodeInformation.gameObject.SetActive(false);
		inputFieldNodeDescription.gameObject.SetActive(false);
		saveChanges.gameObject.SetActive(false);
		allTypesDropdown.gameObject.SetActive(false);
		backoToNodeInfoButton.gameObject.SetActive(false);
		selectedTypes = new List<string>();
		if (select == null)
			select = GameObject.Find("uniqueMoveToSelectedButton").GetComponent<Button>();
		if (deselect == null)
			deselect = GameObject.Find("uniqueRemoveFromSelectedButton").GetComponent<Button>();
		select.gameObject.SetActive(false);
		deselect.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update () {

	}

	public void onEditClick()
	{

		inputFieldNodeInformation.gameObject.SetActive(true);
		inputFieldNodeDescription.gameObject.SetActive(true);
		saveChanges.gameObject.SetActive(true);
		allTypesDropdown.gameObject.SetActive(true);
	//	SaveNodeChangesScript.defText = node.definition;
	//	SaveNodeChangesScript.descText = node.description;
		inputFieldNodeInformation.text = DataHandler.SelectedNrds.node.definition;
		inputFieldNodeDescription.text = DataHandler.SelectedNrds.node.description;
		select.gameObject.SetActive(true);
		deselect.gameObject.SetActive(true);
	/*
		List<string> allTypes = new List<string>(ServerRequestScript.allLabels);
		allTypesDropdown.ClearOptions();
		for (int i = 0; i < node.labels.Count;i++)
		{
			allTypes.Remove(node.labels[i]);
		}
		allTypesDropdown.AddOptions(allTypes);

		allTypes.Clear();
		//typeDropdown.onValueChanged.AddListener(onLeftDropdownClick);
*/

		backoToNodeInfoButton.gameObject.SetActive(true);
//		SaveNodeChangesScript.node_id = node._id;
		edit = true;
	}



}
