using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_2 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public void TimeCount(int id)
    {
        //IDを受け取りフォルダから対応のオブジェクト生成
        GameObject Bod = (GameObject)Resources.Load("id");
        Instantiate(Bod, new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);//生成場所


        //生成した体の移動
        Body_move.instance.Body_Move();
    }
}

//注文したものを流す
//IDに対応した物を動かす
//位置調整
