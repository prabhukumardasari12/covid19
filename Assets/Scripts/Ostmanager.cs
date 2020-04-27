using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ostmanager : MonoBehaviour {
    public static Ostmanager instance;
    public GameObject[] osts;


    void Awake() {
        instance = this;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void nextOSt(int count) {
        hideAllOst();
        osts[count].SetActive(true);
    }

    public void hideAllOst() {
        for (int i=0;i< osts.Length;i++) {
            osts[i].SetActive(false);
        }
    }

}
