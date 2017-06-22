using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManagerScript : MonoBehaviour {

	public GameObject listController;
	SubjectsScrollList subjectsScrollList;
	// Use this for initialization
	void Start () {
		subjectsScrollList = listController.GetComponent<SubjectsScrollList> ();
		subjectsScrollList.PopulateSubjectsList ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
