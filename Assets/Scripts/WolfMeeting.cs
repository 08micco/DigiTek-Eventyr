using System;
using UnityEngine;

public class WolfMeeting : MonoBehaviour
{
    public GameObject wolf;
    public WolfFriendly wolfScript;
    public GameObject bg;
    public GameObject txt1;
    public GameObject txt2;
    public GameObject txt3;
    public GameObject txt4;
    public GameObject txt5;
    public GameObject txt6;
    public GameObject txt7;
    public GameObject txt8;
    public GameObject txt9;

    private int convoNum = 0;

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        switch (convoNum)
        {
            case 1:
                Conversation1();
                break;
            case 2:
                Conversation2();
                break;
            case 3:
                Conversation3();
                break;
            case 4:
                Conversation4();
                break;
            case 5:
                Conversation5();
                break;
            case 6:
                Conversation6();
                break;
            case 7:
                Conversation7();
                break;
            case 8:
                Conversation8();
                break;
            case 9:
                Conversation9();
                break;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "WolfMeetWall")
        {
            Destroy(collision.gameObject);
            GetComponent<PlayerMovement>().enabled = false;
            GetComponentInChildren<PlayerLook>().enabled = false;
            wolf.SetActive(true);
            wolfScript.GoToPlayer();
            ConversationBegin();
        }
    }
    
    private void ConversationBegin()
    {
        convoNum = 1;
        RemoveTxt();
        bg.SetActive(true);
        txt1.SetActive(true);
        // if (Input.GetKeyDown(KeyCode.Space)) Conversation1();
    }

    private void Conversation1()
    {
        convoNum = 2;
        RemoveTxt();
        txt2.SetActive(true);
        // if (Input.GetKeyDown(KeyCode.Space)) Conversation2();
    }
    private void Conversation2()
    {
        convoNum = 3;
        RemoveTxt();
        txt3.SetActive(true);
        // if (Input.GetKeyDown(KeyCode.Space)) Conversation3();
    }
    private void Conversation3()
    {
        convoNum = 4;
        RemoveTxt();
        txt4.SetActive(true);
        // if (Input.GetKeyDown(KeyCode.Space)) Conversation4();
    }
    private void Conversation4()
    {
        convoNum = 5;
        RemoveTxt();
        txt5.SetActive(true);
        // if (Input.GetKeyDown(KeyCode.Space)) Conversation5();
    }
    private void Conversation5()
    {
        convoNum = 6;
        RemoveTxt();
        txt6.SetActive(true);
        // if (Input.GetKeyDown(KeyCode.Space)) Conversation6();
    }
    private void Conversation6()
    {
        convoNum = 7;
        RemoveTxt();
        txt7.SetActive(true);
        // if (Input.GetKeyDown(KeyCode.Space)) Conversation7();
    }
    private void Conversation7()
    {
        convoNum = 8;
        RemoveTxt();
        txt8.SetActive(true);
        // if (Input.GetKeyDown(KeyCode.Space)) Conversation8();
    }
    private void Conversation8()
    {
        convoNum = 9;
        RemoveTxt();
        txt9.SetActive(true);
        // if (Input.GetKeyDown(KeyCode.Space)) Conversation9();
        
    }
    private void Conversation9()
    {
        convoNum = 10;
        RemoveTxt();
        bg.SetActive(false);
        wolfScript.WalkBack();
        
        GetComponent<PlayerMovement>().enabled = true;
        GetComponentInChildren<PlayerLook>().enabled = true;
    }
    
    private void RemoveTxt()
    {
        txt1.SetActive(false); 
        txt2.SetActive(false); 
        txt3.SetActive(false); 
        txt4.SetActive(false); 
        txt5.SetActive(false); 
        txt6.SetActive(false); 
        txt7.SetActive(false); 
        txt8.SetActive(false); 
        txt9.SetActive(false); 
    }


}
