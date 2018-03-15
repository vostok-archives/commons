using System;
using System.Net;
using System.Text;

namespace Vostok.Commons.Binary
{
    public interface IBinarySerializer
    {
        int Position { get; set; }
        bool CanSeek { get; }
        IBinarySerializer Seek(int position);
        IBinarySerializer SeekToEnd();

        IBinarySerializer Write(bool b);
        IBinarySerializer Write(byte b);
        IBinarySerializer Write(short i);
        IBinarySerializer Write(int i);
        IBinarySerializer Write(long i);
        IBinarySerializer Write(ushort i);
        IBinarySerializer Write(uint i);
        IBinarySerializer WriteVariableLength(uint i);
        IBinarySerializer WriteVariableLength(ulong i);
        IBinarySerializer Write(ulong i);
        IBinarySerializer Write(float f);
        IBinarySerializer Write(double d);
        IBinarySerializer Write(string s, Encoding encoding);
        IBinarySerializer Write(string s);
        IBinarySerializer Write(byte[] b, int byteOffset, int count);
        IBinarySerializer Write(byte[] b);
        IBinarySerializer Write(Guid guid);
        IBinarySerializer Write(IPAddress ip);
        IBinarySerializer Write(IPEndPoint endPoint);
        IBinarySerializer Write(TimeSpan ts);
        IBinarySerializer Write(DateTime dt);
    }
}