using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    private float TimeBtwAttack;
    public float startTimeBtwAttack;

    public KeyCode MeleeKey;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;

    public AudioClip swordsound;
    private Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        
        if (TimeBtwAttack <= 0)
        {
           
            //then you can attack;
            if(Input.GetKey(MeleeKey)){
               anim.SetTrigger("Attack");
               AudioManager.instance.RandomizeSfx(swordsound, swordsound);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange,whatIsEnemies);
                for(int i = 0; i<enemiesToDamage.Length;i++){
                    enemiesToDamage[i].GetComponent<BaseEnemy>().takedamage(50);
                }
            }
            TimeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            TimeBtwAttack -= Time.deltaTime;
        }
	}
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    IEnumerator MyCoroutine()
    {
        //This is a coroutine

        yield return 0; 
        
       
    }
}



