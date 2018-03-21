using System;
using System.Net;
using System.Text;

namespace Vostok.Commons.Binary
{
    // TODO(krait): Replace with implementations from old Vostok.Core: https://github.com/vostok/core/tree/master/Vostok.Core/Commons/Binary
    public interface IBinaryDeserializer
    {
        int Position { get; set; }
        bool CanSeek { get; }

        short ReadInt16();
        int ReadInt32();
        long ReadInt64();
        ushort ReadUInt16();
        uint ReadUInt32();
        uint ReadVariableLengthUInt32();
        ulong ReadVariableLengthUInt64();
        ulong ReadUInt64();
        float ReadFloat();
        double ReadDouble();
        bool ReadBool();
        byte ReadByte();
        byte[] ReadByteArray();
        string ReadString();
        string ReadString(Encoding encoding);
        Guid ReadGuid();
        IPAddress ReadIPAddress();
        IPEndPoint ReadIPEndPoint();
        TimeSpan ReadTimeSpan();
        DateTime ReadDateTime();
    }
}