using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSoundZone : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AmbientSound _ambientSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<AmbientListener>() == false)
            return;

        _ambientSound.SetAmbientSound(_clip);
    }
}
