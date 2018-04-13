using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour {
    public AudioClip[] sounds;
    private Vector2 speed = new Vector2(500, 0);
    private Rigidbody2D rbBullet;
    private AudioSource audioSource;
    
    // Use this for initialization
   public virtual void Awake () {
        
        rbBullet = GetComponent<Rigidbody2D>();
   }
	
	// Update is called once per frame
	public virtual void OnTriggerEnter2D (Collider2D col) {

        if(rbBullet !=null)
            rbBullet.AddForce(-speed, ForceMode2D.Force);
        Invoke("Destroy", 0.2f);
    }

    public void Fire(int direction)
    {
        speed = speed * direction;
        rbBullet.AddForce(speed, ForceMode2D.Force);
        Destroy(gameObject, 10f);

        Physics2D.IgnoreLayerCollision(9, 9);
        // selecionar randomicamnte som da lista de 20 itens
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sounds[Random.Range(0, sounds.Length)];
        audioSource.Play();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
   
    
}
