using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SureCanvas : MonoBehaviour {
	public EditingInfo Image;
	public Button but1;
	public Button but2;
	public GameObject ThisObj;
	 GameObject WordList;
	 wordList wordLis;

	// Use this for initialization
	void Start () {
		
		//but1.onClick.AddListener( OnBut1) ;
		//but2.onClick.AddListener( OnBut2) ;
		//WordList = GameObject.FindGameObjectWithTag ("wordList");
		//wordLis = WordList.GetComponent<wordList> ();
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnBut1(){
		Image.DestroyThis ();
		DestroyThis ();

	}
	public void OnBut2(){
		DestroyThis ();

		Image.c = 0;
	}

	public void OnBut11(){
		GameObject.FindGameObjectWithTag ("wordList").GetComponent<wordList> ().SureCanvasInst ();
		DestroyThis ();

	}
	public void OnBut22(){
		DestroyThis ();
		GameObject.FindGameObjectWithTag ("wordList").GetComponent<wordList> ().c = 0;

	}


		

	public void copImage(EditingInfo m){//инициализация имаджа
		Image = m;
	}

	public void DestroyThis(){
		DestroyObject (ThisObj);
	}
}
