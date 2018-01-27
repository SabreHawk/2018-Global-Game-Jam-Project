using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationDistributerController : MonoBehaviour {

    public bool isActive;
    public int distribute_rate;
    public List<TransmissionLineController> distrubute_target_planet;
    public List<bool> isDistributeList;
	// Use this for initialization
	void Start () {
        isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
//
}
