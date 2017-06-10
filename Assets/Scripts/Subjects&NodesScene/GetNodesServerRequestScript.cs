using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LitJson;
using UnityEditor;

public class GetNodesServerRequestScript : MonoBehaviour  {

	public  void categoriesNodeRequest(List<string> categories, Action<List<Node>> categoriesCallback)
	{
		if (categories.Count != 0)
		{
			string pom = "[";
			for (int i = 0; i < categories.Count - 1; i++)
			{
				pom += "\"" + categories[i] + "\",";
			}
			pom += "\"" + categories[categories.Count - 1] + "\"]";
			string data = "{\"labels\":" + pom + "}";
			Debug.Log(data);
			Dictionary<string, string> header = new Dictionary<string, string>();
			header.Add("Content-Type", "application/json");
			header.Add("token", DataHandler.Token);
			var byteData = System.Text.UTF8Encoding.UTF8.GetBytes(data);
			WWW www = new WWW(DataHandler.serverIP + ": 3000 /secure/getnodeswithlabels", byteData, header);
			StartCoroutine(waitForCategoriesNodeResponse(www, categoriesCallback));
		}
		else
		{
			//svi cvorovi da se vrate ?
		}
	}

	 IEnumerator waitForCategoriesNodeResponse(WWW www,Action<List<Node>> categoriesCallback)
	{
		yield return www;

		if (www.error == null)
		{
			//  Debug.Log(www.text);
			List<Node> nodeArray = JsonMapper.ToObject<List<Node>>(www.text);
			//   Debug.Log("nodeArray[0] : "+nodeArray[0].name);
			categoriesCallback(nodeArray);
			//  Debug.Log(nodeArray);
		}
		else
		{

			EditorUtility.DisplayDialog("An error occured", www.text, "Ok");

		}
	}
}
