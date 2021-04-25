using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed;
    public GameObject Player;
    Entity entity;
    public float attackTime;
    float lastAttack;
    public float reach = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        entity = this.GetComponent<Entity>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector2.Distance(Player.transform.position, transform.position) > reach && Time.time > lastAttack)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Time.deltaTime * movementSpeed);
        }
        else if (Time.time > lastAttack)
        {
            entity.Attack(Player.GetComponent<Entity>());
            lastAttack = Time.time + attackTime;
            //Attack();
        }
    }

    
}
