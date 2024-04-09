namespace _01_ChainOfResponsibility
{
    public interface ISupportHandler
    {
        void HandleRequest(UserRequest request);
    }
}