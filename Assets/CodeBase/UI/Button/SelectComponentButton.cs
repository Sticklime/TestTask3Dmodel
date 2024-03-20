using CodeBase.Services;
using CodeBase.Switch;
using CodeBase.UI.Canvas;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CodeBase.UI.Button
{
    [RequireComponent(typeof(Collider))]
    public class SelectComponentButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private SwitchComponentsType _switchComponentsType;
        [SerializeField] private Image _buttonImage;
        [SerializeField] private Sprite _turnedOffSprite;
        [SerializeField] private TMP_Text _nameText;

        private SwitchModel _switchModelView;
        private SwitchModel _switchModel;
        private Sprite _spriteButton;
        private DescriptionCanvas _descriptionCanvas;
        private StaticDataServices _staticData;

        private bool _isEnableComponent = true;

        public void Init(SwitchModel switchModel, SwitchModel switchModelView, DescriptionCanvas descriptionCanvas,
            StaticDataServices staticData)
        {
            _switchModel = switchModel;
            _switchModelView = switchModelView;
            _descriptionCanvas = descriptionCanvas;
            _staticData = staticData;
        }

        private void Start()
        {
            _spriteButton = _buttonImage.sprite;
            _nameText.text = _staticData.GetDescriptionOfLanguage(_switchComponentsType).nameComponents;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _descriptionCanvas.ShowInfo(_staticData.GetDescriptionOfLanguage(_switchComponentsType));
            _switchModel.ShowOutlineComponent(_switchComponentsType);
            _switchModelView.ShowComponent(_switchComponentsType);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _descriptionCanvas.HideInfo();
            _switchModel.HideOutlineComponent(_switchComponentsType);
            _switchModelView.ShowAllComponent();
        }

        public void ShowComponent()
        {
            if (_isEnableComponent)
                SetDisableSprite();
            else
                SetEnableSprite();

            _switchModel.HideShowComponent(_switchComponentsType);
        }

        public void SetEnableSprite()
        {
            _buttonImage.sprite = _spriteButton;
            _isEnableComponent = true;
        }

        private void SetDisableSprite()
        {
            _buttonImage.sprite = _turnedOffSprite;
            _isEnableComponent = false;
        }
    }
}