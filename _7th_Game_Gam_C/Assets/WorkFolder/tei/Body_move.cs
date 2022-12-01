using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_move : MonoBehaviour
{
    public static Body_move instance;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        gameObject.SetActive(true);
    }
    public void Body_Move()
    {
        transform.position += new Vector3(0, 0, 1) * Time.deltaTime;
    }
}
