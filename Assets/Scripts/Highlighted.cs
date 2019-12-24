using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Highlighted : MonoBehaviour, IPointerEnterHandler, ISelectHandler,IDeselectHandler
{   public GameObject Heart;
	public AudioSource SelectFX;
	public GameObject Position;
	public GameObject NoLostFocus;
	public Sprite High;
	public Sprite Low;
	public void OnPointerEnter(PointerEventData eventData)
	{
		
	}
	public void OnSelect(BaseEventData eventData)
	{  Initialise_Button IB = NoLostFocus.GetComponent<Initialise_Button> ();
		Image I= this.GetComponent<Image> ();
		I.sprite = High;
		Heart.transform.position = Position.transform.position;
		if(IB.Mouse==false){
		SelectFX.Play ();
		}
	}
	public void OnDeselect(BaseEventData eventData)
	{
	
		Image I= this.GetComponent<Image> ();
		I.sprite = Low;
		Debug.Log ("Deselected");

	
	}

}