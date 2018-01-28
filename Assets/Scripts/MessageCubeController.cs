using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCubeController : MonoBehaviour {
    public bool isInfo;
    public bool isOut;
    public bool isPostive;
    public Color infoColor;
    public Color postiveColor;
    public Color negativeColor;
    public Color targetColor;
    public float rotate_rate;
	// Use this for initialization
	void Start () {
        isOut = false;
        targetColor = infoColor;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(0,0,1),rotate_rate);
        this.GetComponent<SpriteRenderer>().color = Color.Lerp(this.GetComponent<SpriteRenderer>().color, targetColor, 0.2f);
        if (isInfo&& isPostive) {
            targetColor = postiveColor;
        }else if(isInfo && !isPostive) {
            targetColor = negativeColor;
        }
	}
    private void OnTriggerEnter2D(Collider2D collision) {
        
    }
}
