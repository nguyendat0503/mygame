using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PenguinControl : MonoBehaviour
{
    public float score;
    public static PenguinControl instance;

    public float bounceForce;
    public float red, bubble, missile,power=1,HP=10;

    private Rigidbody2D myBody;
    private Animator anim;

    private bool Alive;
    private bool DidFlap;
    private bool Shoot = true;
    private bool canShoot;

    public float flag = 0;

    [SerializeField]
    private GameObject Redball, BlueBullet, BubbleBullet,Missile,Pause,PauseButton,ScoreShow,Lazer2,Lazer3,Lazer4,Lazer5,Lazer6,Lazer7;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip GetCoin,Hit;

    private void Awake()
    {
        Alive = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        MakeInstance();
    }
    private void Start()
    {
        myBody.centerOfMass = Vector3.zero;
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (flag == 0)
        {
            PenguinMovement();
        }
    }
    private void Update()
    {
        if (power < 1)
        {
            power = 1;
        }
        if (HP < 1)
        {
            myBody.constraints = RigidbodyConstraints2D.None;
            PenguinMove();
            flag = 1;
            if (Alive == true)
            {
                Alive = false;
                anim.SetTrigger("Die");
                audioSource.PlayOneShot(Hit);
            }
            Pause.SetActive(false);
            PauseButton.SetActive(false);
            ScoreShow.SetActive(false);
            if (Level1Control.instance != null)
            {
                Level1Control.instance.GameOverPanel(score);
            }
        }
        if (Alive == true)
        {
           // score = Time.timeSinceLevelLoad;
            if (Level1Control.instance != null)
            {
                Level1Control.instance.SetScore(score);
            }
        }
        if (canShoot)
        {
            if (red > 0)
            {
                if (Shoot)
                {
                    StartCoroutine(ShootRedball());
                    red--;
                }
            }
            else if (bubble > 0)
            {
                if (Shoot)
                {
                    StartCoroutine(ShootBubbleBullet());
                    bubble--;
                }
            }
            else if (missile > 0)
            {
                if (Shoot)
                {
                    StartCoroutine(ShootMissile());
                    missile--;
                }
            }
            else
            {
                if (Shoot)
                {
                    if (power == 4)
                    {
                        StartCoroutine(ShootLazer7());
                    }
                    else if(power==3.5)
                    {
                        StartCoroutine(ShootLazer6());
                    }
                    else if (power == 3)
                    {
                        StartCoroutine(ShootLazer5());
                    }
                    else if (power == 2.5)
                    {
                        StartCoroutine(ShootLazer4());
                    }
                    else if (power == 2)
                    {
                        StartCoroutine(ShootLazer3());
                    }
                    else if (power == 1.5)
                    {
                        StartCoroutine(ShootLazer2());
                    }
                    else
                    {
                        StartCoroutine(ShootBlueBullet());
                    }
                }
            }
        }
    }
    IEnumerator ShootBlueBullet()
    {
        Shoot = false;
        Vector3 temp = transform.position;
        temp.x += 0.3f;
        temp.y += 0.25f;
        Instantiate(BlueBullet, temp, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Shoot = true;
    }
    IEnumerator ShootLazer2()
    {
        Shoot = false;
        Vector3 temp = transform.position;
        temp.x += 0.3f;
        temp.y += 0.25f;
        Instantiate(Lazer2, temp, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Shoot = true;
    }
    IEnumerator ShootLazer3()
    {
        Shoot = false;
        Vector3 temp = transform.position;
        temp.x += 0.3f;
        temp.y += 0.25f;
        Instantiate(Lazer3, temp, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Shoot = true;
    }
    IEnumerator ShootLazer4()
    {
        Shoot = false;
        Vector3 temp = transform.position;
        temp.x += 0.3f;
        temp.y += 0.25f;
        Instantiate(Lazer4, temp, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Shoot = true;
    }
    IEnumerator ShootLazer5()
    {
        Shoot = false;
        Vector3 temp = transform.position;
        temp.x += 0.3f;
        temp.y += 0.25f;
        Instantiate(Lazer5, temp, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Shoot = true;
    }
    IEnumerator ShootLazer6()
    {
        Shoot = false;
        Vector3 temp = transform.position;
        temp.x += 0.3f;
        temp.y += 0.25f;
        Instantiate(Lazer6, temp, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Shoot = true;
    }
    IEnumerator ShootLazer7()
    {
        Shoot = false;
        Vector3 temp = transform.position;
        temp.x += 0.3f;
        temp.y += 0.25f;
        Instantiate(Lazer7, temp, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Shoot = true;
    }
    IEnumerator ShootRedball()
    {
        Shoot = false;
        Vector3 temp = transform.position;
        temp.x += 0.3f;
        temp.y += 0.25f;
        Instantiate(Redball, temp, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Shoot = true;
    }
    IEnumerator ShootBubbleBullet()
    {
        Shoot = false;
        Vector3 temp = transform.position;
        temp.x += 0.8f;
        temp.y += 0.25f;
        Instantiate(BubbleBullet, temp, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        Shoot = true;
    }
    IEnumerator ShootMissile()
    {
        Shoot = false;
        Vector3 temp = transform.position;
        temp.x += 0.3f;
        temp.y += 0.25f;
        Instantiate(Missile, temp, Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Shoot = true;
    }
    void PenguinMove()
    {
        Vector3 temp = transform.position;
        temp.x -= 2 * Time.deltaTime;
        transform.position = temp;
    }
    void PenguinMovement()
    {
        if (Alive == true)
        {
            if (DidFlap == true)
            {
                DidFlap = false;
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
            }
        }
        if (myBody.velocity.y > 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, 90, myBody.velocity.y / 20);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
        else if (myBody.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (myBody.velocity.y < 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, -90, -myBody.velocity.y / 20);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }
    public void FlyButton()
    {
        DidFlap = true;
    }
    public void onPointerDownShootButton()
    {
        canShoot = true;
    }
    public void onPointerUpShootButton()
    {
        canShoot = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock" || collision.gameObject.tag == "Bottom")
        {
            HP -= 10;
            if (HP > 0)
            {
                audioSource.PlayOneShot(Hit);
            }
        }
        if(collision.gameObject.tag == "Cuttle")
        {
            HP -= Random.Range(2,3);
            power -= 0.5f;
            if (HP > 0)
            {
                audioSource.PlayOneShot(Hit);
            }
        }
        if (collision.gameObject.tag == "Star" || collision.gameObject.tag == "RedEnermy")
        {
            HP -= Random.Range(4,6);
            power -= 1;
            if (HP > 0)
            {
                audioSource.PlayOneShot(Hit);
            }
        }
        if (collision.gameObject.tag == "JellyFish")
        {
            HP -= Random.Range(8,10);
            power -= 1.5f;
            if (HP > 0)
            {
                audioSource.PlayOneShot(Hit);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Heart")
        {
            if(HP <= 5)
            {
                HP += 5;
                audioSource.PlayOneShot(GetCoin);
            }
            else
            {
                HP = 10;
                audioSource.PlayOneShot(GetCoin);
            }
 
        }
        if (collision.tag == "GetRedBullet")
        {
            bubble = 0;
            missile = 0;
            red = 8;
            audioSource.PlayOneShot(GetCoin);
        }
        if (collision.tag == "GetBubbleBullet")
        {
            red = 0;
            missile = 0;
            bubble = 5;
            audioSource.PlayOneShot(GetCoin);
        }
        if (collision.tag == "GetMissile")
        {
            bubble = 0;
            red = 0;
            missile = 30;
            audioSource.PlayOneShot(GetCoin);
        }
        if (collision.tag == "Coin")
        {
            score += 1;
            audioSource.PlayOneShot(GetCoin);
        }
        if (collision.tag == "BigCoin")
        {
            score += 3;
            audioSource.PlayOneShot(GetCoin);
        }
        if (collision.tag == "PowerUp")
        {
            if (power < 4)
            {
                power += 0.5f;
            }
            audioSource.PlayOneShot(GetCoin);
        }
    }
}
