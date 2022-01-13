using UnityEngine;
using UnityEngine.UI;

public class EnemyBlood : MonoBehaviour
{
    [Header("��q")]
    public float hp = 100;
    [Header("�ʵe�Ѽ�")]
    public string parameterDead = "Ĳ�o���`";

    private float hpMax;
    private Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        hpMax = hp;
    }

    /// <summary>
    /// ����
    /// </summary>
    /// <param name="damage">�����쪺�ˮ`</param>
    public void Hurt(float damage)
    {
        hp = hp - damage;
        if (hp <= 0)
        {
            Dead();
            ani.SetTrigger(parameterDead);
            Destroy(gameObject);
        }
     
        
    }

    private void Dead()
    {
        ani.SetTrigger(parameterDead);
    }
}
