using CodeBase.Infrastructure;
using CodeBase.StaticData;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.Button
{
    public class ChangeLanguageButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _languageText;

        private LanguageType _currentLanguage = LanguageType.RU;
        private Bootstrapper _bootstrapper;

        public void Construct(Bootstrapper bootstrapper, LanguageType currentLanguage)
        {
            _bootstrapper = bootstrapper;
            _currentLanguage = currentLanguage;
        
            _languageText.text = _currentLanguage == LanguageType.RU ? "RU" : "EN";
        }

        public void ChangeLanguage()
        {
            if (_currentLanguage == LanguageType.RU)
            {
                _currentLanguage = LanguageType.EN;
                _languageText.text = "EN";
                _bootstrapper.LoadProject(LanguageType.EN);
            }
            else
            {
                _currentLanguage = LanguageType.RU;
                _languageText.text = "RU";
                _bootstrapper.LoadProject(LanguageType.RU);
            }
        }
    }
}