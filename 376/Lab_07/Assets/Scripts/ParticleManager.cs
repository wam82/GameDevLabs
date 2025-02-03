using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private AudioClip clip;
    private AudioSource soundComponent;

    private void Start()
    {
        this.GetComponent<ParticleSystem>().Pause();
    }
    public void Activate ()
    {
        soundComponent = GetComponent<AudioSource>();
        clip = soundComponent.clip;
        this.GetComponent<ParticleSystem>().Play();
        soundComponent.PlayOneShot(clip);
        }
    }

