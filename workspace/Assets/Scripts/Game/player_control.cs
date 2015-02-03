using  UnityEngine ;
using  System . Collections ;

public  class  player_control  :  MonoBehaviour  {
	//Character Animation
    protected  Animator animator ;
	private  bool bJump =  false ;
	private float y = 0.0f;
	private float gravity = 100.0f;   
	private float deltaTime = 0.0f;
	private int direction = 0;       // 0:stop, 1:jump, 2:down
	//Character Setting
	private const float jump_speed = 6f;  
	private const float jump_accell = 10f; 
	private const float y_base = -1.5f;     
	private int Jump_count;
	//Bullet
	public GameObject m_bulletObj;
	public Transform BulletPool;
	//Bullet Creator
	public GameObject m_bulletCreator;
	//Player Abillity
	float MaxHp = 0f;
	float CurrentHp = 0f;
	int Damage = 1;
	float Defence = 0.0f;
	float MagicDefence = 0.0f;
	//Weapon
	Weapon wand = new Weapon();
	int Weapon_Grade;
	int Weapon_Element;
	float Rate = 0f;
	//Item
	ItemInterface m_cap;
	ItemInterface m_robe;
	ItemInterface m_shoes;
	ItemInterface m_cloack;
	public int ItemType;
	public int NewItemType;
	public GameObject ChangeItemWindow;
	public GameObject MyDes;
	public GameObject NewDes;
	//RequesyReplace
	public bool isPressedOn;
	//GameObject ne

	//Item Info
	public struct CAP
	{
		public string 		name;			
		public int			armorID;		
		public int			armorType;	
		public int			armorGrade;		
		public int			armorHP;			
		public int			def;			
		public int			mDef;			
		public int			mAtk;			
		public float		critChance;			
		public float		hpRegen;			
		public float		potionup;			
		public int			shield;			
		public int			critOnEnemy;			
		public int			slow;			
		public int			thorns;			
		public int			chargeAtk;
	}
	public struct ROBE
	{
		public string 		name;			
		public int			armorID;		
		public int			armorType;	
		public int			armorGrade;		
		public int			armorHP;			
		public int			def;			
		public int			mDef;			
		public int			mAtk;			
		public float		critChance;			
		public float		hpRegen;			
		public float		potionup;			
		public int			shield;			
		public int			critOnEnemy;			
		public int			slow;			
		public int			thorns;			
		public int			chargeAtk;
	}
	public struct SHOES
	{
		public string 		name;			
		public int			armorID;		
		public int			armorType;	
		public int			armorGrade;		
		public int			armorHP;			
		public int			def;			
		public int			mDef;			
		public int			mAtk;			
		public float		critChance;			
		public float		hpRegen;			
		public float		potionup;			
		public int			shield;			
		public int			critOnEnemy;			
		public int			slow;			
		public int			thorns;			
		public int			chargeAtk;
	}
	public struct CLOACK
	{
		public string 		name;			
		public int			armorID;		
		public int			armorType;	
		public int			armorGrade;		
		public int			armorHP;			
		public int			def;			
		public int			mDef;			
		public int			mAtk;			
		public float		critChance;			
		public float		hpRegen;			
		public float		potionup;			
		public int			shield;			
		public int			critOnEnemy;			
		public int			slow;			
		public int			thorns;			
		public int			chargeAtk;
	}

	public CAP current_cap;
	public ROBE current_robe;
	public SHOES current_shoes;
	public CLOACK current_cloack;
	GameObject DropItemInfo;

    void  Awake()  
	{
        animator =  GetComponentInChildren < Animator > ();
		bJump =  false ;
		y = y_base;
		Jump_count = 0;
		m_bulletObj.GetComponent<Bullet> ().player_damage = Damage;

        //wand = gameObject.AddComponent<WoodWand>();
        wand.Init();
		Weapon_Grade = 0;
		//Weapon_Element = Weapon.Attribute_None;
		m_cap = gameObject.AddComponent<amor_a_info> ();
		m_robe = gameObject.AddComponent<amor_b_info> ();
		m_shoes = gameObject.AddComponent<amor_c_info> ();
		m_cloack = gameObject.AddComponent<amor_d_info> ();
		isPressedOn = false;
		ItemToSave ();
		CurrentHp = MaxHp;
    }
    void  Update()  
	{
        if ( animator )
        {
			animator . SetBool ( "Jump" , bJump );
			JumpProcess();
			Vector3 pos = gameObject.transform.position;
			pos.y = y;
			gameObject.transform.position = pos;

	    }

		//Attack_Speed
		deltaTime += Time.deltaTime;
		if(deltaTime >= wand.m_AttackDelay)
		{
			shoot();
			deltaTime = 0;
		}

		//Check Item Replace
		if(isPressedOn)
		{
			RequestReplace(NewItemType);
		}
    }

