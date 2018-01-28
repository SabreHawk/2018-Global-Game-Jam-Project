using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {
    public InformationCollectorController information_collector;
    public InformationDistributerController information_distributer;
    public List<int> target_planet_index_list;
    public MessageCircle message_circle;
    static public int static_planetIndex;
    public int planet_index;
    public int staff_num;
    public int postive_message_num;
    public int negative_message_num;
    public int message_num;
    public int max_message_num;
    // Use this for initialization
    void Start() {
        static_planetIndex += 1;
        planet_index = static_planetIndex;
        information_collector = this.GetComponentInChildren<InformationCollectorController>();
        information_distributer = this.GetComponent<InformationDistributerController>();
        message_circle = this.GetComponentInChildren<MessageCircle>();

        staff_num = ValueTablet.p_staff_num;
        message_num = ValueTablet.p_message_num;
        max_message_num = ValueTablet.p_max_message_num;
        message_circle.init_message_ball(max_message_num);
    }

    // Update is called once per frame
    void Update() {
    }

    void OnMouseDown() {
        AudioManager.instance.playPlanet();
        if (GameManager.game_manger.isButtonSelected[0]) {
            if (GameManager.game_manger.funds_value > ValueTablet.Staff_Cost) {
                staff_num += 1;
                GameManager.game_manger.funds_value -= ValueTablet.Staff_Cost;
            }
        }
        if (GameManager.game_manger.isButtonSelected[1]) {
            if (GameManager.game_manger.funds_value > ValueTablet.InformationCollector_Cost) {
                this.information_collector.isActive = true;
                GameManager.game_manger.funds_value -= ValueTablet.InformationCollector_Cost;
            }
        }
        if (GameManager.game_manger.isButtonSelected[2]) {
            if (GameManager.game_manger.funds_value > ValueTablet.TransmissionLine_Cost &&GameManager.game_manger.temp_line_tramsform == null) {
                GameManager.game_manger.temp_line_tramsform = this.transform;
            } else if (GameManager.game_manger.funds_value > ValueTablet.TransmissionLine_Cost && GameManager.game_manger.temp_line_tramsform != null) {
                GameManager.game_manger.temp_line_tramsform.GetComponent<InformationDistributerController>().AddTargetPlanet(this.transform);
                GameManager.game_manger.temp_line_tramsform = null;
            }
        }
        GameManager.game_manger.resetButtons();
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Message") {
            if (collision.GetComponent<MessageCubeController>().isOut == false) {
                collision.GetComponent<MessageCubeController>().isOut = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Message") {
            if (collision.GetComponent<MessageCubeController>().isOut) {
                if (collision.GetComponent<MessageCubeController>().isInfo) {
                    AddMessageNum();
                    if (collision.GetComponent<MessageCubeController>().isPostive) {
                        this.postive_message_num++;
                    } else {
                        this.negative_message_num++;
                    }
                }
                Destroy(collision.gameObject);
            } 
        }
    }

    public void AddMessageNum() {
        this.GetComponentInParent<PlanetController>().message_num++;
        if (this.GetComponentInParent<PlanetController>().message_num > this.GetComponentInParent<PlanetController>().max_message_num) {
            this.GetComponentInParent<PlanetController>().message_num = this.GetComponentInParent<PlanetController>().max_message_num;
        }
    }

}
