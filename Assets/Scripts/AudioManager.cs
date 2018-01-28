using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    static public AudioManager instance;
    private AudioSource audio;
    public AudioClip[] audioClips;
	// Use this for initialization
	void Start () {
        instance = this;
        audio = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void playeButton() {
        audio.clip = audioClips[0];
        audio.volume = 0.8f;
        audio.pitch = 1.5f;
        audio.Play();
    }

    public void playPlanet() {
        audio.clip = audioClips[1];
        audio.volume = 0.8f;
        audio.Play();
    }

    public void getScore() {
        audio.clip = audioClips[2];
        audio.volume = 0.8f;
        audio.Play();
    }

    public void minusScore() {
        audio.clip = audioClips[3];
        audio.volume = 0.8f;
        audio.Play();
    }
}
