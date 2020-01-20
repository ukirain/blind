using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    public string NextLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GameObject.Find("Player"))
         SceneManager.LoadScene(NextLevel, LoadSceneMode.Single);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
