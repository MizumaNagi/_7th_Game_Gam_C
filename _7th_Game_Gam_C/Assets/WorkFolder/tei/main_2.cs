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
        //ID���󂯎��t�H���_����Ή��̃I�u�W�F�N�g����
        GameObject Bod = (GameObject)Resources.Load("id");
        Instantiate(Bod, new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);//�����ꏊ


        //���������̂̈ړ�
        Body_move.instance.Body_Move();
    }
}

//�����������̂𗬂�
//ID�ɑΉ��������𓮂���
//�ʒu����
