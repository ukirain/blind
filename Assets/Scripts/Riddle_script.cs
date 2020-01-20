using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using Quests;
using UnityEngine.SceneManagement;

public class Riddle_script : MonoBehaviour
{
    private QuestsReader qr;
    public string[] player_good = { };
    public string[] player_bad = { };
    public string NextLevel;
    public string filename;
    public GameObject[] riddle_answer = { };
    public GameObject player_bubble;
    public GameObject trigger;
    public PlayerScript player;
    public int riddle_index = 0;

    public AudioSource audio_good;
    public AudioSource audio_bad;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        qr = new QuestsReader(Application.dataPath + "/Scripts/" + filename);
        for (int i = 0; i < qr.quests_table.quests[0].properties.dialogs.Length; i++)
        {
            if (qr.quests_table.quests[0].properties.dialogs[i].character == "player") //player
            {
                riddle_index++;
            }
        }
        player_good = new string[riddle_index];
        player_bad = new string[riddle_index];
        riddle_index = 0;
        for (int i = 0; i < qr.quests_table.quests[0].properties.dialogs.Length; i++)
        {
            if (qr.quests_table.quests[0].properties.dialogs[i].character == "player") //player
            {
                player_good.SetValue(qr.quests_table.quests[0].properties.dialogs[i].good, riddle_index);
                player_bad.SetValue(qr.quests_table.quests[0].properties.dialogs[i].bad, riddle_index);
                riddle_index++;
            }
        }
        riddle_index = 0;
    }
    async void Wait(bool show, string text,int seconds,AudioSource audio)
    {
        Debug.Log("Waiting "+seconds+" second...");
        await Task.Delay(System.TimeSpan.FromSeconds(seconds));
        player_bubble.GetComponentInChildren<SpriteRenderer>().enabled = show;
        player_bubble.GetComponentInChildren<TextMeshProUGUI>().text = text;
        audio.Play();
        Debug.Log("Done!");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...    
             if (riddle_index == riddle_answer.Length)
            {
                SceneManager.LoadScene(NextLevel, LoadSceneMode.Single);
                return;
            }
            player_bubble.GetComponentInChildren<SpriteRenderer>().enabled = false;
            player_bubble.GetComponentInChildren<TextMeshProUGUI>().text = "";
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject == riddle_answer[riddle_index] || hit.collider.gameObject == trigger)
                {
                    Wait(true, player_good[riddle_index],1,audio_good);
                    riddle_index++;
                    player.is_dialog = false;
                    if (riddle_index == riddle_answer.Length)
                    {
                        Wait(true, player_good[riddle_index], 1,audio_good);
                        //riddle_index = -1;
                    }
                    if (hit.collider.gameObject == trigger)
                    {
                        Wait(false, "",1,null);
                        player.is_dialog = false;
                    }
                }
                else
                {
                    Wait(true, player_bad[riddle_index],1,audio_bad);
                    // riddle_index = 0;
                    player.is_dialog = false;
                }
                // the object identified by hit.transform was clicked
                // do whatever you want
            } else
            {
                Wait(false, "",1,null);
                player.is_dialog = false;
            }
        }
    }

}
