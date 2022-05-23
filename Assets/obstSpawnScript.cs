using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstSpawnScript : MonoBehaviour {

    public GameObject obstPrefab;
    Vector3 previousPosition = Vector3.one;
    // Start is called before the first frame update
    void Start() {
        int numObst = 0;
        while(numObst < 15) {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-15f, 15f));

            // checks if randomSpawnPosition is (0,0); in which case regenerates position
            if(randomSpawnPosition.x == 0f && randomSpawnPosition.y == 0f) {
                continue;
            }


            if((randomSpawnPosition == previousPosition) || ((randomSpawnPosition - previousPosition).magnitude < 3)) {
                continue;
            }

            Vector3 randomSpawnRotation = Vector3.up * Random.Range(0, 360);

            GameObject obstacle = Instantiate(obstPrefab, randomSpawnPosition, Quaternion.Euler(randomSpawnRotation));

            Vector3 scale = obstacle.transform.localScale;
            scale.x = Random.Range(1,4);
            scale.z = Random.Range(1,5);
            scale.y = Random.Range(2,6);

            obstacle.transform.localScale = scale;
            randomSpawnPosition.y = scale.y / 2;
            obstacle.transform.position = randomSpawnPosition;

            previousPosition = randomSpawnPosition;

            numObst++;
        }
    }
}
