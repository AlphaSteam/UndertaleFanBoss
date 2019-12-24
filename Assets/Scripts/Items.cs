using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Items : MonoBehaviour {
	Text Item;
	public string Item1;
	void Start (){
	
		Item = GetComponent<Text> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		Item.text = Item1;

	}
}
