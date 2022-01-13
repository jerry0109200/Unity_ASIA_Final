using UnityEngine;

public class Rock : MonoBehaviour
{
    [Header("目標圖層")]
    public LayerMask layerTarget;

    //[Header("攻擊力"), Range(0, 100)]
    //public float attack = 35;
    public int damage;

    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "狐狸")
        {
            HurtSystem fox = collision.GetComponent<HurtSystem>();
            fox.Hurt(damage);
            Destroy(gameObject);
        }
    }
}
