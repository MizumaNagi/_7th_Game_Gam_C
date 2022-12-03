using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : SingletonMonoBehaviour<Score>
{
    public List<float> scores = new List<float>();

    [SerializeField]
    private Text judgeText;

    public void Judge()
    {
        float allScore = 0;
        foreach(float f in scores)
        {
            allScore += f;
        }

        allScore = (allScore / scores.Count) * 100;

        judgeText.text = allScore.ToString() + "%çáív!";
    }


}
