using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    class AnimalContainer
    {
        private Animal[] animals;

        public int Count { get; private set; }

        private int Capacity;
        public AnimalContainer()
        {
            this.animals = new Animal[16];//default capacity
        }

        public AnimalContainer(int capacity = 16)//default size
        {
            this.Capacity = capacity;
            this.animals = new Animal[capacity];
        }

        public AnimalContainer(AnimalContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                var animal = container.Get(i); 
            }
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Animal[] temp = new Animal[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.animals[i];
                }
                this.Capacity = minimumCapacity;
                this.animals = temp;
            }
        }

        public void Add(Animal dog)
        {
            if (this.Count == this.Capacity)//if container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.animals[this.Count++] = dog;
        }

        public Animal Get(int index)
        {
            return this.animals[index];
        }

        public void Put(Animal dog, int index) //put element into specified spot
        {
            if (index >= this.Capacity)//if container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.animals[index] = dog;
        }

        public void Insert(Animal dog, int index) //insert element into specified spot without overwriting
        {
            if (index >= this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }   
            Animal[] temp = new Animal[index + 1];
            for (int i = 0; i < this.Count + 1; i++)
            {
                if (i < index - 1)
                {
                    temp[i] = this.animals[i];
                }
                else if (i == index)
                {
                    temp[i] = dog;
                }
                else
                {
                    temp[i] = this.animals[i-1];
                }
            }
            this.animals = temp;
        }

        public void Remove(Animal dog) //remove elements from container by criteria
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                if (this.animals[i] == dog)
                {
                    animals[i] = animals[i+1];
                }
            }
            Count--;
        }

        public void RemoveAt(int index) //remove by index
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                animals[i] = animals[i+1];
            }
            Count--;
        }

        public bool Contains(Animal dog)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.animals[i].Equals(dog))
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
                    Animal a = this.animals[i];
                    Animal b = this.animals[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.animals[i] = b;
                        this.animals[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
    }
}
