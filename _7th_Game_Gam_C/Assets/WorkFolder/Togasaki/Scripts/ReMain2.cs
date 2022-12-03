using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReMain2 : SingletonMonoBehaviour<ReMain2>
{
    [SerializeField]
    private GameObject initObj;

    public bool canLoop = true;
    private WaitForSeconds spawnWaitTime = new WaitForSeconds(12.1f);


    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    public void Spawn()
    {
        Instantiate(initObj,Positions.Instance.leftPartsPos.position, Quaternion.identity);
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
