using  UnityEngine ;
using  System . Collections ;

public  class  player_control  :  MonoBehaviour  {
	//Character Animation
    protected  Animator animator ;
	private  bool bJump =  false ;
	private float y = 0.0f;
	private float gravity = 10.0f;   
	private float deltaTime = 0.0f;
	private int direction = 0;       // 0:stop, 1:jump, 2:down
	//Character Setting
	private const float jump_speed = 0.2f;  
	private const float jump_accell = 0.01f; 
	private const float y_base = -1.5f;     
	private int Jump_count;
	//Bullet
	public GameObject m_bulletObj;
	public Transform BulletPool;
	//Bullet Creator
	public GameObject m_bulletCreator;
	//Player Abillity
	public float Attack_speed = 1;
	public int HP = 10;
	public int MP = 10;
	public float MP_Recorvery = 1.0f;
	public int Damage = 1;
	public float Defence = 0.0f;
	public float Jump_height = 1.0f;

    public Weapon wand;

    void  Awake()  
	{
        animator =  GetComponentInChildren < Animator > ();
		bJump =  false ;
		y = y_base;
		Jump_count = 0;
		m_bulletObj.GetComponent<Bullet> ().player_damage = Damage;

        wand = gameObject.AddComponent<WoodWand>();
        wand.Init();

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

        BulletCreation.transform.position = new Vector3(BulletCreation.transform.position.x, Random.Range(0f, 1f) - 2.5f, BulletCreation.transform.position.z);
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
						y -= gravity;
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
				y += gravity;
				if (gravity <= 0.0f)
				{
					direction = 2;
				}
				else
				{
					gravity -= jump_accell;
				}
				break;
			}
				
			case 2:
			{
				y -= gravity;
				if (y > y_base)
				{
					gravity += jump_accell;
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
			int EnemyDamage = coll.gameObject.GetComponent<Enemy>().Damage;
			Destroy (coll.gameObject);
			HP -= EnemyDamage;
			if (HP <= 0)
				Destroy (this.gameObject);
		} 
	}

    public void ChangeWeapon(int index = 0)
    {
        Weapon newWand;

        switch(index)
        {
            case 0:
                newWand = new StandardWand();
                break;
                
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


    void OnGUI()
    {
        string [] Label = {"Standard", "Wood", "Silver", "Gold" };
        for ( int i = 0 ; i < 4 ; i++)
        {
            if ( GUI.Button(new Rect(50 + 125 * i, 50f, 100f, 50f), Label[i]))
            {
                ChangeWeapon(i);
            }
        }
    }
}
