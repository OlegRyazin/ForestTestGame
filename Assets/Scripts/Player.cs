using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{   
    private Rigidbody rb;
    private Animator animator;    
    private static int wood = 0;
    [SerializeField] private DynamicJoystick joystick;

    public static BalanceInfo balanceInfo;
    //public static int level = 1;
    public static int damage;
    public static int Wood
    {
        get
        {
            return wood;
        }
        set
        {
            if (wood != value) UI.NumberOfLogs_ImageAnimPlay();
            wood = value;
            UI.UI_Wood_Update();
        }
    }
    
    public float speed = 2f;
    public float rotationSpeed = 10f;
    public List<GameObject> ArmorAndAxes = new List<GameObject>();

    private void Awake()
    {
        balanceInfo = Resources.Load<BalanceInfo>("BalanceInfo1");
        damage = balanceInfo.axe1_damage;
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        Wood = 0;
        rb = GetComponent<Rigidbody>();
               
    }

    void Update()
    {
        float horiz = joystick.Horizontal;
        float vert = joystick.Vertical;       

        Vector3 directionVector = new Vector3(horiz, 0, vert);

        if(directionVector.magnitude > Mathf.Abs(0.05f))
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * rotationSpeed);

        animator.SetFloat("Speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);

        rb.velocity = directionVector * speed;
    }

    public void SkinChange(int skinID)
    {
        foreach(GameObject item in ArmorAndAxes)
        {
            item.SetActive(false);
        }

        switch(skinID)
        {
            case 0:
                ArmorAndAxes[0].SetActive(true);
                ArmorAndAxes[1].SetActive(true);
                damage = balanceInfo.axe1_damage;
                break;
            case 1:
                ArmorAndAxes[2].SetActive(true);
                ArmorAndAxes[1].SetActive(true);
                damage = balanceInfo.axe1_damage;
                break;
            case 2:
                ArmorAndAxes[4].SetActive(true);
                ArmorAndAxes[1].SetActive(true);
                damage = balanceInfo.axe1_damage;
                break;
            case 3:
                ArmorAndAxes[0].SetActive(true);
                ArmorAndAxes[3].SetActive(true);
                damage = balanceInfo.axe2_damage;
                break;
            case 4:
                ArmorAndAxes[2].SetActive(true);
                ArmorAndAxes[3].SetActive(true);
                damage = balanceInfo.axe2_damage;
                break;
            case 5:
                ArmorAndAxes[4].SetActive(true);
                ArmorAndAxes[3].SetActive(true);
                damage = balanceInfo.axe2_damage;
                break;
            case 6:
                ArmorAndAxes[0].SetActive(true);
                ArmorAndAxes[5].SetActive(true);
                damage = balanceInfo.axe3_damage;
                break;
            case 7:
                ArmorAndAxes[2].SetActive(true);
                ArmorAndAxes[5].SetActive(true);
                damage = balanceInfo.axe3_damage;
                break;
            case 8:
                ArmorAndAxes[4].SetActive(true);
                ArmorAndAxes[5].SetActive(true);
                damage = balanceInfo.axe3_damage;
                break;
            default: break;
        }
    }
}
