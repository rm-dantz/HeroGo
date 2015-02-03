using UnityEngine;
using System.Collections;

public class monsterData  : MonoBehaviour {
	
	public monsterData(){
	}
	
	public string mName;
	public int ID;
	public int type;
	public int element;
	public int HP;
	public int physAtk;
	public int magicAtk;
	public float moveSpd;
	public float atkSpd;
	public int shotSize;
	public float shotSpd;
	public int flightPattern;
	public int gold;
	public int height;
	public int length;
	public string fileName;
//	public string bulletName;
	
	public monsterData(monsterData _mons){
		mName	 		= _mons.mName;
		ID	 	 		= _mons.ID;
		type	 		= _mons.type;
		element	 		= _mons.element;
		HP 				= _mons.HP;
		physAtk 		= _mons.physAtk;
		magicAtk 		= _mons.magicAtk;
		moveSpd 		= _mons.moveSpd;
		atkSpd 			= _mons.atkSpd;
		shotSize 		= _mons.shotSize;
		shotSpd 		= _mons.shotSpd;
		flightPattern 	= _mons.flightPattern;
		gold 			= _mons.gold;
		height 			= _mons.height;
		length 			= _mons.length;
		fileName 		= _mons.fileName;
	//	bulletName		= _mons.bulletName;
		
	}
	
	public void create(monsterData _mons){
		mName	 		= _mons.mName;
		ID	 	 		= _mons.ID;
		type	 		= _mons.type;
		element	 		= _mons.element;
		HP 				= _mons.HP;
		physAtk 		= _mons.physAtk;
		magicAtk 		= _mons.magicAtk;
		moveSpd 		= _mons.moveSpd;
		atkSpd 			= _mons.atkSpd;
		shotSize 		= _mons.shotSize;
		shotSpd 		= _mons.shotSpd;
		flightPattern 	= _mons.flightPattern;
		gold 			= _mons.gold;
		height 			= _mons.height;
		length 			= _mons.length;
		fileName 		= _mons.fileName;
	//	bulletName 		= _mons.bulletName;
		
	}
	~monsterData(){
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	
	
	//shooter monster trait
	int shooterStage = 0;
	float shooterReloadTime = 0f;
	// Update is called once per frame
	void Update () {
		
		if (type == 0 || type == 3) { //walker
			float move = moveSpd * Time.deltaTime; 
			gameObject.transform.Translate(Vector3.left * move, Space.World);
			if (gameObject.transform.position.x < -4.5) //out of screen
			{
				Destroy(this.gameObject);
			}
		}
		
		if (type == 1) { //shooter
			
			switch(shooterStage)
			{
			case 0://come on screen
				while( gameObject.transform.position.x > 4 )
				{
					float move = moveSpd * Time.deltaTime;
					gameObject.transform.Translate(Vector3.left * move, Space.World);
				}
				shooterStage = 1;
				break;
			case 1://shoot 
				shooterReloadTime += Time.deltaTime;
				if(shooterReloadTime > this.atkSpd){
					//shoot
					GameObject enemyBullet = (GameObject)Instantiate(GameObject.Find("enemyBullet"),this.transform.position,Quaternion.identity);
					enemyBullet.AddComponent("SpriteRenderer");
				//	string fileName = this.bulletName;
					string fileName = "chim";
					string finalPath;
					finalPath = string.Format("enemy/textures/bullets", fileName);
					Sprite mysprite = Resources.Load<Sprite>(finalPath);
					enemyBullet.GetComponent<SpriteRenderer>().sprite = mysprite;
					enemyBullet.AddComponent ("BoxCollider2D");
					enemyBullet.GetComponent<BoxCollider2D> ().isTrigger = true;
					enemyBullet.GetComponent<EnemyBullet>().Init(this.shotSpd);
					
					
					shooterReloadTime=0;
				}
				break;
			}
			
			
			if (gameObject.transform.position.x < -4.5) //out of screen
			{
				Destroy(this.gameObject);
			}
		}
		
		if (type == 2) { //flyer
			
			float move = moveSpd * Time.deltaTime; 
			gameObject.transform.Translate(Vector3.left * move, Space.World);
			
			if (gameObject.transform.position.x < -4.5) //out of screen
			{
				Destroy(this.gameObject);
			}
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") 
		{
			//Destroy (this.gameObject);
		} 
		else if (coll.gameObject.tag == "Bullet") 
		{
			float bulletPower = coll.gameObject.GetComponent<Bullet> ().player_damage;
			Destroy (coll.gameObject);
			HP -= (int)bulletPower;
			if (HP <= 0)
				Destroy (this.gameObject);
			
		}
	}
	
}
