using System.Globalization;

namespace RxUI6WithAutofac
{
    /// <summary>
    /// Such thread safety.
    /// </summary>
    public static class ViewModelInstanceCount
    {
        private static int _instanceCount;

        public static string InstanceCount
        {
            get { return _instanceCount.ToString(CultureInfo.InvariantCulture); }
        }

        public static void Increment()
        {
            _instanceCount++;
        }
    }
}