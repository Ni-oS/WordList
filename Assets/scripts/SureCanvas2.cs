using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SureCanvas2 : MonoBehaviour {
	public string Option;
	public Button but1;
	public Button but2;
	public GameObject ThisObj;


	// Use this for initialization
	void Start () {

		//but1.onClick.AddListener( OnBut1) ;
		//but2.onClick.AddListener( OnBut2) ;
		//WordList = GameObject.FindGameObjectWithTag ("wordList");
		//wordLis = WordList.GetComponent<wordList> ();
	}

	public void Clickbut1(){
		DestroyThis ();
		GameObject.FindGameObjectWithTag ("Respawn").GetComponent<AddNewWordList> ().Delete (Option);
		GameObject.FindGameObjectWithTag ("Respawn").GetComponent<AddNewWordList> ().c = 0;
	}
	public void Clickbu2(){
		DestroyThis ();
		GameObject.FindGameObjectWithTag ("Respawn").GetComponent<AddNewWordList> ().c = 0;
	}

	public void init(string op){
		Option = op;
	}


	public void DestroyThis(){
		DestroyObject (ThisObj);
	}
}

