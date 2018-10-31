using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[System.Serializable]
public class EditingInfo : MonoBehaviour {
	
	public GameObject thisObj;
	public Button but;
	public string word;
	public string translation;
	public int partOfSpeech=0;
	public string example;
	public string Transcription;
	string pos;
	public GameObject Text1;
	public GameObject Text2;
	public GameObject Text3;

	public GameObject[] mASsprite;
	public GameObject SpriteImage;

	public GameObject Canvas;
	GameObject Canvas2V;

	private GameObject WRINF;
	private WordInfo wrInf;
	public GameObject Image;
	Vector3 v3;
	public GameObject AreYouSure;
	GameObject Sure;
	 GameObject parent;




	public void Start(){
		
		WRINF = GameObject.FindGameObjectWithTag ("tag1"		);
		v3 =Image.transform.position;
		but.onClick.AddListener( OnButtonClick) ;

		wrInf = WRINF.GetComponent<WordInfo> ();
		Texting ();
		parent = wrInf.MineCanvas;
	}
	[HideInInspector]
	public int c=0;
	int timer = 0;
	 public void Update(){
		

	}


	public void InstSprite(GameObject i){
		SpriteImage.GetComponent<Text> ().text = pos;
		//GameObject sprt = Instantiate (i,i.transform.position,i.transform.rotation);
		//sprt.transform.SetParent (SpriteImage.transform,false);
	}
	public void ol(int i){
		
		switch (i) {
		case 1:
			pos = "Noun";
			InstSprite (mASsprite [0]);
			break;
		case 2:
			pos = "Pronoun";
			InstSprite (mASsprite [1]);
			break;
		case 3:
			pos = "Verb";
			InstSprite (mASsprite [2]);
			break;
		case 4:
			pos= "Adjective";
			InstSprite (mASsprite [3]);
			break;
		case 5:
			pos = "Numeral";
			InstSprite (mASsprite [4]);
			break;
		case 6:
			pos = "Adverb";
			InstSprite (mASsprite [5]);
			break;
		case 7:
			pos = "Preposition";
			InstSprite (mASsprite [6]);
			break;
		case 8:
			pos= "Article";
			InstSprite (mASsprite [7]);
			break;
		default:
			pos = "";
			break;
		}


	}

	public void Texting(){
		Text1.GetComponent<Text> ().text = word ;
		ol(partOfSpeech);
		if (!Transcription.Equals ("")) {
			Text2.GetComponent<Text> ().text = "[" + Transcription + "]";

			if (Transcription.StartsWith("[")) {
				
				Text2.GetComponent<Text> ().text =  Transcription + "]";
				int i = Transcription.Length;
				if (Transcription.EndsWith("]")) {
					Text2.GetComponent<Text> ().text =  Transcription ;
				}
			}
		}
		else
			Text2.GetComponent<Text> ().text = Transcription ;
		Text3.GetComponent<Text> ().text =translation;
	}

	public void SureCanvas(){
		Sure = Instantiate (AreYouSure,AreYouSure.transform.position,AreYouSure.transform.rotation);
		Sure.transform.SetParent (parent.transform, false);
		Sure.GetComponent<SureCanvas> ().copImage (this);
	}

	public void OnButtonClick(){
	//wrInf.FindDirectory (this);

			Canvas2V = Instantiate (Canvas, Canvas.transform.position, Canvas.transform.rotation);
		Canvas2V.GetComponent<wordList> ().copImage (this,thisObj);
			Canvas2V.GetComponent<wordList> ().StartImage (1);

	}
	public void DestroyThis(){
		wrInf.MassMinus (this);
		DestroyObject (thisObj);
	
	}

}
