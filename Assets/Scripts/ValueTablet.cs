using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueTablet : MonoBehaviour {
    //Global values
    static public int Staff_Cost= 100;
    static public int InformationCollector_Cost = 200;
    static public int InformationDistributer_Cost = 200;
    static public int TransmissionLine_Cost = 150;
    // GameManager
    static public int gm_funds_value = 1000;
    static public int gm_staff_num = 0;
    static public int gm_total_message_num = 0;
    // Planet
    static public int p_staff_num = 1;
    static public int p_message_num = 0;
    static public int p_max_message_num = 10;

    //Information Controller
    static public float ic_rotate_velocity = 3f;
    static public float ic_rotate_radius = 2f;
    static public float ic_trans_velocity = 0.1f;
    // Infornation Distributor
    static public int id_distribute_rate = 1;

    //Message Circle 
    static public float mc_rotate_velocity = 20;
    static public int mc_active_ball_num = 2;
    static public float mc_rotate_radius = 1f;
    static public Color mc_hiden_color = new Color(0, 0, 0, 0);
    
    //Collector
}
