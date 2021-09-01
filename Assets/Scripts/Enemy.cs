using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour


{
    
    [SerializeField] int speed;
    [SerializeField] bool direction;
    [SerializeField] int life;

    float maxX, minX;

    
    

    // Start is called before the first frame update
    void Start()
    {
        
        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        maxX = esquinaSupDer.x;
      

        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        minX = esquinaInfIzq.x;

      
    }

    // Update is called once per frame
    void Update()
    {
        Movement();


        }
    /*  private void OnCollisionEnter2D(Collision2D collision)
      {
          if(collision.gameObject.CompareTag("Bullet"))
          {
              if (life < 0)
              {
                  Destroy(this.gameObject);
              }
              else life--;


          }
      }*/
    private void Movement() {

        if (direction)
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        else
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));

        if (transform.position.x >= maxX)
            direction = false;
        else if (transform.position.x <= minX)
            direction = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) {
            if (life <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                life--;
            }
        }

        
    }

}
