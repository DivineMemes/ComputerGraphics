using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public bool Idle = true;
    public Animator anim;
    public bool WaitForFireb;
    public bool WaitForLightningb;
    public bool WaitForHadukenb;
    public bool WaitForIceb;
    public bool WaitForSummonb;
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
        bool fireball = Input.GetKeyDown(KeyCode.Alpha1);
        bool Lightning = Input.GetKeyDown(KeyCode.Alpha2);
        bool Haduken = Input.GetKeyDown(KeyCode.Alpha3);
        bool Iceblast = Input.GetKeyDown(KeyCode.Alpha4);
        bool Summon = Input.GetKeyDown(KeyCode.Alpha5);

        if(fireball && !WaitForFireb)
        {
            StartCoroutine(WaitForFire());
            anim.SetTrigger("Fireball");
        }
        if(Lightning && !WaitForLightningb)
        {
            StartCoroutine(WaitForLightning());
            anim.SetTrigger("Lightning");
        }
        if(Haduken && !WaitForHadukenb)
        {
            StartCoroutine(WaitForHaduken());
            anim.SetTrigger("Haduken");
        }
        if(Iceblast && !WaitForIceb)
        {
            StartCoroutine(WaitForIce());
            anim.SetTrigger("IceBlast");
        }
        if(Summon && !WaitForSummonb)
        {
            StartCoroutine(WaitForSummon());
            anim.SetTrigger("Summon");
        }

        if(!Idle)
        {
            anim.SetBool("Idle", false);
        }
	}


    IEnumerator WaitForFire()
    {
        WaitForFireb = true;
        yield return new WaitForSeconds(2.300f);
        WaitForIceb = false;
    }
    
    IEnumerator WaitForLightning()
    {
        WaitForLightningb = true;
        yield return new WaitForSeconds(4.300f);
        WaitForLightningb = false;
    }

    IEnumerator WaitForHaduken()
    {
        WaitForHadukenb = true;
        yield return new WaitForSeconds(3.333f);
        WaitForHadukenb = false;
    }

    IEnumerator WaitForIce()
    {
        WaitForIceb = true;
        yield return new WaitForSeconds(2.633f);
        WaitForIceb = false;
    }

    IEnumerator WaitForSummon()
    {
        WaitForSummonb = true;
        yield return new WaitForSeconds(2.167f);
        WaitForSummonb = false;
    }

}
