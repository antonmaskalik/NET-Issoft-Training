using System;

namespace Net02_3
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    internal class TrackingPropertyAttribute : Attribute
    { }
}