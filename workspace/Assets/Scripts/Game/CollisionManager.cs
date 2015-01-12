using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour {

	public Transform BulletPool;

	public GameObject m_plyerObj;
	public GameObject [] m_bulletObj;
	public GameObject [] m_enemyObj;

	void Awake () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GetCurrentBullets()
	{
		//m_bulletObj = BulletPool.GetChild();

		m_bulletObj = GameObject.FindGameObjectsWithTag ("bullets");

		foreach (GameObject bullet in m_bulletObj) {
				
		}
	}
}
