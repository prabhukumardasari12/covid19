using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using IBM.Watson.Examples;

public class Level1Manger : MonoBehaviour {

    public static Level1Manger instance;
    public GameObject player;
    public Animator hand;
    public GameObject leftHand;
    public GameObject rightHand;
    public SkinnedMeshRenderer leftHandMesh;
    public SkinnedMeshRenderer rightHandMesh;
    public Material mat_LeftGloves;
    public Material mat_RightGloves;
    public Transform finalPosition;
	public Transform Location_Experiment;
    public Image FadeImg;
    public GameObject main_Animation;
	public GameObject main_Animation2;
    public GameObject main_door;

    public Image progressBar;
    public Text percentage;
    public Animator Listanimation;
	public Text listcount;
	public Text listcount2;

	public Button ok_Experiment_1;
	public Button ok_Experiment_2;

	public GameObject theory_nitropruside;
	public GameObject theory_aceticAcid;

    private Vector3 achualPositon_R;
    private Vector3 achualrotation_R;
    private Vector3 achualPositon_L;
    private GameObject tempPickableObj;
    private bool isFinalTriggerOn = false;
	private int count_Assests = 0;
	private int experimentNumber=0;


    public GameObject faceshield;
    public GameObject gloves;
    public GameObject labcoat;
    public GameObject mask;
    void Awake() {
        instance = this;
    }
    public Button yourButton;
    // Use this for initialization

    public Transform _maskpos;
    public Transform _nmaskpos;
    void Start() {
        achualPositon_R = rightHand.transform.localPosition;
        achualPositon_L = leftHand.transform.localPosition;
        achualrotation_R = rightHand.transform.localEulerAngles;
       // bothhandspos = hand.gameObject.transform.localPosition;
		QualitySettings.vSyncCount = 1;
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        Debug.Log("clicked");
    }
    // Update is called once per frame
    void Update()
    {		
        if(Input.GetKeyDown(KeyCode.A))
        {
            OpentheDoor();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            CloseDoor();
        }
        //		#if UNITY_WEBGL
        //		#elif
        //		if (Input.GetKeyDown (KeyCode.Escape)) {
        //			Exit ();
        //		}
        //		#endif
    }

    //Open Locker Door
    public void OpenLockerdoor(GameObject lockerdoor) {
        if (lockerdoor.transform.eulerAngles.y == 0) {
            lockerdoor.transform.DOLocalRotate(Vector3.up * 90, 1f);
        } else {
            CloseLockerdoor(lockerdoor);
        }
    }
    private void CloseLockerdoor(GameObject lockerdoor)
    {
        lockerdoor.transform.DOLocalRotate(Vector3.zero, 1f);
    }


    public static bool appliedsanitizer = false;
    private GameObject _temp;
    public void Movemask(GameObject _mask)
    {
        if (appliedsanitizer == false)
        {
            StartCoroutine(SanitizerHelpObj());
            return;
        }
        _temp = _mask;
        if (_temp.gameObject.name == "face_shield")
        {
            _mask.transform.rotation = _maskpos.rotation;
            _mask.transform.parent = player.transform;
            _mask.transform.DOMove(_maskpos.position, 1f);
        }
        if (_temp.gameObject.name == "Mask")
        {
            _mask.transform.rotation = _nmaskpos.rotation;
            _mask.transform.parent = player.transform;
            _mask.transform.DOMove(_nmaskpos.position, 1f);
        }
           
        StartCoroutine(ActiveMask());
    }

    public void SanitizerHelp()
    {
        StartCoroutine(SanitizerHelpObj());
    }
    public GameObject _sanihelp;
    IEnumerator SanitizerHelpObj()
    {
        _sanihelp.SetActive(true);
        yield return new WaitForSeconds(1);
        _sanihelp.SetActive(false);
    }
    IEnumerator ActiveMask()
    {
        
        yield return new WaitForSeconds(1.2f);
        if (_temp.gameObject.name == "face_shield")
        {
            faceshield.SetActive(true);
        }
        if(_temp.gameObject.name== "Mask")
        {
            mask.SetActive(true);
            _temp.SetActive(false);
        }

    }
    public void CloseDoor() {
        main_door.GetComponent<Animator>().SetTrigger("Close");

        for (int i = 0; i < main_door.transform.childCount; i++) {
			//main_door.transform.GetChild(i).GetComponent<Collider>().enabled = true;
        }
    }

