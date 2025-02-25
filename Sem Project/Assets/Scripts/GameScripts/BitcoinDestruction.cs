using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BitcoinDestruction : MonoBehaviour
{
    private int _hitsAmount = 0;
    [Header("GameLength")]
    [SerializeField] private double _hitsFirstGoal;
    [SerializeField] private int _hitsDestructionMultiplayer;
    [SerializeField] private int _destrctionsCount;

    private int _currDestruction = 0;

    [Header("VictoryTrack")]
    [SerializeField] private Canvas _victoryCanvas;
    [SerializeField] private Canvas _gameCanvas;

    public void TakeHit()
    {
        _hitsAmount++;
        BitcoinDestroy();
    }

    private void BitcoinDestroy()
    {
        if (_hitsAmount >= _hitsFirstGoal)
        {
            _currDestruction++;
            //TO DO: Destruction Animation/Mechanic (takes 3 in total to fully destroy a bitcoin)
            if (_currDestruction == _destrctionsCount)
            {
                _gameCanvas.gameObject.SetActive(false);
                _victoryCanvas.gameObject.SetActive(true);
            }
            _hitsAmount = 0;
            _hitsFirstGoal *= _hitsDestructionMultiplayer;
        }
    }
}
