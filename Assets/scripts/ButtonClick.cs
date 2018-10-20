using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour {

	public int Integer;
	public Text text;


	public void click(){
		GameObject.FindGameObjectWithTag ("Respawn").GetComponent<AddNewWordList> ().ClickBut (text.text,Integer);
	}
}
