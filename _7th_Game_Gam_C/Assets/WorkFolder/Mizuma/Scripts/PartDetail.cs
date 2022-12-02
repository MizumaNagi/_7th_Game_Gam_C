using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自分のパーツ箇所, パーツ種類の変数を持つクラス
/// 各パーツに付いている
/// </summary>
public class PartDetail : MonoBehaviour
{
    [SerializeField] private Chara_Type charaIndex;
    [SerializeField] private Part_Type partIndex;

    public Chara_Type CharaIndex => charaIndex;
    public Part_Type PartIndex => partIndex;
}
