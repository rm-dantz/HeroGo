using  UnityEngine ;
using  System . Collections ;

public  class  player_control  :  MonoBehaviour  {
    protected  Animator animator ;
	private  bool bJump =  false ;
	private float y = 0.0f;
	private float gravity = 10.0f;   
	private float deltaTime = 0.0f;
	private int direction = 0;       // 0:stop, 1:jump, 2:down
	// Setting
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


    void  Awake()  {
        animator =  GetComponentInChildren < Animator > ();
		bJump =  false ;
		y = y_base;
		Jump_count = 0;
    }
    void  Update  ()  {
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
		if(deltaTime >= Attack_speed)
		{
			shoot();
			deltaTime = 0;
		}
    }

	public void shoot()
	{
		GameObject BulletCreation = Instantiate (m_bulletObj, m_bulletCreator.transform.position, Quaternion.identity) as GameObject;

		BulletCreation.transform.parent = BulletPool;
	}

	public void Jump ()
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
}
