using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuable : MonoBehaviour, IInteractuable
{
    [SerializeField] private GameObject hintIcon;

    // Components
    Animator myAnim;
    GameObject player;

    protected virtual void Start()
    {
        myAnim = this.GetComponentInChildren<Animator>();
        player = GameObject.Find("Player");
    }

    public virtual void Deinteract()
    {
        myAnim.Play("HideIcon");
    }

    public virtual void Interact()
    {
        
    }

    public virtual void ShowIcon()
    {
        myAnim.Play("ShowIcon");
    }
}
