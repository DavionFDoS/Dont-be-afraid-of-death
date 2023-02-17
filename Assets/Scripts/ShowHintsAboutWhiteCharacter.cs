using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ShowHintsAboutWhiteCharacter : MonoBehaviour
{
    public TextMeshProUGUI[] HintsToShow;
    private bool _isTriggeredFirstTime = true;
    private float _timer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_isTriggeredFirstTime)
        {
            foreach (var hint in HintsToShow)
            {
                if(hint != HintsToShow.Last())
                {
                    hint.gameObject.SetActive(true);
                }
            }
            _timer = 8f;
        }
        _isTriggeredFirstTime = false;
    }

    private void Update()
    {
        if (!_isTriggeredFirstTime)
        {
            if (_timer <= 0f)
            {
                HideHints();
                HintsToShow.Last().gameObject.SetActive(true);
            }
            _timer -= Time.deltaTime;
        }       
    }

    private void HideHints()
    {
        foreach (var hint in HintsToShow)
        {
            hint.gameObject.SetActive(false);
        }
    }
}
