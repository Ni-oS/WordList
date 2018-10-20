using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class AddingWordList : MonoBehaviour {

	public InputField inp;
	public GameObject obj;
	public string Name;
	public GameObject ThisObj;
	public GameObject WordL;
	public AddNewWordList Wordl;
	// Use this for initialization

	public void Start(){
		WordL = GameObject.FindGameObjectWithTag ("Respawn");
		Wordl = WordL.GetComponent<AddNewWordList> ();
	}
	// Update is called once per frame
	void Update () {
		if (inp.text.Length >= 1)
			obj.SetActive (true);
	}


	public void Click(){
		Name = inp.text;
		DestroyObject (ThisObj);
		//Wordl.Name = Name;
		Wordl.AddNew (Name);
		Wordl.no ();////
	}

	public void NewName(){
		DestroyObject (ThisObj);
		Wordl.newName (inp.text);
	}
	void OnGUI()
	{
		if (Input.GetKeyUp(KeyCode.Escape) )
		{
			DestroyObject (ThisObj);
		}

	}
}