	public void UpdateListCount(){
		if (getExperimentNumber() == 0) {
			count_Assests += 1;
			listcount.text = "" + count_Assests;
		} else if (getExperimentNumber () == 1) {
			count_Assests += 1;
			listcount2.text = "" + count_Assests;
		}
	}
    //Pick an Object
    public void PickObject(pickAbleobj obj) {

        if(appliedsanitizer==false && obj.gameObject.name != "Sanitizer_Anim_01")
        {
            StartCoroutine(SanitizerHelpObj());
            return;
        }
        if (obj.isrightObj)
        {
            tempPickableObj = obj.gameObject;
            tempPickableObj.GetComponent<Collider>().enabled = false;
            Camera.main.gameObject.GetComponent<PhysicsRaycaster>().enabled = false;
            Camera.main.gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = false;
            rightHand.transform.DOMove(obj.pickposition.transform.position, .5f).OnComplete(PickAnimation);
            rightHand.transform.DORotate(obj.pickposition.transform.eulerAngles, .5f);
            hand.SetTrigger("grab");
        }
        else {
          //  tempPickableObj = obj.gameObject;
            //tempPickableObj.GetComponent<Collider>().enabled = false;
            //Camera.main.gameObject.GetComponent<PhysicsRaycaster>().enabled = false;
            Camera.main.gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = false;
            hand.transform.DOMove(obj.pickposition.transform.position, .5f);
            //leftHand.transform.DOMove(obj.pickposition.transform.position, .5f);
           // rightHand.transform.DOMove(obj.pickposition.transform.position, .5f).OnComplete(PickAnimation);
            //rightHand.transform.DORotate(obj.pickposition.transform.eulerAngles, .5f);
            hand.SetTrigger("sanitizer");
            StartCoroutine(Sanitizer());
            // Alert choose right object
        }
    }
    public GameObject _sanitizer;
    public Transform bothhandspos;
      IEnumerator Sanitizer()
    {
        yield return new WaitForSeconds(0.5f);
        _sanitizer.GetComponent<Animator>().SetTrigger("sanitizer");
        yield return new WaitForSeconds(3);
        hand.transform.DOMove(bothhandspos.transform.position, .5f);
        yield return new WaitForSeconds(3);
        Camera.main.gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = true;
        appliedsanitizer = true;
        //tempPickableObj.GetComponent<pickAbleobj>().ObjPicked();

    }
    private void PickAnimation() {
        StartCoroutine(ResetPositon());
    }
    IEnumerator ResetPositon() {
        yield return new WaitForSeconds(.7f);
        tempPickableObj.transform.parent = rightHand.transform;
        Camera.main.gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = true;
        rightHand.transform.DOLocalMove(achualPositon_R, .5f).OnComplete(DestroyObj);
        rightHand.transform.DOLocalRotate(achualrotation_R, .5f);
        tempPickableObj.GetComponent<pickAbleobj>().ObjPicked();
    }

    private void DestroyObj() {
        if (tempPickableObj.name.Equals("Gloves")) {
            leftHandMesh.material = mat_LeftGloves;
            rightHandMesh.material = mat_RightGloves;
        }
        tempPickableObj.GetComponent<pickAbleobj>()._obj.SetActive(true);
        tempPickableObj.SetActive(false);
        tempPickableObj = null;
     //   Listanimation.SetTrigger("greenflask");
        progressBar.fillAmount += .0385f;
        percentage.text = "+ " + (int)(progressBar.fillAmount * 100) + "%";
        Camera.main.gameObject.GetComponent<PhysicsRaycaster>().enabled = true;
    }


