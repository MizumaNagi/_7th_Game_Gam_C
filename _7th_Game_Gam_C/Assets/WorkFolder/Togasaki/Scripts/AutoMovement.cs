using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoMovement : MonoBehaviour
{
    private WaitForSeconds waitTime = new WaitForSeconds(0.02f);
    private WaitForSeconds lifeTimeWait = new WaitForSeconds(0.1f);
    [SerializeField]
    private Text textRef;
    private bool deathFlag = false;
    public float lifeTime = 3.0f;

    private void Start()
    {

        Selection.Instance.ClickedGameObject = gameObject;

        StartCoroutine(lifeTimeCul());
        StartCoroutine(Movement());
    }

    private IEnumerator lifeTimeCul()
    {
        while (true)
        {
            lifeTime -= 0.1f;
            lifeTime *= 100;
            lifeTime = Mathf.Floor(lifeTime) / 100;

            textRef.text = lifeTime.ToString();

            if(lifeTime < 0)
            {
                if (!UIManager.Instance.gameEnd)
                {
                    Score.Instance.scores.Add(CharaJudge.Instance.GetCharactersMatchRate(ReMain2.Instance.subjectObj.GetComponent<CharaDetail>(), Selection.Instance.ClickedGameObject.GetComponent<CharaDetail>()));
                }

                textRef.text = "";
                deathFlag = true;
                break;
            }
            yield return lifeTimeWait;
        }
    }


    private IEnumerator Movement()
    {
        bool one = true;
        while(true)
        {
            if(!deathFlag)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(0, 0, 0), 0.25f);

                if(gameObject.transform.position != new Vector3(0,0,0))
                {
                    ArmMovement.Instance.canMove = false;

                }
                else if(one)
                {
                    ArmMovement.Instance.canMove = true;
                    one = false;
                }

            }
            else
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Positions.Instance.rightPartsPos.position, 0.5f);
                
                //èIÇÌÇËÇ…
                if(gameObject.transform.position == Positions.Instance.rightPartsPos.position)
                {
                    Destroy(gameObject);
                }
            }

            yield return waitTime;
        }
    }

}
