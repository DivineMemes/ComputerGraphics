using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirehandParticleEffect : MonoBehaviour
{
    float timeCounter;
    float xCounter;
    float x;
    public float speed = 10;
    bool up = true;
    bool down = false;
    public ParticleSystem launcher;
    public ParticleSystem.Particle[] m_particle;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        InitializeIfNeeded();
        //launcher.Emit(1);
        int particlesAlive = launcher.GetParticles(m_particle);
        for(int i = 0; i < particlesAlive; i++)
        {
            
            timeCounter += Time.deltaTime / speed;
            //clampedspeed = Mathf.Clamp(speed, 1, 10);

            //trying to lerp speed in which particle spins
            speed = Mathf.Lerp(0, 10, Time.deltaTime / 5);
            //float x = Mathf.Cos(timeCounter) * 3;

            float y = Mathf.Cos(timeCounter) * 1;
            //float y = Mathf.Tan(timeCounter)*1;

            //getting the circular motion to oscillate up and down
           if (up)
           {
               xCounter += Time.deltaTime / 1.5f;
               x = xCounter;
           }
           if (down)
           {
               xCounter -= Time.deltaTime / 1.5f;
               x = xCounter;
           }
           if (xCounter > 1)
            { 
                down = true;
                up = false;
            }
           if(xCounter <-1)
            {
                up = true;
                down = false;
            }


            float z = Mathf.Sin(timeCounter) * 1;
           
            m_particle[i].position = new Vector3(x, y, z);
        }
        launcher.SetParticles(m_particle, particlesAlive);
	}

    void InitializeIfNeeded()
    {
        if (launcher == null)
            launcher = GetComponent<ParticleSystem>();

        if (m_particle == null || m_particle.Length < launcher.main.maxParticles)
            m_particle = new ParticleSystem.Particle[launcher.main.maxParticles];
    }
}
