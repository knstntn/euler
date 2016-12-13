using System.Collections.Generic;
using NUnit.Framework;

namespace CCI
{
    public class AnimalShelter
    {
        private AnimalNode catsHead;
        private AnimalNode catsTail;

        private AnimalNode dogsHead;
        private AnimalNode dogsTail;

        public Animal DequeueAny()
        {
            if (catsHead != null && dogsHead != null)
            {
                return catsHead.Length > dogsHead.Length ? DequeueCat() :DequeueDog();
            }

            if (catsHead != null)
            {
                return DequeueCat();
            }

            return DequeueDog();
        }

        public Animal DequeueCat()
        {
            if (catsHead != null)
            {
                var animal = catsHead.Animal;
                var length = catsHead.Length - 1;
                catsHead = catsHead.Next;
                if (catsHead != null)
                {
                    catsHead.Length = length;
                }
                return animal;
            }

            return null;
        }

        public Animal DequeueDog()
        {
            if (dogsHead != null)
            {
                var animal = dogsHead.Animal;
                var length = dogsHead.Length - 1;
                dogsHead = dogsHead.Next;
                if (dogsHead != null)
                {
                    dogsHead.Length = length;
                }
                return animal;
            }

            return null;
        }

        public void Enqueue(Animal animal)
        {
            if (animal.Type == AnimalType.Cat)
            {
                if (catsTail != null)
                {
                    catsTail.Next = new AnimalNode {Animal = animal};
                    catsTail = catsTail.Next;
                    catsHead.Length++;
                }
                else
                {
                    catsHead = new AnimalNode {Animal = animal, Length = 1};
                    catsTail = catsHead;
                }
            }
            else if (animal.Type == AnimalType.Dog)
            {
                if (dogsTail != null)
                {
                    dogsTail.Next = new AnimalNode {Animal = animal};
                    dogsTail = catsTail.Next;
                    dogsTail.Length++;
                }
                else
                {
                    dogsHead = new AnimalNode {Animal = animal, Length = 1};
                    dogsTail = dogsHead;
                }
            }
        }

        private class AnimalNode
        {
            public Animal Animal { get; set; }
            public int Length { get; set; }
            public AnimalNode Next { get; set; }
        }

        [TestFixture]
        public class AnimalShelterTests
        {
            [Test]
            public void Test1()
            {
                var st = new AnimalShelter();
                st.Enqueue(new Animal("1", AnimalType.Cat));
                st.Enqueue(new Animal("2", AnimalType.Cat));
                st.Enqueue(new Animal("3", AnimalType.Cat));

                var a = st.DequeueAny();
                Assert.AreEqual("1", a.Name);
                Assert.AreEqual(AnimalType.Cat, a.Type);

                a = st.DequeueAny();
                Assert.AreEqual("2", a.Name);
                Assert.AreEqual(AnimalType.Cat, a.Type);

                a = st.DequeueAny();
                Assert.AreEqual("3", a.Name);
                Assert.AreEqual(AnimalType.Cat, a.Type);
            }

            [Test]
            public void Test2()
            {
                var st = new AnimalShelter();
                st.Enqueue(new Animal("1", AnimalType.Cat));
                st.Enqueue(new Animal("2", AnimalType.Cat));
                st.Enqueue(new Animal("3", AnimalType.Cat));

                var a = st.DequeueAny();
                Assert.AreEqual("1", a.Name);
                Assert.AreEqual(AnimalType.Cat, a.Type);

                st.Enqueue(new Animal("4", AnimalType.Dog));

                a = st.DequeueAny();
                Assert.AreEqual("2", a.Name);
                Assert.AreEqual(AnimalType.Cat, a.Type);

                a = st.DequeueDog();
                Assert.AreEqual("4", a.Name);
                Assert.AreEqual(AnimalType.Dog, a.Type);

                a = st.DequeueAny();
                Assert.AreEqual("3", a.Name);
                Assert.AreEqual(AnimalType.Cat, a.Type);
            }

        }

    }

    public class Animal
    {
        public Animal(string name, AnimalType type)
        {
            Name = name;
            Type = type;
        }

        public AnimalType Type { get; set; }
        public string Name { get; set; }
    }

    public enum AnimalType
    {
        Cat,
        Dog
    }
}