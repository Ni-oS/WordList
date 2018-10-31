using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

[System.Serializable]
public class WordInfo : MonoBehaviour {

	//public List<EditingInfo> Mas = new List<EditingInfo> ();

	//public static Saving saving;
	[Header("wordINFO")]
	public GameObject option;
	GameObject Option;
	public GameObject parent;
	public GameObject WordWithoutFix;
	GameObject WordWithoutFixOption;


	public GameObject[] Theme =new GameObject[6];
	public int THEMEint=0;
	string LoadW;

	 int Count;
	[Header("Menu")]
	public GameObject Menu;
	GameObject MenuOption;

	public GameObject MineCanvas;

	private Saving Naming;

	[Header("Information/help")]
	public GameObject Inf;

	string NameWordlist;

	public void InitName(string op,int theme){
		NameWordlist= op;
		THEMEint = theme;
	}

	[HideInInspector]
	public  List<EditingInfo> Mas = new List<EditingInfo> ();

	void Start(){


		InitName (Saving.NameWordlist,Saving.Dropdown);
		NameWordlist = "/" + NameWordlist + ".fl";
		Theme [THEMEint].SetActive (true);
		Load (NameWordlist);
		//LoadWorLists ();
		//Fix.onClick.AddListener( ClickBut) ;
		//Zapolnenie ();
	}
	public int v = 0;
	public void InformInstant(){
		if (v == 0) {
			GameObject i = Instantiate (Inf);
			i.transform.SetParent (MineCanvas.transform, false);
			v++;
		}
	}






	public void Load(string Name){
		if (File.Exists (Application.persistentDataPath + Name)) {

			BinaryFormatter bf = new BinaryFormatter ();

			FileStream  TestFile = File.Open (Application.persistentDataPath + Name, FileMode.Open);

			List<string[]> Word =(List<string[]>)bf.Deserialize (TestFile);

			for (int i = 0; i < Word.Count; i++) {

				AddNewOption(Word[i][0],Word[i][1],Word[i][2],Word[i][3],int.Parse(Word[i][4]));

			}

			TestFile.Close ();

		} else

			InformInstant ();

	}

	public void MassPlus(EditingInfo i){
		int m = 0;
		for(int n=0;n<Mas.Count;n++){
			if (Mas [n] != i)
				m++;
		}
		if(m==Mas.Count)
			Mas.Add (i);
		ZapolnenieFaila (NameWordlist);			/////////
	}


	public void MassMinus(EditingInfo img){
		int t = Mas.IndexOf(img);

		Mas.RemoveAt (t);
		ZapolnenieFaila (NameWordlist);			
	}
	[HideInInspector]
	public bool Poisk=false;
	public InputField LookFor;
	public GameObject Scroll1;
	public GameObject Scroll2;
	public GameObject newParent;
	public void poiskWord(){
		LookFor.gameObject.SetActive (true);
		Scroll1.SetActive (false);
		Scroll2.SetActive (true);
		Poisk = true;
		DeleteAll ();
	}


	public void DeleteAll(){

	}
	public  List<EditingInfo> Mas1 = new List<EditingInfo> ();
	public List<GameObject> M1 = new List<GameObject> ();
	void Update () {

		if (Poisk) {

			//if (Input.GetKey (KeyCode.KeypadEnter)) {

				for (int i=0; i < Mas.Count; i++) {
				
				if (Mas[i].word== LookFor.text) {
						
					if (Mas1.Count >= 1) {
						for (int j = 0; j < Mas1.Count; j++) {
							if (Mas1 [j].word != LookFor.text) {
								Option = Instantiate (option, option.transform.position, option.transform.localRotation);
								Option.transform.SetParent (newParent.transform, false);
								Mas1.Add (Option.GetComponent<EditingInfo> ());
								M1.Add (Option);
								Option.GetComponent<EditingInfo> ().word = Mas [i].word;
								Option.GetComponent<EditingInfo> ().translation = Mas [i].translation;
								Option.GetComponent<EditingInfo> ().partOfSpeech = Mas [i].partOfSpeech;
								Option.GetComponent<EditingInfo> ().example = Mas [i].example;
								Option.GetComponent<EditingInfo> ().Transcription = Mas [i].Transcription;
							}
						}
					} else {
						Option = Instantiate (option, option.transform.position, option.transform.localRotation);
						Option.transform.SetParent (newParent.transform, false);
						Mas1.Add (Option.GetComponent<EditingInfo> ());
						M1.Add (Option);
						Option.GetComponent<EditingInfo> ().word = Mas [i].word;
						Option.GetComponent<EditingInfo> ().translation = Mas [i].translation;
						Option.GetComponent<EditingInfo> ().partOfSpeech = Mas [i].partOfSpeech;
						Option.GetComponent<EditingInfo> ().example = Mas [i].example;
						Option.GetComponent<EditingInfo> ().Transcription = Mas [i].Transcription;
					}
					}




			}



			if (Input.GetKeyUp(KeyCode.Escape) )
			{
				LookFor.gameObject.SetActive (false);
				Scroll2.SetActive (false);
				Scroll1.SetActive (true);
				Poisk = false;
				for (int i = 0; i < M1.Count; i++) {
					M1.RemoveAt (i);
					Mas1.RemoveAt (i);
				}
				
			}
		}
	}

	public void ZapolnenieFaila(string Name){

		List<string[]> Word = new List<string[]>();

		BinaryFormatter bf = new BinaryFormatter ();


		FileStream  TestFile = File.Create (Application.persistentDataPath + Name);



		for (int i = 0; i < Mas.Count; i++) {

			string POS = Mas [i].partOfSpeech.ToString ();

			string[] op = new string[5]{ Mas [i].word, Mas [i].translation,Mas[i].example,Mas[i].Transcription,POS};

			Word.Add(op);

		}

		bf.Serialize (TestFile, Word);

		TestFile.Close ();

	}
	void OnGUI()
	{
		if (Input.GetKeyUp(KeyCode.Escape) && !Poisk )
		{
			SceneManager.LoadScene("StartScene");
		}

	}


	public void InstantiateMenu(){
		MenuOption=Instantiate (Menu, Menu.transform.position, Menu.transform.rotation);
		MenuOption.transform.SetParent (MineCanvas.transform, false);
	}
	public void DestroyMenu(){
		DestroyObject (MenuOption);
	}
		
	public void AddNewOption(int i){
		

			Option = Instantiate (option, option.transform.position, option.transform.localRotation);
			Option.transform.SetParent (parent.transform, false);


			Option.GetComponent<EditingInfo> ().OnButtonClick ();

	}

	public void AddNewOption(string a,string b,string c,string h,int d){
		Option = Instantiate (option, option.transform.position, option.transform.localRotation);
		Option.transform.SetParent (parent.transform, false);
		Mas.Add (Option.GetComponent<EditingInfo>());
		Option.GetComponent<EditingInfo> ().word = a;
		Option.GetComponent<EditingInfo> ().translation = b;
		Option.GetComponent<EditingInfo> ().partOfSpeech = d;
		Option.GetComponent<EditingInfo> ().example = c;
		Option.GetComponent<EditingInfo> ().Transcription = h;
	}




}
