using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DropdownScript : MonoBehaviour {

	public Dropdown allTypesDropdown;
	public Dropdown typeDropdown;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	public void moveToSelected()
	{
		if (allTypesDropdown.options.Count > 0)
		{
			List<string> list = new List<string>();

			for (int i = 0; i < allTypesDropdown.options.Count; i++)
			{
				list.Add(allTypesDropdown.options[i].text);
			}
			string selected = allTypesDropdown.options[allTypesDropdown.value].text;
			list.Remove(selected);

			typeDropdown.options.Add(new Dropdown.OptionData(selected));
			allTypesDropdown.ClearOptions();
			allTypesDropdown.AddOptions(list);

		}
	}
	public void removeFromSelected()
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

			allTypesDropdown.options.Add(new Dropdown.OptionData(selected));
			typeDropdown.ClearOptions();
			typeDropdown.AddOptions(list);

		}
	}
}
