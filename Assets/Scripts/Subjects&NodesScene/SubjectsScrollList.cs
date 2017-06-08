using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectsScrollList : MonoBehaviour {

	public Transform contentPanel;
	public GameObject sampleButton;
	string[] subjects;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public  void PopulateSubjectsList()
	{
		if (subjects != null)
		{
			foreach (string s in subjects)
			{
				GameObject newButton = Instantiate(sampleButton) as GameObject;
				//    GameObject newToggle = Instantiate(sampleToggle) as GameObject;
				SampleButtonScript buttonScript = newButton.GetComponent<SampleButtonScript>();
				//    SampleToggleScript toggleScript = newToggle.GetComponent<SampleToggleScript>();
				//    toggleScript.label.text = item.name;
				//    toggleScript.toggle.onValueChanged = item.toggleToDo;
				buttonScript.nameLabel.text = s;
				//  buttonScript.button.onClick = item.thingToDo;
				//   buttonScript.button.onClick.AddListener(() => buttonScript.click());
				//  newButton.GetComponent<Button>().onClick.AddListener(() => buttonScript.click());
				newButton.transform.SetParent(contentPanel);
				// newToggle.transform.SetParent(contentPanel);

			}
		}
		else
		{
			// EditorUtility.DisplayDialog("No nodes ", "No nodes match selected subject(s)", "Ok");
		}
	}
}
