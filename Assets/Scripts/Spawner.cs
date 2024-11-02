using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Bird bird_script;
    public GameObject borular;
    public float height;
    public float time;
    
    private void Start()
    {
        StartCoroutine(spawner_object(time));
    }
    public IEnumerator spawner_object(float time)
    {
        while (!bird_script.is_dead)
        {
            Instantiate(borular, new Vector3(transform.position.x, Random.Range(-height+0.2f, height+0.4f), 0), Quaternion.identity);
            
            yield return new WaitForSeconds(time);
            
        }
    }
}
