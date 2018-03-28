using System;
using System.Collections.Generic;
using System.Text;

namespace Vostok.Commons.Binary
{
    public static class BinaryWriterExtensions
    {
        public static IBinaryWriter Write(this IBinaryWriter writer, string value)
        {
            writer.Write(value, Encoding.UTF8);
            return writer;
        }

        public static IBinaryWriter WriteWithoutLengthPrefix(this IBinaryWriter writer, string value)
        {
            writer.WriteWithoutLengthPrefix(value, Encoding.UTF8);
            return writer;
        }

        public static IBinaryWriter Write(this IBinaryWriter writer, TimeSpan value)
        {
            writer.Write(value.Ticks);
            return writer;
        }

        public static IBinaryWriter WriteCollection<T>(
            this IBinaryWriter writer,
            IReadOnlyCollection<T> values,
            Action<IBinaryWriter, T> writeSingleValue)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            writer.Write(values.Count);

            foreach (var value in values)
            {
                writeSingleValue(writer, value);
            }

            return writer;
        }

        public static IBinaryWriter WriteDictionary<TKey, TValue>(
            this IBinaryWriter writer,
            IReadOnlyDictionary<TKey, TValue> values,
            Action<IBinaryWriter, TKey> writeSingleKey,
            Action<IBinaryWriter, TValue> writeSingleValue)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            writer.Write(values.Count);

            foreach (var pair in values)
            {
                writeSingleKey(writer, pair.Key);
                writeSingleValue(writer, pair.Value);
            }

            return writer;
        }

        public static IBinaryWriter WriteDictionary<TKey, TValue>(
            this IBinaryWriter writer,
            IDictionary<TKey, TValue> values,
            Action<IBinaryWriter, TKey> writeSingleKey,
            Action<IBinaryWriter, TValue> writeSingleValue)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            writer.Write(values.Count);

            foreach (var pair in values)
            {
                writeSingleKey(writer, pair.Key);
                writeSingleValue(writer, pair.Value);
            }

            return writer;
        }

        public static IBinaryWriter WriteNullable<T>(this IBinaryWriter writer, T value, Action<IBinaryWriter, T> writeNonNullValue)
            where T : class
        {
            writer.Write(value != null);

            if (value != null)
                writeNonNullValue(writer, value);

            return writer;
        }

        public static IBinaryWriter WriteNullable<T>(this IBinaryWriter writer, T? value, Action<IBinaryWriter, T> writeNonNullValue)
            where T : struct
        {
            writer.Write(value != null);

            if (value != null)
                writeNonNullValue(writer, value.Value);

            return writer;
        }
    }
}
