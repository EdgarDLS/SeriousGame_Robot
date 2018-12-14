using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuable : MonoBehaviour, IInteractuable
{
    [SerializeField] private GameObject hintIcon;

    // Components
    Animator hintIconAnimator;
    GameObject player;

    protected virtual void Start()
    {
        hintIcon = this.transform.Find("PressSprite").gameObject;
        hintIconAnimator = hintIcon.GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    public virtual void Deinteract()
    {
        hintIconAnimator.Play("HideIcon");
    }

    public virtual void Interact()
    {
        
    }

    public virtual void ShowIcon()
    {
        hintIconAnimator.Play("ShowIcon");
    }
}
