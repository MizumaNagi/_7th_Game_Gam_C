using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    //オブジェクト格納用
    public GameObject ClickedGameObject;
    // Update is called once per frame
    void Update()
    {//選択する
        if (Input.GetMouseButtonDown(0))
        {
            ClickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                ClickedGameObject = hit.collider.gameObject;
            }

            Debug.Log(ClickedGameObject);

        }
    }
}
