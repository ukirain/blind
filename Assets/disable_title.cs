using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disable_title : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tittle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && tittle.activeSelf == true)
        {
            tittle.SetActive(false);
        }
    }
}
