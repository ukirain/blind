using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tittle_button_script : MonoBehaviour
{
    public GameObject button_start;
    public GameObject titles;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...    
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == button_start)
                {
                    titles.SetActive(true);
                }
            }
        }
    }
}
