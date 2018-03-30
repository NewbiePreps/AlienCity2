using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleTiro : MonoBehaviour {
    public AudioClip[] sounds;
    private Vector2 speed = new Vector2(1500, 0);
    private Rigidbody2D rbBullet;
    private Animator anim;
    private AudioSource audioSource;
   

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();

        rbBullet = GetComponent<Rigidbody2D>();
        speed = speed * transform.localScale.x;
        rbBullet.AddForce(speed, ForceMode2D.Force);
        Destroy (gameObject, 10f);

        Physics2D.IgnoreLayerCollision(9, 9);
        // selecionar randomicamnte som da lista de 20 itens
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sounds[Random.Range(0, sounds.Length)];
        audioSource.Play();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col) {

        anim.SetTrigger("explode");
        rbBullet.AddForce(-speed, ForceMode2D.Force);
        Invoke("Destroy", 0.2f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
   
    
}
