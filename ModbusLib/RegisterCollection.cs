using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace ModbusLib
{
    public class RegisterCollection<T> : Collection<T>, INotifyCollectionChanged where T : Register
    {
        protected override void ClearItems()
        {
            base.ClearItems();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        protected override void InsertItem(int index, T item)
        {
            if (this.Any(x => x.Address == item.Address))
                throw new ArgumentException("Адрес регистра не уникальный.");

            base.InsertItem(index, item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new[] { item }, index));
        }

        protected override void RemoveItem(int index)
        {
            var removed = this[index];
            base.RemoveItem(index);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, new[] { removed }));
        }

        protected override void SetItem(int index, T item)
        {
            var old = this[index];

            if (this.Any(x => x.Address == item.Address && x != old))
                throw new ArgumentException("Адрес регистра не уникальный.");

            base.SetItem(index, item);
            CollectionChanged?.Invoke(this,
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, new[] { item }, new[] { old }));
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}
