
namespace Net02_3
{
    [TrackingEntity]
    internal class ClassForChecking
    {
        [TrackingProperty]
        string _value;

        [TrackingProperty]
        public int Value1 { get; }

        [TrackingProperty]
        public int Value2 { get; }

        public ClassForChecking(string value,int value1, int value2)
        {
            _value = value; 
            Value1 = value1;
            Value2 = value2;
        }
    }
}
