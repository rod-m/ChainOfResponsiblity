using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


    public class SoldierController : MonoBehaviour
    {
        public List<Transform> points = new List<Transform>();
        private NavMeshAgent agent;
        public float movementSpeed = 0.4f;
        public int destinationPoint = 0;
  
    

   
       

        private void Awake()
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("EnemyWayPoint");
            foreach (var gameObject in gameObjects)
            {
                points.Add(gameObject.transform);
            }
       
            int way_count = points.Count;
            destinationPoint = Mathf.FloorToInt(Random.Range(0f, (float)way_count));
     
            //Debug.Log("Awake: " + transform.position.ToString() + " " + destinationPoint);
            agent = GetComponent<NavMeshAgent>();

            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            agent.autoBraking = false;

            GotoNextPoint();
        }

        void GotoNextPoint() {
            // Returns if no points have been set up
            if (points.Count == 0)
                return;

            // Set the agent to go to the currently selected destination.
            agent.destination = points[destinationPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destinationPoint = (destinationPoint + 1) % points.Count;
        }


        void Update () {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
    }
