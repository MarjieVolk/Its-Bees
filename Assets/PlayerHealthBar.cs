using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour {

    [SerializeField] private HasHealth player;
    private float startWidth;
    private Transform healthBarHolder;
    private TextMesh healthText;

    SpriteRenderer renderer;

    // Use this for initialization
    void Start () {
        healthBarHolder = transform.GetChild(0);
        healthText = transform.GetChild(1).gameObject.GetComponent<TextMesh>();
        startWidth = healthBarHolder.localScale.x;
        renderer = healthBarHolder.GetChild(0).GetComponent<SpriteRenderer>();
        renderer.color = Color.green;
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthBarHolder.localScale = 
            new Vector3(player.health / player.maxHealth * startWidth, healthBarHolder.localScale.y);
        healthText.text = player.health + " / " + player.maxHealth;
	}
}
