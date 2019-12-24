using UnityEngine;
using System.Collections;

public class MainMenuMusic : MonoBehaviour {
	public float Tme;
	// Use this for initialization
	void Start () {
		Tme = 0;
	}
	
	// Update is called once per frame
	void Update () {
		AudioSource AS = gameObject.GetComponent<AudioSource> ();
		Tme += Time.deltaTime;
		if(Tme > 2.0f){
			AS.enabled = true;

		}
	}
}
