using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
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

    //つかまえたパーツ
    public GameObject attachObject;

    //キャッシュ用
    private Transform selfTransform;
    private WaitForSeconds wfs = new WaitForSeconds(0.02f);
    private WaitForSeconds wfs2 = new WaitForSeconds(0.25f);


    //デバッグ用選択済みボディ座標（メインシステム２で指定）
    private Vector3 selectedBody = new Vector3(0, 0, 0);


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

    IEnumerator ddd()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            ArmToTarget(new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)));
        }
    }


    /// <summary>
    /// 引数で指定されたパーツの場所にロボットアームをもっていき、その後編集するボディまで持っていく
    /// </summary>
    /// <param name="vec">パーツの位置</param>
    public void ArmToTarget(Vector3 partsPos)
    {
        if(canMove)
        {
            canMove = false;
            StartCoroutine(Movement(partsPos));

        }
    }

    /// <summary>
    /// アームの挙動
    /// </summary>
    /// <param name="partsPos"></param>
    /// <returns></returns>
    IEnumerator Movement(Vector3 partsPos)
    {
        selfTransform.rotation = Quaternion.identity;

        //パーツまで
        while (selfTransform.position != partsPos)
        {

            selfTransform.position = Vector3.MoveTowards(selfTransform.position, partsPos, speed);
            var direction = Quaternion.LookRotation(originPos - partsPos ,Vector3.up);
            selfTransform.rotation = Quaternion.Lerp(selfTransform.rotation, direction, speed);

            yield return wfs;

        }

        arrivePatrs = true;
        animator.SetTrigger("GrapTrigger");
        yield return wfs2;


        //選択された体まで
        while (selfTransform.position != selectedBody)
        {

            selfTransform.position = Vector3.MoveTowards(selfTransform.position, selectedBody, speed);

            if(attachObject != null)
            {
                attachObject.transform.position = Vector3.MoveTowards(selfTransform.position, selectedBody, speed);
            }

            var direction = Quaternion.LookRotation(partsPos - selectedBody, Vector3.up);
            selfTransform.rotation = Quaternion.Lerp(selfTransform.rotation, direction, speed);
            yield return wfs;
        }

        yield return wfs2;
        animator.SetTrigger("GrapTrigger");
        yield return wfs2;

        if(attachObject != null)
        {
            Destroy(attachObject);
        }


        //パーツまで戻る
        while (selfTransform.position != partsPos)
        {

            selfTransform.position = Vector3.MoveTowards(selfTransform.position, partsPos, speed);
            var direction = Quaternion.LookRotation(partsPos - selfTransform.position, Vector3.up);
            selfTransform.rotation = Quaternion.Lerp(selfTransform.rotation, direction, speed);

            yield return wfs;
        }

        arrivePatrs = false;

        //初期地点まで戻る
        while (selfTransform.position != originPos)
        {

            selfTransform.position = Vector3.MoveTowards(selfTransform.position, originPos, speed);
            var direction = Quaternion.LookRotation(originPos - partsPos, Vector3.up);
            selfTransform.rotation = Quaternion.Lerp(selfTransform.rotation, direction, speed);

            yield return wfs;
        }

        selfTransform.position =  originPos;
        selfTransform.rotation = originRot;
        canMove = true;

    }

    //private void ArmLineAdjust()
    //{
    //    line.SetPosition(0, originLinePos[0]);

    //    if(arrivePatrs)
    //    {
    //        //ポイントについたら
    //        line.SetPosition(1, originLinePos[1]);
    //    }

    //    line.SetPosition(2, originLinePos[2]);

    //}

}
