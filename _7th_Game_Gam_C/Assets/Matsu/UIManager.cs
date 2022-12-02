using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("次のパーツが流れてくるまでの時間")]
    [SerializeField]
    float NextCount;

    [Header("制限時間(分)")]
    [SerializeField]
    float Minute;

    [Header("制限時間(秒)")]
    [SerializeField]
    float Second;

    [Header("タイマー")]
    [SerializeField]
    Text Timer;

    [Header("パーツ")]
    [SerializeField]
    GameObject[] Body, Arm_R, Arm_L, Leg_R, Leg_L;

    private float M_Time, S_Time, OldSecond;

    void Start()
    {
        //タイマーを初期化
        M_Time = Minute;
        S_Time = Second;
        OldSecond = 0;

        Create();
    }


    private void FixedUpdate()
    {
        Count();
    }

    //タイマー
    void Count()
    {
        //カウントダウン
        Second -= Time.deltaTime;
        if (Second <= 0f)
        {
            Minute--;
            Second = 60 - Second;
        }

        //タイマーを更新
        Timer.text = Minute.ToString("00") + ":" + ((int)Second).ToString("00");
    }

    //注文生成
    void Create()
    {
        //パーツを抽選
        for (int x = 0; x < 5; x++)
        {
            int Parts_No, Parts_ID;

            switch (x)
            {
                case 1:
                    Parts_No = Body.Length;
                    Parts_ID = Random.Range(0, Parts_No);
                    //Instantiate(Body[Parts_ID]);//このタイミングで生成。メインシステムにIDを送る。
                    break;

                case 2:
                    Parts_No = Arm_R.Length;
                    Parts_ID = Random.Range(0, Parts_No);
                    break;

                case 3:
                    Parts_No = Arm_L.Length;
                    Parts_ID = Random.Range(0, Parts_No);
                    break;

                case 4:
                    Parts_No = Leg_R.Length;
                    Parts_ID = Random.Range(0, Parts_No);
                    break;

                case 5:
                    Parts_No = Leg_L.Length;
                    Parts_ID = Random.Range(0, Parts_No);
                    break;
            }
        }
    }
}
