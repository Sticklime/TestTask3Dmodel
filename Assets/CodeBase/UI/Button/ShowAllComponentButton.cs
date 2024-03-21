using System.Collections.Generic;
using CodeBase.Services;
using CodeBase.Switch;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.Button
{
    public class ShowAllComponentButton : MonoBehaviour
    {
        [SerializeField] private List<SelectComponentButton> _otherButtons;
        [SerializeField] private TMP_Text _showAllText;

        private SwitchModel _switchModel;

        public void Construct(SwitchModel switchModel, StaticDataServices staticDataServices)
        {
            _switchModel = switchModel;

            _showAllText.text = staticDataServices.GetDescriptionOfType(SwitchComponentsType.Default).nameComponents;
        }

        public void ShowAllComponent()
        {
            foreach (var otherButton in _otherButtons)
                otherButton.SetEnableSprite();

            _switchModel.ShowAllComponent();
        }
    }
}