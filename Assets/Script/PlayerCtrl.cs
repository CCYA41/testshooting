using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float speed;
    public float power = 1f;

    public bool isTouchTop = false;
    public bool isTouchBottom = false;
    public bool isTouchLeft = false;
    public bool isTouchRight = false;

    Animator anim;

    public GameObject bulletPrefab01;
    public GameObject bulletPrefab02;

    public float curBulletDelay = 0f;
    public float maxBulletDelay = 0.3f;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
        Fire();
        ReloadBullet();


    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
        {
            h = 0;
        }
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
        {
            v = 0;
        }

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;


        anim.SetInteger("Input", (int)h);
    }
    void Fire()
    {
        if (!Input.GetButton("Fire1"))
            return;

        if (curBulletDelay < maxBulletDelay)
            return;

        Power();

        curBulletDelay = 0;
    }
    void Power()
    {
        switch (power)
        {
            case 1:
                {
                    GameObject bulletC1 = Instantiate(bulletPrefab01, transform.position, Quaternion.identity);
                    Rigidbody2D rdC1 = bulletC1.GetComponent<Rigidbody2D>();
                    rdC1.AddForce(Vector2.up * 10, ForceMode2D.Impulse);


                }
                break;
            case 2:
                {
                    GameObject bulletL2 = Instantiate(bulletPrefab01, transform.position + Vector3.left * 0.1f, Quaternion.identity);
                    Rigidbody2D rdL2 = bulletL2.GetComponent<Rigidbody2D>();
                    rdL2.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

                    GameObject bulletR2 = Instantiate(bulletPrefab01, transform.position + Vector3.right * 0.1f, Quaternion.identity);
                    Rigidbody2D rdR2 = bulletR2.GetComponent<Rigidbody2D>();
                    rdR2.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                }
                break;
            case 3:
                {
                    GameObject bulletC3 = Instantiate(bulletPrefab02, transform.position, Quaternion.identity);
                    Rigidbody2D rdC3 = bulletC3.GetComponent<Rigidbody2D>();
                    rdC3.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

                    GameObject bulletL3 = Instantiate(bulletPrefab01, transform.position + Vector3.left * 0.25f, Quaternion.identity);
                    Rigidbody2D rdL3 = bulletL3.GetComponent<Rigidbody2D>();
                    rdL3.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

                    GameObject bulletR3 = Instantiate(bulletPrefab01, transform.position + Vector3.right * 0.25f, Quaternion.identity);
                    Rigidbody2D rdR3 = bulletR3.GetComponent<Rigidbody2D>();
                    rdR3.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

                }

                break;

        }
    }

    void ReloadBullet()
    {
        curBulletDelay += Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBorder")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBorder")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
            }
        }
    }
}
