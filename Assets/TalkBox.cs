using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TalkBox : MonoBehaviour {
	public Image TalkBoxImage;
	public Text TalkBoxText;
	public string TalkBoxTextString;
	public bool Talking = false;
	public bool TalkingProgress = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnEnable () {
		UITextTypeWriterTalkBox Type = TalkBoxText.GetComponent<UITextTypeWriterTalkBox> ();
		TalkBoxImage.enabled = true;
		TalkBoxText.enabled = true;
		Type.ChangeText (TalkBoxTextString, 0);
		Talking = true;

	}
	IEnumerator TalkProgress(float duration){
		yield return new WaitForSeconds (duration);
			 TalkingProgress = true;
		

	}
}
