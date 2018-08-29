using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    //Hadoken particle stuff
    [SerializeField]
    ParticleSystem HadokenStartup;
    [SerializeField]
    ParticleSystem HadokenBlast;


    //Lightning particle stuff
    [SerializeField]
    ParticleSystem LeftSparkle;
    [SerializeField]
    ParticleSystem RightSparkle;
    [SerializeField]
    ParticleSystem LeftLightningSyst;
    [SerializeField]
    ParticleSystem RightLightningSyst;





    public bool Idle = true;
    public Animator anim;
    public bool WaitForFireb;
    public bool WaitForLightningb;
    public bool WaitForIceb;
    public bool WaitForHadokenb;
    public bool WaitForSummonb;
    public bool IsInAnimation;




    public bool startLightningParticle;

	void Start ()
    {
        anim = GetComponent<Animator>();

        //LeftSparkle = transform.Find("LeftSparklingHand");
        //RightSparkle = transform.Find("RightSparklingHand");
        //LeftLightningSyst = transform.Find("LeftLightningSystem");
        //RightLightningSyst = transform.Find("RightLightningSystem");
    }
	
	void Update ()
    {
        bool fireball = Input.GetKeyDown(KeyCode.Alpha1);
        bool Lightning = Input.GetKeyDown(KeyCode.Alpha2);
        bool Hadoken = Input.GetKeyDown(KeyCode.Alpha3);
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
                LeftSparkle.Play();
                RightSparkle.Play();
                StartCoroutine(LightningParticle());
            }

            if (Iceblast && !WaitForIceb)
            {
                StartCoroutine(WaitForIceBlast());
                anim.SetTrigger("IceBlast");
            }

            if (Hadoken && !WaitForHadokenb)
            {
                StartCoroutine(WaitForHadoken());
                anim.SetTrigger("Hadoken");
                StartCoroutine(HadokenParticleStartup());
                StartCoroutine(HadokenBlastParticle());


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
        startLightningParticle = false;
        LeftSparkle.Stop();
        RightSparkle.Stop();
        IsInAnimation = false;
    }

    IEnumerator LightningParticle()
    {
        yield return new WaitForSeconds(1.067f);
            LeftLightningSyst.Play();
            RightLightningSyst.Play();
    }


    IEnumerator WaitForHadoken()
    {
        IsInAnimation = true;
        WaitForHadokenb = true;
        yield return new WaitForSeconds(2.633f);
        WaitForHadokenb = false;
        HadokenStartup.Stop();
        HadokenBlast.Stop();
        IsInAnimation = false;
    }

    IEnumerator HadokenParticleStartup()
    {
        yield return new WaitForSeconds(1.033f);
        HadokenStartup.Play();
    }
    IEnumerator HadokenBlastParticle()
    {
        yield return new WaitForSeconds(1.567f);
        HadokenBlast.Play();
    }
    IEnumerator WaitForIceBlast()
    {
        IsInAnimation = true;
        WaitForIceb = true;
        yield return new WaitForSeconds(3.333f);
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
