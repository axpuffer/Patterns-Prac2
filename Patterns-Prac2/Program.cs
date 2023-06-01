using System;
using System.Collections.Generic;

namespace Patterns
{
    // Прототип
    public abstract class DesignPrototype
    {
        public string color;
        public string size;
        public abstract DesignPrototype Clone();
    }

    // Конкретный прототип
    class Design : DesignPrototype
    {

        public Design(string color, string size)
        {
            this.color = color;
            this.size = size;
        }

        public override DesignPrototype Clone()
        {
            Console.WriteLine($"Добавлен свитер: цвет - {color}, размер одежды - {size}");

            return (DesignPrototype)this.MemberwiseClone();
        }


    }
    // Система компонентов внутри подсистемы магазина
    class ShopComponents
    {
        public void SearchProduct(string keyword)
        {
            Console.WriteLine($"Поиск товара по ключевому слову: {keyword}");
        }

        public void AddToCart(string productId)
        {
            Console.WriteLine($"Добавление товара в корзину, ID товара: {productId}");
        }

        public void ChoosePaymentMethod(string method)
        {
            Console.WriteLine($"Способ оплаты: {method}");
        }

        public void Checkout()
        {
            Console.WriteLine("Проверка корзины");
        }
    }

    // Фасад
    class ShopFacade
    {
        private ShopComponents shopComponents;

        public ShopFacade()
        {
            shopComponents = new ShopComponents();
        }

        public void BuyProduct(string keyword, string productId, string method)
        {
            shopComponents.SearchProduct(keyword);
            shopComponents.AddToCart(productId);
            shopComponents.ChoosePaymentMethod(method);
            shopComponents.Checkout();
        }
    }
    interface IObserver
    {
        void Update(string message);
    }

    // Интерфейс для наблюдаемого товара
    interface IObservable
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void NotifyObservers(string message);
    }

    // Наблюдаемый товар
    class ProductObservable : IObservable
    {
        private List<IObserver> observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }

        public void ChangePrice(decimal newPrice)
        {
            NotifyObservers("Цена в корзине изменилась. Новая цена - " + newPrice);
        }
    }

    // Наблюдатель
    class CustomerObserver : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine("Получено изменение: " + message);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Cоздание одежды с различным дизайном
            DesignPrototype designPrototype1 = new Design("черный", "S");
            DesignPrototype designPrototype2 = new Design("красный", "M");

            //Создание
            ShopFacade shopFacade = new ShopFacade();
            shopFacade.BuyProduct("Свитер", "339564", "картой при получении");

            //Клонирование добавленной в корзину одежды
            DesignPrototype clonedProduct1 = designPrototype1.Clone();
            DesignPrototype clonedProduct2 = designPrototype2.Clone();

            //Создание товара для отслеживания цены
            ProductObservable productObservable = new ProductObservable();

            //Создание клиентов и прикрепление их к товару
            CustomerObserver customerObserver1 = new CustomerObserver();
            CustomerObserver customerObserver2 = new CustomerObserver();
            productObservable.Attach(customerObserver1);
            productObservable.Attach(customerObserver2);

            //Смена цены и получение уведомлений клиентами
            productObservable.ChangePrice(2999);

            //Открепление клиента от отслеживаемого товара
            productObservable.Detach(customerObserver2);

            productObservable.ChangePrice(2499);
        }
    }

}
