using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TMP_Text wavetext;

    public async  void AnnounceWave(int wave)
    {
        wavetext.text = $"wave {wave+1} started";
            await new WaitForSeconds(2f);
        wavetext.text = "";
    }
}
