using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    public GameObject ClickedGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {//‘I‘ð
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
