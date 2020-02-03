namespace BerlinClock.App.Converters
{
    public abstract class BaseConverter
    {
        protected abstract void Validate(int value);
        protected abstract string PrepareResponse();

        protected void UpdateRow(string[] arr, int counter, string color)
        {
            for (int i = 0; i < counter; i++)
            {
                arr[i] = color;
            }
        }
    }
}
