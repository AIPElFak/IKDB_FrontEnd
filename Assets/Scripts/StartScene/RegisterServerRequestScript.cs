using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RegisterServerRequestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void createUserRequest(string username, string password, string email, Action<string> createUserCallback)
    {
        string data = "{\"username\":\"" + username + "\",\"password\":\"" + password + "\",\"email\":\"" + email + "\"}";
        Dictionary<string, string> header = new Dictionary<string, string>();
        header.Add("Content-Type", "application/json");
        var byteData = System.Text.UTF8Encoding.UTF8.GetBytes(data);
        WWW www = new WWW(DataHandler.serverIP + ": 3000 /createuser", byteData, header);
        StartCoroutine(waitForCreateUserResponse(www, createUserCallback));
    }

    IEnumerator waitForCreateUserResponse(WWW www, Action<string> createUserCallback)
    {
        yield return www;
        createUserCallback(www.error);
    }

}

