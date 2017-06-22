using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
		//Debug.Log (subjects[0]);
		DataHandler.Subjects=subjects;

		//nova scena se tu otvara
		SceneManager.LoadScene("MainMenuScene");

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