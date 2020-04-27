using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCollider : MonoBehaviour {

    public Collider[] colliders;
	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player")) {
            for (int i=0;i< colliders.Length;i++) {
                colliders[i].enabled = true;
            }
            Level1Manger.instance.CloseDoor();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name.Equals("Player"))
        {
            for (int i = 0; i < colliders.Length; i++) {
                colliders[i].enabled = false;
            }
        }
    }
}
