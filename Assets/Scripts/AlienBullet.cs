using UnityEngine;
using System.Collections;

public class AlienBullet : BaseBullet
{
    private Animator anim;
    // Use this for initialization
    public override void Awake()
    {
        anim = GetComponent<Animator>();
        base.Awake();
    }

    // Update is called once per frame
    public override void OnTriggerEnter2D (Collider2D col)
    {   
        if(anim != null)
            anim.SetTrigger("explode");
        base.OnTriggerEnter2D(col);
    }
}
