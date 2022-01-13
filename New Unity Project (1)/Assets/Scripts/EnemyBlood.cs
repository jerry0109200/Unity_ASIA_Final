using UnityEngine;
using UnityEngine.UI;

public class EnemyBlood : MonoBehaviour
{
    [Header("血量")]
    public float hp = 100;
    [Header("動畫參數")]
    public string parameterDead = "觸發死亡";

    private float hpMax;
    private Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        hpMax = hp;
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">接受到的傷害</param>
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
