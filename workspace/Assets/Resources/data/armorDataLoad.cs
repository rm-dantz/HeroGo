using UnityEngine;
using System;
using System.Collections;

public class armorDataLoad : CSVParser {

	
	string _baseFileName;
	ArrayList _armorDataMap = new ArrayList();
	
	public armorDataLoad () {
		_baseFileName = "data/armor_data";
		Debug.Log( _baseFileName );
	}
	
	public override void Load()
	{
		_armorDataMap.Add (new armorData ());
		LoadFile( _baseFileName );
	}
	
	public int armorNum () {
		return _armorDataMap.Count;
	}

	
	public override void Parse( string[] inputData )
	{
		
		int count = 0;
		armorData tempData = new armorData();
		Debug.Log (inputData [0]);
		tempData.name 			= inputData[count++];
		tempData.armorID 		= Convert.ToInt32( inputData[count++] );
		tempData.armorType 		= Convert.ToInt32( inputData[count++] );
		tempData.armorGrade 	= Convert.ToInt32( inputData[count++] );
		tempData.armorHP	  	= Convert.ToInt32( inputData[count++] );
		tempData.def 			= Convert.ToInt32( inputData[count++] );	
		tempData.mDef 			= Convert.ToInt32( inputData[count++] );
		tempData.mAtk 			= Convert.ToInt32( inputData[count++] );
		tempData.critChance     = (float)Convert.ToDouble( inputData [count++] ); 
		tempData.hpRegen 	    = (float)Convert.ToDouble( inputData [count++] ); 
		tempData.shield 		= Convert.ToInt32( inputData[count++] );
		tempData.critOnEnemy    = Convert.ToInt32( inputData[count++] );
		tempData.slow 		    = Convert.ToInt32( inputData[count++] );
		tempData.thorns 		= Convert.ToInt32( inputData[count++] );
		tempData.chargeAtk		= Convert.ToInt32( inputData[count++] );

		
		
		_armorDataMap.Add( tempData );
		
		
	}
	
	private armorData GetArmorData( int armorID )
	{
		foreach (armorData returnData in _armorDataMap) {
			if ( returnData.armorID == armorID )
				return returnData;
		}
		return null;
	}
}
