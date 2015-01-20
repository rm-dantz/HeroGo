using UnityEngine;
using System.Collections;
public class Projectile : MonoBehaviour
{
    public int   m_Attribute;
    public float m_moveSpeed;
    public float m_WidthSize;
    public float m_HeightSize;
    public float m_CriticalRate;
    public float m_Damage;

    public const float IncreaseCriticalPercent = 10.0f;

    public Projectile()
    {
        Init();
    }

    void Awake()
    {
        Init();
    }

    public void Init()
    {
        m_Attribute = Weapon.Attribute_None;
        m_moveSpeed = 0f;
        m_WidthSize = 0f;
        m_HeightSize = 0f;
        m_HeightSize = 0f;
        m_CriticalRate = 0f;
        m_Damage = 0f;
    }

    public virtual void GetInfoFromWeapon(Weapon weaponInfo) 
    {
        m_Attribute = weaponInfo.m_Attribute;
        m_CriticalRate = weaponInfo.m_GradeLevel * IncreaseCriticalPercent;
        m_WidthSize = weaponInfo.m_DamageLevel * 0.1f;
        m_HeightSize = weaponInfo.m_DamageLevel * 0.1f;
        m_Damage = Random.Range(1.0f, 5.0f) * weaponInfo.m_AttackDamage;
        m_moveSpeed = 1.0f / (m_HeightSize * m_HeightSize);
    }

    void OnDestroy()
    {
        Debug.Log("Damage : " + m_Damage);
    }

    void Update()
    {
        Vector3 moveVector = Vector3.right * m_moveSpeed * Time.deltaTime;

        transform.Translate(moveVector);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.tag.Equals("Enemy"))
       {
           GameObject.Destroy(this.gameObject);
       }
    }
}
