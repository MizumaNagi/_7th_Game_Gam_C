using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{    

    public void Onclick(int num)
    {
        
        // num = 0 ~ 9
        // num番目の左腕パーツを作る
        if(num>=0&&num<=9)
        {
            if(Selection.Instance.ClickedGameObject == null)
            {
                Debug.Log("EEE");
            }
            GameObject ob = TestCharaFactory.Instance.MakeNewLeftArm(Selection.Instance.ClickedGameObject.GetComponent<CharaDetail>(), (Chara_Type)num);
            ob.gameObject.transform.position = Positions.Instance.leftPartsPos.position;

            ArmMovement.Instance.ArmToTarget(ob, Selection.Instance.ClickedGameObject);
        }
        if (num >= 10 && num <= 19)
        {
            GameObject ob = TestCharaFactory.Instance.MakeNewRightArm(Selection.Instance.ClickedGameObject.GetComponent<CharaDetail>(), (Chara_Type)num-10);

            ob.gameObject.transform.position = Positions.Instance.rightPartsPos.position;

            ArmMovement.Instance.ArmToTarget(ob, Selection.Instance.ClickedGameObject);
        }
        if (num >= 20 && num <= 29)
        {
            GameObject ob = TestCharaFactory.Instance.MakeNewLeftLeg(Selection.Instance.ClickedGameObject.GetComponent<CharaDetail>(), (Chara_Type)num-20);

            ob.gameObject.transform.position = Positions.Instance.leftPartsPos.position;

            ArmMovement.Instance.ArmToTarget(ob, Selection.Instance.ClickedGameObject);
        }
        if (num >= 30 && num <= 39)
        {
            GameObject ob = TestCharaFactory.Instance.MakeNewRightLeg(Selection.Instance.ClickedGameObject.GetComponent<CharaDetail>(), (Chara_Type)num-30);

            ob.gameObject.transform.position = Positions.Instance.rightPartsPos.position;

            ArmMovement.Instance.ArmToTarget(ob, Selection.Instance.ClickedGameObject);
        }
    }
        // num = 10 ~ 19
        // num - 10番目の右腕パーツを作る
        

        // X < Y: XよりYの方が大きい (XはY未満)
        // X > Y: XよりYの方が大きい (Xはより大きい)
        // X <= Y: XはY以下
        // X >= Y: XはY以上
        // X == Y: 等しい
        // X != Y: 等しくない
        
        //↓は仮オブジェクト
        
}