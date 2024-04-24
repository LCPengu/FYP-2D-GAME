using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.IO;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    private GrappleHook hook;



    [SerializeField] private LayerMask jumpableGround;

    private float dirX;
    StreamReader sr;
    StreamWriter sw;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    private Recorder recorder;


    private enum MovementState { Idle, Running, Jumping, Falling };
  

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        hook = GetComponent<GrappleHook>();
        recorder = GetComponent<Recorder>();
        //SetRecording();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
        //RecordPlayerPosition(rb.position, sw);
    }

    private void FixedUpdate()
    {
        if (!hook.retracting)
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void LateUpdate()
    {
        //ReplayData data = new ReplayData(this.transform.position);
        //recorder.RecordReplayFrame(data);
    }

    private void UpdateAnimationState()
    {
        MovementState State;

        if (dirX > 0f)
        {
            State = MovementState.Running;
            sprite.flipX = false;

        }
        else if (dirX < 0f)
        {
            State = MovementState.Running;
            sprite.flipX = true;
        }
        else
        {
            State = MovementState.Idle;
        }

        if (rb.velocity.y > .1f)
        {
            State = MovementState.Jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            State = MovementState.Falling;
        }

        anim.SetInteger("State", (int)State);

    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    /*public void SetRecording()
    {
        string recording1 = "Assets/Recordings/Recording1.txt";
        string recording2 = "Assets/Recordings/Recording2.txt";
        string recording3 = "Assets/Recordings/Recording3.txt";
        string recording4 = "Assets/Recordings/Recording4.txt";
        StreamReader reader1 = new StreamReader(recording1);
        StreamReader reader2 = new StreamReader(recording2);
        StreamReader reader3 = new StreamReader(recording3);
        StreamReader reader4 = new StreamReader(recording4);
        StreamWriter writer1 = new StreamWriter(recording1, false);
        StreamWriter writer2 = new StreamWriter(recording2, false);
        StreamWriter writer3 = new StreamWriter(recording3, false);
        //StreamWriter writer4 = new StreamWriter(recording4, true);
        sw = writer1;
        writer2.Write(reader4);
        writer3.Write(reader4);
        if (reader1 == reader4)
        {
            sw = writer1;
            writer2.Write(reader4);
            writer3.Write(reader4);
            

        }
        else if(reader2 == reader4)
        {
            sw = writer2;
            writer3.Write(reader4);
            writer1.Write(reader4);
        }
        else if (reader3 == reader4)
        {
            sw = writer3;
            writer1.Write(reader4);
            writer2.Write(reader4);
        }
    }

    private void RecordPlayerPosition(Vector2 position, StreamWriter writer)
    {
            writer.WriteLine(position);
            writer.Close();
    }*/
}