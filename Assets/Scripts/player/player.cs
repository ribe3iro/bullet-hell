using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject gameOver;

    public int maxHp;
    [HideInInspector] public int heartNum;

    const string enemyTag = "Enemy";
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private CapsuleCollider2D cc = null;
    private bool isDamage = false;
    private float blinkTime = 0.0f;
    private float damageTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        heartNum = maxHp;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0){
            return;
        }
        if (isDamage){
            cc.enabled = false;
            if (blinkTime > 0.2f){
                sr.enabled = true;
                blinkTime = 0.0f;
            }
            else if(blinkTime > 0.1f){
                sr.enabled = false;
            }
            else{
                sr.enabled = true;  
            }
            if (damageTime > 1.0f){
                isDamage = false;
                damageTime = 0.0f;
                sr.enabled = true;
                cc.enabled = true;
            }
            else{
            blinkTime += Time.deltaTime;
            damageTime += Time.deltaTime;
            }
        }
    }

    void FixedUpdate()
    {
        float xSpeed = 0.0f;
        float ySpeed = 0.0f;
        if(Input.GetKey("d")){
            xSpeed += 1;
        }
        if(Input.GetKey("a")){
            xSpeed -= 1;
        }
        if(Input.GetKey("w")){
            ySpeed += 1;
        }
        if(Input.GetKey("s")){
            ySpeed -= 1;
        }
        Vector2 velocity = new Vector2(xSpeed, ySpeed);
        rb.velocity = velocity.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.tag == enemyTag)
        {
            isDamage = true;
            heartNum--;
            if (heartNum == 0)
            {
                Time.timeScale = 0;
                gameOver.SetActive(true);
                sr.enabled = true;  
            }
        }
    }
}
