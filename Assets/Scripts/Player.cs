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
    public static int level = 1;
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

    public void LevelUp()
    {
        switch(level)
        {
            case 1:
                level++;
                Wood -= balanceInfo.level2_Price;
                damage = balanceInfo.axe2_damage;
                ArmorAndAxes[0].SetActive(false);
                ArmorAndAxes[1].SetActive(false);
                ArmorAndAxes[2].SetActive(true);
                ArmorAndAxes[3].SetActive(true);
                break;
            case 2:
                level++;
                Wood -= balanceInfo.level3_Price;
                damage = balanceInfo.axe3_damage;
                ArmorAndAxes[2].SetActive(false);
                ArmorAndAxes[3].SetActive(false);
                ArmorAndAxes[4].SetActive(true);
                ArmorAndAxes[5].SetActive(true);               
                break;
            default: break;
        }
    }
}
