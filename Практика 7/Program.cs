using System.Net.Sockets;
using System.Numerics;

namespace Практика_7
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        abstract class Delivery
        {
            public abstract string Address
            {
                get;
                set;
            }

            abstract public void ChooseDelivery();
        }
        //Доставка продуктов на дом
        class HomeDelivery : Delivery
        {
            private string address;

            public override string Address
            {
                get 
                {
                    return address;
                }
                set
                {
                    address = value;
                }
            }

            public override void ChooseDelivery()
            {
                Console.WriteLine("ВВедите адрес доставки: ");
                address = Console.ReadLine();
            }

            public void HDelivery()
            {
                Console.WriteLine("Выберите тип доставки:\n1. В течении часа;\n2. В течении рабочего дня.");
            }
        }
        //Доставка продуктов в пункт выдачи
        class PickPointDelivery : Delivery
        {
            private string address;

            public override string Address
            {
                get
                {
                    return address;
                }
                set
                {
                    address = value;
                }
            }

            string[] pDelyvery = 
            {
                "Улица Пункта выдачи 1",
                "Улица Пункта выдачи 2",
                "Улица Пункта выдачи 3",
            };

            public override void ChooseDelivery()
            {
                Console.WriteLine($"ВВедите цифрой адрес пункта выдачи товаров из списка:\n1. {pDelyvery[0]};\n2. {pDelyvery[1]};\n3. { pDelyvery[2]}.");
                address = Console.ReadLine();
            }



            public void PPDelivery()
            {
                Console.WriteLine("Вы выбрали доставку в пункт выдачи.");
            }
        }
        //Доставка продуктов в розничный магазин
        class ShopDelivery : Delivery
        {
            private string address;

            public override string Address
            {
                get
                {
                    return address;
                }
                set
                {
                    address = value;
                }
            }

            string[] sDelyvery =
            [
                "Улица Магазинная 1",
                "Улица Магазинная 2",
            ];

            public override void ChooseDelivery()
            {
                Console.WriteLine($"Выберетие цифрой адрес розничного магазина:\n1. {sDelyvery[0]};\n2. {sDelyvery[1]}.");
                address = Console.ReadLine();
            }

            public void SDelivery()
            {
                Console.WriteLine("Вы выбрали доставку в магазин.");
            }
        }

        class Order<TDelivery, TStruct> where TDelivery : Delivery
        {
            public TDelivery Delivery;

            public int Number;

            public string Destription;

            public void DisplayAddres()
            {
                Console.WriteLine(Delivery.Address);
            }
        }

    }
}