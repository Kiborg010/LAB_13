using ClassLibrary1;
using LAB_13;
using System.Collections.ObjectModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        MyObservableCollection<Car> col = new MyObservableCollection<Car>(4, "������ ���������");
        Journal journal1 = new Journal();
        Journal journal2 = new Journal();


        [TestMethod]
        public void JournalEntryToString()
        {
            col.CollectionCountChanged += journal1.WriteRecord;
            col.CollectionReferenceChanged += journal2.WriteRecord;
            Car car = new Car();
            col.Add(car);
            Car car1 = new Car("1", 2000, "1", 1, 1, 1);
            col[car] = car1;
            Assert.AreEqual(journal1.journal[0].ToString(), $"����� ��������\n\t������ ���������\n\t��������� ���������e ��������\n\t����� ����������: |�����: No brend| ���: 2024| ����: No colour| ����: 0 ������| �������� �������: 1 ��| id: 0|");
            Assert.AreEqual(journal2.journal[0].ToString(), $"����� ��������\n\t������ ���������\n\t��������� ������ ��������\n\t����� ����������: |�����: No brend| ���: 2024| ����: No colour| ����: 0 ������| �������� �������: 1 ��| id: 0|");
        }

        [TestMethod]
        public void JournalRemove()
        {
            Car car = new Car();
            col.Add(car);
            bool flag = col.Remove(car);
            Assert.AreEqual(flag, true);
        }

        [TestMethod]
        public void MyObservableCollectionReplaceOne()
        {
            col.CollectionCountChanged += journal1.WriteRecord;
            col.CollectionReferenceChanged += journal2.WriteRecord;
            Car car = new Car();
            col.Add(car);
            Car car1 = new Car("1", 2000, "1", 1, 1, 1);
            Car car2 = new Car("1", 2001, "1", 1, 1, 1);
            string message = "";
            try
            {
                col[car2] = car1;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            Assert.AreEqual(message, "������� ������� �� ������");
        }

        [TestMethod]
        public void MyObservableCollectionReplaceTwo()
        {
            col.CollectionCountChanged += journal1.WriteRecord;
            col.CollectionReferenceChanged += journal2.WriteRecord;
            Car car = new Car();
            col.Add(car);
            Car car1 = new Car("1", 2000, "1", 1, 1, 1);
            Car car2 = new Car("1", 2001, "1", 1, 1, 1);
            string message = "";
            try
            {
                Car el = col[car2];
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            Assert.AreEqual(message, "������� ������� �� ������");
        }

        [TestMethod]
        public void MyObservableCollectionReplaceThree()
        {
            col.CollectionCountChanged += journal1.WriteRecord;
            col.CollectionReferenceChanged += journal2.WriteRecord;
            Car car = new Car();
            col.Add(car);
            Car car1 = new Car("1", 2000, "1", 1, 1, 1);
            Car car2 = new Car("1", 2001, "1", 1, 1, 1);
            Car el = col[car];
            Assert.AreEqual(car, el);
        }

    }
}