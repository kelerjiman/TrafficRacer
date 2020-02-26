using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionWindow : GenericWindow
{
      public override void Start()
    {
        base.Start();
        Button btn = CloseButton.GetComponent<Button>();
        CloseButton.onClick.AddListener(OnCloseButton);
    }
}
