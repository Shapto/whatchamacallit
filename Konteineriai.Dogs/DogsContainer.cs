using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konteineriai.Dogs
{
    class DogsContainer
    {
        private Dog[] dogs;
        public int Count { get; private set; }
        public DogsContainer()
        {
            this.dogs = new Dog[16];//default capacity
        }
        public void Add(Dog dog)
        {
            if (this.Count == this.Capacity)//if container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.dogs[this.Count++] = dog;
        }
        public Dog Get(int index)
        {
            return this.dogs[index];
        }
        public void Put(Dog dog, int index) //put element into specified spot
        {
            if (index >= this.Capacity)//if container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.dogs[index] = dog;
        }
        public void Insert(Dog dog, int index) //insert element into specified spot without overwriting
        {
            Dog[] temp = new Dog[index + 1];
            for (int i = 0; i < this.Count + 1; i++)
            {
                if (i < index - 1)
                {
                    temp[i] = this.dogs[i];
                }
                else if (i == index - 1)
                {
                    temp[i] = dog;
                }
                else
                {
                    temp[i] = this.dogs[i-1];
                }
            }
            this.dogs = temp;
        }
        public void Remove(Dog dog) //remove elements from container by criteria
        {

        }
        public void RemoveAt(int index) //remove by index
        {
            Dog[] temp = new Dog[this.Count];
            for (int i = 0; i < this.Count + 1; i++)
            {
                if (i < index - 1)
                {
                    temp[i] = this.dogs[i];
                }
                else if (i == index)
                {
                    temp[i] = this.dogs[i+1];
                }
                else
                {
                    temp[i] = this.dogs[i - 1];
                }
            }
        }
        public bool Contains(Dog dog)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.dogs[i].Equals(dog))
                {
                    return true;
                }
            }
            return false;
        }
        private int Capacity;
        public DogsContainer(int capacity = 16)//default size
        {
            this.Capacity = capacity;
            this.dogs = new Dog[capacity];
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Dog[] temp = new Dog[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.dogs[i];
                }
                this.Capacity = minimumCapacity;
                this.dogs = temp;
            }
        }
    }
}
