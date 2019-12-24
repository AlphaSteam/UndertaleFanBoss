using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITextTypeWriterDance2 : MonoBehaviour
{

	 Text txt;
	public string story;
	public bool PlayOnAwake = true;
	public float Delay;
	public AudioSource Fx;
	public GameObject Heart;



	public void Awake()
	{
		txt = GetComponent<Text>();
		if (PlayOnAwake)
			ChangeText(txt.text, Delay);
	}

	//Update text and start typewriter effect
	public void ChangeText(string _text, float _delay)
	{
		StopCoroutine(PlayText()); //stop Coroutime if exist
		story = _text;
		txt.text = ""; //clean text
		Invoke("Start_PlayText", _delay); //Invoke effect

	}

	void Start_PlayText()
	{ 
		StartCoroutine(PlayText());
	}

	IEnumerator PlayText()
	{
		foreach (char c in story)
		{
			
			txt.text += c;
			Fx.Stop ();
			Fx.Play ();
			yield return 0;
			yield return new WaitForSeconds(Delay);


		}
		HeartMove HM = Heart.GetComponent<HeartMove> ();
		HM.Dance2Finished = true;
	}


}