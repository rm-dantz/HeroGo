using  UnityEngine ;
using  System . Collections ;

public  class  player_control  :  MonoBehaviour  {
    protected  Animator animator ;
	private  bool Jump =  false ;

    void  Start  ()  {
        animator =  GetComponent < Animator > ();
		Jump =  false ;
    }
    void  Update  ()  {
        if ( animator )
        {
			if (Input.GetMouseButtonDown(0))
			{
				Jump = true;
				Debug.Log("Click");
			}
			if(Jump)
			{

			}
			animator . SetBool ( "Jump" , Jump );
	    }
    }
}
