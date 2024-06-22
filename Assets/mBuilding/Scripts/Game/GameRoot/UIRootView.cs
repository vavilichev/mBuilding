using UnityEngine;

namespace mBuilding.Scripts
{
    public class UIRootView : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingScreen;

        private void Awake()
        {
            HideLoadingScreen();
        }

        public void ShowLoadingScreen()
        {
            _loadingScreen.SetActive(true);
        }
        
        public void HideLoadingScreen()
        {
            _loadingScreen.SetActive(false);
        }
    }
}