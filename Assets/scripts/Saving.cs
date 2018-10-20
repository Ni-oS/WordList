using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

[System.Serializable]
public  class Saving{
	public static string NameWordlist;

	public void init(string op){
		NameWordlist = op;
	}

}
