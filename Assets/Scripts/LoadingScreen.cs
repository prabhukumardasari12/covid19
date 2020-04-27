using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SceneManager.LoadSceneAsync ("COGNIZANT");
	}

}
