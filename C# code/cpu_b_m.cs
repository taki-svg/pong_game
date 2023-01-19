using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cpu_b_m : MonoBehaviour
{
    private float ball_x_cord;
    public Rigidbody2D cpu_bar;
    public float cpu_bar_speed;

    public move_ball_ a;


    void Start()
    {
        a = FindObjectOfType<move_ball_>();
        
        cpu_bar = GetComponent<Rigidbody2D>();
        cpu_bar_speed = 
        cpu_bar_speed = 0.5f;


    }

    private void Update()
    {
        Debug.Log(a.pla_num_ball_ret_suc); 


    }


    /// <summary>
    /// the code below is just for left and right movement of cpu_bar
    /// </summary>
    void FixedUpdate()
    {
        inc_bar_x_speed();






        ball_x_cord = GameObject.Find("Ball").transform.position.x;

        if(ball_x_cord > cpu_bar.transform.position.x)
        {
            cpu_bar.velocity=new Vector3(cpu_bar_speed, 0, 0);
        }
        if (ball_x_cord < cpu_bar.transform.position.x)
        {
            cpu_bar.velocity = new Vector3(-cpu_bar_speed, 0, 0);
        }

    }

   
    private void inc_bar_x_speed()
    {

        if(a.pla_num_ball_ret_suc % 4 == 0)
        {
            cpu_bar_speed = cpu_bar_speed + 0.1f;
        }

    }
    
}
