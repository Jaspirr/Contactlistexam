using Contactlist.Models;
using Contactlist.Services;
using Xceed.Wpf.Toolkit;

namespace ContactList.Tests__nUnit
{
    public class Calculator_Tests
    {
        private Contact contact;
        public FileService FileService { get; private set; }
        public MenuService Calculator { get; private set; }

        [SetUp]
        public void Setup()
        {
            // arrange
            Calculator = new MenuService();
            Contact contact = new Contact();
            
        }

        [Test]
        public void Should_Add_Contact_To_List()
        {
            // act
            Calculator.contacts.Add(contact);
            Calculator.contacts.Add(contact);

            Assert.That(Calculator.contacts.Count, Is.EqualTo(2));
        }
        [Test]
        public void Should_Remove_Contact_From_List()
        {
            Calculator.contacts.Add(contact);
            Calculator.contacts.Add(contact);

            Calculator.contacts.Remove(contact);

            Assert.That(Calculator.contacts, Does.Not.Contain(contact));
        }
    }
}