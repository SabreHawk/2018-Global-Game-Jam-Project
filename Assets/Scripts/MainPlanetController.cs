using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlanetController : MonoBehaviour {

    public MessageCircleMain message_circle_main;

    public int message_num;
    public int max_message_num;

    public bool isPanelDisp;
    // Use this for initialization
    void Start () {
        message_num = ValueTablet.p_message_num;
        max_message_num = ValueTablet.p_max_message_num;
        message_circle_main = this.GetComponentInChildren<MessageCircleMain>();
        message_circle_main.init_message_ball(max_message_num);
        isPanelDisp = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showPanel() {
        print("PANEL");
    }
    void OnMouseDown() {
        GameManager.game_manger.isPanelDisp = !GameManager.game_manger.isPanelDisp;
    }
}
