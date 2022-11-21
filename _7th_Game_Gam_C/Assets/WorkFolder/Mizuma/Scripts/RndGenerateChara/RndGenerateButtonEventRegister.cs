using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Scene"RndGenerate"内の各Buttonにキャラクター生成, 更新イベントを登録させる
/// </summary>
public class RndGenerateButtonEventRegister : MonoBehaviour
{
    [SerializeField] private Transform headBodyButtonGroup;
    [SerializeField] private Transform leftArmButtonGroup;
    [SerializeField] private Transform rightArmButtonGroup;
    [SerializeField] private Transform leftLegButtonGroup;
    [SerializeField] private Transform rightLegButtonGroup;
    [SerializeField] private Button randomButton;
    [SerializeField] private Toggle alignToggle;

    [SerializeField] private TestCharaFactory charaFactory;

    private GameObject makeChara;
    private CharaDetail makeCharaDetail;
    private Button[] headBodyButtons;
    private Button[] leftArmButtons;
    private Button[] rightArmButtons;
    private Button[] leftLegButtons;
    private Button[] rightLegButtons;

    private void Start()
    {
        makeChara = charaFactory.RandomGenerateChatacter(false);
        makeCharaDetail = makeChara.GetComponent<CharaDetail>();

        headBodyButtons = headBodyButtonGroup.GetComponentsInChildren<Button>();
        leftArmButtons = leftArmButtonGroup.GetComponentsInChildren<Button>();
        rightArmButtons = rightArmButtonGroup.GetComponentsInChildren<Button>();
        leftLegButtons = leftLegButtonGroup.GetComponentsInChildren<Button>();
        rightLegButtons = rightLegButtonGroup.GetComponentsInChildren<Button>();

        for(int i = 0; i < leftArmButtons.Length; i++)
        {
            int tmp = i;
            headBodyButtons[i].onClick.AddListener(() => charaFactory.MakeNewHeadBody(makeCharaDetail, (Chara_Type)tmp));
            leftArmButtons[i].onClick.AddListener(() => charaFactory.MakeNewLeftArm(makeCharaDetail, (Chara_Type)tmp));
            rightArmButtons[i].onClick.AddListener(() => charaFactory.MakeNewRightArm(makeCharaDetail, (Chara_Type)tmp));
            leftLegButtons[i].onClick.AddListener(() => charaFactory.MakeNewLeftLeg(makeCharaDetail, (Chara_Type)tmp));
            rightLegButtons[i].onClick.AddListener(() => charaFactory.MakeNewRightLeg(makeCharaDetail, (Chara_Type)tmp));
        }
        randomButton.onClick.AddListener(() =>
        {
            if (makeChara != null) Destroy(makeChara);
            makeChara = charaFactory.RandomGenerateChatacter(alignToggle.isOn);
            makeCharaDetail = makeChara.GetComponent<CharaDetail>();
        });
    }
}
