using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using LAB_12_4;

namespace LAB_13
{

    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);

    public class MyObservableCollection<T>: MyCollection<T> where T : IInit, ICloneable, new()
    {
        public string Name { get; set; }

        public MyObservableCollection(int size, string name) : base(size)
        {
            Name = name;
        }

        public event CollectionHandler CollectionCountChanged;

        public void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            CollectionCountChanged?.Invoke(source, args);
        }

        public event CollectionHandler CollectionReferenceChanged;

        public void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            CollectionReferenceChanged?.Invoke(source, args);
        }

        public new void Add(T item)
        {
            base.Add(item);
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs("Произошло добавлениe элемента", item));
        }

        public new bool Remove(T item)
        {
            bool isRemove = base.Remove(item);
            if (isRemove) { OnCollectionCountChanged(this, new CollectionHandlerEventArgs("Произошло удаление элемента", item)); }
            return isRemove;
        }

        public T this[T element]
        {
            get
            {
                if (!Contains(element))
                {
                    throw new ArgumentException("Ввёдённый элемент не найден");
                }
                else
                {
                    return element;
                }
            }
            set
            {
                if (!Contains(element))
                {
                    throw new ArgumentException("Ввёдённый элемент не найден");
                }
                else
                {
                    int index = FindItem(element);
                    object previous = tableValue[index].Clone();
                    tableValue[index] = value;
                    OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs("Произошла замена элемента", previous));
                }
            }
        }
    }
}
