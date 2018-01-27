using UnityEngine;
using System;
using System.Collections.Generic;


public enum Meaning {
	WAR,
	PEACE,
	NEUTRAL
}

[Serializable]
public class Symbol {
	
	public Meaning meaning;
	//public Sprite img;
    public GameObject img;

	public override string ToString() {
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

public class Phrase {
	public List<Symbol> symbols;

	public Meaning getGlobalMeaning() {
		int neutral = 0;
		int war = 0;
		int peace = 0;
		foreach(Symbol sym in symbols) {
			if(sym.meaning.Equals(Meaning.NEUTRAL)) {
				neutral++;
			}
			if(sym.meaning.Equals(Meaning.WAR)){
				war++;
			}
			if(sym.meaning.Equals(Meaning.PEACE)){
				peace++;
			}
		}
		if(neutral == 1) {
			return Meaning.NEUTRAL;
		}
		else if(war > peace) {
			return Meaning.WAR;
		}
		else if(war < peace) {
			return Meaning.PEACE;
		}
		return Meaning.NEUTRAL; 
	}

	public override string ToString () {
		string res = "PHRASE=[ ";
		foreach(Symbol sym in symbols) {
			res += sym + " ";
		}
		res += "]";
		return res;
	}
}

public static class PhraseEvents
{
    public static Phrases GetPhrase;
    public delegate Phrase Phrases();
}

public class PhraseGenerator : MonoBehaviour {

	[Header("Difficulty")]
	public int easyTries;
	public int mediumTries;

	[Header("Alphabets")]
	public int currentAlphabet;
	public AlienAlphabet[] alphabets;

	int tries;

	Phrase lastPhrase;

	public Phrase generatePhrase()
    {
		Phrase ph = new Phrase();

        Meaning meaning = GameManagerTopics.GetLastMeaning();

		do {
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
				} while( (isDuplicate(symbols, candidate) || (hasNeutral(symbols) && candidate.meaning.Equals(Meaning.NEUTRAL))) || ( limit == 2 && candidate.meaning.Equals(Meaning.NEUTRAL)) );
				symbols.Add(candidate);
			}
			ph.symbols = symbols;
		} while(!ph.getGlobalMeaning().Equals(meaning));
		tries++;
		lastPhrase = ph;
		return ph;
	}

	public void reset() {
		tries = 0;
	}

	Symbol randomSymbol() {
		return alphabets[currentAlphabet].symbols[UnityEngine.Random.Range(0, alphabets[currentAlphabet].symbols.Length)];
	}

	bool hasNeutral(List<Symbol> syms) {
		bool neutral = false;
		foreach(Symbol sym in syms) {
			if(sym.meaning.Equals(Meaning.NEUTRAL)) {
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

    private void Awake()
    {
        PhraseEvents.GetPhrase = generatePhrase;
    }

	public Phrase replaceNeutral() {
		int neutral = 0;
		int war = 0;
		int peace = 0;
		foreach(Symbol sym in lastPhrase.symbols) {
			if(sym.meaning.Equals(Meaning.NEUTRAL)) {
				neutral++;
			}
			if(sym.meaning.Equals(Meaning.WAR)) {
				war++;
			}
			if(sym.meaning.Equals(Meaning.PEACE)) {
				peace++;
			}
		}
		if(neutral == 0) {
			return lastPhrase;
		}
		else if(neutral == 1) {
			if(war > peace) {
				Symbol candidate;
				do {
					candidate = randomSymbol();
				} while(candidate.meaning.Equals(Meaning.NEUTRAL) && !candidate.meaning.Equals(Meaning.WAR));
				Debug.Log(candidate);
				for(int i=0; i<lastPhrase.symbols.Count; i++) {
					if(lastPhrase.symbols[i].meaning.Equals(Meaning.NEUTRAL)){
						lastPhrase.symbols[i] = candidate;
					}
				}
			}
			else if(war < peace) {
				Symbol candidate;
				do {
					candidate = randomSymbol();
				} while(candidate.meaning.Equals(Meaning.NEUTRAL) && !candidate.meaning.Equals(Meaning.PEACE));

				for(int i=0; i<lastPhrase.symbols.Count; i++) {
					if(lastPhrase.symbols[i].meaning.Equals(Meaning.NEUTRAL)){
						lastPhrase.symbols[i] = candidate;
					}
				}
			}
			else {
				Symbol candidate;
				do {
					candidate = randomSymbol();
				} while(candidate.meaning.Equals(Meaning.NEUTRAL));

				for(int i=0; i<lastPhrase.symbols.Count; i++) {
					if(lastPhrase.symbols[i].meaning.Equals(Meaning.NEUTRAL)){
						lastPhrase.symbols[i] = candidate;
					}
				}
			}
		}

		return lastPhrase;
	}
}
