namespace leave_management.ExtensionMethods
{
    public static class ObjectExtensions
    {
        public static bool HasValue(this object obj)
        {
            return obj != null;
        }
    }
}