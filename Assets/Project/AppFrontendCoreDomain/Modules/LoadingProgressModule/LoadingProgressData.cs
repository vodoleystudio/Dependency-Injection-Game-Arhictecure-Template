namespace Project.AppFrontendCoreDomain.Modules
{
    public class LoadingProgressData
    {
        public const float MaxProgress = 1f;
        private const float MinProgress = 0f;

        public float Progress { get; set; } = MinProgress;
    }
}