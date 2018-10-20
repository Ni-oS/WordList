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

	public void InitName(string op){
		NameWordlist= op;
	}

	[HideInInspector]
	public  List<EditingInfo> Mas = new List<EditingInfo> ();

	void Start(){
		
		InitName (Saving.NameWordlist);
		NameWordlist = "/" + NameWordlist + ".fl";
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



	public  List<string> Mas1 = new List<string> ();



	public void NewWordlist (string p){

		string NameWordl = "/"+p+".fl";

		Mas1.Add (NameWordl);

		List<string> WordLists = new List<string>();

		BinaryFormatter bf = new BinaryFormatter ();


		FileStream  TestFile = File.Create (Application.persistentDataPath + "/WordLists.fl");

		for(int i=0;i<Mas1.Count;i++){

			string op = Mas1 [i];

			WordLists.Add (op);


		}
		bf.Serialize (TestFile, WordLists);

		TestFile.Close ();

	}

	public void LoadWorLists(){
		if (File.Exists (Application.persistentDataPath +  "/WordLists.fl")) {

			BinaryFormatter bf = new BinaryFormatter ();

			FileStream  TestFile = File.Open (Application.persistentDataPath +  "/WordLists.fl", FileMode.Open);

			List<string> Word =(List<string>)bf.Deserialize (TestFile);

			for (int i = 0; i < Word.Count; i++) {

				Mas1.Add (Word [i]);

			}

			TestFile.Close ();

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
		ZapolnenieFaila (NameWordlist);			//////
	}

	public void DeleteAll (){



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
		if (Input.GetKeyUp(KeyCode.Escape) )
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
