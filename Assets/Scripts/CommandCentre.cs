using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CommandCentre : MonoBehaviour
    {
        public int enemies = 5;

        public GameObject prefab;

        public int soldier_number = 0;
  
        

        private void Start()
        {
            StartCoroutine("Spawner");
     
       
        }

        private void Update()
        {
            if (enemies == soldier_number)
            {
                //Debug.Log("StopCoroutine SpawnSoldier");
                StopCoroutine("Spawner");
            }
        }

        void SpawnSoldier()
        {
            GameObject gi = Instantiate(prefab);
            gi.name = "Soldier_" + soldier_number;
            SoldierController soldier = gi.GetComponent<SoldierController>();
            if (soldier == null)
            {
                gi.AddComponent<SoldierController>();
                soldier = gi.GetComponent<SoldierController>();
            }
            
            soldier_number++;
        }
      
        IEnumerator Spawner()
        {
            for (;;)
            {
                SpawnSoldier();
                yield return new WaitForSeconds(3f);
            }
     
        }
    }
