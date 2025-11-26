using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    class DogsContainer
    {
        private Dog[]dogs;

        public int Count { get; private set; }

        private int Capacity;
        public DogsContainer()
        {
            this.dogs = new Dog[16];//default capacity
        }

        public DogsContainer(int capacity = 16)//default size
        {
            this.Capacity = capacity;
            this.dogs = new Dog[capacity];
        }

        public DogsContainer(DogsContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(new Dog(container.Get(i)));
            }
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
            if (index >= this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }   
            Dog[] temp = new Dog[index + 1];
            for (int i = 0; i < this.Count + 1; i++)
            {
                if (i < index - 1)
                {
                    temp[i] = this.dogs[i];
                }
                else if (i == index)
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
            for (int i = 0; i < this.Count - 1; i++)
            {
                if (this.dogs[i] == dog)
                {
                    dogs[i] = dogs[i+1];
                }
            }
            Count--;
        }

        public void RemoveAt(int index) //remove by index
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                dogs[i] = dogs[i+1];
            }
            Count--;
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

        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Dog a = this.dogs[i];
                    Dog b = this.dogs[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.dogs[i] = b;
                        this.dogs[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
    }
}
