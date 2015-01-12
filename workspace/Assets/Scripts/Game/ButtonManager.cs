using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour 
{
	public player_control m_objPlayer;	
	void Awake() {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnClickStart ()
	{
		m_objPlayer.Jump ();
	}

	public void ClickShoot()
	{
		m_objPlayer.shoot ();
	}
}
