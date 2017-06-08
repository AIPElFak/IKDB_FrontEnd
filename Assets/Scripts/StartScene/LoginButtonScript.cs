using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginButtonScript : MonoBehaviour {

	public InputField tbUsername;
	public InputField tbPassword;
	public GameObject loginRequestObject;
	//public GameObject scrollListController;
	// public Canvas canvas;
	// public RectTransform loginPanel;
//	GameObject loginPanel;
//	GameObject subjectsPanel;
//	public static GameObject nodesPanel;
	LoginRequestScript loginRequestScript;

	public void login()
	{
		// serverRequestScript = new ServerRequestScript();
		string username = tbUsername.text;
		string password = tbPassword.text;
		loginRequestScript = loginRequestObject.GetComponent<LoginRequestScript>();
		loginRequestScript.loginRequest(username,password,startSubjectsPanel);
	}

	public void startSubjectsPanel(string[] subjects)
	{
		//Debug.Log(subjects);
		//Debug.Log("Sada se otvara novi panel");
	//	CreateScrollList scrollListScript = scrollListController.GetComponent<CreateScrollList>();
	//	scrollListScript.subjectList = subjects;
	//	scrollListScript.PopulateList();
		// loginPanel = GameObject.Find("PanelLogin");
		// loginPanel.gameObject.SetActive(false);

		//   subjectsPanel = GameObject.Find("SubjectsPanel");
		DataHandler.Subjects=subjects;

	}

	// Use this for initialization
	void Start () {
		//subjectsPanel = GameObject.Find("SubjectsPanel");
		//subjectsPanel.gameObject.SetActive(false);
		//nodesPanel = GameObject.Find("PanelWithNodes");
		//nodesPanel.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update () {

	}
}