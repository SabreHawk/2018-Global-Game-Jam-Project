using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    static public GameManager game_manger;
    public MainPlanetController main_planet;
    public Text fundText;
    public Text staffText;
    public Text ScoreText;
    //UI
    public bool isPanelDisp;
    //Buttons
    public bool[] isButtonSelected = new bool[3];
    public Transform temp_line_tramsform;
    //Attributes
    public int funds_value;
    public int staff_num;
    public int total_message_num;
    public int score;
    private void Awake() {
        game_manger = this;
    }
    // Use this for initialization
    void Start() {
        funds_value = ValueTablet.gm_funds_value;
        staff_num = ValueTablet.gm_staff_num;
        total_message_num = ValueTablet.gm_total_message_num;
        score = 0;
    }

    // Update is called once per frame
    void Update() {
        fundText.text = funds_value.ToString();
        staffText.text = staff_num.ToString();
        ScoreText.text = score.ToString();
    }

    void InputDetection() {
        if (Input.GetMouseButtonDown(0)) {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(myRay.origin.x, myRay.origin.y), Vector2.down);
            if (hit.transform == main_planet.GetComponent<Transform>()) {
                isPanelDisp = !isPanelDisp;
                resetButtons();
            }

        }
    }

    //void renderLines() {
    //    int temp_num = planetConnectionTransformList.Count - planetConnectionTransformList.Count % 2;
    //    planetLineRender.positionCount = temp_num;
    //    for (int i = 0;i < temp_num;++i) {
    //        print(i);
    //        planetLineRender.SetPosition(i/2, planetConnectionTransformList[i].position);
    //    }
    //    planetLineRender.positionCount = 2;
    //    planetLineRender.SetPosition(0, new Vector3(1, 1, 0));
    //    planetLineRender.SetPosition(0, new Vector3(5, 5, 0));
    //    planetLineRender.SetPosition(1, new Vector3(11, -11, 0));
    //    planetLineRender.SetPosition(1, new Vector3(15, 15, 0));
    //}


    public void resetButtons() {
        for (int i = 0; i < 3; ++i) {
            isButtonSelected[i] = false;
        }
    }
    public void selectStaffButton() {
        this.isButtonSelected[0] = true;
    }
    public void selectCollectorButton() {
        this.isButtonSelected[1] = true;
    }
    public void selectLineButton() {
        this.isButtonSelected[2] = true;
    }
}
