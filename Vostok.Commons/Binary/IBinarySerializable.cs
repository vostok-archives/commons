namespace Vostok.Commons.Binary
{
    public interface IBinarySerializable
    {
        void SerializeBinary(IBinarySerializer serializer);
    }
}