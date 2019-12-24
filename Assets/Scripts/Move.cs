using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public GameObject Heart;
	public GameObject ItemPos1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Heart.transform.position = ItemPos1.transform.position;
	}
}
