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

	public Dropdown drop;
	int n;
	// Use this for initialization

	public void Start(){
		
		WordL = GameObject.FindGameObjectWithTag ("Respawn");
		Wordl = WordL.GetComponent<AddNewWordList> ();
		n = Wordl.Dropdown;
		drop.value = n;
	}
	// Update is called once per frame
	void Update () {
		if (inp.text.Length >= 2 || n!= drop.value)
			obj.SetActive (true);
	}


	public void Click(int i){
		
		if (i == 1) {
			if(inp.text.Length>=1){
			Name = inp.text;
			DestroyObject (ThisObj);
			//Wordl.Name = Name;
			Wordl.AddNew (Name,drop.value);
			Wordl.DropInit (drop.value);
				Wordl.no ();}
		}if (i == 2) {
			DestroyObject (ThisObj);
			if(inp.text!="" && inp.text!=" " && inp.text!="  ")
				Wordl.newName (inp.text);
			Wordl.DropInit (drop.value);
			Wordl.Dropdown = drop.value;
		}


	}

	/*public void NewName(){
		DestroyObject (ThisObj);
		Wordl.newName (inp.text);
	}*/
	void OnGUI()
	{
		if (Input.GetKeyUp(KeyCode.Escape) )
		{
			DestroyObject (ThisObj);
		}

	}
}
