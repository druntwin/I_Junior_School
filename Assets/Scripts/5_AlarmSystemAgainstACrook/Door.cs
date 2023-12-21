using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private UnityEvent _doorIsOpen = new UnityEvent();

    public bool IsDoorTiggered { get; private set; }

    public event UnityAction DoorOpened
    {
        add => _doorIsOpen.AddListener(value);
        remove => _doorIsOpen.RemoveListener(value);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out CrookMover crook))
        {
            IsDoorTiggered = true;
            _animator.SetBool("DoorIsTriggered", IsDoorTiggered);
            _doorIsOpen.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent(out CrookMover crook))
        {
            IsDoorTiggered = false;
            _animator.SetBool("DoorIsTriggered", IsDoorTiggered);
            _doorIsOpen.Invoke();
        }
    }
}
