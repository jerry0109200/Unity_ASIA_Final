using UnityEngine;

public class BarryCollect : MonoBehaviour
{
    [Header("目標圖層")]
    public LayerMask layerTarget;

    [Header("補血量"), Range(0, 100)]
    public float heal = 35;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "狐狸")
        {
            HurtSystem health = collision.GetComponent<HurtSystem>();
            health.Heal(heal);
            Destroy(gameObject);
        }
    }

}
