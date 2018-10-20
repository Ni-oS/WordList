using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;



public class LoadWordList:MonoBehaviour {
	/*
	public  List<string> Mas1 = new List<string> ();

	string NameWordl;

	public void NewWordlist (string p){
		
		NameWordl = p+".fl";

		Mas1.Add (NameWordl);

		List<string[]> WordLists = new List<string[]>();

		BinaryFormatter bf = new BinaryFormatter ();


		FileStream  TestFile = File.Create (Application.persistentDataPath + "WordLists.f1");

		for(int i=0;i<Mas1.Count;i++){

			string op = Mas1 [i];

			WordLists.Add (op);


		}
		bf.Serialize (TestFile, WordLists);

		TestFile.Close ();

	}

	public void LoadWorLists(string Name){
		if (File.Exists (Application.persistentDataPath + Name)) {

			BinaryFormatter bf = new BinaryFormatter ();

			FileStream  TestFile = File.Open (Application.persistentDataPath + Name, FileMode.Open);

			List<string[]> Word =(List<string[]>)bf.Deserialize (TestFile);

			for (int i = 0; i < Word.Count; i++) {

				Mas1.Add (Word [i]);

			}

			TestFile.Close ();

		} 
	}



	void Start () {
		
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
		ZapolnenieFaila ();			/////////
	}


	public void MassMinus(EditingInfo img){
		int t = Mas.IndexOf(img);
	
		Mas.RemoveAt (t);
		ZapolnenieFaila ();			//////
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
	void Update(){

	}
*/


	public void AddNew(string op){
		Saving.NameWordlist = op;
		SceneManager.LoadScene ("mainScene1");

	}
}
