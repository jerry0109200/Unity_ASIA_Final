using UnityEngine;

/// <summary>
/// ��� : 2D ��V���b����
/// </summary>
public class Controller2D : MonoBehaviour
{
    #region ��� : ���}
    [Header("���ʳt��"), Range(0, 500)]
    public float speed = 3.5f;
    [Header("���D����"), Range(0, 15000)]
    public float jump = 500;
    [Header("�ˬd�a�O�ؤo�P�첾")]
    [Range(0,1)]
    public float checkGroundRadius = 0.1f;
    public Vector3 checkGroundOffset;
    [Header("���D����P�i���D�ϼh")]
    public KeyCode keyJump = KeyCode.Space;
    public LayerMask canJumpLayer;
    public KeyCode keyRush = KeyCode.LeftShift;
    public LayerMask canRushLayer;
    [Header("�ʵe�Ѽ� : �����P���D")]
    public string parameterWalk = "�}������";
    public string parameterJump = "�}�����D";
    #endregion

    #region ���:�p�H
    private Animator ani;
    /// <summary>
    /// ���餸�� Rigidbody 2D
    /// </summary>
    private Rigidbody2D rig;
    // �N�p�H�����ܦb�ݩʭ��O�W
    [SerializeField]
    /// <summary>
    /// �O�_�b�a�O�W
    /// </summary>
    private bool isGrounded;
    #endregion

    #region �ƥ�
    /// <summary>
    /// ø�s�ϥ�
    /// �b Unity ø�s���U�Ϊ��ϥ�
    /// �u���B�g�u�B�ϧΡB��ΡB���ΡB�Ϥ�
    /// �ϥ� Gizmos ���O
    /// </summary>
    private void OnDrawGizmos()
    {
        // 1. �M�w�ϥ��C��
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        // 2. �M�wø�s�ϧ�
        // transform.position �����󪺥@�ɮy��
        // transform.TransformDirection() �ھ��ܧΤ��󪺰ϰ�y���ഫ���@�ɮy��
        Gizmos.DrawSphere(transform.position +
            transform.TransformDirection(checkGroundOffset), checkGroundRadius);
    }

    private void Start()
    {
        // ������� = ���o����<2D ����>()
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    /// <summary>
    /// Update �� 60FPS
    /// �T�w��s�ƥ� : 50 FPS\
    /// �B�z���z�欰
    /// </summary>
    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Flip();
        CheckGround();
        Jump();
        Rush();
    }
    #endregion

    #region ��k
    /// <summary>
    /// 1. ���a�O�_���������� ���k��V�� ��A�BD
    /// 2. ���󲾰ʦ欰 (API)
    /// </summary>
    private void Move()
    {
        // h �� ���w�� ��J.���o�b�V(�����b) - �����b�N�����k��P AD
        float h = Input.GetAxis("Horizontal");
        //print("���a�b���k�����" + h);

        // ���餸��.�[�t�� = �s �G���V�q(h �� * ���ʳt�סA����.�[�t��.����);
        rig.velocity = new Vector2(h * speed, rig.velocity.y);

        // �� ������ ������s �Ŀ� �����Ѽ�
        ani.SetBool(parameterWalk, h != 0);
    }

    /// <summary>
    /// ½��:
    /// h �� �p�� 0 ��:���� Y 180
    /// h �� �j�� 0 �k:���� Y 0
    /// </summary>
    private void Flip()
    {
        float h = Input.GetAxis("Horizontal");

        // �p�G h �� �p�� 0 ��:���� Y 180
        if (h < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        // �p�G h �� �j�� 0 �k:���� Y 0
        else if (h > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }

    /// <summary>
    /// �ˬd�O�_�b�a�O
    /// </summary>
    private void CheckGround()
    {
        // �I����T = 2D ���z.�л\���(�����I�A�b�|�A�ϼh)
        Collider2D hit = Physics2D.OverlapCircle(transform.position +
            transform.TransformDirection(checkGroundOffset), checkGroundRadius, canJumpLayer);

        //print("�I�쪺����W��:" + hit.name);

        isGrounded = hit;

        // �� ���b�a�O�W �Ŀ�
        ani.SetBool(parameterJump, !isGrounded);
    }

    /// <summary>
    /// ���D
    /// </summary>
    private void Jump()
    {
        // �p�G �b�a�O�W �åB ���U���w����
        if (isGrounded && Input.GetKeyDown(keyJump))
        {
            // ����.�K�[���O(�G���V�q)
            rig.AddForce(new Vector2(0, jump));
        }
    }

    /// <summary>
    /// �Ĩ�
    /// </summary>
    private void Rush()
    {
        if(Input.GetKey(keyRush))
        {
            speed = 10;
        }
        else
        {
            speed = 5;
        }
    }
    #endregion
}