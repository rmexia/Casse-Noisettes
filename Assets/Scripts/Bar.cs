using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField] private float m_Speed = 3f;
    [SerializeField] private float m_Step = 0.1f;
    [SerializeField] private Transform m_VisibleBar = null;
    [SerializeField] private Transform m_VirtualBar = null;

	void Update ()
    {
        //on bouge une barre invisible pour l'utilisateur.
        Vector3 translation = Vector3.zero;
		if (Input.GetKey(KeyCode.LeftArrow))
        {
            translation = Vector3.left * m_Speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            translation = Vector3.right * m_Speed;
        }
        m_VirtualBar.Translate(translation);

        //si la distance entre la barre invisible et la barre visible est supérieur à step, on téléporte la barre visible sur la barre invisible.
        if (Vector3.Distance(m_VisibleBar.position, m_VirtualBar.position) > m_Step)
        {
            m_VisibleBar.position = m_VirtualBar.position;
        }
	}
}
