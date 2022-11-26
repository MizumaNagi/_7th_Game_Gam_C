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

    //�L���b�V���p
    private Transform selfTransform;
    private WaitForSeconds wfs = new WaitForSeconds(0.02f);
    private WaitForSeconds wfs2 = new WaitForSeconds(0.25f);

    [SerializeField, Header("�f�o�b�O�p�p�[�c�I�u�W�F�N�g")]
    private GameObject obj;


    private void Start()
    {
        selfTransform = gameObject.transform;
        originPos = selfTransform.position;
        originRot = selfTransform.rotation;

        for (int i = 0; i < line.positionCount; i++)
        {
            originLinePos.Add(line.GetPosition(i));
        }

        //StartCoroutine(ddd());
    }

    /// <summary>
    /// �f�o�b�O�p
    /// </summary>
    /// <returns></returns>
    IEnumerator ddd()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            ArmToTarget(obj,new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)));
        }
    }

    /// <summary>
    /// �����Ŏw�肳�ꂽ�p�[�c�I�u�W�F�N�g�̏ꏊ�Ƀ��{�b�g�A�[���������Ă����A���̌�ҏW����{�f�B�܂Ŏ����Ă����֐�
    /// </summary>
    /// <param name="partsObj">�I�������p�[�c�I�u�W�F�N�g</param>
    /// <param name="selectedBodyPos">�I�����ꂽ�̂̈ʒu</param>
    public void ArmToTarget(GameObject partsObj,Vector3 selectedBodyPos)
    {
        if(canMove)
        {
            canMove = false;
            StartCoroutine(Movement(partsObj, selectedBodyPos));

        }
    }

    /// <summary>
    /// �A�[���̋���
    /// </summary>
    /// <param name="partsObj">�I�������p�[�c�I�u�W�F�N�g</param>
    /// <param name="selectedBodyPos">�I�����ꂽ�̂̈ʒu</param>
    /// <returns></returns>
    IEnumerator Movement(GameObject partsObj ,Vector3 selectedBodyPos)
    {
        selfTransform.rotation = Quaternion.identity;

        //�p�[�c�܂�
        while (selfTransform.position != partsObj.transform.position)
        {

            selfTransform.position = Vector3.MoveTowards(selfTransform.position, partsObj.transform.position, speed);
            var direction = Quaternion.LookRotation(originPos - partsObj.transform.position, Vector3.up);
            selfTransform.rotation = Quaternion.Lerp(selfTransform.rotation, direction, 0.1f);

            yield return wfs;

        }

        arrivePatrs = true;
        animator.SetTrigger("GrapTrigger");
        yield return wfs2;


        //�I�����ꂽ�̂܂�
        while (selfTransform.position != selectedBodyPos)
        {

            selfTransform.position = Vector3.MoveTowards(selfTransform.position, selectedBodyPos, speed);

            if(partsObj != null)
            {
                partsObj.transform.position = Vector3.MoveTowards(selfTransform.position, selectedBodyPos, speed);
            }

            var direction = Quaternion.LookRotation(partsObj.transform.position - selectedBodyPos, Vector3.up);
            selfTransform.rotation = Quaternion.Lerp(selfTransform.rotation, direction, 0.1f);
            yield return wfs;
        }

        yield return wfs2;
        animator.SetTrigger("GrapTrigger");
        yield return wfs2;

        //�p�[�c�܂Ŗ߂�
        while (selfTransform.position != partsObj.transform.position)
        {

            selfTransform.position = Vector3.MoveTowards(selfTransform.position, partsObj.transform.position, speed);
            var direction = Quaternion.LookRotation(partsObj.transform.position - selfTransform.position, Vector3.up);
            selfTransform.rotation = Quaternion.Lerp(selfTransform.rotation, direction, 0.1f);

            yield return wfs;
        }

        arrivePatrs = false;

        //�����n�_�܂Ŗ߂�
        while (selfTransform.position != originPos)
        {

            selfTransform.position = Vector3.MoveTowards(selfTransform.position, originPos, speed);
            var direction = Quaternion.LookRotation(originPos - partsObj.transform.position, Vector3.up);
            selfTransform.rotation = Quaternion.Lerp(selfTransform.rotation, direction, 0.1f);

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
