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

        public void Add(Animal animal)
        {
            if (this.Count == this.Capacity)
            {
                int newCapacity;
                if (this.Capacity == 0)
                {
                    newCapacity = 1;
                }
                else
                {
                    newCapacity = this.Capacity * 2;
                }
                EnsureCapacity(newCapacity);
            }
            this.animals[this.Count++] = animal;
        }

        public Animal Get(int index)
        {
            return this.animals[index];
        }

        public void Put(Animal animal, int index) //put element into specified spot
        {
            if (index >= this.Capacity)//if container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.animals[index] = animal;
        }

        public void Insert(Animal animal, int index) //insert element into specified spot without overwriting
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
                    temp[i] = animal;
                }
                else
                {
                    temp[i] = this.animals[i-1];
                }
            }
            this.animals = temp;
        }

        public void Remove(Animal animal) //remove elements from container by criteria
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                if (this.animals[i] == animal)
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

        public bool Contains(Animal animal)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.animals[i].Equals(animal))
                {
                    return true;
                }
            }
            return false;
        }
        
        public void Sort()
        {
            Sort(new AnimalsComparator());
        }
        public void Sort(AnimalsComparator comparator)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Animal a = this.animals[i];
                    Animal b = this.animals[i + 1];
                    if (comparator.Compare(a,b) > 0)
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
