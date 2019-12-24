using UnityEngine;
using System.Collections;

public class HeartPositionInGameOver : MonoBehaviour {
	public GameObject HeartFragments;
	// Use this for initialization
	void Start () {
		//gameObject.transform.position = HeartMove.HeartPositionTransform;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = HeartMove.HeartPositionTransform;
		//HeartFragments.transform.position = HeartMove.HeartPositionTransform;
	}
}
