using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public string type;
    public float damage;
    float invulnerabilityTime = 0.5f;
    float lastHit;
    float lastAttack;
    public float attackSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Flash()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Hurt(float damage)
    { 
        if(Time.time > lastHit + invulnerabilityTime)
        {
            health -= damage;
            StartCoroutine(Flash());
            if (health <= 0)
            {
                Death();
            }
            lastHit = Time.time;
        }
    
    }

    public void Death()
    {
        //die
    }

    public void Attack(Entity target)
    {
        if (Time.time > lastAttack)
        {
            target.Hurt(damage);
            lastAttack = Time.time + attackSpeed;
        }

    }
}
