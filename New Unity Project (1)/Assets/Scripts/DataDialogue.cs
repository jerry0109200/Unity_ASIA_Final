using UnityEngine;

// �إ߱M�פ������(menuName = "���W��") ��Ƨ�/�l���
[CreateAssetMenu(menuName = "jerry/��ܸ��")]
/// <summary>
/// ��ܸ��
/// �O�s NP�ѡ@�n�򪱮a������ܤ��e
/// </summary>
/// ScriptableObject �}���ƪ��� : �N�{������x�s�� project ��������
public class DataDialogue : ScriptableObject
{
    // TextArea (�̤p��ơA�̤j���) - �ȭ� string
    [Header("��ܤ��e"), TextArea(3, 5)]
    public string[] dialogues;
}
