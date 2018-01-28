using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCircleMain : MonoBehaviour {
    public GameObject message_ball;
    public List<GameObject> message_ball_list;

    public float rotate_velocity;
    public float rotate_radius;
    public int active_ball_num;
    public Color hiden_color;
    public Color postive_color;
    public Color negative_color;
    public int postive_ball_num;
    public int negative_ball_num;
    // Use this for initialization
    void Start () {
        rotate_velocity = ValueTablet.mc_rotate_velocity;
       // rotate_radius = ValueTablet.mc_rotate_radius;
        active_ball_num = ValueTablet.mc_active_ball_num;
        hiden_color = ValueTablet.mc_hiden_color;
        postive_color = message_ball.GetComponent<SpriteRenderer>().color;
    }
	
	// Update is called once per frame
	void Update () {
        rotate_center();
        update_message_circle_color();
        this.active_ball_num = this.GetComponentInParent<MainPlanetController>().message_num;
        this.postive_ball_num = this.GetComponentInParent<MainPlanetController>().postive_message_num;
        this.negative_ball_num = this.GetComponentInParent<MainPlanetController>().negative_message_num;

    }

    public void init_message_ball(int _ball_num) {
        Vector3 center_pos = this.transform.position;
        float temp_angle = Mathf.PI * 2 / _ball_num;
        float temp_x, temp_y;
        for (int i = 0;i < _ball_num;++i) {
            temp_y = center_pos.y + rotate_radius * Mathf.Cos(i * temp_angle);
            temp_x = center_pos.x + rotate_radius * Mathf.Sin(i * temp_angle);
            GameObject temp_ball = GameObject.Instantiate(message_ball, new Vector3(temp_x,temp_y,0), Quaternion.identity);
            temp_ball.GetComponent<SpriteRenderer>().color = ValueTablet.mc_hiden_color;
            temp_ball.transform.SetParent(this.transform);
            message_ball_list.Add(temp_ball);
        }
    }
    public void rotate_center() {
        this.transform.Rotate(Random.Range(1,1.5f)*rotate_velocity * Time.deltaTime * new Vector3(0,0,1));
    }
    public void update_message_circle_color() {
        if (active_ball_num > message_ball_list.Count) {
            return;
        }
        for (int i = 0; i < postive_ball_num; ++i) {
            message_ball_list[i].GetComponent<SpriteRenderer>().color = postive_color;
        }
        for (int i = postive_ball_num; i < postive_ball_num + negative_ball_num; ++i) {
            message_ball_list[i].GetComponent<SpriteRenderer>().color = negative_color;
        }
        for (int i = active_ball_num; i < message_ball_list.Count; ++i) {
            message_ball_list[i].GetComponent<SpriteRenderer>().color = hiden_color;
        }
    }
}
