using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleSenha : MonoBehaviour {
   
    public GameObject porta;
    public GameObject sinal;
    public GameObject portaFechada;

    private bool Aberto = false;

    private MudarCor pc1;
    private MudarCor pc2;
    private MudarCor pc3;

    // Use this for initialization
    void Start () {

        GameObject pedraCorObject = GameObject.FindWithTag("pedra1");
        if (pedraCorObject != null){
            pc1 = pedraCorObject.GetComponent<MudarCor>();
        }
        pedraCorObject = GameObject.FindWithTag("pedra2");
        if (pedraCorObject != null)
        {
            pc2 = pedraCorObject.GetComponent<MudarCor>();
        }
         pedraCorObject = GameObject.FindWithTag("pedra3");
        if (pedraCorObject != null)
        {
            pc3 = pedraCorObject.GetComponent<MudarCor>();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (pc1.valPedra == 0 && pc2.valPedra == 1 && pc3.valPedra == 2 && !Aberto)
        {
            Vector3 spawnPos = new Vector3(7.32f, -3.41f, -0.5f);
            Quaternion spawnRot = Quaternion.identity;
            Instantiate(porta, spawnPos, spawnRot);

            spawnPos = new Vector3(6f, -4f, -0.5f);
            spawnRot = Quaternion.identity;
            Instantiate(sinal, spawnPos, spawnRot);

            Aberto = true;

            if (portaFechada != null)
            portaFechada.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
