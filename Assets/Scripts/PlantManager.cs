using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    private List<GameObject> plants = new List<GameObject>();

    public void AddPlant(GameObject plant)
    {
        plants.Add(plant);
    }

    public GameObject GetClosestPlant(Vector3 targetPosition, GameObject chickenOwner)
    {
        GameObject closestPlant = null;
        float closestDistance = float.MaxValue;

        foreach (GameObject plant in plants)
        {
            float distance = Vector3.Distance(plant.transform.position, targetPosition);
            if (distance < closestDistance && chickenOwner != plant.GetComponent<Plant>().getOwner())
            {
                closestPlant = plant;
                closestDistance = distance;
            }
        }

        return closestPlant;
    }

    // Additional methods or logic as needed

    // Example method to remove a plant
    public void RemovePlant(GameObject plant)
    {
        plants.Remove(plant);
    }
}
