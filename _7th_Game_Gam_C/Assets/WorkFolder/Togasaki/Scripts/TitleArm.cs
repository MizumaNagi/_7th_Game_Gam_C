using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleArm : MonoBehaviour
{
    [SerializeField, Header("アームのスピード")]
    private float speed = 1;

    [SerializeField, Header("ラインレンダラー")]
    private LineRenderer line;

    [SerializeField, Header("animator")]
    private Animator animator;

    //初期地点
    private Vector3 originPos;
    private Quaternion originRot;

    private List<Vector3> originLinePos = new List<Vector3>();

    //動けるかどうか
    private bool canMove = true;

    //中間地点用bool
    private bool arrivePatrs = false;

    //キャッシュ用
    private Transform selfTransform;
    private WaitForSeconds wfs = new WaitForSeconds(0.02f);
    private WaitForSeconds wfs2 = new WaitForSeconds(0.25f);

    [SerializeField, Header("デバッグ用パーツオブジェクト")]
    private GameObject obj;

    [SerializeField, Header("デバッグ用ボディオブジェクト")]
    private GameObject bObj;


    private void Start()
    {
        selfTransform = gameObject.transform;
        originPos = selfTransform.position;
        originRot = selfTransform.rotation;

        for (int i = 0; i < line.positionCount; i++)
        {
            originLinePos.Add(line.GetPosition(i));
        }

        StartCoroutine(ddd());

    }

    /// <summary>
    /// デバッグ用
    /// </summary>
    /// <returns></returns>
    IEnumerator ddd()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.0f, 3.0f));
            ArmToTarget(new Vector3(Random.Range(0.0f,3.0f), 0, Random.Range(0.0f, 3.0f)), new Vector3(0, 1, 0));
        }
    }

    /// <summary>
    /// 引数で指定されたパーツオブジェクトの場所にロボットアームをもっていき、その後編集するボディまで持っていく関数
    /// </summary>
    /// <param name="partsObj">選択したパーツオブジェクト</param>
    /// <param name="selectedBodyPos">選択された体の位置</param>
    public void ArmToTarget(Vector3 partsObj, Vector3 selectedBody)
    {
        if (canMove)
        {
            canMove = false;
            StartCoroutine(Movement(partsObj, selectedBody));

        }
    }

    /// <summary>
    /// アームの挙動
    /// </summary>
    /// <param name="partsObj">選択したパーツオブジェクト</param>
    /// <param name="selectedBodyPos">選択された体の位置</param>
    /// <returns></returns>
    IEnumerator Movement(Vector3 partsObj, Vector3 selectedBody)
    {
        selfTransform.rotation = Quaternion.identity;

        //パーツまで
        while (selfTransform.position != partsObj)
        {

            selfTransform.position = Vector3.MoveTowards(selfTransform.position, partsObj, speed);
            var direction = Quaternion.LookRotation(originPos - partsObj, Vector3.up);
            selfTransform.rotation = Quaternion.Lerp(selfTransform.rotation, direction, 0.1f);

            yield return wfs;

        }

        arrivePatrs = true;
        animator.SetTrigger("GrapTrigger");
        yield return wfs2;


        //選択された体まで
        while (selfTransform.position != selectedBody)
        {
            selfTransform.position = Vector3.MoveTowards(selfTransform.position, selectedBody, speed);

            if (partsObj != null)
            {
                partsObj = Vector3.MoveTowards(selfTransform.position, selectedBody, speed);
            }

            var direction = Quaternion.LookRotation(partsObj - selectedBody, Vector3.up);
            selfTransform.rotation = Quaternion.Lerp(selfTransform.rotation, direction, 0.1f);
            yield return wfs;
        }

        yield return wfs2;
        animator.SetTrigger("GrapTrigger");
        partsObj = selectedBody;
        yield return wfs2;

        //パーツまで戻る
        while (selfTransform.position != partsObj)
        {

            selfTransform.position = Vector3.MoveTowards(selfTransform.position, partsObj, speed);
            var direction = Quaternion.LookRotation(partsObj - selfTransform.position, Vector3.up);
            selfTransform.rotation = Quaternion.Lerp(selfTransform.rotation, direction, 0.1f);

            yield return wfs;
        }

        arrivePatrs = false;

        //初期地点まで戻る
        while (selfTransform.position != originPos)
        {

            selfTransform.position = Vector3.MoveTowards(selfTransform.position, originPos, speed);
            var direction = Quaternion.LookRotation(originPos - partsObj, Vector3.up);
            selfTransform.rotation = Quaternion.Lerp(selfTransform.rotation, direction, 0.1f);

            yield return wfs;
        }

        selfTransform.position = originPos;
        selfTransform.rotation = originRot;
        canMove = true;


    }
}
