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
        // num�Ԗڂ̍��r�p�[�c�����
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
        // num - 10�Ԗڂ̉E�r�p�[�c�����
        

        // X < Y: X���Y�̕����傫�� (X��Y����)
        // X > Y: X���Y�̕����傫�� (X�͂��傫��)
        // X <= Y: X��Y�ȉ�
        // X >= Y: X��Y�ȏ�
        // X == Y: ������
        // X != Y: �������Ȃ�
        
        //���͉��I�u�W�F�N�g
        
}