using UnityEngine;

public class LearnMethod : MonoBehaviour
{
    // �D�R�A�ݩʨϥΤ覡
    // 1.�w�q�@�����:�Ω��x�s���骫��
    // 2.����ƥ����P�Q�s�����D�R�A�ݩ����O�ۦP
    // 3.��쥲���n�s����骫�� (�N����즲����줺)
    public Transform traObject;
    public Rigidbody2D rig;

    private void Start()
    {
        // �D�R�A��k
        // �I�s��k
        // �y�k:���W��.�D�R�A��k�W��(�������޼�);
        traObject.Rotate(0, 0, 10);
    }

    //��s�ƥ�:�@������ 60���A60 FPS
    private void Update()
    {
        traObject.Rotate(0, 0, 10);
        rig.AddForce(new Vector2(0, 30));
    }
}
