using NUnit.Framework;
using System;

namespace Dev2
{
    [TestFixture]
    public class ConverterToPhonemesTest
    {
        [TestCase("молоко+", "малако")]
        [TestCase("ёлка", "йолка")]
        [TestCase("сде+лать", "зд'элат'")]
        [TestCase("ме+сто", "м'эста")]
        public void Convert_Word_ReturnsPhonemes(string inputString, string expectedString)
        {
            ConverterToPhonemes converter = new ConverterToPhonemes(inputString);
            var actual = converter.ConvertToPhenomes();
            Assert.AreEqual(expectedString, actual);
        }

        [TestCase("")]
        [TestCase(" ")]
        public void Convert_EmptyString_ThrowsException(string inputString)
        {
            Assert.Throws<Exception>(() => new ConverterToPhonemes(inputString));
        }

        [TestCase]
        public void Convert_Null_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => new ConverterToPhonemes(null));
        }

        [TestCase("а+")]
        [TestCase("я")]
        public void Convert_LessThenTwoLetters_ThrowsArgumentOutOfRangeException(string inputString)
        {
            ConverterToPhonemes converter = new ConverterToPhonemes(inputString);
            Assert.Throws<ArgumentOutOfRangeException>(() => converter.ConvertToPhenomes());
        }

        [TestCase("иглк")]
        [TestCase("мо+ло+ко")]
        [TestCase("+правда+")]
        [TestCase("ёж+")]
        public void Convert_IncorrectWord_ThrowsException(string inputString)
        {
            Assert.Throws<Exception>(() => new ConverterToPhonemes(inputString));
        }

        [TestCase("milk")]
        [TestCase("#")]
        [TestCase("3")]
        [TestCase("+")]
        public void Convert_NonCyrillicSymbols_ThrowsException(string inputString)
        {
            Assert.Throws<Exception>(() => new ConverterToPhonemes(inputString));
        }
    }
}