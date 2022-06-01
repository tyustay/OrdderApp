using NUnit.Framework;
using System;

namespace UnitTest
{
    public class Tests
    {
        private object btnSubmit_Click;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void button5_Click(object sender, EventArgs e)
        {
            if (btnSubmit_Click == "qwerty") // вот это тестить хочу
            {
                AdForm adForm = new AdForm(this);
                adForm.Show();
                this.Hide();
            }
        }

        private void Hide()
        {
            throw new NotImplementedException();
        }
    }

    internal class AdForm
    {
        public AdForm(Tests tests)
        {
            Tests = tests;
        }

        public Tests Tests { get; }

        internal void Show()
        {
            throw new NotImplementedException();
        }
    }
}