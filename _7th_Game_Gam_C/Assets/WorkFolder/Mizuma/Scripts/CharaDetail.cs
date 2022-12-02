using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 身体5箇所に付いているパーツの情報を持つ
/// パーツの更新も行う
/// </summary>
public class CharaDetail : MonoBehaviour
{
    private GameObject headBody;
    private GameObject leftArm;
    private GameObject rightArm;
    private GameObject leftLeg;
    private GameObject rightLeg;

    private Chara_Type headBodyType;
    private Chara_Type leftArmType;
    private Chara_Type rightArmType;
    private Chara_Type leftLegType;
    private Chara_Type rightLegType;

    public void ChgHeadBody(GameObject newHeadBody, Chara_Type charaType)
    {
        if (headBody != null) Destroy(headBody);
        headBody = newHeadBody;
        headBodyType = charaType;
    }

    public void ChgLeftArm(GameObject newLeftArm, Chara_Type charaType)
    {
        if (leftArm != null) Destroy(leftArm);
        leftArm = newLeftArm;
        leftArmType = charaType;
    }

    public void ChgRightArm(GameObject newRightArm, Chara_Type charaType)
    {
        if (rightArm != null) Destroy(rightArm);
        rightArm = newRightArm;
        rightArmType = charaType;
    }

    public void ChgLeftLeg(GameObject newLeftLeg, Chara_Type charaType)
    {
        if (leftLeg != null) Destroy(leftLeg);
        leftLeg = newLeftLeg;
        leftLegType = charaType;
    }

    public void ChgRightLeg(GameObject newRightLeg, Chara_Type charaType)
    {
        if (rightLeg != null) Destroy(rightLeg);
        rightLeg = newRightLeg;
        rightLegType = charaType;
    }

    public Chara_Type[] GetAllPartType()
    {
        Chara_Type[] result = new Chara_Type[5];
        result[0] = headBodyType;
        result[1] = leftArmType;
        result[2] = rightArmType;
        result[3] = leftLegType;
        result[4] = rightLegType;

        return result;
    }
}
