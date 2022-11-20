using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    [SerializeField, Header("�A�[���̃X�s�[�h")]
    private float speed = 1;

    [SerializeField, Header("���C�������_���[")]
    private LineRenderer line;

    [SerializeField, Header("animator")]
    private Animator animator;

    //�����n�_
    private Vector3 originPos;
    private Quaternion originRot;

    private List<Vector3> originLinePos = new List<Vector3>();

    //�����邩�ǂ���
    private bool canMove = true;

    //���Ԓn�_�pbool
    private bool arrivePatrs = false;

    //���܂����p�[�c
    public GameObject attachObject;

    //�L���b�V���p
    private Transform selfTransform;
    private WaitForSeconds wfs = new WaitForSeconds(0.02f);
    private WaitForSeconds wfs2 = new WaitForSeconds(0.25f);


    //�f�o�b�O�p�I���ς݃{�f�B���W�i���C���V�X�e���Q�Ŏw��j
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
    /// �����Ŏw�肳�ꂽ�p�[�c�̏ꏊ�Ƀ��{�b�g�A�[���������Ă����A���̌�ҏW����{�f�B�܂Ŏ����Ă���
    /// </summary>
    /// <param name="vec">�p�[�c�̈ʒu</param>
    public void ArmToTarget(Vector3 partsPos)
    {
        if(canMove)
        {
            canMove = false;
            StartCoroutine(Movement(partsPos));

        }
    }

    /// <summary>
    /// �A�[���̋���
    /// </summary>
    /// <param name="partsPos"></param>
    /// <returns></returns>
    IEnumerator Movement(Vector3 partsPos)
    {
        selfTransform.rotation = Quaternion.identity;

        //�p�[�c�܂�
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


        //�I�����ꂽ�̂܂�
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


        //�p�[�c�܂Ŗ߂�
        while (selfTransform.position != partsPos)
        {

            selfTransform.position = Vector3.MoveTowards(selfTransform.position, partsPos, speed);
            var direction = Quaternion.LookRotation(partsPos - selfTransform.position, Vector3.up);
            selfTransform.rotation = Quaternion.Lerp(selfTransform.rotation, direction, speed);

            yield return wfs;
        }

        arrivePatrs = false;

        //�����n�_�܂Ŗ߂�
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
    //        //�|�C���g�ɂ�����
    //        line.SetPosition(1, originLinePos[1]);
    //    }

    //    line.SetPosition(2, originLinePos[2]);

    //}

}
