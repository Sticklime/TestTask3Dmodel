using System.Collections.Generic;
using CodeBase.Switch;
using UnityEngine;

namespace CodeBase.UI.Button
{
    public class ShowAllComponentButton : MonoBehaviour
    {
        [SerializeField] private SwitchModel _switchModel;
        [SerializeField] private List<SelectComponentButton> _otherButtons;

        public void ShowAllComponent()
        {
            foreach (var otherButton in _otherButtons) 
                otherButton.SetEnableSprite();

            _switchModel.ShowAllComponent();
        }
    }
}