namespace Inventory
{
    public interface INavigationService
    {
        void Navigate(object token);
        bool CanGoBack { get; }
    }
}