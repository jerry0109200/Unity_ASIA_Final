using UnityEngine;
using UnityEngine.UI;        // 引用 介面 API
using UnityEngine.Events;    // 引用 事件 API

public class HurtSystem : MonoBehaviour
{
    [Header("血條")]
    public Image imgHpBar;
    [Header("血量")]
    public float hp = 100;
    [Header("動畫參數")]
    public string parameterDead = "到蘇州賣鴨蛋";
    [Header("死亡事件")]
    public UnityEvent onDead;

    private float hpMax;
    private Animator ani;

    // 喚醒事件 : 在 Start 之前執行一次
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
        hp -= damage;
        imgHpBar.fillAmount = hp / hpMax;
        if (hp <= 0) Dead();
    }

    /// <summary>
    /// 補血
    /// </summary>
    /// <param name="health">補充的血量</param>
    public void Heal(float health)
    {
        hp = hp + health;
        imgHpBar.fillAmount = hp / hpMax;
    }

    private void Dead()
    {
        ani.SetTrigger(parameterDead);
        onDead.Invoke();
    }
}
