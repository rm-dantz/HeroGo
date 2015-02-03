using UnityEngine;
using System.Collections;

public class monsterData   {

	public monsterData(){
	}

	public string name;
	public int ID;
	public int type;
	public int element;
	public int HP;
	public int physAtk;
	public int magicAtk;
	public float moveSpd;
	public float atkSpd;
	public float shotSize;
	public float shotSpd;
	public int flightPattern;
	public int gold;
	public int height;
	public int length;


	public monsterData(monsterData _mons){
		name	 		= _mons.name;
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

	}

	~monsterData(){
	}
}
