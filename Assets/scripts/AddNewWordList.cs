using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

public class AddNewWordList : MonoBehaviour {

	public string Name;
	public GameObject AddingWordList;
	public GameObject EditWordList;
	public int Integer;
	public GameObject Option;
	public GameObject OptionsParent;
	public GameObject Information;
	public GameObject meObject;

	public int Dropdown;
	// Use this for initialization
	void Start () {
		
		StartMethod0 ();
		Load ();
		StartMethod ();

	}
	public GameObject SureCanvas;



	public void StartMethod0(){
		if (File.Exists (Application.persistentDataPath + "/WordLists.fl")) {
			BinaryFormatter bf1 = new BinaryFormatter ();
			FileStream TestFile3 = File.Open (Application.persistentDataPath + "/WordLists.fl", FileMode.Open);

			List<string> Wr = (List<string>)bf1.Deserialize (TestFile3);
			TestFile3.Close ();
			File.Delete (Application.persistentDataPath +  "/WordLists.fl");

			if (!Wr [0] [2].Equals ("1")) {
				Debug.Log ("yes");
				FileStream TestFile4 = File.Create (Application.persistentDataPath + "/WordLists1.fl");
				List<string[]> Word1 = new List<string[]> ();

				for (int i = 0; i < Wr.Count; i++) {
					string[] op = new string[3]{ Wr [i], "0", "1" };
					Word1.Add (op);
				}
				bf1.Serialize (TestFile4, Word1);
				TestFile4.Close ();
			}
		}
	}


	public void StartMethod(){
		if (!File.Exists (Application.persistentDataPath + "/WordLists1.fl")) {
			
			BinaryFormatter bf = new BinaryFormatter ();

			if(File.Exists(Application.persistentDataPath+"/word.fl") && File.Exists(Application.persistentDataPath+"/POS.fl")){
				AddNew ("word",0);
			
				FileStream  TestFile1 = File.Open (Application.persistentDataPath +  "/word.fl", FileMode.Open);
				FileStream  TestFile2 = File.Open (Application.persistentDataPath +  "/POS.fl", FileMode.Open);
				List<string[]> Word =(List<string[]>)bf.Deserialize (TestFile1);
				List<int> Pos = (List<int>)bf.Deserialize (TestFile2);
				TestFile2.Close ();TestFile1.Close ();

				List<string[]> Word2 = new List<string[]>();
				for (int i = 0; i < Word.Count; i++) {
					string[] op = new string[5]{ Word [i] [0], Word [i] [1], Word [i] [2], Word [i] [3], Pos [i].ToString () };
					Word2.Add (op);

				}
				File.Delete (Application.persistentDataPath + "/POS.fl");
				FileStream  TestFile = File.Create (Application.persistentDataPath + "/word.fl");
				bf.Serialize (TestFile, Word2);

				TestFile.Close ();
			}
		
		}

	}



	public void InstInf(){
		GameObject i = Instantiate (Information);
		i.transform.SetParent (meObject.transform, false);
	}


	List<string[]> mas= new List<string[]>();
	List<GameObject> mas2 = new List<GameObject> ();

	public void InstNew(){
		Instantiate (AddingWordList);
	}
	public void InstEdit(){
		if(Name!="")
		Instantiate (EditWordList);
	}

