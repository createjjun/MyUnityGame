using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class SpawnStore
{
    public List<GameObject> KeyW;
    public List<GameObject> KeyS;
    public List<GameObject> KeyA;
    public List<GameObject> KeyD;

}

public class KeySpawnHandler : MonoBehaviour
{
    [SerializeField] private GameObject W;
    [SerializeField] private GameObject S;
    [SerializeField] private GameObject A;
    [SerializeField] private GameObject D;
    [SerializeField] private Transform panel;
    public SpawnStore spawnStore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void KeyStore()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject w = Instantiate(W);
            GameObject a = Instantiate(A);
            GameObject s = Instantiate(S);
            GameObject d = Instantiate(D);
            w.SetActive(false);
            a.SetActive(false);
            s.SetActive(false);
            d.SetActive(false);
            spawnStore.KeyW.Add(w);
            spawnStore.KeyA.Add(a);
            spawnStore.KeyS.Add(s);
            spawnStore.KeyD.Add(d);
        }
    }

    public void KeySpawn()
    {
        int rand = UnityEngine.Random.Range(0, 4);
        var select = spawnStore.KeyW;
        switch (rand)
        {
            case 1:
                select = spawnStore.KeyA;
                break;
            case 2:
                select = spawnStore.KeyS;
                break;
            case 3:
                select = spawnStore.KeyD;
                break;
        }
        foreach (GameObject k in select)
        {
            if (!k.activeSelf)
            {   
                k.transform.SetParent(panel);
                k.SetActive(true);
                var sp = k.GetComponent<Image>();
                Debug.Log(sp.sprite.name);
                break;
            }
        }
        
    }
}
