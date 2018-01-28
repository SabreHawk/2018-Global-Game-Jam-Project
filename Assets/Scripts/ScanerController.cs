using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanerController : MonoBehaviour {

    public float rotate_rate;
    public Color initialColor;
    public Color hideColor;
    public Color targetColor;
    public bool isActive;
	// Use this for initialization
	void Start () {
        initialColor = this.GetComponent<SpriteRenderer>().color;
        isActive = false;
	}

    // Update is called once per frame
    void Update() {
        this.transform.Rotate(new Vector3(0, 0, 1), rotate_rate);
        isActive = this.GetComponentInParent<InformationCollectorController>().isActive;
        this.GetComponent<SpriteRenderer>().color = Color.Lerp(this.GetComponent<SpriteRenderer>().color, targetColor, 0.2f);
        if (isActive) {
            targetColor = initialColor;
        } else {
            targetColor = hideColor;
        }
 
	}
 
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Star" && isActive) {
            if (collision.GetComponent<StarController>().status == 1) {
                if (this.GetComponentInParent<PlanetController>() == null) {
                    this.GetComponentInParent<MainPlanetController>().postive_message_num++;
                    this.GetComponentInParent<MainPlanetController>().message_num++;
                } else {
                    this.GetComponentInParent<PlanetController>().postive_message_num++;
                    this.GetComponentInParent<PlanetController>().message_num++;
                }

               
            }
            if(collision.GetComponent<StarController>().status == 2) {
                if (this.GetComponentInParent<PlanetController>() == null) {
                    this.GetComponentInParent<MainPlanetController>().negative_message_num++;
                    this.GetComponentInParent<MainPlanetController>().message_num++;
                } else {
                    this.GetComponentInParent<PlanetController>().negative_message_num++;
                    this.GetComponentInParent<PlanetController>().message_num++;
                }
            }
            collision.GetComponent<StarController>().status = 0;
        }
    }
}
