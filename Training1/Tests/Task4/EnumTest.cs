using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainig1.Task4;

namespace Training1.Tests.Task4
{
    struct IStub : IConvertible
    {
        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
    }

    [TestFixture]
    public class EnumTest
    {
        private void ExceptionMethod()
        {
            System.Array array = Enum<IStub>.SortedValues;
        }

        [Test]
        public void SortedValuesExceptionTest()
        {
            Assert.Throws<ArgumentException>(() => this.ExceptionMethod());
        }

        [TestCase(new object[] { "Blue", "Black", "Red", "Yellow", "Grey", "Green" })]
        public void SortedValuesTest(object[] correctArray)
        {
            System.Array array = Enum<Colors>.SortedValues;

            string[] test = new string[array.Length];
            int i = 0;
            foreach (var item in array)
            {
                test[i] = item.ToString();
                i++;
            }

            string[] correctArray1 = correctArray.Cast<string>().ToArray();
            bool result = correctArray.SequenceEqual(test);
            Assert.IsTrue(result);
        }
    }
}
