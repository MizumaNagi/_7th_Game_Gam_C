using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �L�����N�^�[�𐶐�����
/// </summary>
public class TestCharaFactory : SingletonMonoBehaviour<TestCharaFactory>
{
    [SerializeField] private GameObject[] headBodyPartsPrefabArr;
    [SerializeField] private GameObject[] leftArmPartsPrefabArr;
    [SerializeField] private GameObject[] rightArmPartsPrefabArr;
    [SerializeField] private GameObject[] leftLegPartsPrefabArr;
    [SerializeField] private GameObject[] rightLegPartsPrefabArr;

    private int partsTypeLen;

    private void Start()
    {
        if (IsAllPartsSameNumber()) partsTypeLen = headBodyPartsPrefabArr.Length;
        else UtilitySystem.EndGame();
    }

    /// <summary>
    /// ������Ԃɂ���L�����N�^�[�𐶐�����
    /// </summary>
    /// <returns></returns>
    public GameObject GenerateInitCharacter(Chara_Type headBodyPart)
    {
        GameObject newCharaParent = new GameObject("Character");
        CharaDetail charaDetail = newCharaParent.AddComponent<CharaDetail>();
        MakeNewHeadBody(charaDetail, headBodyPart);

        return newCharaParent;
    }

    /// <summary>
    /// �����_���ȓ�/��, ���r, �E�r, ����, �E�����t�����L�����N�^�[�𐶐�����
    /// </summary>
    /// <param name="isAlignCharacter">�p�[�c�̎�ނ𑵂��Đ������邩</param>
    /// <returns></returns>
    public GameObject RandomGenerateChatacter(bool isAlignCharacter)
    {
        GameObject newCharaParent = new GameObject("Character");
        CharaDetail charaDetail = newCharaParent.AddComponent<CharaDetail>();
        Transform newCharaParentTrans = newCharaParent.transform;
        int[] rndIndexEachParts = new int[5];

        // �e�p�[�c�̕��ʌ���
        if (isAlignCharacter)
        {
            rndIndexEachParts[0] = Random.Range(0, partsTypeLen);
            for(int i = 1; i < 5; i++)
            {
                rndIndexEachParts[i] = rndIndexEachParts[0];
            }
        }
        else
        {
            for(int i = 0; i < 5; i++)
            {
                rndIndexEachParts[i] = Random.Range(0, partsTypeLen);
            }
        }

        // �e�p�[�c����
        GameObject[] newParts = new GameObject[5];
        newParts[0] = Instantiate(headBodyPartsPrefabArr[rndIndexEachParts[0]], newCharaParentTrans);
        newParts[1] = Instantiate(leftArmPartsPrefabArr[rndIndexEachParts[1]], newCharaParentTrans);
        newParts[2] = Instantiate(rightArmPartsPrefabArr[rndIndexEachParts[2]], newCharaParentTrans);
        newParts[3] = Instantiate(leftLegPartsPrefabArr[rndIndexEachParts[3]], newCharaParentTrans);
        newParts[4] = Instantiate(rightLegPartsPrefabArr[rndIndexEachParts[4]], newCharaParentTrans);

        for(int i = 0; i < 5; i++)
        {
            newParts[i].transform.localPosition = Vector3.zero;
        }

        // �e�p�[�c�o�^
        charaDetail.ChgHeadBody(newParts[0], (Chara_Type)rndIndexEachParts[0]);
        charaDetail.ChgLeftArm(newParts[1], (Chara_Type)rndIndexEachParts[1]);
        charaDetail.ChgRightArm(newParts[2], (Chara_Type)rndIndexEachParts[2]);
        charaDetail.ChgLeftLeg(newParts[3], (Chara_Type)rndIndexEachParts[3]);
        charaDetail.ChgRightLeg(newParts[4], (Chara_Type)rndIndexEachParts[4]);

        return newCharaParent;
    }

    /// <summary>
    /// ���̃p�[�c��V�����t����
    /// </summary>
    /// <param name="parent">�p�[�c��t���ւ���e��</param>
    /// <param name="charaType">�t���铪�p�[�c�̎�� (�ȗ��\)</param>
    /// <returns>���������p�[�c</returns>
    public GameObject MakeNewHeadBody(CharaDetail parent, Chara_Type? charaType = null)
    {
        Chara_Type _charaType = charaType ?? (Chara_Type)Random.Range(0, partsTypeLen);
        GameObject newPart = Instantiate(headBodyPartsPrefabArr[(int)charaType], parent.transform);
        newPart.transform.localPosition = Vector3.zero;
        parent.ChgHeadBody(newPart, _charaType);

        return newPart;
    }

    /// <summary>
    /// ���r�̃p�[�c��V�����t����
    /// </summary>
    /// <param name="parent">�p�[�c��t���ւ���e��</param>
    /// <param name="charaType">�t���鍶�r�p�[�c�̎�� (�ȗ��\)</param>
    /// <returns>���������p�[�c</returns>
    public GameObject MakeNewLeftArm(CharaDetail parent, Chara_Type? charaType = null)
    {
        Chara_Type _charaType = charaType ?? (Chara_Type)Random.Range(0, partsTypeLen);
        GameObject newPart = Instantiate(leftArmPartsPrefabArr[(int)charaType], parent.transform);
        newPart.transform.localPosition = Vector3.zero;
        parent.ChgLeftArm(newPart, _charaType);

        return newPart;
    }

    /// <summary>
    /// �E�r�̃p�[�c��V�����t����
    /// </summary>
    /// <param name="parent">�p�[�c��t���ւ���e��</param>
    /// <param name="charaType">�t����E�r�p�[�c�̎�� (�ȗ��\)</param>
    /// <returns>���������p�[�c</returns>
    public GameObject MakeNewRightArm(CharaDetail parent, Chara_Type? charaType = null)
    {
        Chara_Type _charaType = charaType ?? (Chara_Type)Random.Range(0, partsTypeLen);
        GameObject newPart = Instantiate(rightArmPartsPrefabArr[(int)charaType], parent.transform);
        newPart.transform.localPosition = Vector3.zero;
        parent.ChgRightArm(newPart, _charaType);

        return newPart;
    }

    /// <summary>
    /// �����̃p�[�c��V�����t����
    /// </summary>
    /// <param name="parent">�p�[�c��t���ւ���e��</param>
    /// <param name="charaType">�t���鍶���p�[�c�̎�� (�ȗ��\)</param>
    /// <returns>���������p�[�c</returns>
    public GameObject MakeNewLeftLeg(CharaDetail parent, Chara_Type? charaType = null)
    {
        Chara_Type _charaType = charaType ?? (Chara_Type)Random.Range(0, partsTypeLen);
        GameObject newPart = Instantiate(leftLegPartsPrefabArr[(int)charaType], parent.transform);
        newPart.transform.localPosition = Vector3.zero;
        parent.ChgLeftLeg(newPart, _charaType);

        return newPart;
    }

    /// <summary>
    /// �E�r�̃p�[�c��V�����t����
    /// </summary>
    /// <param name="parent">�p�[�c��t���ւ���e��</param>
    /// <param name="charaType">�t����E�r�p�[�c�̎�� (�ȗ��\)</param>
    /// <returns>���������p�[�c</returns>
    public GameObject MakeNewRightLeg(CharaDetail parent, Chara_Type? charaType = null)
    {
        Chara_Type _charaType = charaType ?? (Chara_Type)Random.Range(0, partsTypeLen);
        GameObject newPart = Instantiate(rightLegPartsPrefabArr[(int)charaType], parent.transform);
        newPart.transform.localPosition = Vector3.zero;
        parent.ChgRightLeg(newPart, _charaType);

        return newPart;
    }

    private bool IsAllPartsSameNumber()
    {
        bool result = true;
        int i = headBodyPartsPrefabArr.Length;
        if (i != leftArmPartsPrefabArr.Length) result = false;
        if (i != rightArmPartsPrefabArr.Length) result = false;
        if (i != leftLegPartsPrefabArr.Length) result = false;
        if (i != rightLegPartsPrefabArr.Length) result = false;

        if (result == false) Debug.LogError("�S�p�[�c���ψ�̐��Z�b�g����Ă��܂���B");
        return result;
    }
}
