using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPerfom : MonoBehaviour {
    public GameObject uiPenal;
    public bool isOst;
// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

    }

    public Transform _lookatobj;
    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player"))
        {
            gameObject.SetActive(false);
            uiPenal.SetActive(true);
            other.transform.LookAt(_lookatobj);
            Level1Manger.instance.StopMovement();
            /*if (isOst)
            {
                Ostmanager.instance.hideAllOst();
            }
            else {
                Ostmanager.instance.hideAllOst();
                Level1Manger.instance.StopMovement();
            }
            uiPenal.SetActive(true);*/
        }
    }

   
}
