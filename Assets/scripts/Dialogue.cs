using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

	public string name;
	public string sentence;

	public Dialogue(string n, string s) {
		name = n;
		sentence = s;
	}
}
