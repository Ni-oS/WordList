using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

	GameObject GlMan;
	void Start () {
		GlMan = GameObject.FindGameObjectWithTag ("tag1");
	}

	public void GestroyThis(){
		GlMan.GetComponent<WordInfo> ().DestroyMenu ();
	}

	void Update () {
		
	}
}
