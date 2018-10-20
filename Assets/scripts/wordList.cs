using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class wordList : MonoBehaviour {
	
	public GameObject MiCanvas;
	public GameObject knopka;
	GameObject WordWithoutFixOption;


	public GameObject WordInput;

	public GameObject translationInput;

	public GameObject POSInput;

	public GameObject exampleInput;
	public GameObject transcriptionInput;
	[HideInInspector]
	public EditingInfo Image;
	public GameObject Imag;


	public GameObject SureCanvas;
	private GameObject WRINF;
	private WordInfo wrInf;
	[HideInInspector]
	public int c=0;
	public void copImage(EditingInfo m,GameObject m1){//инициализация имаджа
		Image = m;
		Imag = m1;
	}
	public void copImage(EditingInfo m){//инициализация имаджа
		Image = m;

	}

	void Start () {
		WRINF = GameObject.FindGameObjectWithTag ("tag1");

		wrInf = WRINF.GetComponent<WordInfo> ();
		
		//for (int i = 0; i < massiv.Length; i++) {
		//	AddNewOption (1);
		//}
	}
	public GameObject WordWithoutFix;

	public void StartImage(int i){

		WordInput.GetComponent<InputField>().text = Image.word;
		translationInput.GetComponent<InputField> ().text = Image.translation;
		POSInput.GetComponent<Dropdown> ().value = Image.partOfSpeech;
		exampleInput.GetComponent<InputField> ().text = Image.example;
		transcriptionInput.GetComponent<InputField> ().text = Image.Transcription;
		if (Image.word != "" && i!=0) {
			
			Destroy (MiCanvas);
		}

	}

	void Update () {
		if (WordInput.GetComponent<InputField> ().text.Length >=1)
			KnopkaOn ();
	}

	public void KnopkaOn(){
		knopka.SetActive (true);
	}



	public void Destroy(GameObject m){
		FinishFixing ();
		WordWithoutFixOption = Instantiate (WordWithoutFix);
		WordWithoutFixOption.GetComponent<WordCanvasNoFix> ().copImage (Image);
		DestroyObject (m);


	}

	void OnGUI()
	{
		if (Input.GetKeyUp(KeyCode.Escape) && c==0)
		{
			GameObject i=Instantiate (SureCanvas,SureCanvas.transform.position,SureCanvas.transform.rotation);
			i.transform.SetParent (MiCanvas.transform,false);
			c++;
		}

	}

	public void SureCanvasInst(){
		DestroyObject (GameObject.FindGameObjectWithTag("wordList"));
		DestroyObject (Imag);
	}

	public void FinishFixing(){
		Image.word=WordInput.GetComponent<InputField> ().text;
		Image.translation=translationInput.GetComponent<InputField> ().text ;
		Image.partOfSpeech=POSInput.GetComponent<Dropdown> ().value ;
		Image.example=exampleInput.GetComponent<InputField> ().text ;
		Image.Transcription=transcriptionInput.GetComponent<InputField> ().text ;
		Image.Texting ();

	}
}
