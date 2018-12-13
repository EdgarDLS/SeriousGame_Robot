using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuable : MonoBehaviour, IInteractuable
{
    [SerializeField] private GameObject hintIcon;

    // Components
    Animator myAnim;

    void Start()
    {
        myAnim = this.GetComponentInChildren<Animator>();
    }

    public void Deinteract()
    {
        myAnim.Play("HideIcon");
    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }

    public void ShowIcon()
    {
        myAnim.Play("ShowIcon");
    }
}
