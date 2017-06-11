using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToPreviousScene : MonoBehaviour {

	public void backToPreviousSceneClick() {
		SceneManager.LoadScene (1);
	}
}
