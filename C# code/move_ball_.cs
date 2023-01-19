using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

/// <summary>
/// this code deals with the all sorts of ball movements and it also deals with the ui management of score
/// coordinates in unity are always taken from geometric center of gameobject
/// </summary>

public class move_ball_ : MonoBehaviour
{
    private float ball_deviation;
    private float ball_speed_y = 4;
    private float ball_speed_x=-1;
    private float player_bar_x_cord;
    private float cpu_bar_y_cord;
    private float player_bar_y_cord;
    private float ball_x_cord;
    private float ball_y_cord;


    public float pla_num_ball_ret_suc;  // static is used to make it a global variable so it can be accessed in any script






    public Rigidbody2D ball;

    // this is for ui management//
    [SerializeField] private int player_score;
    [SerializeField] private int cpu_score;
    [SerializeField] private TMP_Text player_score_text;
    [SerializeField] private TMP_Text cpu_score_text;
  
    void Start()
    {
        pla_num_ball_ret_suc = 1;

        player_score = 0;
        cpu_score = 0;
        ball_deviation = 8;


        ball = GetComponent<Rigidbody2D>();
        
    }
    void FixedUpdate()
    {
        
        Inc_ball_speed();
        
        
        
    }

    private void Update()
    {
        ball.velocity = new Vector3(ball_speed_x , ball_speed_y  , 0);
       // Inc_ball_speed();
        Reset_ball_y_cord();

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "cpu_bar") // when ball collides with cpu_bar its velocity is reversed
        {
            ball_speed_y = -ball_speed_y;

        }
        if (col.gameObject.name == "player_bar")// when ball collides with player_bar its velocity is reversed and also depending on where it 
            // collides with player_bar some x_velocity is given to the ball no such provision is done for cpu bar.
        {
            pla_num_ball_ret_suc++;
            player_bar_x_cord = GameObject.Find("player_bar").transform.position.x;
            ball_x_cord = ball.transform.position.x;

            ball_speed_x = (ball_x_cord / player_bar_x_cord);
            if (ball_speed_x < 0)
            {
                ball_speed_x = -(ball_x_cord / player_bar_x_cord) * (ball_x_cord - player_bar_x_cord) * ball_deviation;

            }
            else
                ball_speed_x = (ball_x_cord / player_bar_x_cord) * (ball_x_cord - player_bar_x_cord) * ball_deviation;
            ball_speed_y = -ball_speed_y;

        }
        if (col.gameObject.name == "lb") // x velocity of ball is reversed on left boundry collision
        {
            ball_speed_x = -ball_speed_x;

        }
        if (col.gameObject.name == "rb")// x velocity of ball is reversed on left boundry collision
        {
            ball_speed_x = -ball_speed_x;

        }



    }




    // this part of code detects when the object goes out of game window and resets ballcordinates to 0,0,0 but
    //with same velocities in x and y direction
    // this piece of code is also responsible for ui score management using TMP.

    private void Inc_ball_speed()
    {
        if (pla_num_ball_ret_suc % 4 == 0)
        {
            ball_speed_y = ball_speed_y + 0.5f;
            pla_num_ball_ret_suc = 1;

        }

    }



    private void Reset_ball_y_cord()
    {
        ball_y_cord = GameObject.Find("Ball").transform.position.y;
        cpu_bar_y_cord = GameObject.Find("cpu_bar").transform.position.y;
        player_bar_y_cord = GameObject.Find("player_bar").transform.position.y;

        if (ball_y_cord > cpu_bar_y_cord+5) // when ball goes beyond cpu_bar
        {
            ball.transform.position = new Vector3(0, 0, 0); //resets ball transform to 0,0,0
            ball_speed_x = 0;
            player_score++;                                 // adds one to player_score integer
            player_score_text.text =player_score.ToString(); // converts player score integer to a string
        }

        if (ball_y_cord < player_bar_y_cord - 5)// when ball goes beyond player bar
        {
            ball.transform.position = new Vector3(0, 0, 0);//resets ball transform to 0,0,0
            ball_speed_x = 0;
            cpu_score++;                                   // adds one to player_score integer
            cpu_score_text.text =cpu_score.ToString();     // converts player score integer to a string
        }
    }

     


}
