using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarUIBehavior : MonoBehaviour
{
    [SerializeField]
    private RawImage _healthBarFG;

    [SerializeField]
    private HealthBehaviour _healthBehavior;

    [SerializeField]
    private Gradient _healthBarGradient;

    [SerializeField]
    private TextMeshProUGUI _text;

    void Start()
    {
        Debug.Assert(_healthBarFG);
        Debug.Assert(_healthBehavior);
    }

    void Update()
    {
        if (_healthBarFG == null || _healthBehavior == null)
            return;

        float health = _healthBehavior.Health;

        //Min of 1 to ensure no dividing by zero or negative numbers
        float maxHealth = Mathf.Max(1, _healthBehavior.MaxHealth);

        ///No dividing by zero
        ///if (maxHealth == 0)
        ///    return;

        //Get health as a value between 0 and 1
        float healthPercentage = Mathf.Clamp01(health / maxHealth);

        //Set health bar scale
        Vector3 newScale = _healthBarFG.rectTransform.localScale;
        newScale.x = healthPercentage;
        _healthBarFG.rectTransform.localScale = newScale;

        //Set health bar color
        _healthBarFG.color = _healthBarGradient.Evaluate(healthPercentage);
    }
}
