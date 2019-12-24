using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeToBlack : MonoBehaviour {

	void OnEnable () {
		SceneManager.LoadScene (2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
