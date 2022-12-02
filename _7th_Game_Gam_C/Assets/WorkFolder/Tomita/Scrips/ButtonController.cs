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
        
        // num = 0 ~ 9
        // num�Ԗڂ̍��r�p�[�c�����
        if(num>=0&&num<=9)
        {
            GameObject parent = new GameObject();
            f.MakeNewLeftArm(parent.GetComponent<CharaDetail>(), (Chara_Type)num);
        }
        if (num >= 10 && num <= 19)
        {
            GameObject parent = new GameObject();
            f.MakeNewRightArm(parent.GetComponent<CharaDetail>(), (Chara_Type)num-10);
        }
        if (num >= 20 && num <= 29)
        {
            GameObject parent = new GameObject();
            f.MakeNewLeftLeg(parent.GetComponent<CharaDetail>(), (Chara_Type)num-20);
        }
        if (num >= 30 && num <= 39)
        {
            GameObject parent = new GameObject();
            f.MakeNewRightLeg(parent.GetComponent<CharaDetail>(), (Chara_Type)num-30);
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