using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class PlayerMovement : MonoBehaviour
{

    public  AudioMixer audioMix;
    public CanvasGroup optionsMenu, playerUI;
    public AudioSource jumpSound;

    // component variables
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    [SerializeField]
    private float
        horizontal,
        speed = 8f,
        jumpingPower = 16f;

    private bool isFacingRight = true;

    private Animator anim;

    private void Awake()
    {
        UnPause();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if(!isFacingRight && horizontal > 0f)
        {
            Flip();
        }else if(isFacingRight && horizontal < 0f)
        {
            Flip();
        }
        if(horizontal != 0f)
        {
            anim.SetBool("isMoving", true);
        }else
        {
            anim.SetBool("isMoving", false);
        }
        if (IsGrounded())
        {
            anim.SetBool("isGrounded", true);
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
        else
        {
            anim.SetBool("isGrounded", false);
        }
        if(rb.velocity.y > 2f)
        {
            anim.SetBool("isJumping",true);
            anim.SetBool("isFalling", false);
        }else if(rb.velocity.y < -2f)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && IsGrounded())
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if(context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    public void Quit(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            //pasue game
            pauseGame();

        }
    }

    void pauseGame()
    {

        Time.timeScale = 0;

        playerUI.alpha = 0;
        playerUI.interactable = false;
        playerUI.blocksRaycasts = false;

        optionsMenu.alpha = 1;
        optionsMenu.interactable = true;
        optionsMenu.blocksRaycasts = true;
    }

    public void UnPause()
    {

        Time.timeScale = 1;

        playerUI.alpha = 1;
        playerUI.interactable = false;
        playerUI.blocksRaycasts = false;

        optionsMenu.alpha = 0;
        optionsMenu.interactable = false;
        optionsMenu.blocksRaycasts = false;
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;



    }
}
