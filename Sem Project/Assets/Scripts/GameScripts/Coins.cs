using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private float _coinsAmount = 0;

    [SerializeField] private TextMeshProUGUI _showingCoinsAmount;

    [Header("Const")]
    private const int _k = 1000;
    private const int _m = 1000000;
    private const int _b = 1000000000;

    [Header("Scripts")]
    [SerializeField] private Interactables _interactablesScript;
    [SerializeField] private BitcoinDestruction _destructionScript;

    public void AddCoins(float coins)
    {
        _coinsAmount += (int)coins;
        ShowANDConvertCurrencies();
        _interactablesScript.SwitchInteractables();
        _destructionScript.TakeHit();
    }

    public bool IsEnoughCoinsToBuy(float coins)
    {
        if (_coinsAmount - coins < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }    

    private void ShowANDConvertCurrencies()
    {
        _showingCoinsAmount.text = _coinsAmount.ToString();
        if (_coinsAmount >= _k)
        {
            _showingCoinsAmount.text = $"{_coinsAmount / _k}K";
        }
        if (_coinsAmount >= _m)
        {
            _showingCoinsAmount.text = $"{_coinsAmount / _m}M";
        }
        if (_coinsAmount >= _b)
        {
            _showingCoinsAmount.text = $"{_coinsAmount / _b}B";
        }
    }

}
