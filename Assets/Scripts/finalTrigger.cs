using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalTrigger : MonoBehaviour {
    public static finalTrigger instance;
    public GameObject[] itemenabled;
    public GameObject[] itemDisabled;
   

    void Awake() {
        instance = this;
    }
	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player"))
        {
			

            for (int i = 0; i < itemenabled.Length; i++)
            {
				
                itemenabled[i].SetActive(true);
				print ("Ontrigger "+i+" = "+itemenabled[i].name);
            }

            for (int i = 0; i < itemDisabled.Length; i++)
            {
                itemDisabled[i].SetActive(false);
            }
            startnewLevle();
        }
    }

    private void startnewLevle() {
		Level1Manger.instance.StartNewlevel ();
		Ostmanager.instance.nextOSt (5);

		for (int i = 0; i < itemenabled.Length; i++) {
			print ("Ontrigger " + i + " = " + itemenabled [i].name);
		}
	}

	public void Skip()
	{
		for (int i = 0; i < itemenabled.Length; i++)
		{
			itemenabled[i].SetActive(true);
		}

		for (int i = 0; i < itemDisabled.Length; i++)
		{
			itemDisabled[i].SetActive(false);
		}
		startnewLevle();
	}
    
}
