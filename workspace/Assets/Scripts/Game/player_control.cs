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
	float Attack_speed = 1;
	float MaxHp = 0f;
	float CurrentHp = 0f;
	int MP = 10;
	float MP_Recorvery = 1.0f;
	int Damage = 1;
	float Defence = 0.0f;
	float MagicDefence = 0.0f;
	float Jump_height = 1.0f;
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
		public string 	Item_Name;
		public float 	HP;
		public float 	Defence;
		public float	MagicDefence;
		public int 		Damage;
		public int 		Cri;
		public int 		HP_Regen;
		public int 		Barrier;
		public int 		Potion_Up;
		public int 		Item_Type;
	}
	public struct ROBE
	{
		public string 	Item_Name;
		public float 	HP;
		public float 	Defence;
		public float	MagicDefence;
		public int 		Damage;
		public int 		Cri;
		public int 		HP_Regen;
		public int 		Barrier;
		public int 		Potion_Up;
		public int 		Item_Type;
	}
	public struct SHOES
	{
		public string 	Item_Name;
		public float 	HP;
		public float 	Defence;
		public float	MagicDefence;
		public int 		Damage;
		public int 		Cri;
		public int 		HP_Regen;
		public int 		Barrier;
		public int 		Potion_Up;
		public int 		Item_Type;
	}
	public struct CLOACK
	{
		public string 	Item_Name;
		public float 	HP;
		public float 	Defence;
		public float	MagicDefence;
		public int 		Damage;
		public int 		Cri;
		public int 		HP_Regen;
		public int 		Barrier;
		public int 		Potion_Up;
		public int 		Item_Type;
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
			ItemType = coll.gameObject.GetComponent<DropItem>().Type;
			NewItemType = coll.gameObject.GetComponent<DropItem>().Type;
			NGUITools.SetActive(ChangeItemWindow.gameObject, true);
			Time.timeScale = 0f;
			NewDes.gameObject.GetComponent<NewItemDes>().DropItem = coll.gameObject;
			DropItemInfo = coll.gameObject;
			MyDes.SendMessage("Init");
			NewDes.SendMessage("Init");
		}

		if (coll.gameObject.tag.Equals("Wand"))
		{
			Debug.Log("ddd");
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
		current_cap.Item_Name = m_cap.Item_Name;
		current_cap.HP = m_cap.HP;
		current_cap.Defence = m_cap.Defence;
		current_cap.MagicDefence = m_cap.MagicDefence;
		current_cap.Damage = m_cap.Damage;
		current_cap.Cri = m_cap.Cri;
		current_cap.HP_Regen = m_cap.HP_Regen;
		current_cap.Barrier = m_cap.Barrier;
		current_cap.Potion_Up = m_cap.Potion_Up;
		current_cap.Item_Type = m_cap.Item_Type;
		//ROBE
		current_robe.Item_Name = m_robe.Item_Name;
		current_robe.HP = m_robe.HP;
		current_robe.Defence = m_robe.Defence;
		current_robe.MagicDefence = m_robe.MagicDefence;
		current_robe.Damage = m_robe.Damage;
		current_robe.Cri = m_robe.Cri;
		current_robe.HP_Regen = m_robe.HP_Regen;
		current_robe.Barrier = m_robe.Barrier;
		current_robe.Potion_Up = m_robe.Potion_Up;
		current_robe.Item_Type = m_robe.Item_Type;
		//SHOES
		current_shoes.Item_Name = m_shoes.Item_Name;
		current_shoes.HP = m_shoes.HP;
		current_shoes.Defence = m_shoes.Defence;
		current_shoes.MagicDefence = m_shoes.MagicDefence;
		current_shoes.Damage = m_shoes.Damage;
		current_shoes.Cri = m_shoes.Cri;
		current_shoes.HP_Regen = m_shoes.HP_Regen;
		current_shoes.Barrier = m_shoes.Barrier;
		current_shoes.Potion_Up = m_shoes.Potion_Up;
		current_shoes.Item_Type = m_shoes.Item_Type;
		//CLOACK
		current_cloack.Item_Name = m_cloack.Item_Name;
		current_cloack.HP = m_cloack.HP;
		current_cloack.Defence = m_cloack.Defence;
		current_cloack.MagicDefence = m_cloack.MagicDefence;
		current_cloack.Damage = m_cloack.Damage;
		current_cloack.Cri = m_cloack.Cri;
		current_cloack.HP_Regen = m_cloack.HP_Regen;
		current_cloack.Barrier = m_cloack.Barrier;
		current_cloack.Potion_Up = m_cloack.Potion_Up;
		current_cloack.Item_Type = m_cloack.Item_Type;

		MaxHp = m_cap.HP + m_robe.HP + m_shoes.HP + m_cloack.HP;
		Defence = m_cap.Defence + m_robe.Defence + m_shoes.Defence + m_cloack.Defence;
		MagicDefence = m_cap.MagicDefence + m_robe.MagicDefence + m_shoes.MagicDefence + m_cloack.MagicDefence;

		Debug.Log 
			(
				"HP : " + MaxHp + " / " +
				"Defence" + Defence + " / " +
				"Damage : " + MagicDefence
				);
	}
}
