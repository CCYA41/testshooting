using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public float speed;
    public float health;

    public Sprite[] sprites;

    Rigidbody2D rd;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(int nPoint)
    {
        if (nPoint == 5 || nPoint == 6)
        {
            rd.velocity = new Vector2(speed * (-1), -1);
        }
        else if (nPoint == 3 || nPoint == 4)
        {
            rd.velocity = new Vector2(speed * (1), -1);
        }
        else
        {
            rd.velocity = Vector2.down * speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyBorder"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "PlayerBullet")
        {
            BulletCtrl bulletCtrl = GetComponent<BulletCtrl>();

            OnHit(bulletCtrl.power);
            Destroy(collision.gameObject);

        }
    }

    private void OnHit(float bulletPower)
    {
        health -= bulletPower;
        spriteRenderer.sprite = sprites[1];

        Invoke("ReturnSprite", 0.1f);


        if (health < 0)
            Destroy(gameObject);
    }
    private void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }
}
