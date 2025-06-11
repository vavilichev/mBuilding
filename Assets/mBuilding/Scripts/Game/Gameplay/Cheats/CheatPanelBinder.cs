using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace mBuilding.Game
{
    public class CheatPanelBinder : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _cheatInputField;
        [SerializeField] private Button _btnApply;

        private CheatPanelViewModel _viewModel;
    
        public void Bind(CheatPanelViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        private void OnEnable()
        {
            _btnApply.onClick.AddListener(OnApplyButtonClick);
        }

        private void OnDisable()
        {
            _btnApply.onClick.RemoveListener(OnApplyButtonClick);
        }

        public void OnApplyButtonClick()
        {
            _viewModel.HandleCheatApplying(_cheatInputField.text);
        }
    }
}