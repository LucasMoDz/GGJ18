using UnityEngine;
using System;
using System.Collections.Generic;

//TODO: define alien race

[Serializable]
public class Symbol {
	public enum Meaning {
		WAR,
		PEACE,
		NEUTRAL
	}
	public Meaning meaning;
	public Sprite img;

	public override string ToString ()
	{
		return string.Format ("[Symbol {0} {1}]", meaning, img.name);
	}

	public bool Equals2 (Symbol obj) {
		return obj != null && obj.meaning.Equals(meaning) && obj.img.Equals(img); 
	}
}

[Serializable]
public class AlienAlphabet {
	public string name;
	public Symbol[] symbols;
}


public class PhraseGenerator : MonoBehaviour {


	[Header("Difficulty")]
	public int easyTries;
	public int mediumTries;

	[Header("Alphabets")]
	public int currentAlphabet;
	public AlienAlphabet[] alphabets;


	int tries;

	public List<Symbol> generatePhrase() {
		List<Symbol> symbols = new List<Symbol>();
		int limit = 0;
		if(tries < easyTries) {
			limit = 1;
		}
		else if(tries < mediumTries) {
			limit = 2;
		}
		else {
			limit = 3;
		}

		for(int i=0; i<limit; i++) {
			Symbol candidate;
			do {
				candidate = randomSymbol();
			} while(isDuplicate(symbols, candidate) || (hasNeutral(symbols) && candidate.meaning.Equals(Symbol.Meaning.NEUTRAL)));
			symbols.Add(candidate);
		}
		tries++;
		return symbols;
	}

	Symbol randomSymbol() {
		return alphabets[currentAlphabet].symbols[UnityEngine.Random.Range(0, alphabets[currentAlphabet].symbols.Length)];
	}

	bool hasNeutral(List<Symbol> syms) {
		bool neutral = false;
		foreach(Symbol sym in syms) {
			if(sym.meaning.Equals(Symbol.Meaning.NEUTRAL)){
				neutral = true;
			}
		}
		return neutral;
	}

	bool isDuplicate(List<Symbol> syms, Symbol sym) {
		bool duplicate = false;
		foreach(Symbol _sym in syms) {
			if(_sym.Equals2(sym)){
				duplicate = true;
			}
		}
		return duplicate;
	}

	void Start() {
		tries = 0;
//		for(int i=0; i<20; i++) {
//			var syms = generatePhrase();
//			printPhrase(syms);
//		}
	}

	void printPhrase(List<Symbol> syms) {
		string res = "PHRASE=[ ";
		foreach(Symbol sym in syms) {
			res += sym + " ";
		}
		res += "]";
		Debug.Log(res);
	}

}
