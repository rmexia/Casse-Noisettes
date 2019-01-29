using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSModifierManager : MonoBehaviour {

    public int fps = 60;

    public bool switchOnOff = false;

    public bool activated
    {
        get
        {
            return m_Activated;
        }
        set
        {
            m_Activated = value;
            if(value)
            {
                m_FPSModifier.Activate(fps);
            }
            else
            {
                m_FPSModifier.Desactivate();
            }
        }
    }

    private bool m_Activated = false;
    [SerializeField] private FPSModifier m_FPSModifier = null;

	// Update is called once per frame
	void Update () {
		if(switchOnOff)
        {
            switchOnOff = false;
            activated = !activated;
        }
	}
}
