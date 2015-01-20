using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	// Use this for initialization
	float speed = 10f;
	public int player_damage = 0;
	float maxiamDistance;

    public int type = 0;
    public float height = 0f;
    public float width = 0f;

    public Sprite Fire;
    public Sprite Wood;
    public Sprite Water;

	void Awake() 
	{
		maxiamDistance = gameObject.transform.position.x + 15;
	}

	// Update is called once per frame
	void Update() 
	{
		float move = speed * Time.deltaTime; 
		gameObject.transform.Translate(Vector3.right * move, Space.World);
		if (gameObject.transform.position.x > maxiamDistance) 
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Enemy") 
		{
			//Destroy(this.gameObject);
		}
	}

    public void GetInfoFromWeapon(Weapon weapon)
    {
        width = weapon.m_AttackDamage  * (Random.Range(0f, weapon.m_DamageLevel) + 1.0f) ;
        height = weapon.m_AttackDamage * (Random.Range(0f, weapon.m_DamageLevel) + 1.0f);
        speed = 15f / (width * height);

        transform.localScale = new Vector3(width, height, 1f);

        switch(weapon.m_Attribute)
        {
            case 1 : // wood
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Wood;
                break;

            case 2 : // fire
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Fire;
                break;

            case 3 : // water
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Water;
                break;

            default :
                Debug.Log("Bug Code Aha?");
                break;
        }
        
    }
}
