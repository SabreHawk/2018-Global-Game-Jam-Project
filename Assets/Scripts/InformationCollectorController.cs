using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationCollectorController : MonoBehaviour {

    public bool isActive;
    public int planet_index;
    public float rotate_velocity;
    public SpriteRenderer _sprite;
    public Color initialColor;
    public Color hidenColor;
    public Color targetColor;
    public float trans_velocity;
	// Use this for initialization
	void Start () {
        isActive = false;
        rotate_velocity = ValueTablet.ic_rotate_velocity;
        trans_velocity = ValueTablet.ic_trans_velocity;
        _sprite = this.GetComponentInChildren<SpriteRenderer>();
        initialColor = _sprite.color;
        _sprite.color = hidenColor;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isActive) {
            targetColor = hidenColor;
        } else {
            targetColor = initialColor;
        }
        rotateCenter();
        _sprite.color = Color.Lerp(_sprite.color, targetColor, trans_velocity);
    }

    private void rotateCenter() {
        this.transform.Rotate(rotate_velocity * Random.Range(0.8f,1.5f)* Time.deltaTime * new Vector3(0, 0, 1));

    }
}
