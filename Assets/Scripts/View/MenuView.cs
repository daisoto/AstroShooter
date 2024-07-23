using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class MenuView: MonoBehaviour
    {
        [field: SerializeField] 
        public Button RestartButton { get; private set; }

        [SerializeField] 
        private GameObject _root;

        [SerializeField] 
        private GameObject _winLabel;
        
        [SerializeField] 
        private GameObject _loseLabel;

        public void SetWin()
        {
            _loseLabel.SetActive(false);
            _winLabel.SetActive(true);
        }
        
        public void SetLose()
        {
            _winLabel.SetActive(false);
            _loseLabel.SetActive(true);
        }

        public void Show()
        {
            _root.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _root.gameObject.SetActive(false);
        }
    }
}