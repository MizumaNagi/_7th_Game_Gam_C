using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����̃p�[�c�ӏ�, �p�[�c��ނ̕ϐ������N���X
/// �e�p�[�c�ɕt���Ă���
/// </summary>
public class PartDetail : MonoBehaviour
{
    [SerializeField] private Chara_Type charaIndex;
    [SerializeField] private Part_Type partIndex;

    public Chara_Type CharaIndex => charaIndex;
    public Part_Type PartIndex => partIndex;
}