	public void Naming(string p){
		Name = p;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void newName(string op){

		BinaryFormatter bf = new BinaryFormatter ();
		if (File.Exists (Application.persistentDataPath + "/" + Name + ".fl")) {



			FileStream  TestFile = File.Open (Application.persistentDataPath +  "/" + Name + ".fl", FileMode.Open);

			List<string[]> Word =(List<string[]>)bf.Deserialize (TestFile);

			TestFile.Close ();

			File.Delete (Application.persistentDataPath + "/" + Name + ".fl");

			FileStream  TestFile1 = File.Create (Application.persistentDataPath + "/" + op + ".fl");

			bf.Serialize (TestFile1, Word);

			TestFile1.Close ();

		}
		mas [Integer][0] = op;
		mas [Integer] [1] = Dropdown.ToString ();
		Debug.Log (mas [0] [0] + " " + mas [0] [1]);
		mas2 [Integer].GetComponent<ButtonClick> ().text.text = op;
		mas2 [Integer].GetComponent<ButtonClick> ().Theme = Dropdown;

		List<string[]> Word1 = new List<string[]>();
		FileStream  TestFile3 = File.Open (Application.persistentDataPath +  "/WordLists1.fl", FileMode.Open);
		for (int i = 0; i < mas.Count; i++) {
			

			string[] qw = new string[3]{mas [i][0],mas [i][1],mas [i][2]};
			Word1.Add(qw);

		}

		bf.Serialize (TestFile3, Word1);
		TestFile3.Close ();

		no ();
	}
	public void DropInit(int i){
		mas [Integer] [1] = i.ToString ();
		mas2 [Integer].GetComponent<ButtonClick> ().Theme = i;
		Zapolnenie ();
	}

	public void ClickBut(string op,int inp,int drp){
		Name = op;
		Integer=inp;
		Dropdown = drp;
	}

	public void AddNew(string op,int drpDown){
		string[] newq =new string[3]{op,drpDown.ToString (),"1"};
		mas.Add (newq);
		Zapolnenie ();
		AddOption (op,drpDown);
	}
	public void perexod(){
		if (Name != "") {
			Saving.NameWordlist = Name;
			Saving.Dropdown = Dropdown;
			SceneManager.LoadScene ("mainScene1");
		}
	}

	int n;
	int t;
	public void Delete(string op){
		bool a = false;

		for (int i = 0; i < mas.Count; i++) {
			if(op.Equals(mas[i][0]))
				t=i;
		}
			//int t = mas.IndexOf(op);

		DestroyObject (mas2 [Integer]);
		mas2.RemoveAt (Integer);

		for (int i = 0; i<mas2.Count; i++) {
			mas2 [i].GetComponent<ButtonClick> ().Integer = i;
		}

		if (File.Exists (Application.persistentDataPath + "/" + op + ".fl")) {
			File.Delete (Application.persistentDataPath + "/" + op + ".fl");
		}
			mas.RemoveAt (t);
			Zapolnenie ();
		no ();

	}

	public int c=0;
	public void SureInst(){
		if (c == 0 && Name!="") {
			c++;
			GameObject i = Instantiate (SureCanvas);
			i.GetComponent<SureCanvas2> ().init (Name);
			i.transform.SetParent (GameObject.FindGameObjectWithTag ("Respawn").transform, false);
		}
	}



	public void Load(){
		if (File.Exists (Application.persistentDataPath +  "/WordLists1.fl")) {

			BinaryFormatter bf = new BinaryFormatter ();

			FileStream  TestFile = File.Open (Application.persistentDataPath +  "/WordLists1.fl", FileMode.Open);

			List<string[]> Word =(List<string[]>)bf.Deserialize (TestFile);

			for (int i = 0; i < Word.Count; i++) {
				string[] ui = new string[3]{Word [i][0],Word [i][1],Word [i][2]};
				mas.Add (ui);
				AddOption (Word [i][0],int.Parse(Word[i][1]));

			}

			TestFile.Close ();

		} 
	}

	public void no(){
		Name = "";
	}


	public void AddOption(string msop,int Theme){
		GameObject op = Instantiate (Option);
		op.transform.SetParent (OptionsParent.transform, false);
		op.GetComponent<ButtonClick> ().text.text = msop;
		op.GetComponent<ButtonClick> ().Integer = mas2.Count;
		op.GetComponent<ButtonClick> ().Theme= Theme;
		mas2.Add (op);

	}

	public void Zapolnenie(){
		
		List<string[]> Word = new List<string[]>();
		BinaryFormatter bf = new BinaryFormatter ();


		FileStream  TestFile = File.Create (Application.persistentDataPath + "/WordLists1.fl");



		for (int i = 0; i < mas.Count; i++) {



			string[] op = new string[3]{mas [i][0],mas [i][1],mas [i][2]};

			Word.Add(op);

		}

		bf.Serialize (TestFile, Word);

		TestFile.Close ();
	}
}
