using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlanetController : MonoBehaviour {

    public MessageCircleMain message_circle_main;
    public int postive_message_num;
    public int negative_message_num;
    public int message_num;
    public int max_message_num;


    // Use this for initialization
    void Start () {
        message_num = ValueTablet.p_message_num;
        max_message_num = 16;
        // max_message_num = ValueTablet.p_max_message_num;
        message_circle_main = this.GetComponentInChildren<MessageCircleMain>();
        message_circle_main.init_message_ball(max_message_num);
        this.GetComponentInChildren<InformationCollectorController>().isActive = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnMouseDown() {
        AudioManager.instance.playPlanet();

        if (GameManager.game_manger.isButtonSelected[2]) {
            if (GameManager.game_manger.funds_value > ValueTablet.TransmissionLine_Cost && GameManager.game_manger.temp_line_tramsform == null) {
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
           // print("ASD");
            if (collision.GetComponent<MessageCubeController>().isOut == false) {
                collision.GetComponent<MessageCubeController>().isOut = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Message") {
            if (collision.GetComponent<MessageCubeController>().isOut) {
                if (collision.GetComponent<MessageCubeController>().isInfo) {
                    AddMessageNum();
                    if (collision.GetComponent<MessageCubeController>().isPostive) {
                        this.postive_message_num++;
                        AudioManager.instance.getScore();
                        GameManager.game_manger.score += 10;
                        GameManager.game_manger.funds_value += 30;
                    } else {
                        this.negative_message_num++;
                        AudioManager.instance.minusScore();
                        GameManager.game_manger.score -= 5;
                        GameManager.game_manger.funds_value += 15;
                    }
                }
                Destroy(collision.gameObject);
            }
        }
    }


    public void AddMessageNum() {
        if (this.message_num >= this.max_message_num) {
            return;
        }
        this.GetComponentInParent<MainPlanetController>().message_num++;

    }
}
