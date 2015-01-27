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
    Weapon wand;
	int Weapon_Grade;
	int Weapon_Element;
	float Rate = 0f;
	//Item
	ItemInterface m_cap;
	ItemInterface m_robe;
	ItemInterface m_shoes;
	ItemInterface m_cloak;

    void  Awake()  
	{
        animator =  GetComponentInChildren < Animator > ();
		bJump =  false ;
		y = y_base;
		Jump_count = 0;
		m_bulletObj.GetComponent<Bullet> ().player_damage = Damage;

        wand = gameObject.AddComponent<WoodWand>();
        wand.Init();
		Weapon_Grade = 0;
		Weapon_Element = Weapon.Attribute_None;
		m_cap = gameObject.AddComponent<amor_a_info> ();
		m_robe = gameObject.AddComponent<amor_b_info> ();
		m_shoes = gameObject.AddComponent<amor_c_info> ();
		m_cloak = gameObject.AddComponent<amor_d_info> ();
		MaxHp = m_cap.HP + m_robe.HP + m_shoes.HP + m_cloak.HP;
		CurrentHp = MaxHp;
		Defence = m_cap.Defence + m_robe.Defence + m_shoes.Defence + m_cloak.Defence;
		MagicDefence = m_cap.MagicDefence + m_robe.MagicDefence + m_shoes.MagicDefence + m_cloak.MagicDefence;
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
	}

    public void ChangeWeapon(int index)
    {
        Weapon newWand;
		Weapon_Grade = 0;

        switch(index)
        {       
            case 1:
                newWand = new WoodWand();
                break;

            case 2:
                newWand = new SilverWand();
                break;

            case 3:
                newWand = new GoldWand();
                break;

            default :
                newWand = new Weapon();
                break;
        }
        newWand.Init();
        wand.Replace(newWand);
        wand.ShowInfo();
    }

	float CompareToType(int MyType, int OtherType)
	{
		if(MyType == 1)//Fire
		{
			if(OtherType == 1)//Fire
			{
				return 1.0f;
			}
			else if(OtherType == 2)//Wood
			{
				return 1.2f;
			}
			else if(OtherType == 3)//Water
			{
				return 0.8f;
			}
			else
			{
				return 1.0f;
			}
		}
		else if(MyType == 2)//Wood
		{
			if(OtherType == 1)//Fire
			{
				return 0.8f;
			}
			else if(OtherType == 2)//Wood
			{
				return 1.0f;
			}
			else if(OtherType == 3)//Water
			{
				return 1.2f;
			}
			else
			{
				return 1.0f;
			}
		}
		else if(MyType == 3)//Water
		{
			if(OtherType == 1)//Fire
			{
				return 1.2f;
			}
			else if(OtherType == 2)//Wood
			{
				return 0.8f;
			}
			else if(OtherType == 3)//Water
			{
				return 1.0f;
			}
			else
			{
				return 1.0f;
			}
		}
		else
			return 1.0f;
	}

    void OnGUI()
    {
        string [] Label = {"Standard", "Wood", "Silver", "Gold" };
        for ( int i = 1 ; i < 4 ; i++)
        {
            if ( GUI.Button(new Rect(50 + 125 * i, 50f, 100f, 50f), Label[i]))
            {
                ChangeWeapon(i);
            }
        }
    }
}
