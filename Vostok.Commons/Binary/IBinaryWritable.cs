namespace Vostok.Commons.Binary
{
    public interface IBinaryWritable
    {
        void SerializeBinary(IBinaryWriter serializer);
    }
}