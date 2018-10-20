using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordCanvasNoFix : MonoBehaviour {

	private GameObject WRINF;
	private WordInfo wrInf;
	public Text Header;
	[HideInInspector]
	public EditingInfo Image;
	public Text translation;
	public Text PartOfSpeech;
	public Text example;
	public Text Transcription;

	public GameObject MiCanvas;

	public GameObject WordF;
	GameObject WordInf;

	void Start () {
		Header.text = Image.word;
		ol (Image.partOfSpeech);

		translation.text = Image.translation;
		example.text = Image.example;

		if (!Image.Transcription.Equals ("")) {
			Transcription.text = "[" + Image.Transcription + "]";
			if (Image.Transcription.StartsWith("[")) {
				Transcription.text = Image.Transcription + "]";
				int i = Image.Transcription.Length;
				if (Image.Transcription.EndsWith("]")) {
					Transcription.text = Image.Transcription;
				}
			}
		} else
			Transcription.text = "[   ]";
		WRINF = GameObject.FindGameObjectWithTag ("tag1");

		wrInf = WRINF.GetComponent<WordInfo> ();
	}
	
	public void copImage(EditingInfo m){//инициализация имаджа
		Image = m;
	}

	public void ol(int i){
		switch (i) {
		case 1:
			PartOfSpeech.text = "Noun";
			break;
		case 2:
			PartOfSpeech.text = "Pronoun";
			break;
		case 3:
			PartOfSpeech.text = "Verb";
			break;
		case 4:
			PartOfSpeech.text = "Adjective";
			break;
		case 5:
			PartOfSpeech.text = "Numeral";
			break;
		case 6:
			PartOfSpeech.text = "Adverb";
			break;
		case 7:
			PartOfSpeech.text = "Preposition";
			break;
		case 8:
			PartOfSpeech.text = "Article";
			break;
		default:
			PartOfSpeech.text = "";
			break;
		}

	}

	public void Destroy(GameObject m){
		
		wrInf.MassPlus (Image);

		DestroyObject (m);


	}
	public void FixButton(GameObject mn){
		WordInf = Instantiate (WordF);
		WordInf.GetComponent<wordList> ().copImage (Image);
		WordInf.GetComponent<wordList> ().StartImage (0);
		WordInf.GetComponent<wordList> ().c = 1;
		Destroy(MiCanvas);

	}


}
