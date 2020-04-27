using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AnimationEvents : MonoBehaviour {
    public Collider[] Colliders;
    public GameObject[] particles;
    public GameObject[] precautions;
    public GameObject flame;
    public GameObject abstact_Particle;

    public GameObject sodiumPiece;
    private GameObject tempsodium;
	private Vector3 initialPosition_Camera;
	private Vector3 initialRotation_Camera;


    public GameObject wirgauge;
    public GameObject breaktube;
    public GameObject achualtube;
    public GameObject fusioncompound;
    public GameObject testtubeCompound;
    public GameObject redhotFusion;
    public MeshRenderer fillDropper;
    public GameObject tripod;
    public GameObject drop2nd;
    public GameObject fusionPenal;
    public GameObject testTube_Penal;
    public Transform finalPosition;
    public GameObject lastMassage;
	public Transform zoomInpos_Camera;

    public AudioClip breaktube_Clip;
    public AudioClip click_clip;
    public AudioClip penal_clip;

    // Use this for initialization
    void Start() {
		initialPosition_Camera = Camera.main.transform.localPosition;
		initialRotation_Camera = Camera.main.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update() {

    }

    void DisablePaper(float value) {

    }

    public void DisableAllCollider() {
        for (int i = 0; i < Colliders.Length; i++) {
            Colliders[i].enabled = false;
            particles[i].SetActive(false);
        }
    }

    public void NextcolliderOn(int i) {
        DisableAllCollider();
        Colliders[i].enabled = true;
        particles[i].SetActive(true);
    }

    public void FlameOn() {
        flame.SetActive(true);
    }
    public void FlameOff() {
        flame.SetActive(false);
    }

    public void Placesodium() {
        sodiumPiece.SetActive(false);
        tempsodium = Instantiate(sodiumPiece, null) as GameObject;
        tempsodium.transform.position = Vector3.zero;
        tempsodium.SetActive(true);
    }
    public void disablesodium() {
        sodiumPiece.SetActive(true);
        Destroy(tempsodium);
    }

    public void wiregaudEvent() {
        wirgauge.SetActive(false);
        tempsodium = Instantiate(wirgauge, null) as GameObject;
        tempsodium.transform.localPosition = wirgauge.transform.position;
        tempsodium.SetActive(true);
    }

    public void breakTube() {
        achualtube.SetActive(false);
        breaktube.SetActive(true);
        Level1Manger.instance.player.GetComponent<AudioSource>().PlayOneShot(breaktube_Clip);
    }

    public void FillDropper() {
        fillDropper.gameObject.SetActive(true);
    }

    public void showTripod() {
        tripod.SetActive(true);
    }

    public void Play_click_sound() {
        Level1Manger.instance.player.GetComponent<AudioSource>().PlayOneShot(click_clip);
    }

    public void ProcessEncrement() {
        StopCoroutine("Increement");
        StartCoroutine("Increement");
    }

	public void ShowDrop2nd(){
		drop2nd.SetActive (true);
	}

    IEnumerator Increement() {
        yield return new WaitForEndOfFrame();
        Level1Manger.instance.progressBar.fillAmount = Level1Manger.instance.progressBar.fillAmount + 0.0385f;
        Level1Manger.instance.percentage.text = "+ " + (int)(Level1Manger.instance.progressBar.fillAmount * 100) + "%";
    }

    public void Play_penal_sound()
    {
        Level1Manger.instance.player.GetComponent<AudioSource>().PlayOneShot(penal_clip);
    }

    public void FinalComplete() {
		Camera.main.transform.DOLocalMove (zoomInpos_Camera.position, 1f);
		Camera.main.transform.DOLocalRotate (zoomInpos_Camera.localEulerAngles, 1f);

//      EnableLastMsg(
		Invoke("ShowFinalTube_Penal",8f);
//		ShowFinalTube_Penal ();
    }
    void EnableLastMsg()
    {
        lastMassage.SetActive(true);
    }

    public void NextActivity(int i) {
       

		if (Level1Manger.instance.getExperimentNumber () == 0) {
			Ostmanager.instance.nextOSt(i);
		} else {
			Ostmanager.instance.nextOSt(i+4);
		}
    }

    public void Nextprecautions(int i) {
		if (precautions.Length > i) {
			Ostmanager.instance.hideAllOst ();
			precautions [i].SetActive (true);
			Play_penal_sound ();
			this.GetComponent<Animator> ().speed = 0;
		}
	}

    public void Fusioncompound_ON() {
        fusioncompound.SetActive(true);
        fillDropper.gameObject.SetActive(false);
		disolve ();
    }

	public void disolve(){
		if (Level1Manger.instance.getExperimentNumber () == 1) {
			tripod.GetComponent<MeshRenderer> ().material.DOColor (new Color32(0,0,0,255), 1.5f).SetDelay(3f);	
		} else {
			tripod.GetComponent<MeshRenderer> ().material.DOColor (new Color32(67,6,92,255), 1.5f).SetDelay(3f);
		
		}
	}

    public void Testtubefinal() {
        testtubeCompound.SetActive(true);
    }

    public void Redhotfusion() {
        redhotFusion.SetActive(true);
		achualtube.SetActive (false);
//        testtubeCompound.SetActive(false);
    }

    public void MakeFinal() {
        this.GetComponent<Animator>().SetTrigger("Final");
    }

    public void ShowchinaDish() {
        // show penal of Break fusion tube in china dish
		Ostmanager.instance.hideAllOst();
        fusionPenal.SetActive(true);
        Play_penal_sound();
        this.GetComponent<Animator>().speed = 0;
    }

    public void ShowFinalTube_Penal()
    {
        testTube_Penal.SetActive(true);
		Camera.main.transform.DOLocalMove (initialPosition_Camera, 1f);
		Camera.main.transform.DOLocalRotate (initialRotation_Camera, 1f);
        Play_penal_sound();
        this.GetComponent<Animator>().speed = 0;
    }

    public void startpouring() {
        abstact_Particle.SetActive(true);
    }

    public void stoppouring() {
        abstact_Particle.SetActive(false);
    }

}
