using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class SpeedHUDManager : MonoBehaviour
{
    public TextMeshProUGUI speedText;
    public GameObject playerObj = null;
    private static Material m_TextBaseMaterial;
    private static Material m_TextHighlightMaterial;

    // Start is called before the first frame update
    void Start()
    {
		if (playerObj == null)
			playerObj = GameObject.FindGameObjectWithTag("Player");

        if (speedText == null)
            speedText = GameObject.Find("SpeedIndicator").GetComponent<TMPro.TextMeshProUGUI>();

        m_TextBaseMaterial = speedText.fontSharedMaterial;
        m_TextHighlightMaterial = new Material(m_TextBaseMaterial);
        m_TextHighlightMaterial.SetFloat(ShaderUtilities.ID_GlowPower, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        speedText.gameObject.SetActive(true);

        // Multiply displayed speed because bigger numbers are more fun!
        var speed = playerObj.GetComponent<Rigidbody>().velocity.magnitude * 2;

        // Speed glow settings - More speed = More glow
        if (speed > 41) 
        {
            m_TextHighlightMaterial.SetFloat(ShaderUtilities.ID_GlowPower, 1.0f);
        }
        else if (speed <= 30)
        {
            m_TextHighlightMaterial.SetFloat(ShaderUtilities.ID_GlowPower, 0f);
        }
        else
        {
            m_TextHighlightMaterial.SetFloat(ShaderUtilities.ID_GlowPower, 0.35f);
        }

        // Speed text color settings
        if (speed > 35) 
        {
            speedText.color = Color.red;
        }
        else if (speed > 20 && speed <= 35) 
        {
            speedText.color = Color.yellow;
        }
        else 
        {
            speedText.color = Color.white;
        }

        speedText.fontSharedMaterial = m_TextHighlightMaterial;
        speedText.UpdateMeshPadding();
        speedText.text = string.Format("{0}\nKPH", speed.ToString("0"));
    }
}