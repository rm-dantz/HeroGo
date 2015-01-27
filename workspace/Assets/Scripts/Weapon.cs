using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    public float    m_AttackDamage; /* for Weapon's damage                  */
    public float    m_AttackDelay;   /* for delay time asfter attack */
    public int      m_DamageLevel;  /* for damage range apply min or max    */
    public int      m_Attribute;    /* for unique attribute : fire, wood,   */
    public int      m_GradeLevel;   /* for Upgrade item when get the item that had equal attribute. GradeMax is 10. */

    public const int Attribute_None     = 0;
    public const int Attribute_Wood     = 1;
    public const int Attribute_Fire     = 2;
    public const int Attribute_Water    = 3;

    public const int GradeLevelMax = 10;

    public Weapon()
    {
    
    }

    public virtual void Init()
    {
        m_AttackDamage = 0.0f;
        m_DamageLevel = 0;
        m_Attribute = Attribute_None;
        m_GradeLevel = 0;
        m_AttackDelay = 0f;
    }

    public void Replace(Weapon w)
    {

        if (int.Equals(m_Attribute, w.m_Attribute))
        {
            if ( this.m_GradeLevel < GradeLevelMax )
                ++this.m_GradeLevel;
        }
        else
        {
            this.m_GradeLevel = 1;
            this.m_Attribute = w.m_Attribute;
        }

        this.m_AttackDelay  = w.m_AttackDelay;
        this.m_DamageLevel  = w.m_DamageLevel;
        this.m_GradeLevel   = w.m_GradeLevel;
        this.m_AttackDelay  = w.m_AttackDelay;
    }

    public void Replace(string WeaponName, float AttackDamage, float AttackDelay, int DamageLevel, int GradeLevel, int Attribute)
    {
        m_AttackDamage = AttackDamage;
        m_AttackDelay = AttackDelay;
        m_DamageLevel = DamageLevel;
        m_GradeLevel = GradeLevel;
        m_Attribute = Attribute;
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



public class WoodWand : Weapon
{
    public WoodWand()
    {
        
    }

    public override void Init()
    {
        m_Attribute = Attribute_Wood;
        m_DamageLevel = 1;
        m_GradeLevel = 1;
        m_AttackDelay = 0.75f;
        m_AttackDamage = 10.0f;

    }
}

public class SilverWand : Weapon
{
    public SilverWand()
    {
        
    }

    public override void Init()
    {
        m_Attribute = Attribute_Fire;
        m_AttackDelay = 0.75f;
        m_DamageLevel = 1;
        m_GradeLevel = 1;
        m_AttackDamage = 10.0f;
    }
}

public class GoldWand : Weapon
{
    public GoldWand()
    {
        
    }

    public override void Init()
    {
        m_Attribute = Attribute_Water;
        m_AttackDelay = 0.75f;
        m_DamageLevel = 1;
        m_GradeLevel = 1;
        m_AttackDamage = 10.0f;
    }
}