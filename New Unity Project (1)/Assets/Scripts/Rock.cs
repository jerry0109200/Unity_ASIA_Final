using UnityEngine;

public class Rock : MonoBehaviour
{
    [Header("�ؼйϼh")]
    public LayerMask layerTarget;

    //[Header("�����O"), Range(0, 100)]
    //public float attack = 35;
    public int damage;

    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "���W")
        {
            HurtSystem fox = collision.GetComponent<HurtSystem>();
            fox.Hurt(damage);
            Destroy(gameObject);
        }
    }
}
