using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDeleteCategoryPanel : MonoBehaviour {

	public GameObject panelHolder;
	PanelHolderScript2 panelHolderScript;
	public Dropdown allCategoriesDropdown;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void onClick() {
		panelHolderScript = panelHolder.GetComponent<PanelHolderScript2> ();
		panelHolderScript.deleteCategoryPanel.SetActive (true);
		List<string> allCategories = new List<string> ();
		for(int i = 0;i<DataHandler.Subjects.Length;i++)
		{
			allCategories.Add(DataHandler.Subjects[i]);
		}
		allCategoriesDropdown.ClearOptions ();
		allCategoriesDropdown.AddOptions(allCategories);
	}
}
