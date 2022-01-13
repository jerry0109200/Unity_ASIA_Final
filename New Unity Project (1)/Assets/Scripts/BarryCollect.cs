using UnityEngine;

public class BarryCollect : MonoBehaviour
{
    [Header("�ؼйϼh")]
    public LayerMask layerTarget;

    [Header("�ɦ�q"), Range(0, 100)]
    public float heal = 35;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "���W")
        {
            HurtSystem health = collision.GetComponent<HurtSystem>();
            health.Heal(heal);
            Destroy(gameObject);
        }
    }

}
