using UnityEngine;
using System.Collections;

public class RandomForce : MonoBehaviour {
	public static Vector2 Force = new Vector2();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Force.x = Random.Range (500, 1000);
		Force.y = Random.Range (2000, 2500);
	}
}
