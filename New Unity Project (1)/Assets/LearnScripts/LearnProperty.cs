using UnityEngine;

/// <summary>
/// �ǲ߫D�R�A�ݩ�
/// </summary>
public class LearnProperty : MonoBehaviour
{
    // �D�R�A�ݩʨϥΤ覡
    // 1.�w�q�@�����:�Ω��x�s���骫��
    // 2.����ƥ����P�Q�s�����D�R�A�ݩ����O�ۦP
    // 3.��쥲���n�s����骫��
    public Transform traA;
    public Camera camA;

    private void Start()
    {
        // ���o Get
        // �y�k:���W��.�D�R�A�ݩʦW��
        print("A ���󪺮y��:" + traA.position);
        print("A ��v�����`��:" + camA.depth);
        // �]�w Set
        // �y�k:���W��.�D�R�A�ݩʦW�� ���w ��;
        camA.depth = 9.9f;
        traA.position = new Vector3(-7, 3);
    }
}
