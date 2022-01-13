using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    #region ���
    [Header("�ؼйϼh")]
    public LayerMask layerTarget;
    [Header("�����Z��"), Range(0, 5)]
    public float attackDistance = 1.3f;
    [Header("�����N�o�ɶ�"), Range(0, 10)]
    public float attackCD = 2.8f;
    [Header("�ˬd�����ϰ�j�p�P�첾")]
    public Vector3 v3AttackSize = Vector3.one;
    public Vector3 v3AttackOffset;

    private Rigidbody2D rig;
    #endregion

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3AttackOffset), v3AttackSize);
    }

    private void Update()
    {
        Attack();
    }

    [Header("�����O"), Range(0, 100)]
    public float attack = 35;

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3AttackOffset), v3AttackSize, 0, layerTarget);
            hit.GetComponent<EnemyBlood>().Hurt(attack);
            print("�����쪺����:" + hit.name);
        }
    }
}
