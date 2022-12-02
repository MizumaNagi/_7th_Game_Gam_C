using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("���̃p�[�c������Ă���܂ł̎���")]
    [SerializeField]
    float NextCount;

    [Header("��������(��)")]
    [SerializeField]
    float Minute;

    [Header("��������(�b)")]
    [SerializeField]
    float Second;

    [Header("�^�C�}�[")]
    [SerializeField]
    Text Timer;

    [Header("�p�[�c")]
    [SerializeField]
    GameObject[] Body, Arm_R, Arm_L, Leg_R, Leg_L;

    private float M_Time, S_Time, OldSecond;

    void Start()
    {
        //�^�C�}�[��������
        M_Time = Minute;
        S_Time = Second;
        OldSecond = 0;

        Create();
    }


    private void FixedUpdate()
    {
        Count();
    }

    //�^�C�}�[
    void Count()
    {
        //�J�E���g�_�E��
        Second -= Time.deltaTime;
        if (Second <= 0f)
        {
            Minute--;
            Second = 60 - Second;
        }

        //�^�C�}�[���X�V
        Timer.text = Minute.ToString("00") + ":" + ((int)Second).ToString("00");
    }

    //��������
    void Create()
    {
        //�p�[�c�𒊑I
        for (int x = 0; x < 5; x++)
        {
            int Parts_No, Parts_ID;

            switch (x)
            {
                case 1:
                    Parts_No = Body.Length;
                    Parts_ID = Random.Range(0, Parts_No);
                    //Instantiate(Body[Parts_ID]);//���̃^�C�~���O�Ő����B���C���V�X�e����ID�𑗂�B
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
