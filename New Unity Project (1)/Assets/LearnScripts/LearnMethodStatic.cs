using UnityEngine;

/// <summary>
/// �ǲ��R�A��k
/// </summary>
public class LearnMethodStatic : MonoBehaviour
{
    private void Start()
    {
        // �R�A�y�k
        // �y�k:���O�W��.�R�A��k�W��(�������޼�);
        int rInt = Random.Range(1, 3);
        print("�H����� 1 �P 3 :" + rInt);

        print("-99 ������� :" + Mathf.Abs(-99));
    }
}
