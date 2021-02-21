using TMPro;
using UnityEngine;

public class QuestFlower : MonoBehaviour
{
    private bool isActive;

    private int flowersRequired = 5;
    private int applesRequired = 10;

    private int flowers;
    private int apples;

    public Inventory items;

    public TMP_Text objectiveApple;
    public TMP_Text objectiveFlower;

    public GameObject QuestEnd;
    public GameObject wolves;

    public AudioSource wolfHowl;

    private void Awake()
    {
        isActive = false;
        objectiveApple.enabled = false;
        objectiveFlower.enabled = false;
    }

    private void Update()
    {
        flowers = items.FlowerAmount();
        apples = items.AppleAmount();
        if (flowers >= flowersRequired && apples >= applesRequired) isActive = false;
        switch (isActive)
        {
            case true:
                ShowQuest();
                break;
            case false:
                QuestComplete();
                break;
        }
    }

    private void ShowQuest()
    {
        objectiveApple.SetText("Æbler indsamlet: {0}/{1}", apples, applesRequired );
        objectiveFlower.SetText("Blomster indsamlet: {0}/{1}", flowers, flowersRequired );
        if (objectiveApple.enabled != false) return;
        objectiveApple.enabled = true;
        objectiveFlower.enabled = true;
        QuestEnd.SetActive(true);
        wolfHowl.Play();
    }

    private void QuestComplete()
    {
        objectiveApple.enabled = false;
        objectiveFlower.enabled = false; 
        QuestEnd.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "FlowerQuestActivate")
        {
            isActive = true;
            Destroy(collision.gameObject);
            wolves.SetActive(true);
        }
    }
}
