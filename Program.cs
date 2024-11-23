using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace BelleFleur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string menu = "0) Pour commander votre propre bouquet\n" +
                "1) Connaître le prix moyen des bouquets achetés;\n" +
                "2) Connaître le meilleur bouquet du mois en cours\n" +
                "3) Connaître le meilleur bouquet de l'année en cours\n" +
                "4) Connaître le client du mois\n" +
                "5) Connaître le client de l'année\n" +
                "6) Connaître le magasin générant le plus grand chiffre d'affaire\n" +
                "7) Connaître le nombre de bouquet de mariage qui nous a été confié à confectionner\n" +
                "8) Connaître les commande à livrer durant les 7 prochains jours\n" +
                "9) Connaître la fidélité d'un client\n" +
                "Tapez sur la touche escape pour fermer la console.\n";
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            Console.WriteLine("Bienvenue\nVoici les informations disponible concernant les affaires Bellefleur");
            string premier = "";
            do
            {
                Console.WriteLine(premier + menu);
                keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        Console.Clear();
                        Console.WriteLine("Vous avez décidé de commander votre propre bouquet\n");
                        CommandeBouquet();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1 :
                        Console.Clear();
                        Console.WriteLine("Vous avez décidé de connaître le prix moyen des bouquets achetés\n");
                        MoyenneBouquet();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        Console.WriteLine("Vous avez décidé de connaître le meilleur bouquet du mois en cours (le mois numéro :" + DateTime.Now.Month + ")\n");
                        MeilleurBouquetMois();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        Console.WriteLine("Vous avez décidé de connaître le meilleur bouquet de l'année en cours (l'année :" + DateTime.Now.Year + ")\n");
                        MeilleurBouquetAnnee();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        Console.WriteLine("Vous avez décidé de connaître le client du mois en cours(le mois numéro :" + DateTime.Now.Month + ")\n");
                        MeilleurClientMois();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Console.Clear();
                        Console.WriteLine("Vous avez décidé de connaître le client l'année en cours (l'année :" + DateTime.Now.Year + ")\n");
                        MeilleurClientAnnee();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        Console.Clear();
                        Console.WriteLine("Vous avez décidé de connaître le magasin générant le plus grand chiffre d'affaire\n");
                        MeilleurMagasin();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        Console.Clear();
                        Console.WriteLine("Vous avez décidé de connaître le nombre de bouquet de mariage qui nous a été confié à confectionner\n");
                        NbBouquetMariage();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.D8:
                    case ConsoleKey.NumPad8:
                        Console.Clear();
                        Console.WriteLine("Vous avez décidé de connaître les commandes qui sont à livrer dans la semaine à venir\n");
                        CommandeSemaine();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.D9:
                    case ConsoleKey.NumPad9:
                        Console.Clear();
                        Console.WriteLine("Vous avez décidé de connaître la fidélité d'un compte\n");
                        Fidelite();
                        Console.ReadKey();
                        Console.Clear();
                        break;


                    case ConsoleKey.Escape:
                        Console.Clear();
                        Console.WriteLine("aVous avez pressé la touche echap vous voilà donc sorti à bientôt\n");
                        Console.ReadKey();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Désolé nous n'avons pas compris votre demande merci de bien veiller à entrer un numéro présent.\n");
                        MySqlConnection maConnexion = new MySqlConnection();
                        try
                        {
                            string connexionString = "SERVER=localhost;PORT=3306;" + "DATABASE=fleurs;" + "UID=root;PASSWORD=root";
                            maConnexion = new MySqlConnection(connexionString);
                            maConnexion.Open();
                        }
                        catch (MySqlException e)
                        {
                            Console.WriteLine("ERREUR de connexion : " + e.Message);
                            return;
                        }
                        string requete = "SELECT concat(Numcom,' ', Courriel,' ', Prix,' ', EtatLivraison,' ', DateCom,' ', NomBouquet,' ',NumMag) as com From Commande order by Numcom desc";
                        MySqlCommand command = maConnexion.CreateCommand();
                        command.CommandText = requete;
                        MySqlDataReader reader = command.ExecuteReader();
                        string[] value = new string[reader.FieldCount];
                        while (reader.Read())
                        {
                            string com = (string)reader["com"];
                            Console.WriteLine(com);
                        }
                        Console.WriteLine("\n");
                        reader.Close();
                        maConnexion.Close();
                        try
                        {
                            string connexionString = "SERVER=localhost;PORT=3306;" + "DATABASE=fleurs;" + "UID=root;PASSWORD=root";
                            maConnexion = new MySqlConnection(connexionString);
                            maConnexion.Open();
                        }
                        catch (MySqlException e)
                        {
                            Console.WriteLine("ERREUR de connexion : " + e.Message);
                            return;
                        }
                        requete = "SELECT concat(Nom,' ', Prénom,' ', NumTel,' ', Mdp,' ', AdressFact,' ', CarteCredit,' ',Fidélité,' ',Courriel) as clientt From Clients";
                        command = maConnexion.CreateCommand();
                        command.CommandText = requete;
                        reader = command.ExecuteReader();
                        string[] value1 = new string[reader.FieldCount];
                        while (reader.Read())
                        {
                            string clientt = (string)reader["clientt"];
                            Console.WriteLine(clientt + "\n");
                        }
                        maConnexion.Close(); //permet de vérifier la mise à jour des tables
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
                premier = "Et maintenant que voulez vous exécuter ?\n";
            } while (keyInfo.Key != ConsoleKey.Escape);
        }
        static void CommandeBouquet()
        {
            Console.WriteLine("Avez vous un compte chez nous ? Tapez \"oui\" ou \"non\"");
            string test = ""; // variable qui sert à prendre dfférente des chaine de caractère et vérifier les condition des boucle while
            string email = ""; // chaine qui recoit toute les adresses mail de la table clients
            string nom = ""; // recoit le nom du client
            string prenom = "";// recoit le prenom du client
            string numtel = "";// meme principe
            string mdp = "";// meme principe
            string Adresse = "";// meme principe
            string carte = "";// meme principe
            string mail = "";// meme principe
            string fide = "Aucune";// meme principe
            string[] BouquetPrix = new string[3]; // contient à l'index 0 le nom du bouquet et index 1 le prix apres réduction en fonction de la fidélité et 2 l'etat de commande qui dépend du type de bouquet vinv ou cpav
            string numcommande = ""; // recoit le nouveau numéro de commande
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" + "DATABASE=fleurs;" + "UID=root;PASSWORD=root";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("ERREUR de connexion : " + e.Message);
                return;
            }
            string requete = "Select NumCom from Commande order by NumCom desc limit 1;"; // cette requete va permettre de créer le numéro de commande de la commande en cours de rédaction par l'utilisateur
            MySqlCommand command4 = maConnexion.CreateCommand();
            command4.CommandText = requete;
            MySqlDataReader reader4 = command4.ExecuteReader();

            string[] value4 = new string[reader4.FieldCount];
            while (reader4.Read())
            {
                numcommande = (string)reader4["NumCom"];
            }
            int var = Convert.ToInt32(numcommande); // pour convertir le numéro de commande en entier pour l'incrémenter
            var++;
            if (var > 0 && var < 10) // car les numéro de commande on sont des nombres à 4 chiffre par exemple commande 14 => 0014
                numcommande = "000" + var;
            else if (var > 9 && var < 100)
                numcommande = "00" + var;
            else if (var > 99 && var < 1000)
                numcommande = "0" + var;
            else 
                numcommande = Convert.ToString(var);
            Random r = new Random(); // va permettre la création rapide de nom prenom etc au hasard afin de créer un client sans entrer nous même les informations tout ça pour aller vite
            do
            {
                test = Console.ReadLine().ToLower();
                Console.Clear();
                if (test != "oui" && test != "non")
                    Console.WriteLine(test + " ne correspond ni à \"oui\" ni à \"non\" merci d'entrer un de ces mots correctement");
            } while (test != "oui" && test != "non");
            switch (test)
            {
                case "oui":
                    Console.WriteLine("Veuillez donc entrer votre adresse email (copiez collez directement votre adresse parmis\n celle en dessous pour aller plus vite)"); 
                    // en réalité on ne montre pas la listes des mail deja présent mais ici cela permet d'aller plus vite
                    maConnexion = null;
                    try
                    {
                        string connexionString = "SERVER=localhost;PORT=3306;" + "DATABASE=fleurs;" + "UID=root;PASSWORD=root";
                        maConnexion = new MySqlConnection(connexionString);
                        maConnexion.Open();
                    }
                    catch (MySqlException e)
                    {
                        Console.WriteLine("ERREUR de connexion : " + e.Message);
                        return;
                    }
                    requete = "SELECT Courriel\r\nFrom Clients\r\n"; //va afficher la liste des adresses mail présentent dans la table Clients
                    MySqlCommand command = maConnexion.CreateCommand();
                    command.CommandText = requete;
                    MySqlDataReader reader = command.ExecuteReader();
                    
                    string[] value = new string[reader.FieldCount];
                    while (reader.Read())
                    {
                        string Courriel = (string)reader["Courriel"];
                        email += Courriel + " ";
                        Console.WriteLine(Courriel);
                    }
                    do
                    {
                        mail = Console.ReadLine();
                        if (!ChainePresente(email, mail))
                            Console.WriteLine("Aïe le copier-coller n'a pas fonctionné réessayer et veillez à bien copier UNIQUEMENT une adresse email");
                    } while (!ChainePresente(email, mail)); // boucle while pour bien vérifier que la chaine entrée par l'utilisateur appartient à la liste de mail de la table client
                    maConnexion.Close();
                    try
                    {
                        string connexionString = "SERVER=localhost;PORT=3306;" + "DATABASE=fleurs;" + "UID=root;PASSWORD=root";
                        maConnexion = new MySqlConnection(connexionString);
                        maConnexion.Open();
                    }
                    catch (MySqlException e)
                    {
                        Console.WriteLine("ERREUR de connexion : " + e.Message);
                        return;
                    }
                    requete = "SELECT Fidélité from Clients WHERE Clients.Courriel = '" + mail + "';"; // cette requete va retourner la fidélité du client ayant pour courriel la saisie de l'utilisateur
                    MySqlCommand command1 = maConnexion.CreateCommand();
                    command1.CommandText = requete;
                    MySqlDataReader reader1 = command1.ExecuteReader();
                    string[] value1 = new string[reader1.FieldCount];
                    while (reader1.Read())
                    {
                        string Fidélité = (string)reader1["Fidélité"];
                        fide = Fidélité; // on stock la fidélité du compte associé
                        Console.WriteLine();
                    }
                    maConnexion.Close();
                    BouquetPrix= ConfectionBouquet(mail,fide); // ici on va pouvoir enregistrer le nom du bouquet, le prix apres réduction, ainsi que l'état de livraison qui change selon si le bouquet est personnalisé ou standard
                    break;

                case "non": // l'utilisateur va donc créer un nouveau client 
                    Console.WriteLine("Tout d'abord j'aimerai savoir si vous tenez à entrer vous même les\n" +
                        "informations relatives au compte ou alors vous voulez uniquement entrerle bouquet\n" +
                        "(les informations seront donc générées aléatoirement mais vous seront affichés)\n" +
                        "Tapez \"oui\" pour entrer vos informations\n" + // l'utilisateur peut choisir de rentrer lui même les informations relatives au compte
                        "Tapez \"non\" pour passer directement à la conception de bouquet"); // ou de laisser des informations générées par la machine
                    do
                    {
                        test = Console.ReadLine().ToLower();
                        Console.Clear();
                        if (test != "oui" && test != "non")
                            Console.WriteLine(test + " ne correspond ni à \"oui\" ni à \"non\" merci d'entrer un de ces mots correctement"); // verification pour etre sûr de la saisie e l'utilisateur
                    } while (test != "oui" && test != "non");
                    switch (test)
                    {
                        case "oui": // saisie des info par l'utilisateur
                            Console.WriteLine("Veuillez entrer votre nom");
                            nom = Console.ReadLine();
                            Console.WriteLine("Veuillez entrer votre prenom");
                            prenom = Console.ReadLine();
                            Console.WriteLine("Veuillez entrer votre numéro de téléphone");
                            numtel = Console.ReadLine();
                            Console.WriteLine("Veuillez entrer votre adresse email");
                            do
                            {
                                mail = Console.ReadLine();
                                if (ChainePresente(email, mail))
                                    Console.WriteLine("Malheureusement cette adresse email est déjà utilisée.\nVeuillez entrer une autre adresse."); // pour pas que l'utilisateur "crée" une adresse deja existante
                            }while(ChainePresente(email, mail));
                            Console.WriteLine("Veuillez entrer votre mot de passe");
                            mdp = Console.ReadLine();
                            Console.WriteLine("Veuillez entrer votre adresse postale");
                            Adresse = Console.ReadLine();
                            Console.WriteLine("Veuillez entrer votre carte de crédit");
                            carte = Console.ReadLine();
                            break;

                        case "non": // saisie par l'ordinateur afin d'aller plus vite
                            do
                            {
                                nom = "Nomtest" + r.Next(0, 1000000000);
                                prenom = "Prénomtest" + r.Next(0, 1000000000);
                            } while (ChainePresente(email, nom + "." + prenom + "@gmail.fr"));
                            numtel = Convert.ToString(r.Next(100000000, 999999999));
                            mdp = Convert.ToString(r.Next(0, 1000000000));
                            Adresse = Convert.ToString(r.Next(0, 200)) + " Avenue de la campagne, 75012 Paris";
                            carte = Convert.ToString(r.Next(100000000, 999999999));
                            mail = nom + "." +prenom + "@gmail.fr";
                            break;

                        default: // au cas où il y a une faille que le code ne plante pas
                            Console.WriteLine("Oups une erreur est survenue désolé veuillez recommencer");
                            break;
                    }
                    try
                    {
                        string connectionString = "SERVER=localhost;PORT=3306;" + "DATABASE=fleurs;" + "UID=root;PASSWORD=root";
                        MySqlConnection connection = new MySqlConnection(connectionString);
                        connection.Open();

                        string query = "INSERT INTO Clients (Nom, Prénom, NumTel, Mdp, AdressFact, CarteCredit, Fidélité, Courriel) VALUES ('" + nom + "','" + prenom + "','" + numtel + "" +
                            "','" + mdp + "','" + Adresse + "','" + carte + "','" + fide + "','" +mail + "')"; 
                        //cette requete va nous permettre d'insérer le nouveau client dans la table Clients que l'utilisateur a créé
                        MySqlCommand command2 = new MySqlCommand(query, connection);
                        command2.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (MySqlException e)
                    {
                        Console.WriteLine("ERREUR de connexion Clients: " + e.Message);
                        return;
                    }
                    BouquetPrix = ConfectionBouquet(mail, fide); // passage à la création de la commande
                    break;

                default:
                    Console.WriteLine("Oups une erreur est survenue désolé veuillez recommencer");
                    break;
            }
            try
            {
                string connectionString = "SERVER=localhost;PORT=3306;" + "DATABASE=fleurs;" + "UID=root;PASSWORD=root";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                string query = "INSERT INTO Commande (Numcom, Courriel, Prix, EtatLivraison, DateCom, NomBouquet, NumMag) VALUES ('" + numcommande + "','" + mail + "','" + Convert.ToDouble(BouquetPrix[1]) + "'" +
                    ",'" + BouquetPrix[2] + "','" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "','" + BouquetPrix[0] + "','" + r.Next(1,3) + "')";
                //cette requete va nous permettre d'insérer la nouvelle commande dans la table Commande que l'utilisateur a choisi
                MySqlCommand command3 = new MySqlCommand(query, connection);
                command3.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("ERREUR de connexion Commande : " + e.Message);
                return;
            }

            Console.WriteLine("Voulez vous un récapitulatif de votre commande ?");
            do
            {
                test = Console.ReadLine().ToLower();
                Console.Clear();
                if (test != "oui" && test != "non")
                    Console.WriteLine(test + " ne correspond ni à \"oui\" ni à \"non\" merci d'entrer un de ces mots correctement");
            } while (test != "oui" && test != "non");
            switch (test)
            {
                case "oui":
                    Console.WriteLine("Voici donc le récapitulatif de votre commande : \n" +
                "Adresse email : " + mail + "\n" +
                "Bouquet choisi : " + BouquetPrix[0] + "\n" +
                "Numéro de commande : " + numcommande + "\n" +
                "Total des achats : " + BouquetPrix[1] + " euros\n14" +
                "Date de livraison estimée : " + DateTime.Now.AddDays(14).Day + "/" + DateTime.Now.AddDays(14).Month + "/" + DateTime.Now.AddDays(14).Year);
                    break;

                case "non":
                    break;

                default:
                    break;
            }
        }
        static void MoyenneBouquet()
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" + "DATABASE=fleurs;" + "UID=root;PASSWORD=root"; // adresse connexion avec sql
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open(); // ouverture connexion avec sql
            }
            catch (MySqlException e) // test problème communication avec sql
            {
                Console.WriteLine("ERREUR de connexion : " + e.Message);
                return;
            }
            string requete = "SELECT concat('Voici la moyenne des bouquets : ',AVG(Prix),' euros') as Moyenne_prix\r\nFROM Commande\r\nwhere NomBouquet != 'Autre';"; // requete qui renvoie une chaine de caractère contenant la moyenne des bouquets vendus
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader = command.ExecuteReader();
            string[] value = new string[reader.FieldCount];
            while(reader.Read()) // lecture des tuples renvoyés
            {
                string Moyenne_prix = (string)reader["Moyenne_prix"];
                Console.WriteLine(Moyenne_prix);
                for(int i = 0;i<reader.FieldCount;i++)
                {
                    value[i] = reader.GetValue(i).ToString();
                    Console.WriteLine();
                }
            }
            maConnexion.Close(); // fermeture de la connexion avec sql
        } 
        static void MeilleurBouquetMois()
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" + "DATABASE=fleurs;" + "UID=root;PASSWORD=root";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("ERREUR de connexion : " + e.Message);
                return;
            }
            string requete = "Select concat('Voici le bouquet le plus vendu du mois : ',NomBouquet, ' avec un total de ',Count(NomBouquet), ' bouquets vendus')" +
                " as Bouquet_du_mois from Commande where  NomBouquet != 'Bouquet personnalisé' and MONTH(Datecom) = " + DateTime.Now.Month + " and YEAR(Datecom) = " + DateTime.Now.Year + " group by NomBouquet order by Count(NomBouquet)" +
                " desc\r\nlimit 1;"; // requete qui doit retourner la chaine de caractère contenant le nom du bouquet standard et le nombre de bouquets vendus uniquement le plus vendu
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader = command.ExecuteReader();
            string[] value = new string[reader.FieldCount];
            while (reader.Read())
            {
                string Bouquet_du_mois = (string)reader["Bouquet_du_mois"]; // lecture du bouquet standard le plus vendu
                Console.WriteLine(Bouquet_du_mois);
            }
            maConnexion.Close();
        }
        static void MeilleurBouquetAnnee()
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" + "DATABASE=fleurs;" + "UID=root;PASSWORD=root";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("ERREUR de connexion : " + e.Message);
                return;
            }
            string requete = "Select concat('Voici le bouquet le plus vendu de l année : ' , NomBouquet , ' avec un total de ' , Count(NomBouquet) , ' bouquets vendus')" +
                " as Bouquet_de_l_année from Commande where NomBouquet != 'Bouquet personnalisé' and YEAR(Datecom) = " + DateTime.Now.Year + " group by NomBouquet order by Count(NomBouquet)" +
                " desc limit 1;"; // renvoie la chaine de caractère contenant le nom du bouquet et le nombre de bouquet vendu du bouquet standard le plus vendu sur l'année en cours
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader = command.ExecuteReader();
            string[] value = new string[reader.FieldCount];
            while (reader.Read()) // lecture du tuple renvoyé
            {
                string Bouquet_de_l_année = (string)reader["Bouquet_de_l_année"];
                Console.WriteLine(Bouquet_de_l_année);
            }
            maConnexion.Close();
        } 
        static void MeilleurClientMois()
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" + "DATABASE=fleurs;" + "UID=root;PASSWORD=root";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("ERREUR de connexion : " + e.Message);
                return;
            }
            string requete = "SELECT concat('Voici le meilleur client du mois : ',Nom,' ',Prénom, ' avec un total de ', Sum(Commande.Prix)" +
                ", ' euros dépensés') as Client_du_mois\r\nFrom Clients, Commande\r\nwhere Clients.Courriel = Commande.Courriel and MONTH(Datecom) = " +
                "" + DateTime.Now.Month + " and YEAR(Datecom) = " + DateTime.Now.Year + " GROUP BY Clients.Courriel \r\norder by Sum(Commande.Prix) " +
                "desc\r\nlimit 1;"; // nous retourne la chaine de caractère contenant le nom prenom et total d'argent dépensé par le meilleur client du mois en cours
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader = command.ExecuteReader();
            string[] value = new string[reader.FieldCount];
            while (reader.Read())
            {
                string Client_du_mois = (string)reader["Client_du_mois"];
                Console.WriteLine(Client_du_mois);
            }
            maConnexion.Close();
        } 
        static void MeilleurClientAnnee()
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" + "DATABASE=fleurs;" + "UID=root;PASSWORD=root";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("ERREUR de connexion : " + e.Message);
                return;
            }
            string requete = "SELECT concat('Voici le meilleur client de l année : ',Nom,' ',Prénom, ' avec un total de '," +
                "Sum(Commande.Prix),' euros dépensés') as Client_de_l_année\r\nFrom Clients, Commande\r\nwhere Clients.Courriel " +
                "= Commande.Courriel and YEAR(Datecom) = " + DateTime.Now.Year + " GROUP BY Clients.Courriel \r\norder by " +
                "Sum(Commande.Prix) desc\r\nlimit 1;"; // cette requete va retourner une chaine de caractère comprenant le nom, prénom et total d'argent dépensé par le meilleur client de l'année en cours
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader = command.ExecuteReader();
            string[] value = new string[reader.FieldCount];
            while (reader.Read())
            {
                string Client_de_l_année = (string)reader["Client_de_l_année"];
                Console.WriteLine(Client_de_l_année);
            }
            maConnexion.Close();
        } 
        static void MeilleurMagasin()
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" + "DATABASE=fleurs;" + "UID=root;PASSWORD=root";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("ERREUR de connexion : " + e.Message);
                return;
            }
            string requete = "select concat('Le meilleur magasin est le n°',NumMag, ' avec un chiffre d\\'affaire de ' ,Sum(Prix),' euros')" +
                " as TotalCA\r\nfrom Commande\r\ngroup by NumMag\r\norder by Sum(Prix) desc\r\nlimit 1;"; // cette requete nous retourne le numéro de magasin avec le total de chiffre d'affaire du magasin ayant le plus gros chiffre d'affaire
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader = command.ExecuteReader();
            string[] value = new string[reader.FieldCount];
            while (reader.Read())
            {
                string TotalCA = (string)reader["TotalCA"];
                Console.WriteLine(TotalCA);
            }
            maConnexion.Close();
        } 
        static void NbBouquetMariage()
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" + "DATABASE=fleurs;" + "UID=root;PASSWORD=root";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("ERREUR de connexion : " + e.Message);
                return;
            }
            string requete = "SELECT concat(Count(NomBouquet),' personnes ont fait appel à nous pour concevoir un bouquet de mariage') as Bouquet_Vive_la_mariée \r\nFROM Commande\r\nwhere NomBouquet = 'Vive la mariée';";
            // cette requete renvoie le nombre de bouquet vive la mariée qui ont été commandé depuis la création 
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader = command.ExecuteReader();
            string[] value = new string[reader.FieldCount];
            while (reader.Read())
            {
                string Bouquet_Vive_la_mariée = (string)reader["Bouquet_Vive_la_mariée"];
                Console.WriteLine(Bouquet_Vive_la_mariée);
            }
            maConnexion.Close();
        } 
        static void CommandeSemaine()
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" + "DATABASE=fleurs;" + "UID=root;PASSWORD=root";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("ERREUR de connexion : " + e.Message);
                return;
            }
            string requete = "SELECT concat('La commande n°',NumCom,' est à livrer à l\\'adresse : ',AdressFact,' pour M/Mme ',Clients.Nom, ' ' ,Clients.Prénom) as CommandeSemaine\r\n" +
                "From Commande, Clients where Clients.Courriel = Commande.Courriel and EtatLivraison = 'CAL';";
            // cette requete va renvoyer une chaine de caractère contenant le numéro de commande, l'adresse, le nom de client, et le prénom de client concernant une commande. Les commandes
            // renvoyée sont celle dont l'etat de livraison est cal (commande à livrer) je pars du principe que lorsqu'une commande est prete à être livrer elle sera livrée dans la semaine qui suit
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader = command.ExecuteReader();
            string[] value = new string[reader.FieldCount];
            while (reader.Read())
            {
                string CommandeSemaine = (string)reader["CommandeSemaine"];
                Console.WriteLine(CommandeSemaine);
            }
            maConnexion.Close();
        } 
        static void Fidelite()
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" + "DATABASE=fleurs;" + "UID=root;PASSWORD=root";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("ERREUR de connexion : " + e.Message);
                return;
            }
            string requete = "SELECT Courriel\r\nFrom Clients\r\n"; // cette requette va nous permettre d'afficher à l'utilisateur la liste des adresse mail pour qu'il puisse choisir laquelle il veut vérifier
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader = command.ExecuteReader();
            string[] value = new string[reader.FieldCount];
            string email = "";
            Console.WriteLine("Voici toutes les adresses email que nous possédons (pour rendre la recherche plus rapide vous pouvez copier-coller)");
            while (reader.Read())
            {
                string Courriel = (string)reader["Courriel"];
                email += Courriel + " ";
                Console.WriteLine(Courriel);
            }
            Console.WriteLine("\n");
            Console.WriteLine("De quelle adresse email voulez vous connaître la fidélité ?");
            string mail = Console.ReadLine();
            if (ChainePresente(email, mail))
                Console.WriteLine("\nEn effet " + mail + " existe bien dans notre base de données\n");
            else
            {
                Console.WriteLine("Malheureusement " + mail + " ne se trouve pas dans notre base de données");
                maConnexion.Close();
                return;
            }
            maConnexion.Close();
            maConnexion.Open();
            requete = "SELECT concat(Clients.Nom,' ',Clients.Prénom,' a une fidélité : ',Fidélité) as Fidélité\r\nfrom Clients\r\nWHERE Clients.Courriel = '" + mail + "';";
            // cette requete va retourner une chaine de caractère comprenant le nom, prénom ainsi que la fidélité del'adresse email choisie par l'utilisateur
            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = requete;
            MySqlDataReader reader2 = command2.ExecuteReader();
            string[] value2 = new string[reader2.FieldCount];
            while (reader2.Read())
            {
                string Fidélité = (string)reader2["Fidélité"];
                Console.WriteLine("\"" + Fidélité + "\"");
            }
            maConnexion.Close();
        } 
        static bool ChainePresente(string retoursql,string mail)
        {
            bool VF = false;
            int compteur = 0;
            for(int i = 0;i < retoursql.Length - mail.Length && !VF; i++)
            {
                VF = true;
                for(int j = 0;j < mail.Length && VF;j++)
                {
                    if (retoursql[i+j] != mail[j])
                        VF = false;
                    compteur = i+j;
                }
                if (VF && retoursql[compteur + 1] != ' ')
                    VF = false;
            }
            return VF;
        }// retourne vrai si la chaine de caractère mail se trouve dans retoursql
        static string[] ConfectionBouquet(string mail, string fide)
        {
            int result = 0;//pour permettre le tryparse
            string test = "";//variable qui va nous permettre de faire des test de saisie de l'utilisateur
            int i = 0; // index qui servira pour BouquetPrix
            string[] BouquetPrix = {"","",""}; // tableau qui va recueillir nom du bouquet, le prix apres réduction, ainsi que l'état de la commande
            double prix = 0; // le prix
            string nom = "";//variable qui va accueillir le nom du bouquet
            Console.Clear();
            Console.WriteLine("Voici tous les type de bouquets disponible chez nous :\n");
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" + "DATABASE=fleurs;" + "UID=root;PASSWORD=root";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("ERREUR de connexion : " + e.Message);
                return BouquetPrix;
            }
            string requete = "SELECT concat(NomBouquet,' à ',Prix) as bouquet From Assemblage"; // requete qui va retourner le nom du bouquet ainsi que le prix associé
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader = command.ExecuteReader();
            string[] value = new string[reader.FieldCount];
            while (reader.Read())
            {
                string bouquet = (string)reader["bouquet"];
                Console.WriteLine(bouquet);
            }
            maConnexion.Close();
            Console.WriteLine("Le bouquet personnalisé est selon vos choix il n'a donc pas de prix fixe\n\n" +
                "Veuillez entrer le nom du bouquet désiré\n"); // calcul selon les fleurs le composant
            do
            {
                nom = Console.ReadLine().ToLower();
                if (nom != "gros merci" && nom != "amoureux" && nom != "exotique" && nom != "maman" && nom != "vive la mariée" && nom != "arc en ciel de rose" && nom != "bouquet personnalisé" && nom != "personnalisé")
                    Console.WriteLine("Un problème est survenu veuillez réentrer le bouquet souhaité");
            } while (nom != "gros merci" && nom != "amoureux" && nom != "exotique" && nom != "maman" && nom != "vive la mariée" && nom != "arc en ciel de rose" && nom != "bouquet personnalisé" && nom != "personnalisé");
            switch (nom)
            {
                case "gros merci":
                    nom = "Gros Merci";
                    prix = 45;
                    break;

                case "amoureux":
                    nom = "Amoureux";
                    prix = 65;
                    break;

                case "exotique":
                    nom = "Exotique";
                    prix = 40;
                    break;

                case "maman":
                    nom = "Maman";
                    prix = 80;
                    break;

                case "vive la mariée":
                    nom = "Vive la Mariée";
                    prix = 120;
                    break;

                case "arc en ciel de rose":
                    nom = "Arc en ciel de rose";
                    prix = 25;
                    break;

                case "bouquet personnalisé":
                case "personnalisé":
                    nom = "Bouquet personnalisé";
                    Console.WriteLine("Voici toutes les fleurs disponible pour votre bouquet");
                    int[] fleurs = new int[6]; // 6 cases pour chaque fleur
                    maConnexion.Open();
                    requete = "SELECT concat(Nom, ' ', Stock, ' sont disponible') as fleur from Fleurs"; // cette requete va retourner le nom ainsi que le Stock disponible des fleurs
                    MySqlCommand command1 = maConnexion.CreateCommand();
                    command.CommandText = requete;
                    MySqlDataReader reader1 = command.ExecuteReader();
                    string[] value1 = new string[reader1.FieldCount];
                    while (reader1.Read())
                    {
                        string fleur = (string)reader1["fleur"];
                        Console.WriteLine(fleur);
                    }
                    maConnexion.Close();
                    maConnexion.Open();
                    requete = "SELECT Nom from Fleurs"; // On va parcourir les noms de fleurs pour demander combien de fleurs de la variétés en question l'utilisateur veut
                    MySqlCommand command2 = maConnexion.CreateCommand();
                    command.CommandText = requete;
                    MySqlDataReader reader2 = command.ExecuteReader();
                    string[] value2 = new string[reader2.FieldCount];
                    while (reader2.Read())
                    {
                        string Nom = (string)reader2["Nom"];
                        Console.WriteLine("\nCombien voulez vous de " + Nom);
                        test = Console.ReadLine();
                        if (!int.TryParse(test, out result))
                        {
                            do
                            {
                                do
                                {
                                    Console.WriteLine("Nous n'avons pas compris votre demande veuillez réentrer le nombre de " + Nom);
                                    test = Console.ReadLine();
                                } while (!int.TryParse(test, out result));
                            } while (Convert.ToInt32(test) < 20);
                        }
                        fleurs[i] = Convert.ToInt32(test);
                        i++;
                    }
                    maConnexion.Close();
                    maConnexion.Open();
                    i = 0;
                    requete = "SELECT Prix from Fleurs"; // ici nous allons calculer le prix du bouquet avec le tableau que l'on a rempli au préalable
                    MySqlCommand command3 = maConnexion.CreateCommand();
                    command.CommandText = requete;
                    MySqlDataReader reader3 = command.ExecuteReader();
                    string[] value3 = new string[reader3.FieldCount];
                    while (reader3.Read())
                    {
                        double Prix = (double)reader3["Prix"];
                        prix += fleurs[i] * Prix;
                        Console.WriteLine();
                        i++;
                    }
                    Console.WriteLine("Voulez vous un vase avec ceci ? (\"oui\" \"non\")"); //demande de vase en plus
                    test = Console.ReadLine().ToLower();
                    if (test != "oui" && test != "non")
                    {
                        do
                        {
                            Console.WriteLine("Nous n'avons pas compris");
                            test = Console.ReadLine().ToLower();
                        } while (test != "oui" && test != "non");
                    }
                    if (test == "oui")
                        prix += 10;
                    maConnexion.Close();
                    break;
            }
            Console.Clear();
            switch (fide)
            {
                case "Bronze":
                    Console.Write("La fidélité associée au compte : " + mail + " étant \"Bronze\".\nLe total passe de " + prix + " à  ");
                    prix = prix * 0.95;
                    Console.Write((int)Math.Floor(prix) + " euros avec la réduction de 5%\n");
                    break;
                case "OR":
                    Console.Write("La fidélité associée au compte : " + mail + " étant \"OR\".\nLe total passe de " + prix + " à ");
                    prix = prix * 0.85;
                    Console.Write((int)Math.Floor(prix) + " euros avec la réduction de 15%\n");
                    break;
                default :
                    Console.WriteLine("Le total s'élève à " + (int)Math.Floor(prix) + " euros");
                    break;
            }
            BouquetPrix[0] = nom;
            BouquetPrix[1] = Convert.ToString((int)Math.Floor(prix)); // car la virgule fait buguer sql lors de l'insertion on ne peut donc pas obtenir de nombre à virgule malheureusement... 
            if (nom == "Bouquet personnalisé")
                BouquetPrix[2] = "CPAV";
            else
                BouquetPrix[2] = "VINV";
            return BouquetPrix;
        }

    }
}
