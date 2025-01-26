using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 3f;
    public GameObject[] hearts;

    private bool immune = false;
    private Animator animator;
    const string ENEMY = "Enemy";
    void Start()
    {
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WaitAfterHit(float time)
    {
        yield return new WaitForSeconds(time);
        immune = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ENEMY)
        {
            if (health > 0 && health <= hearts.Length && !immune)
            {
                hearts[(int)(health - 1)].SetActive(false);
                immune = true;
                animator.Play("Damaged");
                StartCoroutine(WaitAfterHit(0.2f));
            }
            if (health == 0)
            {
               //DeathScenario();
            }
                

            health -= 1;
        }
    }
}
