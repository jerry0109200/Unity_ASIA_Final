using UnityEngine;
using UnityEngine.UI;        // �ޥ� ���� API
using UnityEngine.Events;    // �ޥ� �ƥ� API

public class HurtSystem : MonoBehaviour
{
    [Header("���")]
    public Image imgHpBar;
    [Header("��q")]
    public float hp = 100;
    [Header("�ʵe�Ѽ�")]
    public string parameterDead = "��Ĭ�{���n�J";
    [Header("���`�ƥ�")]
    public UnityEvent onDead;

    private float hpMax;
    private Animator ani;

    // ����ƥ� : �b Start ���e����@��
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
        hp -= damage;
        imgHpBar.fillAmount = hp / hpMax;
        if (hp <= 0) Dead();
    }

    /// <summary>
    /// �ɦ�
    /// </summary>
    /// <param name="health">�ɥR����q</param>
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
