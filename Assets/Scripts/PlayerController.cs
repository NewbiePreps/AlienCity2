using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class PlayerController : MonoBehaviour {

	
	private Animator anim;
	private Rigidbody2D rb2d;

	public Transform posPe;
	[HideInInspector] public bool tocaChao = false;
    [HideInInspector] public bool jump;


	public float Velocidade;
	public float ForcaPulo = 1000f;
	[HideInInspector] public bool viradoDireita = true;

	public Image vida;
	private MensagemControle MC;

    private float shootingRate = 0.1f;
    private float shootCooldown = 0f;
    public Transform spawnBullet;
    
    //armas ativas
    public static string activeWeaponType;
    public List<GameObject> hudWeapons;
    int activeGunIndex;
    public List<GameObject> bulletType;

    void Start () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
        //GameObject mensagemControleObject = GameObject.FindWithTag ("MensagemControle");
        //if (mensagemControleObject != null) {
        //MC = mensagemControleObject.GetComponent<MensagemControle> ();
        SetWeapon(0);

    }

    private void SetWeapon(int v)
    {
        activeGunIndex = v;
        for (int i = 0; i < hudWeapons.Count; i++)
        {
            hudWeapons[i].SetActive(false);
        }
        hudWeapons[activeGunIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update () {
         
        tocaChao = Physics2D.Linecast(transform.position, posPe.position, 1 << LayerMask.NameToLayer("chao"));

        if (Input.GetKeyDown("space") && tocaChao){
            jump = true;
        }
        if (Input.GetKeyDown("1"))
        {
            SetWeapon(0);
        }
        else if (Input.GetKeyDown("2"))
        {
            SetWeapon(1);
        }

    }

    //public GameObject GetActiveWeapon()
    //{
    //    return activeGun;
    //}


    void FixedUpdate()
	{
		float translationY = 0;
		float translationX = Input.GetAxis ("Horizontal") * Velocidade;
		transform.Translate (translationX, translationY, 0);
		transform.Rotate (0, 0, 0);
		if (translationX != 0 && tocaChao) {
			anim.SetTrigger ("corre");
		} else {
			anim.SetTrigger("parado");
		}

        //Programar o pulo Aqui! 
        if (jump){
            anim.SetTrigger("pula");
                rb2d.AddForce(new Vector2(0f, ForcaPulo));
                jump = false;
            }
		if (translationX > 0 && !viradoDireita) {
			Flip ();
		} else if (translationX < 0 && viradoDireita) {
			Flip();
		}
        //programação do tiro
        if (shootCooldown > 0)
            shootCooldown -= Time.deltaTime;
        //programação da animação atirando
        if (Input.GetButtonDown ("Fire1"))
        {
            
            Fire();
            shootCooldown = shootingRate;
        }

	}
    // instanciação do tiro
    void Fire()
    {
        if (shootCooldown <= 0f)
        {
            var cloneBullet = Instantiate (bulletType [activeGunIndex], spawnBullet.position, Quaternion.identity) as GameObject;
            cloneBullet.transform.localScale = this.transform.localScale;

            cloneBullet.GetComponent<BaseBullet>().Fire(transform.localScale.x > 0 ? 1 : -1);
            
            anim.SetTrigger("fire");
        }



    }
    void Flip()
	{
		viradoDireita = !viradoDireita;
		Vector3 escala = transform.localScale;
		escala.x *= -1;
		transform.localScale = escala;
	}

	public void SubtraiVida()
	{
		vida.fillAmount-=0.1f;
		if (vida.fillAmount <= 0) {
			MC.GameOver();
			Destroy(gameObject);
		}
	}
	
}
