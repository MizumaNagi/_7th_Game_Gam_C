using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キャラクターを生成する
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
    /// 初期状態にあるキャラクターを生成する
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
    /// ランダムな頭/胴, 左腕, 右腕, 左足, 右足が付いたキャラクターを生成する
    /// </summary>
    /// <param name="isAlignCharacter">パーツの種類を揃えて生成するか</param>
    /// <returns></returns>
    public GameObject RandomGenerateChatacter(bool isAlignCharacter)
    {
        GameObject newCharaParent = new GameObject("Character");
        CharaDetail charaDetail = newCharaParent.AddComponent<CharaDetail>();
        Transform newCharaParentTrans = newCharaParent.transform;
        int[] rndIndexEachParts = new int[5];

        // 各パーツの部位決定
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

        // 各パーツ生成
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

        // 各パーツ登録
        charaDetail.ChgHeadBody(newParts[0], (Chara_Type)rndIndexEachParts[0]);
        charaDetail.ChgLeftArm(newParts[1], (Chara_Type)rndIndexEachParts[1]);
        charaDetail.ChgRightArm(newParts[2], (Chara_Type)rndIndexEachParts[2]);
        charaDetail.ChgLeftLeg(newParts[3], (Chara_Type)rndIndexEachParts[3]);
        charaDetail.ChgRightLeg(newParts[4], (Chara_Type)rndIndexEachParts[4]);

        return newCharaParent;
    }

    /// <summary>
    /// 頭のパーツを新しく付ける
    /// </summary>
    /// <param name="parent">パーツを付け替える親元</param>
    /// <param name="charaType">付ける頭パーツの種類 (省略可能)</param>
    /// <returns>生成したパーツ</returns>
    public GameObject MakeNewHeadBody(CharaDetail parent, Chara_Type? charaType = null)
    {
        Chara_Type _charaType = charaType ?? (Chara_Type)Random.Range(0, partsTypeLen);
        GameObject newPart = Instantiate(headBodyPartsPrefabArr[(int)charaType], parent.transform);
        newPart.transform.localPosition = Vector3.zero;
        parent.ChgHeadBody(newPart, _charaType);

        return newPart;
    }

    /// <summary>
    /// 左腕のパーツを新しく付ける
    /// </summary>
    /// <param name="parent">パーツを付け替える親元</param>
    /// <param name="charaType">付ける左腕パーツの種類 (省略可能)</param>
    /// <returns>生成したパーツ</returns>
    public GameObject MakeNewLeftArm(CharaDetail parent, Chara_Type? charaType = null)
    {
        Chara_Type _charaType = charaType ?? (Chara_Type)Random.Range(0, partsTypeLen);
        GameObject newPart = Instantiate(leftArmPartsPrefabArr[(int)charaType], parent.transform);
        newPart.transform.localPosition = Vector3.zero;
        parent.ChgLeftArm(newPart, _charaType);

        return newPart;
    }

    /// <summary>
    /// 右腕のパーツを新しく付ける
    /// </summary>
    /// <param name="parent">パーツを付け替える親元</param>
    /// <param name="charaType">付ける右腕パーツの種類 (省略可能)</param>
    /// <returns>生成したパーツ</returns>
    public GameObject MakeNewRightArm(CharaDetail parent, Chara_Type? charaType = null)
    {
        Chara_Type _charaType = charaType ?? (Chara_Type)Random.Range(0, partsTypeLen);
        GameObject newPart = Instantiate(rightArmPartsPrefabArr[(int)charaType], parent.transform);
        newPart.transform.localPosition = Vector3.zero;
        parent.ChgRightArm(newPart, _charaType);

        return newPart;
    }

    /// <summary>
    /// 左足のパーツを新しく付ける
    /// </summary>
    /// <param name="parent">パーツを付け替える親元</param>
    /// <param name="charaType">付ける左足パーツの種類 (省略可能)</param>
    /// <returns>生成したパーツ</returns>
    public GameObject MakeNewLeftLeg(CharaDetail parent, Chara_Type? charaType = null)
    {
        Chara_Type _charaType = charaType ?? (Chara_Type)Random.Range(0, partsTypeLen);
        GameObject newPart = Instantiate(leftLegPartsPrefabArr[(int)charaType], parent.transform);
        newPart.transform.localPosition = Vector3.zero;
        parent.ChgLeftLeg(newPart, _charaType);

        return newPart;
    }

    /// <summary>
    /// 右腕のパーツを新しく付ける
    /// </summary>
    /// <param name="parent">パーツを付け替える親元</param>
    /// <param name="charaType">付ける右腕パーツの種類 (省略可能)</param>
    /// <returns>生成したパーツ</returns>
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

        if (result == false) Debug.LogError("全パーツが均一の数セットされていません。");
        return result;
    }
}
