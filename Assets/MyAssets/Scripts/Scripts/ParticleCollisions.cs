using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisions : MonoBehaviour
{
    public ParticleSystem particleLauncher;
    List<ParticleCollisionEvent> collisionEvents;
    public ParticleSystem otherSystem;
    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }
    void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher, other, collisionEvents);
        for (int i = 0; i < collisionEvents.Count; i++)
        {
            otherSystem.Play();
            particleLauncher.Stop(true);
        }
    }
}

