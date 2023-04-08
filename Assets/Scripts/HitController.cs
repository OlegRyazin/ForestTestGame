using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    private Animator animator;
    private GameObject tree;
    private AudioSource audioSource;

    private bool isHitting = false;
    private float cooldown;

    private const float hitTime = 0.867f;
    private const float firstHitTime = 0.4f;

    void Start()    
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        cooldown = firstHitTime;
    }

    private void Update()
    {
        if(tree != null)
        {
            cooldown -= Time.deltaTime;

            if (cooldown <= 0f)
            {
                tree.gameObject.transform.parent.gameObject.GetComponent<Tree>().TreeGetHit(Player.damage);
                cooldown = hitTime;
                audioSource.Play();
            }
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        cooldown = firstHitTime;

        tree = other.gameObject;
        if (tree.tag == "Tree")
        {
            animator.SetBool("Hit", true);
            isHitting = true;
        }
        else tree = null;
    }

    private void OnTriggerExit(Collider other)
    {
        TreeMiss();
    }

    public void TreeMiss()
    {
        animator.ResetTrigger("Hit");
        animator.SetBool("Hit", false);
        isHitting = false;
        cooldown = firstHitTime;
        tree = null;
    }
}
