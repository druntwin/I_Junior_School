using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FootStepsSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private SurfaceStepsSound[] _stepSounds;
    [SerializeField] private Transform _checkSurfacePoint;

    private SurfaceType _currentSurface;

    private void FixedUpdate()
    {
        if (Physics.Raycast(_checkSurfacePoint.position, Vector3.down, out RaycastHit hitInfo) == false)
            return;

        if(hitInfo.transform.TryGetComponent(out Surface surface) == false) 
            return;

        if (surface.Type == _currentSurface)
            return;

        SetSurfaceSteps(surface.Type);
    }

    public void Play()
    {
        _audioSource.Play();
    }

    public void Pause()
    {
        _audioSource.Pause();
    }

    private void SetSurfaceSteps(SurfaceType surfaceType)
    {
        _currentSurface = surfaceType;
        _audioSource.clip = _stepSounds.First(sound => sound.Type == _currentSurface).Clip;
    }
}
