using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yarn.Unity.Example
{
    public class BotPolicial : MonoBehaviour
    {
        Animator myAnim;

        void Start()
        {
            myAnim = this.GetComponent<Animator>();
        }

        [YarnCommand("unlockdoor")]
        public void UnlockDoor()
        {
            myAnim.Play("TryUnlockDoor");
        }
    }
}
