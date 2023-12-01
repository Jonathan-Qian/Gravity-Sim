using System;
using UnityEngine;

public class MassSystem : MonoBehaviour {
    [SerializeField] private float gravitationalConstant;
    private int numMasses;
    public Vector3[] netForces;

    void Start() {
        numMasses = transform.childCount;
        netForces = new Vector3[numMasses];
    }

    void FixedUpdate() {
        calculateNetForces();
        applyNetForces();
    }

    private void calculateNetForces() {
        //int counter = 0;
        float distance;
        float forceMagnitude;
        float forceDistanceRatio;
        
        Vector3 forceComponents, distanceComponents, netForce1, netForce2;
        Transform mass1, mass2;
        MassData massData1, massData2;

        for (int i = 0; i < numMasses; i++) {
            for (int j = i + 1; j < numMasses; j++) {
                mass1 = transform.GetChild(i);
                mass2 = transform.GetChild(j);

                distanceComponents = mass2.position - mass1.position;

                distance = Mathf.Sqrt(
                    distanceComponents.x * distanceComponents.x +
                    distanceComponents.y * distanceComponents.y +
                    distanceComponents.z * distanceComponents.z
                );

                massData1 = mass1.GetComponent<MassData>();
                massData2 = mass2.GetComponent<MassData>();
                
                forceMagnitude = gravitationalConstant * massData1.mass * massData2.mass / (distance * distance);

                forceDistanceRatio = forceMagnitude / distance;

                forceComponents = distanceComponents * forceDistanceRatio;

                netForce1 = netForces[i];
                netForce2 = netForces[j];

                netForce1 += forceComponents;

                netForce2 -= forceComponents;

                netForces[i] = netForce1;
                netForces[j] = netForce2;

                //Debug.Log(counter + "; " + i + ", " + j + "; distance components: " + distanceComponents + "; force components: " + forceComponents + "; netForce1: " + netForce1 + "; netForce2: " + netForce2);

                //counter++;
            }
        }
    }

    private void applyNetForces() {
        MassData massData;

        for (int i = 0; i < numMasses; i++) {
            massData = transform.GetChild(i).GetComponent<MassData>();
            massData.moveWithForce(netForces[i]);
        }
    }
}
