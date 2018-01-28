using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineButtonController : MonoBehaviour {

    void OnMouseDown() {
        GameManager.game_manger.isButtonSelected[2] = true;
    }
}
