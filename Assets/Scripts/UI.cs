using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text numberOfLogs_Text;
    public Button upgrade_Button;
    public Image numberOfLogs_Image;

    public static Action UI_Wood_Update;

    private static Animation upgrade_Button_Animation;
    private static Animation numberOfLogs_Image_Animation;

    private static AudioSource upgrade_Button_AudioSource;
    private static AudioSource numberOfLogs_Image_AudioSource;

    private void Awake()
    {
        UI_Wood_Update += numberOfLogs_Update;
    }

    void Start()
    {        
        upgrade_Button_Animation = upgrade_Button.GetComponent<Animation>();
        numberOfLogs_Image_Animation = numberOfLogs_Image.GetComponent<Animation>();
        upgrade_Button_AudioSource = upgrade_Button.GetComponent<AudioSource>();
        numberOfLogs_Image_AudioSource = numberOfLogs_Image.GetComponent<AudioSource>();
        upgrade_Button.gameObject.SetActive(false);

    }

    public void Upgrade_ButtonAnimPlay()
    {
        upgrade_Button_Animation.Play();
        upgrade_Button_AudioSource.Play();
    }

    public static void NumberOfLogs_ImageAnimPlay()
    {
        numberOfLogs_Image_Animation.Play();
        numberOfLogs_Image_AudioSource.Play();
    }

    public IEnumerator WaitEndAnimation()
    {
        yield return new WaitForSeconds(0.3f);
        upgrade_Button.gameObject.SetActive(false);
    }

    private void numberOfLogs_Update()
    {
        bool showUpButton = false;
        string str = Player.Wood.ToString();
        switch(Player.level)
        {
            case 1:
                str += "/" + Player.balanceInfo.level2_Price;
                if (Player.Wood >= Player.balanceInfo.level2_Price) showUpButton = true;
                break;
            case 2:
                str += "/" + Player.balanceInfo.level3_Price;
                if (Player.Wood >= Player.balanceInfo.level3_Price) showUpButton = true;
                break;
            default:
                break;
        }
        numberOfLogs_Text.text = str;


        if (showUpButton) upgrade_Button.gameObject.SetActive(true);
        else StartCoroutine(WaitEndAnimation());

    }
}
