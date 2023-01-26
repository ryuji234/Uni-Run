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
        // ������
        //GF.Assert(playerRigid != null || playerRigid != default);        // ��������� ������ �߻�
        //GF.Assert(playerAni != null || playerAni != default);            // ��������� ������ �߻�
        //GF.Assert(playerAudio!= null || playerAudio != default);         // ��������� ������ �߻�
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
    // Ʈ���� �⵹ ���� ó���� ���� �Լ�
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DeadZone" && !isDead)
        {
            Die();
        }
    }

    //! �ٴڿ� ��Ҵ��� üũ�ϴ� �Լ� 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > PLAYER_STEP_ON_Y_POS)
        {
            isGrounded= true;
            jumpCount = 0;
        }
    }

    //! �ٴڿ��� ������� üũ�ϴ� �Լ�
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
