using Project.AppFrontendDomain.Modules;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Project.AppFrontendDomain.Managers
{
    public class UIViewsManager : IInitializable
    {
        private List<UIViewGOBaseModule> _views = new();

        public void Initialize()
        {
            _views.AddRange(GameObject.FindObjectsOfType<UIViewGOBaseModule>());
            StopGame();
        }

        public void StartGame()
        {
            ShowSingleView<HUDMenuGOModule>();
        }

        public void StopGame()
        {
            ShowSingleView<MainMenuGOModule>();
        }

        private void ShowSingleView<T>() where T : UIViewGOBaseModule
        {
            HideAllViews();
            var view = _views.Find(view => view is T);
            view.Show();
        }

        private void HideAllViews()
        {
            _views.ForEach(view => view.Hide());
        }
    }
}