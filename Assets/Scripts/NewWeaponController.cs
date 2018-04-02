using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewWeaponController : MonoBehaviour {
    //criação da imagem do user interface (arma)
    public Image uiArma;

	// Use this for initialization
	void Start () {
        //imagem não aparecer até ser chamada
        uiArma.gameObject.SetActive(false);


    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D other){
        //colisão com o player vai acarretar no aparecimento da armana no HUD e da destruição dela no mapa
      if (other.gameObject.CompareTag("Player")){
            uiArma.gameObject.SetActive(true);
            Destroy(gameObject); }
        
      
    }

}
