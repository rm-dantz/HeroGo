using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour 
{
	public player_control m_objPlayer;	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnClickStart ()
	{
		m_objPlayer.Jump ();
	}
}
