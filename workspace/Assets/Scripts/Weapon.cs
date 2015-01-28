using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    public float    m_AttackDamage; /* for Weapon's damage                  */
    public float    m_AttackDelay;   /* for delay time asfter attack */
    public int      m_DamageLevel;  /* for damage range apply min or max    */
    public int      m_Attribute;    /* for unique attribute : fire, wood,   */
    public int      m_GradeLevel;   /* for Upgrade item when get the item that had equal attribute. GradeMax is 10. */

	public float	m_AttackLevelFactor = 2;
	public float	m_AttackDelayFactor = 0.8f;

    public const int Attribute_Fire     = 1;
    public const int Attribute_Grass     = 2;
    public const int Attribute_Water    = 3;

    public const int GradeLevelMax = 10;

    public Weapon()
    {
    
    }
	void Awake(){
		}
    public virtual void Init()
    {
        m_AttackDamage = 1.0f;
        m_DamageLevel = 0;
        m_Attribute = 1;
        m_GradeLevel = 1;
        m_AttackDelay = 1f;
    }


    public void AccumWand(int _Attribute)
    {
		Debug.Log ("accum att : " + _Attribute);
		if (_Attribute == this.m_Attribute) {
			this.m_AttackDamage += m_AttackLevelFactor; 
			this.m_GradeLevel ++;
			this.m_AttackDelay *= m_AttackDelayFactor;
		}
		else {
			m_Attribute = _Attribute;
			m_AttackDamage = 1.0f;
			m_DamageLevel = 0;
			m_GradeLevel = 1;
			m_AttackDelay = 1f;
		}

       
    }

    public void ShowInfo()
    {
        Debug.Log(  
                    "AttackDamage : " + this.m_AttackDamage + " / " +
                    "AttackDelay : " + this.m_AttackDelay + " / " +
                    "DamageLv : " + this.m_DamageLevel + " / " +
                    "GradeLv : " + this.m_GradeLevel + " / " +
                    "Attribute : " + this.m_Attribute);
    }
    //public virtual Projectile CreateProjectile() { return null; }
}


