using CodeBase.Logic.Camera;
using CodeBase.Services;
using CodeBase.StaticData;
using CodeBase.Switch;
using CodeBase.UI;
using CodeBase.UI.Button;
using CodeBase.UI.Canvas;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class InitializationScene
    {
        private readonly StaticDataServices _staticData;
        private readonly Bootstrapper _bootstrapper;

        private SwitchModel _switchModelPrefab;
        private SwitchModel _switchModelViewPrefab;
        private SelectComponentCanvas _componentCanvasPrefab;
        private DescriptionCanvas _descriptionCanvasPrefab;
        private GameObject _viewComponentCanvasPrefab;

        private SwitchModel _switchModel;
        private SwitchModel _switchModelView;
        private GameObject _viewComponentCanvas;
        private DescriptionCanvas _descriptionCanvas;
        private SelectComponentCanvas _componentCanvas;

        private CameraController _mainCamera;
        private readonly LanguageType _languageType;

        public InitializationScene(StaticDataServices staticData, Bootstrapper bootstrapper, LanguageType languageType)
        {
            _staticData = staticData;
            _bootstrapper = bootstrapper;
            _languageType = languageType;
        }

        public void LoadPrefabs()
        {
            _switchModelPrefab = Resources.Load<SwitchModel>(PathProver.SwitchModelPath);
            _switchModelViewPrefab = Resources.Load<SwitchModel>(PathProver.SwitchModelViewPath);
            _componentCanvasPrefab = Resources.Load<SelectComponentCanvas>(PathProver.ComponentCanvas);
            _descriptionCanvasPrefab = Resources.Load<DescriptionCanvas>(PathProver.InfoCanvas);
            _viewComponentCanvasPrefab = Resources.Load<GameObject>(PathProver.ViewComponentCanvas);
        }

        public void InitScene()
        {
            InitModels();
            InitUI();
            InitCamera();
        }

        private void InitModels()
        {
            _switchModel = Object.Instantiate(_switchModelPrefab, Vector3.zero, Quaternion.identity);
            _switchModelView = Object.Instantiate(_switchModelViewPrefab, new Vector3(-27.597f, 0, 0),
                Quaternion.identity);
        }

        private void InitUI()
        {
            _componentCanvas = Object.Instantiate(_componentCanvasPrefab);
            _descriptionCanvas = Object.Instantiate(_descriptionCanvasPrefab);
            _viewComponentCanvas = Object.Instantiate(_viewComponentCanvasPrefab);

            _componentCanvas.Construct(_switchModel, _switchModelView, _descriptionCanvas, _staticData);
            _descriptionCanvas.GetComponentInChildren<ChangeLanguageButton>().Construct(_bootstrapper, _languageType);
        }

        private void InitCamera()
        {
            if (Camera.main != null)
                _mainCamera = Camera.main.GetComponent<CameraController>();

            _mainCamera.Construct(_switchModel.CentralPoint);
        }
    }
}