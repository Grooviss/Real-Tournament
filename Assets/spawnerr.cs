using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class spawnerr : MonoBehaviour
{
    public GameObject prefab;
    public List<Transform> spawnpoints;
    public List<int> enemiesPerWave;
   [Range(0f, 10f)] public float timebetweenwaves = 10f;
    [Range(0f, 10f)]  public float spawnInterval;
     int enemiesLeft;
    public UnityEvent onspawn;
    public UnityEvent<int> onwavestart;
    public UnityEvent<int> onwaveend;
    public UnityEvent onwavescleared;
    public AudioClip wavestart;
    public AudioClip waveend;
    public AudioClip wavesclearees;

    int wave;
    public void Spawn()
    {
        var point = spawnpoints[Random.Range(0, spawnpoints.Count)];
        Instantiate(prefab, point.position, point.rotation);
        onspawn.Invoke();
    }
    // Start is called before the first frame update
    async void Start()
    {
        foreach (var count in enemiesPerWave)
        {
            
            enemiesLeft = count;
            AudioManager.Play(wavestart);
            onwavestart.Invoke(wave);
            while (enemiesLeft > 0)

            {
                await new WaitForSeconds(spawnInterval);
                Spawn();
                enemiesLeft--;

            }
            AudioManager.Play(waveend);
            onwaveend.Invoke(wave);
            wave++;
            await new WaitForSeconds(timebetweenwaves
              );
        }
        onwavescleared.Invoke();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
