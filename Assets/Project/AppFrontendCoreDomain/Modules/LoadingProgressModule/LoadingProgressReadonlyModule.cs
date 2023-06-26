using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Project.AppFrontendCoreDomain.Modules
{
    public class LoadingProgressModule : ILoadingProgressModule, ITickable
    {
        private List<LoadingProgressData> _loadingData = new List<LoadingProgressData>();

        public float Progress => _loadingData.Count == 0 ? LoadingProgressData.MaxProgress : _loadingData.Sum(l => l.Progress) / _loadingData.Count;

        public bool IsDone => Progress >= LoadingProgressData.MaxProgress;

        public void Add(LoadingProgressData loadingData)
        {
            _loadingData.Add(loadingData);
        }

        public void Tick()
        {
            if (Progress >= LoadingProgressData.MaxProgress)
            {
                _loadingData.Clear();
            }
        }
    }
}