using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVoiceOver : MonoBehaviour {
	
	public AudioSource VoAudioSrc;
    public bool isOst = true;

	void Awake(){
		
	}

	void OnEnable(){
		Play_VoiceOver ();
        if (!isOst) {
            StartCoroutine("DestroyAnimator");
        }
	}

	// Use this for initialization
	void Start () {
		
	}

	public void Play_VoiceOver(){
		AudioClip clip = (AudioClip) Resources.Load("voiceOver/"+this.gameObject.name);
		VoAudioSrc.clip = clip;
		VoAudioSrc.Play ();
	}

	void OnDisable(){
		if(VoAudioSrc!=null){
			VoAudioSrc.Stop ();
		}
	}

    IEnumerator DestroyAnimator()
    {
        yield return new WaitForSeconds(VoAudioSrc.clip.length);
		Animator anim = GetComponentInChildren<Animator>();
		if (anim != null) {
			anim.SetTrigger("stop");
		}
    }

    //void OnDestroy(){
    //VoAudioSrc.Stop ();
    //}
}
