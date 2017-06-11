using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateNodeDropdownsScript : MonoBehaviour {

	public Dropdown typeDropdown;
	public Dropdown selectedTypeDropDown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void moveToSelected()
	{
		if (typeDropdown.options.Count > 0)
		{
			List<string> list = new List<string>();

			for (int i = 0; i < typeDropdown.options.Count; i++)
			{
				list.Add(typeDropdown.options[i].text);
			}
			string selected = typeDropdown.options[typeDropdown.value].text;
			list.Remove(selected);

			selectedTypeDropDown.options.Add(new Dropdown.OptionData(selected));
			typeDropdown.ClearOptions();
			typeDropdown.AddOptions(list);

		}
	}
	public void removeFromSelected()
	{
		if (selectedTypeDropDown.options.Count > 0)
		{
			List<string> list = new List<string>();

			for (int i = 0; i < selectedTypeDropDown.options.Count; i++)
			{
				list.Add(selectedTypeDropDown.options[i].text);
			}
			string selected = selectedTypeDropDown.options[selectedTypeDropDown.value].text;
			list.Remove(selected);

			typeDropdown.options.Add(new Dropdown.OptionData(selected));
			selectedTypeDropDown.ClearOptions();
			selectedTypeDropDown.AddOptions(list);

		}
	}
}
