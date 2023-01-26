using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float PLAYER_STEP_ON_Y_POS = 0.7f;

    public AudioClip deathSound = default;
    public float jumpForce = default;

    private int jumpCount = default;
    private bool isGrounded = false;
    private bool isDead = false;

    #region player's component
    private Rigidbody2D playerRigid = default;
    private Animator playerAni = default;
    private AudioSource playerAudio = default;
    #endregion      // Player's component
    // Start is called before the first frame update
    void Start()
    {
        playerRigid = gameObject.GetComponentMust<Rigidbody2D>();
        playerAni = gameObject.GetComponentMust<Animator>();
        playerAudio = gameObject.GetComponentMust<AudioSource>();
        // 방어로직
        //GF.Assert(playerRigid != null || playerRigid != default);        // 비어있을때 에러를 발생
        //GF.Assert(playerAni != null || playerAni != default);            // 비어있을때 에러를 발생
        //GF.Assert(playerAudio!= null || playerAudio != default);         // 비어있을때 에러를 발생
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            return;
        }
        if(Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            playerRigid.velocity = Vector2.zero;
            playerRigid.AddForce(new Vector2(0, jumpForce));

            playerAudio.Play();
        }
        else if(Input.GetMouseButtonUp(0) &&  playerRigid.velocity.y > 0) 
        {
            playerRigid.velocity = playerRigid.velocity * 0.5f;
        }

        playerAni.SetBool("Grounded", isGrounded);
    }

    //! player die
    private void Die()
    {
        playerAni.SetTrigger("Die");
        playerAudio.clip = deathSound;
        playerAudio.Play();
        playerRigid.velocity = Vector2.zero;
        isDead = true;
    }
    // 트리거 출돌 감지 처리를 위한 함수
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DeadZone" && !isDead)
        {
            Die();
        }
    }

    //! 바닥에 닿았는지 체크하는 함수 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > PLAYER_STEP_ON_Y_POS)
        {
            isGrounded= true;
            jumpCount = 0;
        }
    }

    //! 바닥에서 벗어났는지 체크하는 함수
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
