namespace _CharacterController.Interfaces
{
    internal interface IPlayerInput
    {
        float movX { get; }
        float movZ { get; }
        bool jump { get; }

        void ReadInput();
    }
}
