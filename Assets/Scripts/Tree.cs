using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Tree : MonoBehaviour
{
    public GameObject player;
    public GameObject liveTree;
    public GameObject dieTree;

    public ParticleSystem particleSystem;

    private Animation animation;
    private Collider liveTreeCollider;
    

    private Vector3[,] logTransforms = new Vector3[3,3];

    private int HP;

    void Start()
    {
        animation = liveTree.GetComponent<Animation>();
        liveTreeCollider = liveTree.GetComponent<Collider>();
        for (int i = 0; i < 3; i++)
        {
            Transform child = dieTree.transform.GetChild(i);
            logTransforms[0, i] = new Vector3(child.position.x, child.position.y, child.position.z);
            logTransforms[1, i] = new Vector3(child.localEulerAngles.x, child.localEulerAngles.y, child.localEulerAngles.z);
            logTransforms[2, i] = new Vector3(child.localScale.x, child.localScale.y, child.localScale.z);
        }
        HP = Player.balanceInfo.tree_HP;
    }

    public void TreeGetHit(int damage)
    {
        particleSystem.Play();
        animation.Play("TreeHit");
        HP -= damage;
        if (HP <= 0) TreeDie();
    }
    public void TreeDie()
    {
        player.GetComponent<HitController>().TreeMiss();
        liveTree.SetActive(false);
        dieTree.SetActive(true);
        StartCoroutine(TreeReborn());
    }
    public IEnumerator TreeReborn()
    {        
        yield return new WaitForSeconds(Random.Range(10f, 20f));

        
        for (int i = 0; i < 3; i++)
        {
            Transform log = dieTree.transform.GetChild(i);
            log.position = logTransforms[0, i];
            log.localEulerAngles = logTransforms[1, i];
            log.localScale = logTransforms[2, i];
        }
        dieTree.SetActive(false);

        liveTree.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        liveTree.SetActive(true);
        liveTreeCollider.enabled = false;
        HP = Player.balanceInfo.tree_HP;
        animation.Play("TreeGrow");

        yield return new WaitForSeconds(10f);
        liveTreeCollider.enabled = true;

    }
}
