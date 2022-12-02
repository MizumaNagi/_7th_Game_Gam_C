using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : SingletonMonoBehaviour<Selection>
{
    //�I�u�W�F�N�g�i�[�p
    public GameObject ClickedGameObject;
    // Update is called once per frame
    void Update()
    {//�I������
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
