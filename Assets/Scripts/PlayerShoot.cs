using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject impactPrefab;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f)) // "out" fa si che nella funzione ritorino 2 parametri (non solo la booleana ma anche raycast hit)
        {
            Debug.Log(hit.transform.name); // viene quindi "sputato" tutto l'oggetto e le sue informazioni, in "hit"
            Vector3 spawnPos = hit.point + (hit.normal * 0.01f);
            Quaternion spawnRotation = Quaternion.LookRotation(hit.normal);
            GameObject impact = Instantiate(impactPrefab, spawnPos, spawnRotation);
            Destroy(impact, 5f);
        }
    }
}
