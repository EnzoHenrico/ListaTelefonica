using ListaDeTelefoneDinamica;
using System.Diagnostics.Tracing;
using System.Reflection;

namespace ListaDinamica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option;
            bool exit = false;
            ContactList phoneBook = new();

            do
            {
                option = Menu();
                switch (option)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1: // Add
                        Contact contact = InputContactFromUser();
                        phoneBook.Add(contact);
                        Console.WriteLine("\nContato criado com sucesso!");
                        break;
                    case 2: // Remover
                        string name;
                        bool removed;

                        if (phoneBook.IsEmpty())
                        {
                            Console.WriteLine("\nA lista está vazia impossível remover.\n");
                            break;
                        }
                        do
                        {
                            Console.Write("\nNome do contato a ser removido: ");
                            name = Console.ReadLine();
                            removed = phoneBook.RemoveByName(name);

                            if (!removed)
                            {
                                Console.WriteLine("Contato não encontrado, tente novamente.");
                            }
                        } while (!removed);

                        Console.WriteLine("\nContato removido com sucesso!");                        

                        break;
                    case 3: // Mostrar um
                        if (phoneBook.IsEmpty())
                        {
                            Console.WriteLine("\nA lista está vazia impossível remover.\n");
                        }
                        Console.Write("\nNome do contato desejado: ");
                        name = Console.ReadLine();
                        Contact target = phoneBook.FindByName(name);

                        if (target == null)
                        {
                            Console.WriteLine("\nContato não encontrado.");
                        }
                        else
                        {
                            Console.WriteLine("\n" + target + "\n");
                        }
                        break;
                    case 4: // Mostrar todos
                        if (phoneBook.IsEmpty())
                        {
                            Console.WriteLine("\nA lista está vazia impossível exibir contatos.\n");
                            break;
                        }
                        Console.WriteLine(phoneBook);
                        break;
                    case 5: // Editar contato
                        if (phoneBook.IsEmpty())
                        {
                            Console.WriteLine("\nA lista está vazia impossível editar contato.\n");
                        }
                        break;
                }
            } while (!exit);
            Console.ReadKey();
        }

        static int Menu()
        {
            int option = 0;
            do
            {
                Console.WriteLine("\r\n" +
                                  "1) Adicionar novo contato\r\n" +
                                  "2) Remover contato\r\n" +
                                  "3) Buscar contato\r\n" +
                                  "4) Exibir todos contatos\r\n" +
                                  "5) Editar contato\r\n" +
                                  "0) Sair\r\n");
                option = int.Parse(Console.ReadLine());

                if (option < 0 || option > 5)
                {
                    Console.WriteLine("Opção inválida, tente novamente.\n");
                }
            } while (option < 0 || option > 5);

            return option;
        }

        static Contact InputContactFromUser()
        {
            string name;
            string phone;
            bool decision = false;

            Console.Write("Nome do contato: ");
            name = Console.ReadLine();
            
            Console.Write("Número de telefone: ");
            phone = Console.ReadLine();
            
            Contact newContact = new(name, phone);

            do
            {
                Console.Write("Deseja adiconar mais alugum telefone? s / n : ");
                decision = Console.ReadLine() == "s";

                if (decision)
                {
                    Console.Write("Número de telefone adicional: ");
                    newContact.PushNewPhone(Console.ReadLine());

                }
            } while (decision);

            Console.Write("Deseja adiconar um e-mail? s / n : ");
            decision = Console.ReadLine() == "s";

            if (decision)
            {
                Console.Write("E-mail: ");
                newContact.SetEmail(Console.ReadLine());

            }

            Console.Write("Deseja adiconar um endereço? s / n : ");
            decision = Console.ReadLine() == "s";

            if (decision)
            {
                Console.Write("Nome da rua: ");
                string street = Console.ReadLine();
                
                Console.Write("Nome da rua: ");
                string city = Console.ReadLine();

                Console.Write("Nome da rua: ");
                string state = Console.ReadLine();

                Console.Write("Nome da rua: ");
                string zip = Console.ReadLine();

                newContact.SetAddress(new(street, city, state, zip));
            }

            return newContact;
        }
    }
}
