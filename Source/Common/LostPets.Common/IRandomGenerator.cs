namespace LostPets.Common
{
    public interface IRandomGenerator
    {
        string RandomString(int minLength, int maxLength);

        int RandomNumber(int min, int max);
    }
}