    //  Stop First person controller functioning
    public void StopMovement() {
        Camera.main.gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = false;
        Camera.main.GetComponent<PhysicsRaycaster>().enabled = false;
    }

    public void StartMovement()
    {
        Camera.main.gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = true;
        Camera.main.GetComponent<PhysicsRaycaster>().enabled = true;
        if (isFinalTriggerOn) {
            StartNewlevel();
        }
    }

    public void StartNewlevel() {
        Camera.main.gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = false;
        Camera.main.GetComponent<PhysicsRaycaster>().enabled = false;
        player.transform.DOMove(finalPosition.position, .5f).OnComplete(startcamera);
        Camera.main.transform.DOLocalRotate(finalPosition.localEulerAngles, .5f);
        player.transform.eulerAngles = Vector3.zero;
        FadeImg.gameObject.SetActive(true);
        isFinalTriggerOn = true;
    }

    private void startcamera() {
        hand.gameObject.SetActive(false);
        Camera.main.GetComponent<PhysicsRaycaster>().enabled = true;
        for (int i = 0; i < finalTrigger.instance.itemenabled.Length; i++) {
//            finalTrigger.instance.itemenabled[i].SetActive(false);
        }
		if(getExperimentNumber()==0){
			main_Animation.SetActive(true);
		}else if (getExperimentNumber()==1){
			main_Animation2.SetActive (true);
		}
    }

	public void StartExperiment_2(){
		Camera.main.gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = true;
		Camera.main.GetComponent<PhysicsRaycaster>().enabled = true;
		player.transform.DOMove (Location_Experiment.position, .5f);
		main_Animation.SetActive (false);

		player.transform.eulerAngles = Location_Experiment.localEulerAngles;
		FadeImg.gameObject.SetActive(true);
		isFinalTriggerOn = false;
		hand.gameObject.SetActive(true);			
		setExperimentNumber (1);
		count_Assests = 0;
		ok_Experiment_2.onClick.Invoke ();
	}

	public void StartExperiment_1(){
			Camera.main.gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = true;
			Camera.main.GetComponent<PhysicsRaycaster>().enabled = true;
			player.transform.DOMove (Location_Experiment.position, .5f);
			main_Animation2.SetActive (false);

			player.transform.eulerAngles = Location_Experiment.localEulerAngles;
			FadeImg.gameObject.SetActive(true);
			isFinalTriggerOn = false;
			hand.gameObject.SetActive(true);			
			setExperimentNumber (0);
			count_Assests = 0;
			ok_Experiment_1.onClick.Invoke ();
	
	}

	public void setExperimentNumber(int i){
		experimentNumber = i;
	}
	public int getExperimentNumber(){
		return experimentNumber;
	}

    public void Restart() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void Exit() {
        Application.Quit();
    }

    public void OnClickHelpButton(GameObject obj) {
        if (main_door.GetComponentInChildren<Collider>().enabled) {
            obj.SetActive(true);
        }
    }


    public void volumeOnClick() {
        GetComponent<AudioSource>().mute=true;
        player.GetComponent<AudioSource>().mute = true;
    }

    public void volumeOffClick() {
        GetComponent<AudioSource>().mute = false;
        player.GetComponent<AudioSource>().mute = false;

    }

    public void QuitButtonClick() {
        Time.timeScale = 0;
    }

    public void Quit_No_Click() {
        Time.timeScale = 1;
    }

	public void showTheory(){
		if (getExperimentNumber () == 0) {
			theory_aceticAcid.SetActive (true);
		}else{
			theory_nitropruside.SetActive(true);
		}
	}

	public void hideTheory(){
		theory_aceticAcid.SetActive (false);
		theory_nitropruside.SetActive (false);
	}

    public GameObject _doorhelp;
    public void OpentheDoor()
    {
        StartMovement();
        main_door.gameObject.GetComponent<Animator>().SetTrigger("Open");
        //OnClickHelpButton(_doorhelp);
       // Ostmanager.instance.nextOSt(0);
    }
    
}
