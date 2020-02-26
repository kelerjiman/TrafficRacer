using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenericAnimation : MonoBehaviour
{
    enum e_TObject
    {
        image,
        text
    }
    public float during = 0f;
    [SerializeField] e_TObject Types;
    [SerializeField] Color defColor;
    [SerializeField] Color nextColor;
    private Color m_tempColor;
    private float m_during = 0f;
    private void Start()
    {

    }

    private void Update()
    {
        m_during += Time.deltaTime;
            Handler_State();
    }
    void Handler_State()
    {
        if (m_during >= during)
        {
            m_during = 0;
            animationHandler();
            m_tempColor = defColor;
            defColor = nextColor;
            nextColor = m_tempColor;
        }
    }
    void animationHandler()
    {
        switch (Types)
        {
            case e_TObject.image:
                GetComponent<Image>().color = defColor;
                GetComponent<Image>().color = nextColor;
                break;
            case e_TObject.text:
                GetComponent<Text>().color = defColor;
                GetComponent<Text>().color = nextColor;
                break;
            default:
                break;
        }
    }
}
