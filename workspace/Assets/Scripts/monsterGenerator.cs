using UnityEngine;
using System.Collections;

public class monsterGenerator : MonoBehaviour {

	public Transform generatePos;
	public GameObject monsterBase;
	private static monsterDataLoad mData ;
	private monsterData data;

	//Sprite myTextures = Resources.LoadAll<Sprite>("Enemy/Textures");
	void Awake(){
		mData= new monsterDataLoad(); 
		mData.Load ();
		Debug.Log ("plz open");
	}
	// Use this for initialization
	void Start () {
		//Generate (2);
	}

	// Update is called once per frame
	void Update () {

	}

	public void Generate(int Id){
		Debug.Log ("ID : " + Id);
		Debug.Log (monsterBase);
		//if (data == null)
		//				Debug.Log ("NJULLLDSFLKJSLKDFJLKDSFJ");
	//	monsterData data = new monsterData(mData.CreateMonster (Id));
		data = new monsterData(mData.CreateMonster (Id));
		GameObject monster = Instantiate (monsterBase) as GameObject;
		monster.AddComponent ("monsterData");
		monster.GetComponent<monsterData> ().create (mData.CreateMonster (Id));

		string fileName = data.fileName;
		string finalPath;
		finalPath = string.Format("enemy/textures/{0}", fileName);
		monster.AddComponent ("SpriteRenderer");

		SpriteRenderer monRenderer = (SpriteRenderer)monster.GetComponent ("SpriteRenderer");
		Sprite mysprite = Resources.Load<Sprite>(finalPath);
		monRenderer.sprite = mysprite;

		monster.AddComponent ("BoxCollider2D");
		monster.GetComponent<BoxCollider2D> ().isTrigger = true;


		//monster.GetComponent<monsterData> ();// =  monsterDataLoad.CreateMonster (Id);
	}
}
