using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Quests;
using UnityEngine.SceneManagement;
public class Dialogue_System : MonoBehaviour
{
    private QuestsReader qr;
    public GameObject bubble_player;
    public GameObject bubble_NPC;
    public GameObject bubble_narrator;
    public PlayerScript playerscript;
    public string filename;

    public AudioSource player_sound;
    public AudioSource NPC_sound;
    public AudioSource narrator_sound;
    
    public string NextLevel;

    public string[] player = {  };
    public string[] NPC = {  };
    public string[] narrator = {  };
    public string[] order = {  };

    private int order_index = 0;
    private int player_index = 0;
    private int NPC_index = 0;
    private int narrator_index = 0;

    // Start is called before the first frame update
    void Start()
    {
        qr = new QuestsReader (Application.dataPath + "/Scripts/" + filename);
        for (int i = 0; i < qr.quests_table.quests[0].properties.dialogs.Length; i++)
        {
            if(qr.quests_table.quests[0].properties.dialogs[i].character == "player") //player
            {
                player_index++;
            }
            if (qr.quests_table.quests[0].properties.dialogs[i].character == "npc") //NPC
            {
                NPC_index++;
            }
            if (qr.quests_table.quests[0].properties.dialogs[i].character == "narrator") //narrator
            {
                narrator_index++;
            }
            order_index++;
        }
        player = new string[player_index];
        NPC = new string[NPC_index];
        narrator = new string[narrator_index];
        order = new string[order_index];
        player_index = NPC_index = narrator_index = order_index =0;
        for (int i = 0; i < qr.quests_table.quests[0].properties.dialogs.Length; i++)
        {
            if (qr.quests_table.quests[0].properties.dialogs[i].character == "player") //player
            {
                player.SetValue(qr.quests_table.quests[0].properties.dialogs[i].text, player_index);
                order.SetValue(qr.quests_table.quests[0].properties.dialogs[i].character, order_index);
                System.Text.UTF8Encoding encodingUnicode = new System.Text.UTF8Encoding();
                byte[] cyrillicTextByte = encodingUnicode.GetBytes(qr.quests_table.quests[0].properties.dialogs[i].text);
                Debug.Log(encodingUnicode.GetString(cyrillicTextByte));
                player_index++;
            }
            if (qr.quests_table.quests[0].properties.dialogs[i].character == "npc") //NPC
            {
                NPC.SetValue(qr.quests_table.quests[0].properties.dialogs[i].text, NPC_index);
                order.SetValue(qr.quests_table.quests[0].properties.dialogs[i].character, order_index);
                NPC_index++;
            }
            if (qr.quests_table.quests[0].properties.dialogs[i].character == "narrator") //narrator
            {
                narrator.SetValue(qr.quests_table.quests[0].properties.dialogs[i].text, narrator_index);
                order.SetValue(qr.quests_table.quests[0].properties.dialogs[i].character, order_index);
                narrator_index++;
            }
            order_index++;
        }
        player_index = NPC_index = narrator_index = order_index = 0;
    }


      public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        audioSource.Play();
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioSource.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            bubble_player.GetComponentInChildren<SpriteRenderer>().enabled = false;
            bubble_NPC.GetComponentInChildren<SpriteRenderer>().enabled = false;
            bubble_narrator.GetComponentInChildren<SpriteRenderer>().enabled = false;

            bubble_NPC.GetComponentInChildren<TextMeshProUGUI>().text = "";
            bubble_player.GetComponentInChildren<TextMeshProUGUI>().text = "";
            bubble_narrator.GetComponentInChildren<TextMeshProUGUI>().text = "";

            if (order_index == order.Length)
            {
                SceneManager.LoadScene(NextLevel, LoadSceneMode.Single);
                return;
            }
            if (order[order_index].Contains("player"))
            {
                bubble_player.GetComponentInChildren<SpriteRenderer>().enabled = true;
                bubble_player.GetComponentInChildren<TextMeshProUGUI>().text = player[player_index];
                player_index++;
                if (player_index == player.Length)
                    player_index = 0;
                playerscript.is_dialog = true;
                player_sound.Play();
            }
            if (order[order_index].Contains("npc"))
            {
                bubble_NPC.GetComponentInChildren<SpriteRenderer>().enabled = true;
                bubble_NPC.GetComponentInChildren<TextMeshProUGUI>().text = NPC[NPC_index];
                NPC_index++;
                if (NPC_index == NPC.Length)
                    NPC_index = 0;
                playerscript.is_dialog = true;
                NPC_sound.Play();
            }
            if (order[order_index].Contains("narrator"))
            {
                bubble_narrator.GetComponentInChildren<SpriteRenderer>().enabled = true;
                bubble_narrator.GetComponentInChildren<TextMeshProUGUI>().text = narrator[narrator_index];
                narrator_index++;
                if (narrator_index == narrator.Length)
                    narrator_index = 0;
                playerscript.is_dialog = true;
                narrator_sound.Play();
            }
            order_index++;
        }
    }
}
