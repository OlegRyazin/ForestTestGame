using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Log : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.Wood++;
            gameObject.transform.position = new Vector3(0f, -10f, 0f);
        }
    }
}
