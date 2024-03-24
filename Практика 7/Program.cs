using System.Net.Sockets;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace Практика_7
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

    }

    //Аккаунт магазина для перевода денег
    class ShopAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WalletMony { get; set; }
        public ShopAccount(int Id)
        {
            Id = Id;
        }
    }

    //аккаунт человека, кто делает заказ
    class UserAccount : ShopAccount 
    {
        public UserAccount(int Id) : base(Id) { }
    }

    //Перевод денег для покупки
    class Transaction<T> where T : ShopAccount
    {
        public T ShopAcc {  get; set; }
        public T UserAcc {  get; set; }
        public int Transactioin { get; set; }
        public void CheckTransaction()
        {
            if (UserAcc.WalletMony > Transactioin)
            {
                UserAcc.WalletMony -= Transactioin;
                ShopAcc.WalletMony += Transactioin;
            }
        }
    }

    //абстрактный класс доставки
    abstract class Delivery
    {
        public abstract string Address { get; set; }

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

        public static void HDelivery()
        {
            //Дополнительный метод в классе доставки на дом 
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
            Console.WriteLine($"ВВедите цифрой адрес пункта выдачи товаров из списка:\n1. {pDelyvery[0]};\n2. {pDelyvery[1]};\n3. {pDelyvery[2]}.");
            address = Console.ReadLine();
        }

        public void PPDelivery()
        {
            //Дополнительный метод в классе доставки в пункт выдачи
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
            //Дополнительный метод в классе доставки в розничный магазин
        }
    }

    //Товар
    class Order<TDelivery, TStruct, TNumber> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public string[] Product =
        {
            "Товар 1",
            "Товар 2",
            "Товар 3",
            "Товар 4",
            "Товар 5",
            "Товар 6",
            "Товар 7",
            "Товар 8",
            "Товар 9",
            "Товар 10"
        };

        //закупка товара
        public void Purchase()
        {
            Console.WriteLine("Выберете товар из списка");
            int i = 0;
            foreach (var item in Product)
            {
                Console.WriteLine($"{++i}. {item}\n");

                string[] ProductOrder = new string[i];

                for (int j = 0; j < ProductOrder.Length; j++)
                {
                    ProductOrder[j] = Console.ReadLine();
                }
            }
        }
        //номер заказа
        public TNumber Number;
        public void NumberProduct(TNumber Number)
        {
            Console.WriteLine($"Номер Вашего заказа: {Number}");
        }
        //Описание товара
        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }
    }

}
