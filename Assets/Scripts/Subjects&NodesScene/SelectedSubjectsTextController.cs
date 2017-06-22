using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedSubjectsTextController : MonoBehaviour {

	//public GameObject selectedSubjectsObject;
	public Text selectedSubjectsText;

	// Use this for initialization
	void Start () {
		//selectedSubjectsText = selectedSubjectsObject.GetComponent<Text> ();
		DataHandler.SelectedSubjects.Clear();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addToList(string name)
	{
		if(!DataHandler.SelectedSubjects.Contains(name))
			DataHandler.SelectedSubjects.Add(name);
		if (DataHandler.SelectedSubjects.Count > 0)
		{
			selectedSubjectsText.text = DataHandler.SelectedSubjects[0];
			for (int i = 1; i < DataHandler.SelectedSubjects.Count; i++)
			{
				selectedSubjectsText.text += "," + DataHandler.SelectedSubjects[i];
			}
		}
		else
		{
			this.selectedSubjectsText.text = "";
		}
	}

	public void removeFromList(string name)
	{
		if(DataHandler.SelectedSubjects.Contains(name))
			DataHandler.SelectedSubjects.Remove(name);
		if (DataHandler.SelectedSubjects.Count > 0)
		{
			selectedSubjectsText.text = DataHandler.SelectedSubjects[0];
			for (int i = 1; i < DataHandler.SelectedSubjects.Count; i++)
			{
				selectedSubjectsText.text += "," + DataHandler.SelectedSubjects[i];
			}
		}
		else
		{
			selectedSubjectsText.text = "";
		}
	}
}
