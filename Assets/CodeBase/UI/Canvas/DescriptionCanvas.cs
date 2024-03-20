using CodeBase.StaticData;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.Canvas
{
    public class DescriptionCanvas : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _descriptionText;
        [SerializeField] private GameObject _descriptionContainer;

        public void ShowInfo(DescriptionComponent descriptionComponent)
        {
            _descriptionContainer.gameObject.SetActive(true);
            _nameText.text = descriptionComponent.nameComponents;
            _descriptionText.text = descriptionComponent.description;
        }

        public void HideInfo()
        {
            _descriptionContainer.gameObject.SetActive(false);
        }
    }
}