using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LitJson;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LoginRequestScript : MonoBehaviour {


	private string userId;
	public string[] allLabels;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void loginRequest(string user,string password,Action<string[]> loginCallback)
	{
		string data = "{\"username\":\"" + user + "\",\"password\":\"" + password + "\"}";
		//  string data = "{username:" + user + ",password:" + password + "}";
		Dictionary<string, string> header = new Dictionary<string, string>();
		header.Add("Content-Type", "application/json");
		var byteData = System.Text.UTF8Encoding.UTF8.GetBytes(data);
		WWW www = new WWW(DataHandler.serverIP+": 3000 /login", byteData, header);
		StartCoroutine(waitForLoginResponse(www, loginCallback));
	}



	IEnumerator waitForLoginResponse(WWW www,Action<string[]> loginCallback)
	{
		yield return www;

		if(www.error == null)
		{
			LoginResponse loginResponse = JsonMapper.ToObject<LoginResponse>(www.text);
			DataHandler.Token = loginResponse.token;
			DataHandler.UserId = loginResponse.user_id;
			//this.allLabels = loginResponse.labels;
			loginCallback(loginResponse.labels);
			//Debug.Log(DataHandler.token);
		}
		else
		{

//			EditorUtility.DisplayDialog("An error occured", www.text, "Ok");
			Debug.Log("Login error");
			Debug.Log (www.text);

		}
	}
}
public class LoginResponse
{
	public string token;
	public string[] labels;
	public string user_id;
}
