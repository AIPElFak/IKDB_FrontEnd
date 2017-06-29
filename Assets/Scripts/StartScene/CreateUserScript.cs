using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

public class CreateUserScript : MonoBehaviour {

	public GameObject serverRequest;
	public RegisterServerRequestScript serverRequestScript;
	public InputField username;
	public InputField password;
	public InputField email;
	public GameObject panelHolder;
	PanelHolderScript panelHolderScript;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}



	public void onCreateUserClick()
	{
		serverRequestScript = serverRequest.GetComponent<RegisterServerRequestScript>();
		serverRequestScript.createUserRequest(username.text, password.text, email.text, onCreateUserCallback);

	}
	public void onCreateUserCallback(string s)
	{
		
		if (s != null)
		{
			EditorUtility.DisplayDialog("Error", "An error occurred", "Ok");
		}
		else
		{
			panelHolderScript = panelHolder.GetComponent<PanelHolderScript> ();
			EditorUtility.DisplayDialog("Success", "Successfully created user account. Check your email to verify", "Ok");
			panelHolderScript.signupPanel.SetActive (false);
			panelHolderScript.loginPanel.SetActive (true);
		}
	}
}
