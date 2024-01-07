using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBehavior : MonoBehaviour
{
    public GameObject projectile;
    public GameObject explodeProjectile;
    public GameObject bounceProjectile;
    public GameObject acidIndicator;
    public GameObject acidAttack;
    public GameObject iceProjectile;
    public GameObject iceHeart;
    public GameObject lightningProjectile;
    public GameObject heart;
    public Sprite newDragon;
    public SpriteRenderer dragonSprite;
    public Sprite fireDragon;
    public Sprite acidDragon;
    public Sprite lightningDragon;
    public Sprite iceDragon;
    public int phase = 1;
    public float bulletSpeed = 15f;
    public float bulletAngle = -180f;

    public float attack1Interval = 8f;
    private float timerAttack1 = 5f;

    public float attackInterval2 = 14f;
    private float timerAttack2 = 2f;

    public float attackInterval3 = 9f;
    private float timerAttack3 = 2f;

    public float attackInterval4 = 12f;
    private float timerAttack4 = 6f;

    public float attackInterval5 = 18f;
    private float timerAttack5 = 6f;

    public float attackInterval6 = 25f;
    private float timerAttack6 = 8f;

    public float heartInterval = 12f;
    private float heartTimer = 0f;


    public GameObject audio;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.Find("AudioManager");
        audioManager = audio.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        heartTimer += Time.deltaTime;
        if(heartTimer >= heartInterval)
        {
            float randomX = Random.Range(-9f, 9f);
            float randomY = Random.Range(-4f, 0.4f);
            Vector2 randomPosition = new Vector2(randomX, randomY);
            Instantiate(heart, randomPosition, Quaternion.identity);
            heartTimer = 0f;
        }
        if(phase == 1)
        {
            timerAttack1 += Time.deltaTime;
            timerAttack2 += Time.deltaTime;
            timerAttack3 += Time.deltaTime;
            if (timerAttack1 >= attack1Interval)
            {
                timerAttack2 -= 0.5f;
                timerAttack3 -= 0.5f;
                StartCoroutine(fireProjectile());               
                timerAttack1 = 0f;
                attack1Interval -= 0.1f;
            }
            if (timerAttack2 >= attackInterval2)
            {
                timerAttack1 -= 0.5f;
                timerAttack3 -= 0.5f;
                int randNum = Random.Range(1, 3);
                if(randNum == 1)
                {
                    StartCoroutine(bouncingProjectile());
                } else if (randNum == 2)
                {
                    StartCoroutine(spawnAcidPlus());
                }
                attackInterval2 -= 0.3f;
                timerAttack2 = 0f;
            }
            if (timerAttack3 >= attackInterval3)
            {
                timerAttack1 -= 0.5f;
                timerAttack2 -= 0.5f;
                int randNum = Random.Range(1, 3);
                if (randNum == 1)
                {
                    StartCoroutine(spawnAcid());
                }
                else if (randNum == 2)
                {
                    StartCoroutine(explodingProjectile());
                }
                attackInterval3 -= 0.3f;
                timerAttack3 = 0f;
            }
        } else if (phase == 2)
        {
            timerAttack4 += Time.deltaTime;
            timerAttack5 += Time.deltaTime;
            timerAttack6 += Time.deltaTime;
            if (timerAttack4 >= attackInterval4)
            {
                timerAttack5 -= 0.5f;
                timerAttack6 -= 0.5f;
                int randNum = Random.Range(1, 3);
                if (randNum == 1)
                {
                    StartCoroutine(iceAttack());
                }
                else if (randNum == 2)
                {
                    StartCoroutine(iceAttack2());
                }
                
                attackInterval4 = attackInterval4 - 0.3f;
                timerAttack4 = 0f;
            }
            if (timerAttack5 >= attackInterval5)
            {
                timerAttack4 -= 0.5f;
                timerAttack6 -= 0.5f;
                int randNum = Random.Range(1, 3);
                if (randNum == 1)
                {
                    StartCoroutine(iceHeartAttack());
                }
                else if (randNum == 2)
                {
                    StartCoroutine(lightningAttack());
                }
                
                attackInterval5 = attackInterval5 - 0.4f;
                timerAttack5 = 0f;
            } else if (timerAttack6 >= attackInterval6)
            {
                timerAttack5 -= 0.5f;
                timerAttack4 -= 0.5f;
                StartCoroutine(lightningAttack2());
                
                attackInterval6 = attackInterval6 - 0.5f;
                timerAttack6 = 0f;
            }
        }
        
        

        
    }

    IEnumerator fireProjectile()
    {
        dragonSprite.sprite = fireDragon;
        bulletAngle = -180f;
        for (int i = 0; i < 10; i++)
        {
           
            audioManager.Play("Fireball");
            float radians = Mathf.Deg2Rad * bulletAngle;
            Vector2 force = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * bulletSpeed / 2.0f;
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            float angle = Mathf.Atan2(force.y, force.x) * Mathf.Rad2Deg + 90;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            rb.AddForce(force, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.2f);

            float randomAngle = Random.Range(10f, 20f);
            bulletAngle += randomAngle;
        }
        dragonSprite.sprite = fireDragon;
        for (int i = 0; i < 10; i++)
        {
            audioManager.Play("Fireball");
            float radians = Mathf.Deg2Rad * bulletAngle;
            Vector2 force = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * bulletSpeed / 2.0f;
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            float angle = Mathf.Atan2(force.y, force.x) * Mathf.Rad2Deg + 90;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            rb.AddForce(force, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.2f);
            float randomAngle = Random.Range(10f, 20f);
            bulletAngle -= randomAngle;
        }
        
      
    }

    IEnumerator explodingProjectile()
    {
        dragonSprite.sprite = fireDragon;
        audioManager.Play("Fireball");
        bulletAngle = -90f;
        float radians = Mathf.Deg2Rad * bulletAngle;
        Vector2 force = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * (bulletSpeed/5.0f);
        GameObject bullet = Instantiate(explodeProjectile, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        float angle = Mathf.Atan2(force.y, force.x) * Mathf.Rad2Deg + 90;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rb.AddForce(force, ForceMode2D.Impulse);
        yield break;

    }

    IEnumerator bouncingProjectile()
    {
        dragonSprite.sprite = fireDragon;
        bulletAngle = -135f;

        for (int i = 0; i < 5; i++)
        {
            audioManager.Play("Fireball");
            GameObject bullet = Instantiate(bounceProjectile, transform.position, Quaternion.identity);
            float radians = Mathf.Deg2Rad * bulletAngle;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Vector2 force = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * (bulletSpeed / 3.0f);
            float angle = Mathf.Atan2(force.y, force.x) * Mathf.Rad2Deg + 90;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            rb.AddForce(force, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.5f);
            bulletAngle += 20f;
        }

    }
    
    IEnumerator spawnAcid()
    {
        dragonSprite.sprite = acidDragon;
        audioManager.Play("Acid");
        for (int i = 0; i < 3; i++)
        {
            float randomX = Random.Range(-9f, 9f);
            float randomY = Random.Range(-4.5f, 0.7f);
            Vector2 randomCoord = new Vector2(randomX, randomY);

            GameObject acidInd = Instantiate(acidIndicator, randomCoord, Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
        }
        
    }

    IEnumerator spawnAcidPlus()
    {
        dragonSprite.sprite = acidDragon;
        audioManager.Play("Acid");
        float currentY = -2.0f;
        float currentX = -8.8f;
        for (int i = 0; i < 20; i++)
        {
            
            Vector2 randomCoord = new Vector2(currentX, currentY);

            GameObject acidInd = Instantiate(acidIndicator, randomCoord, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            currentX += 0.9f;
        }
        currentX = 0.0f;
        currentY = -4.4f;
        for(int i = 0; i < 12; i++)
        {
            Vector2 randomCoord = new Vector2(currentX, currentY);

            GameObject acidInd = Instantiate(acidIndicator, randomCoord, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            currentY += 0.4f;
        }
    }

    IEnumerator iceAttack()
    {
        dragonSprite.sprite = iceDragon;
        audioManager.Play("Ice");
        float currentBulletAngle = 180f;
        for (int i = 0; i < 14; i++)
        {
            GameObject bullet = Instantiate(iceProjectile, transform.position, Quaternion.identity);
            float radians = Mathf.Deg2Rad * currentBulletAngle;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Vector2 force = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * (bulletSpeed / 3.0f);
            float angle = Mathf.Atan2(force.y, force.x) * Mathf.Rad2Deg + 90;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            rb.AddForce(force, ForceMode2D.Impulse);

            GameObject bullet1 = Instantiate(iceProjectile, transform.position, Quaternion.identity);
            float radians1 = Mathf.Deg2Rad * currentBulletAngle;
            Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
            Vector2 force1 = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * (bulletSpeed / 6.0f);
            float angle1 = Mathf.Atan2(force1.y, force1.x) * Mathf.Rad2Deg + 90;
            bullet1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle1));
            rb1.AddForce(force1, ForceMode2D.Impulse);

            yield return new WaitForSeconds(0.05f);
            currentBulletAngle += 10f;
        }
    }

    IEnumerator iceAttack2()
    {
        dragonSprite.sprite = iceDragon;
        audioManager.Play("Ice");
        float currentBulletAngle = 180f;
        for(int j = 0; j < 3; j++)
        {
            for (int i = 0; i < 25; i++)
            {
                GameObject bullet = Instantiate(iceProjectile, transform.position, Quaternion.identity);
                float radians = Mathf.Deg2Rad * currentBulletAngle;
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                float randomSpeed = Random.Range(2.5f, 4f);
                Vector2 force = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * (randomSpeed);
                float angle = Mathf.Atan2(force.y, force.x) * Mathf.Rad2Deg + 90;
                bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                rb.AddForce(force, ForceMode2D.Impulse);
                yield return new WaitForSeconds(0.03f);

                float randomAngle = Random.Range(5f, 8f);
                currentBulletAngle += randomAngle;
            }
            yield return new WaitForSeconds(2.0f);
            currentBulletAngle = 180f;
        }
        
    }

    IEnumerator iceHeartAttack()
    {
        dragonSprite.sprite = iceDragon;
        audioManager.Play("Ice");
        float currentBulletAngle = Random.Range(-20f, -160f);

        for (int i = 0; i < 4; i++)
        {
            GameObject bullet = Instantiate(iceHeart, transform.position, Quaternion.identity);
            float radians = Mathf.Deg2Rad * currentBulletAngle;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Vector2 force = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * (4.0f);
            rb.AddForce(force, ForceMode2D.Impulse);
            yield return new WaitForSeconds(2.0f);

            float randomAngle = Random.Range(-20f, -160f);
            currentBulletAngle = randomAngle;
        }
    }

    IEnumerator lightningAttack()
    {
        dragonSprite.sprite = lightningDragon;
        audioManager.Play("Lightning");
        float currentBulletAngle = -90f;
        float randomX = -8.5f;
        float randomY = 2.2f;
        for(int j = 0; j < 7; j++)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector2 randomCoord = new Vector2(randomX, randomY);
                GameObject bullet = Instantiate(lightningProjectile, randomCoord, Quaternion.identity);
                float radians = Mathf.Deg2Rad * currentBulletAngle;
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                Vector2 force = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * (7.0f);
                rb.AddForce(force, ForceMode2D.Impulse);
                randomX += 0.5f;
                
            }
            yield return new WaitForSeconds(0.5f);
            randomX += 1.0f;
        }
        randomX = -8.0f;
        randomY = 2.0f;
        currentBulletAngle = 0f;

        for (int j = 0; j < 4; j++)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector2 randomCoord = new Vector2(randomX, randomY);
                GameObject bullet = Instantiate(lightningProjectile, randomCoord, Quaternion.identity);
                float radians = Mathf.Deg2Rad * currentBulletAngle;
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                Vector2 force = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * (7.0f);
                float angle = Mathf.Atan2(force.y, force.x) * Mathf.Rad2Deg + 90;
                bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                rb.AddForce(force, ForceMode2D.Impulse);
                randomY -= 0.3f;

            }
            yield return new WaitForSeconds(0.5f);
            randomY -= 1.0f;
        }
    }

    IEnumerator lightningAttack2()
    {
        dragonSprite.sprite = lightningDragon;
        audioManager.Play("Lightning");
        float currentBulletAngle = -20f;
        float coordX = -8.2f;
        float coordY = 2.2f;
        for (int i = 0; i < 20; i++)
        {
            Vector2 randomCoord = new Vector2(coordX, coordY);
            GameObject bullet = Instantiate(lightningProjectile, randomCoord, Quaternion.identity);
            float radians = Mathf.Deg2Rad * currentBulletAngle;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Vector2 force = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * (7.0f);
            float angle = Mathf.Atan2(force.y, force.x) * Mathf.Rad2Deg + 90;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            rb.AddForce(force, ForceMode2D.Impulse);

            Vector2 randomCoord1 = new Vector2(8.2f, 2.2f);
            GameObject bullet1 = Instantiate(lightningProjectile, randomCoord1, Quaternion.identity);
            float radians1 = Mathf.Deg2Rad * -160f;
            Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
            Vector2 force1 = new Vector2(Mathf.Cos(radians1), Mathf.Sin(radians1)) * (7.0f);
            float angle1 = Mathf.Atan2(force1.y, force1.x) * Mathf.Rad2Deg + 90;
            bullet1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle1));
            rb1.AddForce(force1, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.2f);

        }

    }




}
