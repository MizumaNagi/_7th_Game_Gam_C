using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeText : MonoBehaviour
{
    public float lifeTime = 3.0f;
    private bool deathFlag = false;
    private WaitForSeconds lifeTimeWait = new WaitForSeconds(0.1f);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(lifeTimeCul());

    }

    private IEnumerator lifeTimeCul()
    {
        while (true)
        {
            lifeTime -= 0.1f;



            if (lifeTime < 0)
            {
                deathFlag = true;
                break;
            }
            yield return lifeTimeWait;
        }
    }

}