	public void shoot()
	{
		GameObject BulletCreation = Instantiate (m_bulletObj, m_bulletCreator.transform.position, Quaternion.identity) as GameObject;

		BulletCreation.transform.position = new Vector3(BulletCreation.transform.position.x, BulletCreation.transform.position.y, BulletCreation.transform.position.z);
        BulletCreation.GetComponent<Bullet>().GetInfoFromWeapon(wand);
		BulletCreation.transform.parent = BulletPool;
	}

	public void Jump()
	{
		if (Jump_count < 2) 
		{
			DoJump ();
			bJump = true;
		}
	}

	void DoJump()
	{
		direction = 1;
		gravity = jump_speed;
		Jump_count++;
	}
	void JumpProcess()
	{
		switch (direction)
		{
			case 0:
			{
				bJump = false;
				if (y > y_base)
				{
					if (y >= jump_accell)
					{
						y -= gravity * Time.deltaTime;
					}
					else
					{
						y = y_base;
					}
				}
				break;
			}
			case 1:
			{
				y += gravity * Time.deltaTime;
				if (gravity <= 0.0f)
				{
					direction = 2;
				}
				else
				{
					gravity -= jump_accell * Time.deltaTime;
				}
				break;
			}
			case 2:
			{
				y -= gravity * Time.deltaTime;
				if (y > y_base)
				{
					gravity += jump_accell * Time.deltaTime;
				}
				else
				{
					direction = 0;
					y = y_base;
					Jump_count = 0;
				}
				break;
			}
		}	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Enemy") 
		{
			Rate = CompareToType(wand.m_Attribute, coll.gameObject.GetComponent<Enemy>().type);
			float EnemyDamage = (coll.gameObject.GetComponent<Enemy>().Damage * Rate ) - Defence;

			if(EnemyDamage < 1)
			{
				CurrentHp -= 1f;
			}
			else
			{
				CurrentHp -= EnemyDamage;
			}
			Debug.Log(CurrentHp);
			Destroy (coll.gameObject);
			//HP_Bar Sync
			VitalBar.getInstance().UpdateDisplay(MaxHp, CurrentHp);

			//Weapon Stack
			Weapon_Element = Weapon.Attribute_Fire;
			wand.m_Attribute = Weapon_Element;
			if(Weapon_Element == Weapon.Attribute_Fire)
			{
				Weapon_Grade++;
				wand.m_GradeLevel = Weapon_Grade;
			}
			if (CurrentHp <= 0)
				Destroy (this.gameObject);
		} 
		if (coll.gameObject.tag == "GiftBox")
		{
			ItemType = coll.gameObject.GetComponent<DropItem>().m_item.armorType;
			//NewItemType = coll.gameObject.GetComponent<DropItem>().m_item.armorType;
			Debug.Log ("ItemType : " + ItemType);
			Debug.Log ("NewItemType : " + NewItemType);
			NGUITools.SetActive(ChangeItemWindow.gameObject, true);
			Time.timeScale = 0f;
			NewDes.gameObject.GetComponent<NewItemDes>().DropItem = coll.gameObject;
			DropItemInfo = coll.gameObject;
			MyDes.SendMessage("Init");
			NewDes.SendMessage("Init");
		}

		if (coll.gameObject.tag.Equals("Wand"))
		{
			wand.AccumWand(coll.gameObject.GetComponent<wand_drop>().currentElement);
			Destroy(coll.gameObject);
		}
	}

	float CompareToType(int MyType, int OtherType)
	{
		if (OtherType == MyType)
			return 1.0f;
		
		else if (OtherType - MyType > 0) {
			if(OtherType - MyType >1)
				return 1.2f;
			else
				return 0.8f;
		} else if (OtherType - MyType < 0) {
			if(OtherType - MyType < -1)
				return 0.8f;
			else
				return 1.2f;
		}
		return 1.0f;
	}
	
	void RequestReplace(int NewItemType)
	{
		switch(NewItemType)
		{
			case 1:
				m_cap.replace(DropItemInfo);
				break;
			
			case 2:
				m_robe.replace(DropItemInfo);
				break;
			
			case 3:
				m_shoes.replace(DropItemInfo);
				break;
			case 4:
				m_cloack.replace(DropItemInfo);
				break;
		}
		ItemToSave ();
		isPressedOn = false;
		Time.timeScale = 1f;
		NGUITools.SetActive(ChangeItemWindow.gameObject, false);
	}
	
