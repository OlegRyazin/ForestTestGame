using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text numberOfLogs_Text;
    [SerializeField] private Button upgrade_Button;
    [SerializeField] private Image numberOfLogs_Image;
    [SerializeField] private GameObject shop;
    [SerializeField] private Player player;

    public static Action UI_Wood_Update;

    private static Animation upgrade_Button_Animation;
    private static Animation numberOfLogs_Image_Animation;

    private static AudioSource upgrade_Button_AudioSource;
    private static AudioSource numberOfLogs_Image_AudioSource;

    private bool isShopOpen = false;

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
    }

    private void numberOfLogs_Update()
    {
        numberOfLogs_Text.text = Player.Wood.ToString();
    }

    public void OpenAndCloseShopButton()
    {
        shop.SetActive(!isShopOpen);
        isShopOpen = !isShopOpen;
    }

    public void ChangeSkinButtons(int skinID)
    {
        player.SkinChange(skinID);
    }
}
