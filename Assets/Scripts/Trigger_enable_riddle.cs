using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_enable_riddle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] riddle_answer = { };
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        for(int i = 0; i < riddle_answer.Length; i++)
        {
            riddle_answer[i].SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
