using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KrakenBehaviour : MonoBehaviour
{
    public GameObject soulEffect;

    bool cinematic = false;

    public float shotDelay = 3.0f;
    public GameObject tint;
    public Transform shootLocationRight;
    public Transform shootLocationLeft;
    public Transform shootLocationMiddle;
    public Transform shootLocationTop;
    private bool canShoot = false;
    private Animator anim;

    private float delayHit = 0.0f;
    private bool hit = false;
    private bool changedImage = false;
    public GameObject healthBar;
    public GameObject imageKraken;
    public Sprite[] images;

    public bool alive = true;
    public int healthPoints = 100;

    private bool endGame = false;
    private float timeToEndGame = 0f;
    // Start is called before the first frame update
    void Start()
    {
        soulEffect.SetActive(false);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cinematic)
        {
            transform.Translate(0.0f, 4.0f * Time.deltaTime, 0.0f);
            if (transform.position.y >= -90.0f)
            {
                cinematic = false;
                canShoot = true;
            }
        }
        else if (!cinematic && canShoot)
        {
            shotDelay -= Time.deltaTime;

            if (shotDelay <= 0.0f && alive)
            {
                ShootTint();
                if (healthPoints > 75)
                {
                    shotDelay = 2.5f;
                }
                else if (healthPoints > 50)
                {
                    shotDelay = 1.5f;

                }
                else if (healthPoints > 25)
                {
                    shotDelay = 1.0f;

                }
                else
                {
                    shotDelay = 1.0f;
                }
            }


            if (hit && changedImage == false)
            {
                imageKraken.GetComponent<Image>().sprite = images[1];
                delayHit = 0.1f;
                changedImage = true;
            }

            if (changedImage)
            {

                delayHit -= 0.25f * Time.deltaTime;
            }

            if (delayHit <= 0.0f)
            {
                hit = false;
                changedImage = false;
                imageKraken.GetComponent<Image>().sprite = images[0];
            }

            if (endGame == true)
                timeToEndGame += Time.deltaTime;

            if (timeToEndGame >= 5f)
                SceneManager.LoadScene(4);
        }
    }

    public void ShootTint()
    {
        int number = Random.Range(1, 5);
        string attack = "Attack_" + number;
        anim.SetTrigger(attack);

        if (number == 1 || number == 2)
        {
            Instantiate(tint, shootLocationLeft.position, shootLocationLeft.rotation);

        }
        else if (number == 3)
        {
            Instantiate(tint, shootLocationRight.position, shootLocationRight.rotation);
        }
        else if (number == 4)
        {
            Instantiate(tint, shootLocationMiddle.position, shootLocationMiddle.rotation);
        }
        else
        {
            Instantiate(tint, shootLocationTop.position, shootLocationTop.rotation);
        }

        
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cannon")
        {
            healthPoints -= 1;

            Vector2 curr = healthBar.GetComponent<RectTransform>().sizeDelta;
            float newHpWidth = healthPoints * 285.0f / 100.0f;

            healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(newHpWidth, curr.y);

            hit = true;
            if (healthPoints <= 0)
            {
                Die();
            }
        }

        if (other.gameObject.tag == "Electric")
        {
            healthPoints -= 25;

            Vector2 curr = healthBar.GetComponent<RectTransform>().sizeDelta;
            float newHpWidth = healthPoints * 285.0f / 100.0f;

            healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(newHpWidth, curr.y);

            hit = true;
            if (healthPoints <= 0)
            {
                Die();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       
    }

    private void Die()
    {
        alive = false;
        this.GetComponent<Collider>().enabled = false;
        anim.SetTrigger("Die");
        soulEffect.SetActive(true);
        soulEffect.GetComponent<ParticleSystem>().Play();

        endGame = true;
    }

    public void Cinematic()
    {
        anim.SetTrigger("Intimidate_3");
        cinematic = true;
    }
}
