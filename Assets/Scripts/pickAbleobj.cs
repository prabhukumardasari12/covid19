using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class pickAbleobj : MonoBehaviour {

    public Transform pickposition;
    public bool isrightObj;
    public bool ispicked;
    public PickObjManager manager;
    public GameObject icon;
    public Button bttn;

    public GameObject _obj;
    // Use this for initialization
    void Start () {
		
	}

    public void ObjPicked() {
        if (Level1Manger.appliedsanitizer == false)
        {
            //Level1Manger.instance.SanitizerHelp();
            return;
        }

        if (!ispicked) {
            ispicked = true;
            manager.Show_dialog();
            if (icon != null)
            {
                bttn.onClick.Invoke();
				Level1Manger.instance.UpdateListCount ();
            }
        }
    }
}
