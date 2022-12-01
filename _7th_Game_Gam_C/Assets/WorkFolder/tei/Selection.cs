using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    //�I�u�W�F�N�g�i�[�p
    public GameObject ClickedGameObject;
    // Update is called once per frame
    void Update()
    {//�I������
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
