using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_scene : MonoBehaviour
{
    private float nextSpawnTime;
    [SerializeField]
    public GameObject prefab;
    public int count;
    public Text ctext;
    [SerializeField] float delay = 0.25f;

    void Spawn()
    {
        nextSpawnTime = Time.time + delay;
        float x = Random.Range(-8,8);
        float y = Random.Range(-4,4);
        Instantiate(prefab, new Vector2(x,y), Quaternion.identity);
        count++;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawning()){
            Spawn();
            ctext.text = "Count: " + count.ToString();
        }
    }
    private bool spawning(){
        return Time.time > nextSpawnTime;
    }
}
