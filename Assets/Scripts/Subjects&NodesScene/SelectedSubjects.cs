using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class SelectedSubjectsClass  {

	private static List<string> selectedSubjects;
	public static List<string> SelectedSubjects {
		get {
			return selectedSubjects;
		}
		set {
			selectedSubjects=value;
		}
	}

	private static Text selectedSubjectsText;
	public static Text SelectedSubjectsText {
		get {
			return selectedSubjectsText;
		}
		set {
			selectedSubjectsText=value;
		}
	}

	public static void addToList(string name)
	{
		if(SelectedSubjects.Contains(name))
			SelectedSubjects.Add(name);
		if (selectedSubjects.Count > 0)
		{
			selectedSubjectsText.text = selectedSubjects[0];
			for (int i = 1; i < selectedSubjects.Count; i++)
			{
				selectedSubjectsText.text += "," + selectedSubjects[i];
			}
		}
		else
		{
			selectedSubjectsText.text = "";
		}
	}

	public static void removeFromList(string name)
	{
		if(selectedSubjects.Contains(name))
			selectedSubjects.Remove(name);
		if (selectedSubjects.Count > 0)
		{
			selectedSubjectsText.text = selectedSubjects[0];
			for (int i = 1; i < selectedSubjects.Count; i++)
			{
				selectedSubjectsText.text += "," + selectedSubjects[i];
			}
		}
		else
		{
			selectedSubjectsText.text = "";
		}
	}
}
