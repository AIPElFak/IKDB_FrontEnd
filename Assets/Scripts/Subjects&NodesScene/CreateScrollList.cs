using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEditor;

[System.Serializable]
public class item
{
	public string name;
	// public Button.ButtonClickedEvent thingToDo;
	// public Toggle.ToggleEvent toggleToDo;

	public item(string name)
	{
		this.name = name;
	}

}

public class CreateScrollList : MonoBehaviour
{


	void Start()
	{
		PopulateList();


	}

	public  void PopulateList()
	{
		
	}

	public void populateNodeList()
	{
		
	}

	public void clearNodeList()
	{
		
	}



}
