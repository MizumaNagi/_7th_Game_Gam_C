using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReMain2 : SingletonMonoBehaviour<ReMain2>
{
    [SerializeField]
    private GameObject initObj;

    public bool canLoop = true;
    private WaitForSeconds spawnWaitTime = new WaitForSeconds(12.5f);

    public GameObject subjectObj;

    [SerializeField]
    private Transform oitokuPos;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    public void Spawn()
    {
        Instantiate(initObj,Positions.Instance.leftPartsPos.position, Quaternion.identity);
        if(subjectObj != null)
        {
            Destroy(subjectObj);
        }
        subjectObj = TestCharaFactory.Instance.RandomGenerateChatacter(false);
        subjectObj.transform.position = oitokuPos.position;
    }

    private IEnumerator SpawnLoop()
    {
        while(canLoop)
        {
            Spawn();

            yield return spawnWaitTime;
        }
    }


}
