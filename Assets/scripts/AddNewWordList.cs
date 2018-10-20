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
	// Use this for initialization
	void Start () {
		Load ();
		StartMethod ();
	}
	public GameObject SureCanvas;


	public void StartMethod(){
		if (!File.Exists (Application.persistentDataPath + "/WordLists.fl")) {
			if(File.Exists(Application.persistentDataPath+"/word.fl") && File.Exists(Application.persistentDataPath+"/POS.fl")){
				AddNew ("word");

				BinaryFormatter bf = new BinaryFormatter ();

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


	List<string> mas= new List<string>();
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
		mas [Integer] = op;
		mas2 [Integer].GetComponent<ButtonClick> ().text.text = op;

		List<string> Word1 = new List<string>();
		FileStream  TestFile3 = File.Open (Application.persistentDataPath +  "/WordLists.fl", FileMode.Open);
		for (int i = 0; i < mas.Count; i++) {
			
			string qw = mas [i];

			Word1.Add(qw);

		}

		bf.Serialize (TestFile3, Word1);
		TestFile3.Close ();

		no ();
	}

	public void ClickBut(string op,int inp){
		Name = op;
		Integer=inp;
	}

	public void AddNew(string op){
		mas.Add (op);
		Zapolnenie ();
		AddOption (op);
	}
	public void perexod(){
		if (Name != "") {
			Saving.NameWordlist = Name;
			SceneManager.LoadScene ("mainScene1");
		}
	}

	int n;
	public void Delete(string op){
		bool a = false;
			int t = mas.IndexOf(op);

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
		if (File.Exists (Application.persistentDataPath +  "/WordLists.fl")) {

			BinaryFormatter bf = new BinaryFormatter ();

			FileStream  TestFile = File.Open (Application.persistentDataPath +  "/WordLists.fl", FileMode.Open);

			List<string> Word =(List<string>)bf.Deserialize (TestFile);

			for (int i = 0; i < Word.Count; i++) {

				mas.Add (Word [i]);
				AddOption (mas [i]);

			}

			TestFile.Close ();

		} 
	}

	public void no(){
		Name = "";
	}


	public void AddOption(string msop){
		GameObject op = Instantiate (Option);
		op.transform.SetParent (OptionsParent.transform, false);
		op.GetComponent<ButtonClick> ().text.text = msop;
		op.GetComponent<ButtonClick> ().Integer = mas2.Count ;
		mas2.Add (op);

	}

	public void Zapolnenie(){
		
		List<string> Word = new List<string>();
		BinaryFormatter bf = new BinaryFormatter ();


		FileStream  TestFile = File.Create (Application.persistentDataPath + "/WordLists.fl");



		for (int i = 0; i < mas.Count; i++) {



			string op = mas [i];

			Word.Add(op);

		}

		bf.Serialize (TestFile, Word);

		TestFile.Close ();
	}
}
