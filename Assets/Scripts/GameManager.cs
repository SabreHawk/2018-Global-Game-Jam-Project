using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    static public GameManager game_manger;
    public MainPlanetController main_planet;
    public List<PlanetController> planet_list;
    //UI
    public bool isPanelDisp;
    //Buttons
    public GameObject staffButton;
    public GameObject collectorButton;
    public GameObject lineButton;
    public bool[] isButtonSelected = new bool[3];
    public Transform temp_line_tramsform;
    //Attributes
    public int funds_value;
    public int staff_num;
    public int total_message_num;

    private void Awake() {
        game_manger = this;
    }
    // Use this for initialization
    void Start() {
        funds_value = ValueTablet.gm_funds_value;
        staff_num = ValueTablet.gm_staff_num;
        total_message_num = ValueTablet.gm_total_message_num;
    }

    // Update is called once per frame
    void Update() {
     //   InputDetection();
        if (isPanelDisp) {
            showMainPlanetPanel();
        } else {
            hideMainPlanetPanel();
        }
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

    void showMainPlanetPanel() {
        staffButton.SetActive(true);
        collectorButton.SetActive(true);
        lineButton.SetActive(true);

    }
    void hideMainPlanetPanel() {
        staffButton.SetActive(false);
        collectorButton.SetActive(false);
        lineButton.SetActive(false);
    }
    public void resetButtons() {
        for (int i = 0; i < 3; ++i) {
            isButtonSelected[i] = false;
        }
    }
}
