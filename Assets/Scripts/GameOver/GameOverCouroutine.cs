using UnityEngine;
using System.Collections;

public class GameOverCouroutine : MonoBehaviour {
	public Animator Game;
	public Animator Over;
	public AudioSource GameOverMusic;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator GameOver(float duration){
		yield return new WaitForSeconds (duration);
		Game.Play ("Game");
		Over.Play ("Over");
		GameOverMusic.Play ();
	}
}
