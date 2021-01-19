using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarmanJobHandler : MonoBehaviour
{
    public GameObject beerCratePrefab;
    public GameObject beerCratePosition;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("BeerCrate") && StoryState.TookBeerCrate) {
            StoryState.HelpedBarman = true;
            // Put one on the table
            Destroy(other.gameObject);
            other.gameObject.transform.parent = beerCratePosition.transform;
            Instantiate(beerCratePrefab, beerCratePosition.gameObject.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }
    }
}
