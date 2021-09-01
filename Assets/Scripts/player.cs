using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour

{
    [SerializeField] int speed;
    [SerializeField] GameObject bullet, bullet2;
    [SerializeField] float nextFire, nextFire2;
    bool fireMode = false;


    float minX, maxX, minY, maxY,tamX,tamY, canFire;

    // Start is called before the first frame update
    void Start()
    {
        tamX = (GetComponent<SpriteRenderer>()).bounds.size.x;
        tamY = (GetComponent<SpriteRenderer>()).bounds.size.y;

        //viewport
        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        maxX = esquinaSupDer.x - tamX/2;
        maxY = esquinaSupDer.y - tamY/2;

        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        minX = esquinaInfIzq.x + tamX/2;
        minY = esquinaInfIzq.y+7;

      
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Fire();
    }
    void Movement()
    {
        /*
       if (Input.GetKey(KeyCode.RightArrow))
           transform.Translate(new Vector2(0.1f,0));

       if (Input.GetKey(KeyCode.LeftArrow))
           transform.Translate(new Vector2(-0.1f, 0));

       if (Input.GetKey(KeyCode.UpArrow))
           transform.Translate(new Vector2(0, 0.1f));

       if (Input.GetKey(KeyCode.DownArrow))
           transform.Translate(new Vector2(0, -0.1f));
       */
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(movH * Time.deltaTime * speed, movV * Time.deltaTime * speed));

        float newX = Mathf.Clamp(transform.position.x, minX, maxX);
        float newY = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector2(newX, newY);


    }

    void Fire()
    {
       

        if (Input.GetKeyDown(KeyCode.Z)) {
            if (fireMode == false)
            {
                Debug.Log("Cambio a true");
                fireMode = true;
            }
            else
            {
                fireMode = false;
                Debug.Log("Cambio a false");
            }
            
        
        
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= canFire)
        {
            if (fireMode == false)
            {
                Instantiate(bullet, transform.position - new Vector3(0, tamY / 2, 0), Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().gravityScale = 1;
                canFire = Time.time + nextFire;

            }
            else {
                for (int i = 0; i < 3; i++) { 
                    Instantiate(bullet2, transform.position - new Vector3(0, (tamY / 2)-(i*0.5f), 0), Quaternion.identity);
                    bullet2.GetComponent<Rigidbody2D>().gravityScale = 5;
                    canFire = Time.time + nextFire2;


                }

                




            }
            


        }

     


        }





    }

