using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    #region 欄位
    [Header("目標圖層")]
    public LayerMask layerTarget;
    [Header("攻擊距離"), Range(0, 5)]
    public float attackDistance = 1.3f;
    [Header("攻擊冷卻時間"), Range(0, 10)]
    public float attackCD = 2.8f;
    [Header("檢查攻擊區域大小與位移")]
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

    [Header("攻擊力"), Range(0, 100)]
    public float attack = 35;

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3AttackOffset), v3AttackSize, 0, layerTarget);
            hit.GetComponent<EnemyBlood>().Hurt(attack);
            print("攻擊到的物件:" + hit.name);
        }
    }
}
