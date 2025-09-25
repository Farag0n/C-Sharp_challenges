using System;
using System.Collections;
using System.Collections.Generic;

namespace AnaStore;

public class Store
{
    //Lista en la que se van a guardar todos los productos(ArrayList)
        static List<ArrayList> inventory = new List<ArrayList>();
        
        /*Caracteres para mejorar el estilo del menu de bienvenida
         con este metodo se piden dos valores un char y la cantidad
         de veces que se va a repetir*/
        static string welcomeStyle1 = new string('=', 83);
        static string welcomeStyle2 = new string('-', 84);
        static string welcomeStyle3 = new string('=', 35);
        
        //Carrito de compras global
        static List<ArrayList> shopingCart = new List<ArrayList>();
        
        
        //-------------------------------------------------------------------------------------
        //Metodo inicializador
        public static void OpenStore()
        {
            //Se crea un ArrayList por cada producto con nombre,precio y cantidad
            ArrayList product1 = new ArrayList() { "alfajor", 2.5, 32 };
            ArrayList product2 = new ArrayList() { "papas", 1.9, 12 };
            ArrayList product3 = new ArrayList() { "platanitos", 1.9, 23 };
            ArrayList product4 = new ArrayList() { "revolcon", 8.0, 56 };
            ArrayList product5 = new ArrayList() { "chicle", 2.0, 1 };
            
            //Se agregan los productos al inventario
            inventory.Add(product1);
            inventory.Add(product2);
            inventory.Add(product3);
            inventory.Add(product4);
            inventory.Add(product5);
            
            //Se llaman todos los metodos en orden al llamar este metodo
            welcome();
            showProducts();
            Console.WriteLine(welcomeStyle2);
            buyProducts();
        }
        
        
        //-------------------------------------------------------------------------------------
        //Metodo para dar el mensaje de bienvenida
        public static void welcome()
        {
            Console.WriteLine($"{welcomeStyle1}");
            Console.WriteLine(" --Bienvenido a la Tienda de Ana estos son los productos que tenemos disponibles-- ");
            Console.WriteLine($"{welcomeStyle1}\n{welcomeStyle2}");
        }
        

        //-------------------------------------------------------------------------------------
        //Metodo que muestra productos
        public static void showProducts()
        {
            foreach (ArrayList product in inventory)
            {
                Console.WriteLine($"| - {product[0]}, Precio: {product[1]}, Cantidad: {product[2]}");
            }
        }
        
        
        //-------------------------------------------------------------------------------------
        //Metodo para agregar al carrito
        public static void buyProducts()
        {
            //Variable para el estado del while
            bool status = true;
            
            //Variable para almacenar el producto elejido
            string chosenProduct;
            
            while (status)
            {
                Console.WriteLine($"{welcomeStyle3}");
                Console.WriteLine(" --Escriba el producto que desea (o escriba 'salir' para finalizar)-- ");
                Console.WriteLine(welcomeStyle3);
                
                chosenProduct = Console.ReadLine().ToLower();
                
                if (chosenProduct == "salir")
                {
                    status = false;
                    sumTotal();
                    break;
                }

                //Buscar producto en inventario
                bool found = false;
                
                //Se busca el producto en el inventario
                foreach (ArrayList product in inventory)
                {
                    //Si el producto existe se cambia el estado de la busqueda
                    if (product[0].ToString().ToLower() == chosenProduct)
                    {
                        found = true;
                        
                        Console.WriteLine("Ingrese la cantidad que desea:");
                        int qty = int.Parse(Console.ReadLine());

                        int stock = Convert.ToInt32(product[2]);
                        
                        //Se valida que la cantidad elegida no supere el stock
                        if (qty <= stock)
                        {
                            //Reducir inventario
                            product[2] = stock - qty;

                            //Agregar al carrito
                            ArrayList item = new ArrayList() { product[0], product[1], qty };
                            shopingCart.Add(item);

                            Console.WriteLine($"{qty} unidad(es) de {product[0]} agregado(s) al carrito.");
                        }
                        else
                        {
                            Console.WriteLine("No hay suficiente stock disponible.");
                        }
                        break;
                    }
                }

                //Si es diferente a lo que se esta buscando advierte al usuario
                if (!found)
                {
                    Console.WriteLine("Producto no encontrado, intente nuevamente.");
                }
            }
        }
        
        
        //-------------------------------------------------------------------------------------
        //Metodo para calcular el total y aplicar el descuento si aplica
        public static void sumTotal()
        {
            //Variable para almacenar el total
            double total = 0;
            
            //Se itera cada item que este en el carrito
            foreach (ArrayList item in shopingCart)
            {
                double price = Convert.ToDouble(item[1]);
                int qty = Convert.ToInt32(item[2]);
                total += price * qty;
            }

            Console.WriteLine(welcomeStyle2);
            Console.WriteLine($"Subtotal: ${total}");

            //Aplicar descuentos según las politicas
            if (total > 20000)
            {
                double discount = total * 0.20;
                total -= discount;
                Console.WriteLine($"Descuento 20% aplicado: -${discount}");
            }
            else if (total > 10000)
            {
                double discount = total * 0.10;
                total -= discount;
                Console.WriteLine($"Descuento 10% aplicado: -${discount}");
            }

            Console.WriteLine($"Total final: ${total}");
            Console.WriteLine(welcomeStyle2);

            purchaseReceipt();
        }
        
        
        //-------------------------------------------------------------------------------------
        //Metodo para Mostrar el ticket de compra
        public static void purchaseReceipt()
        {
            Console.WriteLine("==== Ticket de Compra ====");
            foreach (ArrayList item in shopingCart)
            {
                Console.WriteLine($"{item[0]} - Cantidad: {item[2]} - Precio unitario: {item[1]}");
            }
            Console.WriteLine("==========================");
            Console.WriteLine("¡Gracias por su compra!");
        }
}