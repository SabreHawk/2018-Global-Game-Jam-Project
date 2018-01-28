using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationDistributerController : MonoBehaviour {

    public int isMsg;
    public GameObject messageCubeObject;
    public int distribute_rate;
    public int distribute_interval;
    public int dis_message_counter;
    public List<Transform> distribute_target_planet;
    public float Timer;
    public float Counter;

    public Color infoColor;
    public Color postiveColor;
    public Color negativeColor;
    // Use this for initialization
    void Start () {
        Timer = 0;
        Counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;
        for(int i =0;i < distribute_target_planet.Count;++i) {
            DistributeMessage(distribute_target_planet[i]);
        }
    }
    public void AddTargetPlanet(Transform _transform) {
        distribute_target_planet.Add(_transform);
    }
    public void DistributeMessage(Transform _target_planet) {
        if (Timer > distribute_interval) {
            if(Counter >= dis_message_counter && this.GetComponentInParent<PlanetController>().message_num > 0) {
                GameObject temp_object = GameObject.Instantiate(messageCubeObject, this.transform.position, Quaternion.identity);
                temp_object.GetComponent<Rigidbody2D>().velocity = (_target_planet.position - this.transform.position).normalized * distribute_rate;
                temp_object.GetComponent<MessageCubeController>().isInfo = true;
                if(this.GetComponent<PlanetController>() == null) {
                    if (this.GetComponent<MainPlanetController>().postive_message_num > 0) {
                        temp_object.GetComponent<MessageCubeController>().isPostive = true;
                        temp_object.GetComponent<MessageCubeController>().targetColor = postiveColor;
                    } else if (this.GetComponent<MainPlanetController>().negative_message_num > 0) {
                        temp_object.GetComponent<MessageCubeController>().isPostive = false;
                        temp_object.GetComponent<MessageCubeController>().targetColor = negativeColor;
                    }
                } else {
                    if (this.GetComponent<PlanetController>().postive_message_num > 0) {
                        temp_object.GetComponent<MessageCubeController>().isPostive = true;
                        temp_object.GetComponent<MessageCubeController>().targetColor = postiveColor;
                    } else if (this.GetComponent<PlanetController>().negative_message_num > 0) {
                        temp_object.GetComponent<MessageCubeController>().isPostive = false;
                        temp_object.GetComponent<MessageCubeController>().targetColor = negativeColor;
                    }
                }


                this.GetComponentInParent<PlanetController>().message_num--;
                Timer = 0;
                Counter = 0;
            } else {
                GameObject temp_object = GameObject.Instantiate(messageCubeObject, this.transform.position, Quaternion.identity);
                temp_object.GetComponent<Rigidbody2D>().velocity = (_target_planet.position - this.transform.position).normalized * distribute_rate;
                Timer = 0;
                Counter ++;
            }

        }
    }


//
}
