
namespace Net01_1
{
    interface IVersionable
    {
        public void SetVersion(byte[] version);

        public byte[] GetVersion();
    }
}
