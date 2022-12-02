using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : SingletonMonoBehaviour<Selection>
{
    //オブジェクト格納用
    public GameObject ClickedGameObject;
    // Update is called once per frame
    void Update()
    {//選択する
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.GetComponent<CharaDetail>() != null)
                {
                    ClickedGameObject = hit.collider.gameObject;
                }
            }

            //Debug.Log(ClickedGameObject);

        }
    }
}
