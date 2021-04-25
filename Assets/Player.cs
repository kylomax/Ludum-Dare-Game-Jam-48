using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed = 4;
    public GameObject AttackHitBox;
    public float radius = 0.8f;
  //  Camera camera;

    // Start is called before the first frame update
    void Start()
    {
       // camera = Camera.main
        rb = this.GetComponent<Rigidbody2D>();
    }

   // IEnumerator HitAnim()
   // {
  //    //  yield return new WaitForSeconds(0.6f);
       // AttackHitBox.SetActive(false);
   // }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * movementSpeed;
        float v = Input.GetAxis("Vertical") * movementSpeed;

        rb.velocity = new Vector2(h * Time.deltaTime, v * Time.deltaTime);

        if(Input.GetButtonDown("Attack"))
        { 
          ///  Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           // targetPos.z = transform.position.z;
           // transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            

           // RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
           // AttackHitBox.transform.up = transform.position - Input.mousePosition;
          AttackHitBox.transform.position = this.transform.position;
           
            //Vector3 mousePos = Input.mousePosition;
            //mousePos.z = 10;
 
            Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            mousePos.z = 0;
            //mousePos.x = mousePos.x - objectPos.x;
            //mousePos.y = mousePos.y - objectPos.y;
 
           // float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            //AttackHitBox.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            AttackHitBox.transform.right = mousePos - AttackHitBox.transform.position;
            AttackHitBox.transform.Translate(new Vector3 (0.3f, 0, 0));

            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(AttackHitBox.transform.position, radius);
            foreach (Collider2D hitCollider in hitColliders)
            {
                if (hitCollider.GetComponent<Entity>())
                {
                    this.gameObject.GetComponent<Entity>().Attack(hitCollider.GetComponent<Entity>());
                }
            }
            


           // AttackHitBox.SetActive(true);
           // StartCoroutine(HitAnim());
            
        }
        /*
        Vector2 velocityVector = rb.velocity;

        if (h > 0.01f)
        {
            velocityVector.x = velocityVector.x + h;
        }
        else if (h < 0)
        {
            velocityVector.x = velocityVector.x - h;
        }
        if (v > 0.01f)
        {
            velocityVector.y = velocityVector.y + v;
        }
        else if (v < 0)
        {
            velocityVector.y = velocityVector.y - v;
        }

        rb.velocity = velocityVector;
        */
    }
}
