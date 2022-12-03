using UnityEngine;

public class CharaJudge : SingletonMonoBehaviour<CharaJudge>
{
    /// <summary>
    /// 2キャラクターの全パーツの合致率を返す
    /// </summary>
    /// <param name="chara1"></param>
    /// <param name="chara2"></param>
    /// <returns>合致率 (0f <= x <= 1f)</returns>
    public float GetCharactersMatchRate(CharaDetail chara1, CharaDetail chara2)
    {
        Chara_Type[] chara1PartType = chara1.GetAllPartType();
        Chara_Type[] chara2PartType = chara2.GetAllPartType();

        int matchParts = 0;
        for(int i = 0; i < 5; i++)
        {
            if (chara1PartType[i] == chara2PartType[i]) matchParts++;
        }

        if (matchParts == 0) return 0f;
        else return matchParts / 5f;
    }
}
