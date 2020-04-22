using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChainOfResponsibility
{
    public class DoorHandler : MonoBehaviour
    {
        private Animator anim;
        public List<string> keysRequired;
        public float _radius = 10f;
        DoorKey newKeyChain;
        private void KeyEntryControl(IHandler handler)
        {
            int openDoor = 0;
            foreach (var key in keysRequired)
            {
                Debug.Log($"Player: Open with {key}?");
                var result = handler.Handle(key);
                if (result != null)
                {
                    Debug.Log($"GOT KEY {result}");
                    openDoor++;
                }
                else
                {
                    Debug.Log($"This {key} didnt work! Carry on? Penalty?");
                }
            }
            Debug.Log($"{openDoor} keys of {keysRequired.Count}");
            if (openDoor == keysRequired.Count)
            {
                anim.SetTrigger("DoorOpen");
            }
        }

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }
        
        void CheckLocale()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius);
            int i = 0;
            while (i < hitColliders.Length)
            {
                var hitgo = hitColliders[i];
                if (hitgo.CompareTag("DoorKey"))
                {
                    
                    var newKey = hitgo.gameObject.GetComponent<DoorKey>();
                    Debug.Log($"{newKey.keyType} set!");
                    if (newKeyChain == null)
                    {
                        newKeyChain = newKey;
         
                    }
                    else
                    {
                        newKeyChain.SetNext(newKey);
                    }

                }
                i++;
            }
            //try door
            if (newKeyChain != null)
            {
                KeyEntryControl(newKeyChain);
            }
            
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                CheckLocale();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            newKeyChain = null;
        }
    }
}