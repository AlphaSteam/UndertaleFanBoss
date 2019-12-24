using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	public Text Life;
	public GameObject Hearth;
	public GameObject Bar;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PlayerHealth Health = Hearth.GetComponent<PlayerHealth> ();
		HealthBar Max = Bar.GetComponent<HealthBar> ();
		Life.text =( Health.PHealth.ToString() + " / " + Max.MaxLife.ToString());
	}
}
