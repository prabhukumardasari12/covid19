using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HelpScreenManager : MonoBehaviour {

    public GameObject mouseRightClick;
    public GameObject pressW;
    public GameObject pressS;
    public GameObject pressA;
    public GameObject pressD;

    public GameObject Ok_Button;
    public GameObject Text;

    private bool isMousePress = false;
    private bool isWpress = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(1)) {
            mouseRightClick.transform.localScale = Vector3.one * 1.3f;
            mouseRightClick.GetComponent<Image>().color = Color.red;
            isMousePress = true;
        } else if (Input.GetMouseButtonUp(1)) {
            mouseRightClick.transform.localScale = Vector3.one;
            mouseRightClick.GetComponent<Image>().color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            pressW.transform.localScale = Vector3.one * 1.3f;
            pressW.GetComponent<Image>().color = Color.red;
            isWpress = true;
        }
        else if (Input.GetKeyUp(KeyCode.W)) {
            pressW.transform.localScale = Vector3.one;
            pressW.GetComponent<Image>().color = Color.white;
		

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            pressS.transform.localScale = Vector3.one * 1.3f;
            pressS.GetComponent<Image>().color = Color.red;
			isWpress = true;

        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            pressS.transform.localScale = Vector3.one;
            pressS.GetComponent<Image>().color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            pressA.transform.localScale = Vector3.one * 1.3f;
            pressA.GetComponent<Image>().color = Color.red;
			isWpress = true;

        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            pressA.transform.localScale = Vector3.one;
            pressA.GetComponent<Image>().color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            pressD.transform.localScale = Vector3.one * 1.3f;
            pressD.GetComponent<Image>().color = Color.red;
			isWpress = true;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            pressD.transform.localScale = Vector3.one;
            pressD.GetComponent<Image>().color = Color.white;
        }

        if (isMousePress && isWpress) {
            Ok_Button.SetActive(true);
            Text.SetActive(true);
        }
    }
}
