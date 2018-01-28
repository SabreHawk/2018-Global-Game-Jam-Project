using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffButtonController : MonoBehaviour {

    void OnMouseDown() {
        GameManager.game_manger.isButtonSelected[0] = true;
    }
}
