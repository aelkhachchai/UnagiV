using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public string next;
	public AudioSource source;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Next () {
		SceneManager.LoadScene(next);
	}

	public void Play() {
		source.Play();
		Next();
	}
}
