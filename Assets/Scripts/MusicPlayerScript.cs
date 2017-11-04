using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayerScript : MonoBehaviour {

	static public bool startAudio = true;
	public GameObject musicPlayer;
	public AudioClip mainMusic;
	public AudioSource audioSource;

	void Awake() {
		if (startAudio) {
			DontDestroyOnLoad (this.audioSource);
			startAudio = false;
			this.audioSource.clip = this.mainMusic;
			this.audioSource.Play();
			this.audioSource.loop = true;
		}
	}
}
/*
private GameObject Jugador_1;
     private GameObject MainCamera;
     public AudioClip musicaFinal;
     void Start () {
         Jugador_1 = GameObject.FindWithTag("Player");
         MainCamera = GameObject.FindWithTag("MainCamera");
     }
     void OnTriggerEnter2D(Collider2D colisionador) {
         if (colisionador.gameObject.tag == "Player") {
             MainCamera.GetComponent<AudioSource>().Stop();
             if (musicaFinal != null) {
                 audio.clip = musicaFinal;
                 audio.Play();
                 audio.loop = true;
             }
         }
     }
*/
