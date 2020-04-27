using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObjManager : MonoBehaviour {
    public pickAbleobj[] Obj;
   // public GameObject backgroundPenal;
    public GameObject dialogBox_UI;
	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Show_dialog() {
        for (int i=0;i<Obj.Length;i++) {
          if(!Obj[i].ispicked){
                return;
          }
        }
        Level1Manger.instance.StopMovement();
        //backgroundPenal.SetActive(true);
        Ostmanager.instance.hideAllOst();
        dialogBox_UI.SetActive(true);
        this.gameObject.SetActive(false);
    }
    
}
