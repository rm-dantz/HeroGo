using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	//Game time
	public GameObject GameTime;
	//Monster Data
	CSVParser m_monsterData;
    #region MonterTypeValues

    public int      id;                                 //  monster's unique id;
    public int      color;                              // monster's Color;
    public int      grade;
    public int      type    = BehaviourType.Walk;       // Behaviour type. Range, Hover, and Walk.
    public int      element = ElementType.Fire;         //  monster's element type.
    public int      movePat = 0;                        // one or zero, this move is apply move style.
    
    #endregion

    #region MonsterParameter

    public float    moveSpd = 1f;                       // moveSpeed;
	public float      Damage = 1;                         // Attacking Damage
	public int      Level = 1;                          // Monster's Level;
    public float      HP;                                 // Health Point
    public float    atkSpd;                             // attack Speed;
    public float    projSize;                           // Projectile's Size;  
    public float    projSpeed;                          // projectile's Speed;
    public int      gold;                               // Player get the gold when monster was dead.
    public int[]    lootID;                             // dropping item when monster was dead.
    public int      lootMaxQuant;                       // Range 1 to 3.

    #endregion


    //Destroy Distance
	float maxiamDistance; 

	void Awake() 
	{
		maxiamDistance = gameObject.transform.position.x - 15;
		GameTime = GameObject.Find ("TimeCounting");
		//Level += GameTime.gameObject.GetComponent<TimeCounting> ().Monster_Level;
		m_monsterData = new monsterDataLoad ();
		m_monsterData.Load ();
	}
	
	// Update is called once per frame
	void Update() 
	{
		float move = moveSpd * Time.deltaTime; 
		gameObject.transform.Translate(Vector3.left * move, Space.World);
		if (gameObject.transform.position.x < maxiamDistance) 
		{
			Destroy(this.gameObject);
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
			HP -= bulletPower;
			if (HP <= 0)
				Destroy (this.gameObject);

		}
	}
}

public class ElementType
{
    public const int Fire   = 1;
    public const int Earth  = 2;
    public const int Water  = 3;
}

public class MonsterGrade
{
    public const int Normal = 0;
    public const int Named = 1;
}

public class BehaviourType
{
    public const int Walk = 0;
    public const int Hover = 1;
    public const int RangeAttack = 2;
}