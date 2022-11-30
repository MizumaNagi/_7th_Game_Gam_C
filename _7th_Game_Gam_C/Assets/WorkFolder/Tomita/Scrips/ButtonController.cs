using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private Transform pos;
    public GameObject GameObject;
    public Button button;

    public GameObject[] patuobjs;

    private TestCharaFactory f;
    
    public void Onclick(int num)
    {
        int a = 39;
        // num = 0 ~ 9
        // num番目の左腕パーツを作る
        if(a>=0&&a<=9)
        {
            GameObject parent = new GameObject();
            f.MakeNewLeftArm(parent.GetComponent<CharaDetail>(), (Chara_Type)num);
        }
        if (a >= 10 && a <= 19)
        {
            GameObject parent = new GameObject();
            f.MakeNewRightArm(parent.GetComponent<CharaDetail>(), (Chara_Type)num);
        }
        if (a >= 20 && a <= 29)
        {
            GameObject parent = new GameObject();
            f.MakeNewLeftLeg(parent.GetComponent<CharaDetail>(), (Chara_Type)num);
        }
        if (a >= 30 && a <= 39)
        {
            GameObject parent = new GameObject();
            f.MakeNewRightLeg(parent.GetComponent<CharaDetail>(), (Chara_Type)num);
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