using System;

using System.Collections.Generic;



namespace GangOfFour.Decorator.RealWorld

{

    /// <summary>

    /// MainApp startup class for Real-World 

    /// Decorator Design Pattern.

    /// </summary>

    class MainApp

    {
        public static BurgerThree BurgerThree { get; private set; }

        /// <summary>

        /// Entry point into console application.

        /// </summary>

        static void Main()

        {

            // Create BurgerOne

            BurgerOne BurgerOne = new BurgerOne("Classic", "300grams", 12.50);

            BurgerOne.Display();



            // Create BurgerTwo

            BurgerTwo BurgerTwo = new BurgerTwo("Classic with cheese", "400grams", 15.30);

            BurgerTwo.Display();

            //Create BurgerThree


            BurgerThree BurgerThree = new BurgerThree("Classic with eggs", "400grams" , 15.50);

            BurgerThree.Display();



            // Make BurgerTwo rented, then rent and display

            Console.WriteLine("\nReceived Order:");



            Order orderBurgerTwo = new Order(BurgerTwo);

            orderBurgerTwo.orderBurger("Ivan Atanasov");





            orderBurgerTwo.Display();



            // Wait for user

            Console.ReadKey();

        }

    }



    /// <summary>

    /// The 'Component' abstract class

    /// </summary>

    abstract class LibraryItem

    {

        private double price;



        // Property

        public double _price

        {

            get { return price; }

            set { price = value; }

        }



        public abstract void Display();

    }



    /// <summary>

    /// The 'ConcreteComponent' class

    /// </summary>

    class BurgerOne : LibraryItem

    {

        private string _burger;

        private string _grams;



        // Constructor

        public BurgerOne(string burger, string grams, double price)

        {

            this._burger = burger;

            this._grams = grams;

            this._price = price;

        }



        public override void Display()

        {

            Console.WriteLine("\nBurgerOne ------ ");

            Console.WriteLine(" Burger: {0}", _burger);

            Console.WriteLine(" Grams: {0}", _grams);

            Console.WriteLine(" price: {0}", _price);

        }

    }



    /// <summary>

    /// The 'ConcreteComponent' class

    /// </summary>

    class BurgerTwo : LibraryItem

    {

        private string _burger;

        private string _grams;

        private double price;



        // Constructor

        public BurgerTwo(string burger, string grams, double price)

        {

            this._burger = burger;

            this._grams = grams;

            this._price = price;



        }



        public override void Display()

        {

            Console.WriteLine("\nBurgerTwo ----- ");

            Console.WriteLine(" Burger: {0}", _burger);

            Console.WriteLine(" Grams: {0}", _grams);

            Console.WriteLine(" price: {0}", _price);



        }

    }

    class BurgerThree: LibraryItem

    {

    private string _burger;

    private string _grams;

    private double price;


    public BurgerThree(string burger, string grams, double price)

    {

        this._burger = burger;

        this._grams = grams;

        this._price = price;

    }



    public override void Display()

    {

        Console.WriteLine("\nBurgerThree ------ ");

        Console.WriteLine(" Burger: {0}", _burger);

        Console.WriteLine(" Grams: {0}", _grams);

        Console.WriteLine(" price: {0}", _price);

    }

}




/// <summary>

/// The 'Decorator' abstract class

/// </summary>

abstract class Decorator : LibraryItem

    {

        protected LibraryItem libraryItem;



        // Constructor

        public Decorator(LibraryItem libraryItem)

        {

            this.libraryItem = libraryItem;

        }



        public override void Display()

        {

            libraryItem.Display();

        }

    }



    /// <summary>

    /// The 'ConcreteDecorator' class

    /// </summary>

    class Order : Decorator

    {

        protected List<string> customer = new List<string>();



        // Constructor

        public Order(LibraryItem libraryItem)

          : base(libraryItem)

        {

        }



        public void orderBurger(string name)

        {

            customer.Add(name);

            libraryItem._price--;

        }



        public void OrderReceived(string name)

        {

            customer.Remove(name);

            libraryItem._price++;

        }



        public override void Display()

        {

            base.Display();



            foreach (string customers in customer)

            {

                Console.WriteLine(" Customer: " + customers);

            }

        }

    }

}
