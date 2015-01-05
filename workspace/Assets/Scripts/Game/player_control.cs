using  UnityEngine ;
using  System . Collections ;

public  class  player_control  :  MonoBehaviour  {
    protected  Animator animator ;
	private  bool bJump =  false ;
	private float y = 0.0f;
	private float gravity = 10.0f;     // 중력느낌용
	private int direction = 0;       // 0:정지상태, 1:점프중, 2:다운중
	// 설정값
	private const float jump_speed = 0.2f;  // 점프속도
	private const float jump_accell = 0.01f; // 점프가속
	private const float y_base = 0.0f;      // 캐릭터가 서있는 기준점
	private int Jump_count = 0;

    void  Start  ()  {
        animator =  GetComponent < Animator > ();
		bJump =  false ;
		y = y_base;
    }
    void  Update  ()  {
        if ( animator )
        {
			animator . SetBool ( "Jump" , bJump );
			JumpProcess();
			//if (Input.GetMouseButtonDown(0))
			//{
			//	DoJump();
		//		Jump = true;
		//	}
			// y값을 gameObject에 적용하세요.
			Vector3 pos = gameObject.transform.position;
			pos.y = y;
			gameObject.transform.position = pos;

	    }
    }

	public void Jump ()
	{
		DoJump();
		bJump = true;
	}

	void DoJump() // 점프키 누를때 1회만 호출
	{
		direction = 1;
		gravity = jump_speed;
		Jump_count++;
	}
	void JumpProcess()
	{
		switch (direction)
		{
		case 0: // 2단 점프시 처리
		{
			bJump = false;
			if (y > y_base)
			{
				if (y >= jump_accell)
				{
					//y -= jump_accell;
					y -= gravity;
				}
				else
				{
					y = y_base;
				}
			}
			break;
		}
		case 1: // up
		{
			y += gravity;
			if (gravity <= 0.0f && Jump_count < 2)
			{
				direction = 2;
			}
			else
			{
				gravity -= jump_accell;
			}
			break;
		}
			
		case 2: // down
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