	void ItemToSave()
	{
		//CAP
		current_cap.name 			= m_cap.name;			
		current_cap.armorID 		= m_cap.armorID;		
		current_cap.armorType 		= m_cap.armorType;	
		current_cap.armorGrade 		= m_cap.armorGrade;		
		current_cap.armorHP 		= m_cap.armorHP;			
		current_cap.def 			= m_cap.def;			
		current_cap.mDef 			= m_cap.mDef;			
		current_cap.mAtk 			= m_cap.mAtk;			
		current_cap.critChance 		= m_cap.critChance;			
		current_cap.hpRegen 		= m_cap.hpRegen;			
		current_cap.potionup 		= m_cap.potionup;			
		current_cap.shield 			= m_cap.shield;			
		current_cap.critOnEnemy 	= m_cap.critOnEnemy;		
		current_cap.slow 			= m_cap.slow;			
		current_cap.thorns			= m_cap.thorns;			
		current_cap.chargeAtk 		= m_cap.chargeAtk;			
		//ROBE
		current_robe.name 			= m_robe.name;			
		current_robe.armorID 		= m_robe.armorID;		
		current_robe.armorType 		= m_robe.armorType;	
		current_robe.armorGrade 	= m_robe.armorGrade;		
		current_robe.armorHP 		= m_robe.armorHP;			
		current_robe.def 			= m_robe.def;			
		current_robe.mDef 			= m_robe.mDef;			
		current_robe.mAtk 			= m_robe.mAtk;			
		current_robe.critChance 	= m_robe.critChance;			
		current_robe.hpRegen 		= m_robe.hpRegen;			
		current_robe.potionup 		= m_robe.potionup;			
		current_robe.shield 		= m_robe.shield;			
		current_robe.critOnEnemy 	= m_robe.critOnEnemy;		
		current_robe.slow 			= m_robe.slow;			
		current_robe.thorns			= m_robe.thorns;			
		current_robe.chargeAtk 		= m_robe.chargeAtk;			
		//SHOES
		current_shoes.name 			= m_shoes.name;			
		current_shoes.armorID 		= m_shoes.armorID;		
		current_shoes.armorType 	= m_shoes.armorType;	
		current_shoes.armorGrade 	= m_shoes.armorGrade;		
		current_shoes.armorHP 		= m_shoes.armorHP;			
		current_shoes.def 			= m_shoes.def;			
		current_shoes.mDef 			= m_shoes.mDef;			
		current_shoes.mAtk 			= m_shoes.mAtk;			
		current_shoes.critChance 	= m_shoes.critChance;			
		current_shoes.hpRegen 		= m_shoes.hpRegen;			
		current_shoes.potionup 		= m_shoes.potionup;			
		current_shoes.shield 		= m_shoes.shield;			
		current_shoes.critOnEnemy 	= m_shoes.critOnEnemy;		
		current_shoes.slow 			= m_shoes.slow;			
		current_shoes.thorns		= m_shoes.thorns;			
		current_shoes.chargeAtk 	= m_shoes.chargeAtk;	
		//CLOACK
		current_cloack.name 		= m_cloack.name;			
		current_cloack.armorID 		= m_cloack.armorID;		
		current_cloack.armorType 	= m_cloack.armorType;	
		current_cloack.armorGrade 	= m_cloack.armorGrade;		
		current_cloack.armorHP 		= m_cloack.armorHP;			
		current_cloack.def 			= m_cloack.def;			
		current_cloack.mDef 		= m_cloack.mDef;			
		current_cloack.mAtk 		= m_cloack.mAtk;			
		current_cloack.critChance 	= m_cloack.critChance;			
		current_cloack.hpRegen 		= m_cloack.hpRegen;			
		current_cloack.potionup 	= m_cloack.potionup;			
		current_cloack.shield 		= m_cloack.shield;			
		current_cloack.critOnEnemy 	= m_cloack.critOnEnemy;		
		current_cloack.slow 		= m_cloack.slow;			
		current_cloack.thorns		= m_cloack.thorns;			
		current_cloack.chargeAtk 	= m_cloack.chargeAtk;

		MaxHp = m_cap.armorHP + m_robe.armorHP + m_shoes.armorHP + m_cloack.armorHP;
		Defence = m_cap.def + m_robe.def + m_shoes.def + m_cloack.def;
		MagicDefence = m_cap.mDef + m_robe.mDef + m_shoes.mDef + m_cloack.mDef;

		Debug.Log 
			(
				"HP : " + MaxHp + " / " +
				"Defence" + Defence + " / " +
				"Damage : " + MagicDefence
				);
	}
}
