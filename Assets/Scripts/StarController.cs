using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

    private SpriteRenderer starRender;
    public int status;
    public int change_interval;
    public float Timer = 0;
    public float postive_rate;
    public float negative_rate;
    public float color_change_rate;
    public Color initialColor;
    public Color postiveColor;
    public Color negativeColor;
    public Color TargetColor;
	// Use this for initialization
	void Start () {
        starRender = this.GetComponent<SpriteRenderer>();
        color_change_rate = 0.5f;
        TargetColor = initialColor;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(0, 0, 1), 0.2f);
        Timer += Time.deltaTime;
        starRender.color = Color.Lerp(starRender.color, TargetColor, color_change_rate);
        if (Timer > change_interval * Random.Range(0.7f,1.4f)) {
            if (Random.Range(-4,2) > 0) {

                float flag = Random.Range(-10 * negative_rate, 10*postive_rate);
                if (flag < 0) {
                    status = 1;
                } else {
                    status = 2;
                }
            } else {
                status = 0;
            }
            Timer = 0;
        }
        if(status == 0) {
            TargetColor = initialColor;
        }else if(status == 1) {
            TargetColor = postiveColor;
        }else if(status == 2) {
            TargetColor = negativeColor;
        }
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Scaner" && collision.GetComponent<ScanerController>().isActive) {

            if(this.status == 1) {
                collision.GetComponentInParent<PlanetController>().postive_message_num++;
            }else if(this.status == 2) {
                collision.GetComponentInParent<PlanetController>().negative_message_num++;
            }

            this.status = 0;
        }
    }
}
