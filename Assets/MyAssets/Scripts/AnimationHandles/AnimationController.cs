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
    public bool IsInAnimation;
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

        if(!IsInAnimation)
        {
            if (fireball && !WaitForFireb)
            {
                StartCoroutine(WaitForFire());
                anim.SetTrigger("Fireball");
            }
            if (Lightning && !WaitForLightningb)
            {
                StartCoroutine(WaitForLightning());
                anim.SetTrigger("Lightning");
            }
            if (Haduken && !WaitForHadukenb)
            {
                StartCoroutine(WaitForHaduken());
                anim.SetTrigger("Haduken");
            }
            if (Iceblast && !WaitForIceb)
            {
                StartCoroutine(WaitForIce());
                anim.SetTrigger("IceBlast");
            }
            if (Summon && !WaitForSummonb)
            {
                StartCoroutine(WaitForSummon());
                anim.SetTrigger("Summon");
            }

            if (!Idle)
            {
                anim.SetBool("Idle", false);
            }
        }
    }
        


    IEnumerator WaitForFire()
    {
        IsInAnimation = true;
        WaitForFireb = true;
        yield return new WaitForSeconds(2.300f);
        WaitForFireb = false;
        IsInAnimation = false;
    }
    
    IEnumerator WaitForLightning()
    {
        IsInAnimation = true;
        WaitForLightningb = true;
        yield return new WaitForSeconds(4.300f);
        WaitForLightningb = false;
        IsInAnimation = false;
    }

    IEnumerator WaitForHaduken()
    {
        IsInAnimation = true;
        WaitForHadukenb = true;
        yield return new WaitForSeconds(3.333f);
        WaitForHadukenb = false;
        IsInAnimation = false;
    }

    IEnumerator WaitForIce()
    {
        IsInAnimation = true;
        WaitForIceb = true;
        yield return new WaitForSeconds(2.633f);
        WaitForIceb = false;
        IsInAnimation = false;
    }

    IEnumerator WaitForSummon()
    {
        IsInAnimation = true;
        WaitForSummonb = true;
        yield return new WaitForSeconds(2.167f);
        WaitForSummonb = false;
        IsInAnimation = false;
    }

}
