using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 3f;
    public GameObject[] hearts;

    public static bool dead = false;
    public GameObject deathMenu;

    private bool immune = false;

    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator animator;

    public AudioSource audiosource;
    public AudioClip clip;

    const string ENEMY = "Enemy";
    void Start()
    {
        animator= GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sp =  GetComponent<SpriteRenderer>();
        audiosource = GetComponent<AudioSource>();
    }
    private IEnumerator WaitForSeconds(float time)
    {
        yield return new WaitForSeconds(time);
    }
    private IEnumerator DeathScenario()
    {
        dead = true;
        animator.Play("death");
        AudioManagerScript.INSTANCE.PlayTrack(AudioManagerScript.Audio_Ids.LOSE_TRACK);
        yield return new WaitForSeconds(2.5f);


        transform.GetChild(0).gameObject.SetActive(true);

        deathMenu.SetActive(true);
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

                rb.linearVelocityX = 0;
                rb.AddForce(new Vector2(7f * (sp.flipX ? 1 : -1), 0f), ForceMode2D.Impulse);


                StartCoroutine(WaitAfterHit(0.2f));
            }
            if (health == 0)
            {
              StartCoroutine(DeathScenario());
            }
                

            health -= 1;
        }
    }
}
