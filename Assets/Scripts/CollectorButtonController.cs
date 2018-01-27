using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorButtonController : MonoBehaviour {

    void OnMouseDown() {
        GameManager.game_manger.isButtonSelected[1] = true;
    }
}
