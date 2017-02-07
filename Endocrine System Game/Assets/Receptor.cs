using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptor : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public Sprite unbound;
    public Sprite bound;



    public char receptorType;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = unbound;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void bindToLigand() {
        spriteRenderer.sprite = bound;
    }
}
