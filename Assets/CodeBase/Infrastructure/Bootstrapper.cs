using CodeBase.Services;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Bootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private static Bootstrapper _instance;

        private InitializationScene _initializationScene;
        private LanguageType _language = LanguageType.RU;
        private StaticDataServices _staticData;
        private SceneLoader _sceneLoader;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;

            LoadProject(_language);

            DontDestroyOnLoad(gameObject);
        }

        public void LoadProject(LanguageType language)
        {
            _language = language;

            _sceneLoader = new SceneLoader(this);

            _sceneLoader.Load("SampleScene", StartProject);
        }

        private void StartProject()
        {
            _staticData = new StaticDataServices();
            _initializationScene = new InitializationScene(_staticData, this, _language);

            _staticData.Load(_language);

            _initializationScene.LoadPrefabs();
            _initializationScene.InitScene();
        }
    }
}