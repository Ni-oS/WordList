using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Information : MonoBehaviour {

	public GameObject thisObj;
	public Button but;
	Animator anim;
	private GameObject WRINF;
	private WordInfo wrInf;
	// Use this for initialization
	void Start () {
		WRINF = GameObject.FindGameObjectWithTag ("tag1");
		wrInf = WRINF.GetComponent<WordInfo> ();

		but.onClick.AddListener (DeleteTh);
		anim = thisObj.GetComponent<Animator> ();
	}

	public void DeleteTh (){
		anim.SetTrigger ("poi");
		wrInf.v = 0;
		Invoke ("del",0.8f);


	}
	public void del(){
		DestroyObject (thisObj);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
