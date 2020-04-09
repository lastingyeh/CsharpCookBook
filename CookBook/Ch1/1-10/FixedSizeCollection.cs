using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch1._1_10
{
    public class FixedSizeCollection
    {
        public static int InstanceCount { get; set; }
        public int ItemCount { get; private set; }
        private object[] Items { get; set; }

        public FixedSizeCollection(int maxItems)
        {
            FixedSizeCollection.InstanceCount++;
            this.Items = new object[maxItems];
        }

        public int AddItem(object item)
        {
            if (this.ItemCount < this.Items.Length)
            {
                this.Items[this.ItemCount] = item;
                return this.ItemCount++;
            }
            throw new Exception("Item queue is full");
        }

        public object GetItem(int index)
        {
            if (index >= this.Items.Length && index >= 0)
                throw new ArgumentOutOfRangeException(nameof(index));
            return this.Items[index];
        }

        public override string ToString() =>
            $"There are {FixedSizeCollection.InstanceCount.ToString()} instances of {this.GetType().ToString()} and this instance contains {this.ItemCount} items...";
    }

    public class FixedSizeCollection<T>
    {
        public static int InstanceCount { get; set; }
        public int ItemCount { get; private set; }
        private T[] Items { get; set; }

        public FixedSizeCollection(int items)
        {
            FixedSizeCollection<T>.InstanceCount++;
            this.Items = new T[items];
        }

        public int AddItem(T item)
        {
            if (this.ItemCount < this.Items.Length)
            {
                this.Items[this.ItemCount] = item;
                return this.ItemCount++;
            }
            throw new Exception("Item queue is full");
        }

        public T GetItem(int index)
        {
            if (index >= this.Items.Length && index >= 0)
                throw new ArgumentOutOfRangeException(nameof(index));
            return this.Items[index];
        }

        public override string ToString() => $"There are {FixedSizeCollection<T>.InstanceCount.ToString()} instances of {this.GetType().ToString()} and this instance contains {this.ItemCount} items...";

    }
}
