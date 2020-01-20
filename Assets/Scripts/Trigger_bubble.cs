using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trigger_bubble : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bubble;
    public string text = "hello madafucka";
    public AudioSource audio;
    private void OnAudioFilterRead(float[] data, int channels)
    {

    }
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        audio.Play();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other==GameObject.Find("Player").GetComponent<Collider>())
        {
            bubble.GetComponentInChildren<SpriteRenderer>().enabled = true;
            bubble.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == GameObject.Find("Player").GetComponent<Collider>())
        {
            bubble.GetComponentInChildren<SpriteRenderer>().enabled = false;
            bubble.GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
