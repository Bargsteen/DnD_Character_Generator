using Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class BackButtonController : MonoBehaviour
    {
        public void OnBackButtonClicked() => SceneManager
            .LoadScene(SceneIndexes.MainMenuIndex);
    }
}
