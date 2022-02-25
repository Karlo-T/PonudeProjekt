using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonudeProjekt
{
    public class SqliteDataAccess
    {
        public static List<PonudeModel> UcitajPonude()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<PonudeModel>("select * from Ponude", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<PonudeModel> UcitajPonudePoRijeci(string s)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<PonudeModel>("select * from Ponude where Klijent like '%"+s+ "%' or Naslov like '%" + s + "%' or Adresa like '%" + s + "%' or Posta like '%" + s + "%' or Oib like '%" + s + "%' or Dodatno like '%" + s + "%' or BrojPonude like '%" + s + "%' or Datum like '%" + s + "%'", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<KlijentModel> UcitajKlijentePoRijeci(string s)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<KlijentModel>("select * from Klijenti where Ime like '%" + s + "%' or Adresa like '%" + s + "%' or Posta like '%" + s + "%' or Oib like '%" + s + "%' or Dodatno like '%" + s + "%'", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SpremiPonudu(PonudeModel ponuda)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Ponude (BrojPonude, Datum, Naslov, Klijent, Adresa, Posta, Oib, Dodatno, Napomena, Ukupno, Osnovica, Rabat, PDV, Iznos, SifraKlijenta) values (@BrojPonude, @Datum, @Naslov, @Klijent, @Adresa, @Posta, @Oib, @Dodatno, @Napomena, @Ukupno, @Osnovica, @Rabat, @PDV, @Iznos, @SifraKlijenta)", ponuda);
            }
        }

        public static void IzbrisiPonudu(string ponuda)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from Ponude where BrojPonude='" + ponuda + "'");
                cnn.Execute("delete from DetaljiPonude where BrojPonude = '" + ponuda + "'");
            }
        }



        public static List<DetaljiPonudeModel> UcitajDetaljePonude()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<DetaljiPonudeModel>("select * from DetaljiPonude", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SpremiDetaljePonude(DetaljiPonudeModel detalji)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into DetaljiPonude (BrojPonude, Opis, Cijena) values (@BrojPonude, @Opis, @Cijena)", detalji);
            }
        }

        public static List<PostavkeModel> UcitajPostavke()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<PostavkeModel>("select * from Postavke", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void AzurirajBrojPonude(int b)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("update Postavke set BrojPonude = " + (b + 1).ToString() + " where BrojPonude = '" + b.ToString() + "'");
            }
        }

        public static void AzurirajBrojPonudeBrisanje(int b)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("update Postavke set BrojPonude = " + b.ToString() + " where BrojPonude = '" + (b + 1).ToString() + "'");
            }
        }

        public static void AzurirajSaveLocation(string s)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("update Postavke set SaveLocation = '" + s.ToString() + "'");
            }
        }

        public static void DodajKlijenta(KlijentModel klijent)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Klijenti (Ime, Adresa, Posta, Oib, Dodatno, Telefon, Mail) values (@Ime, @Adresa, @Posta, @Oib, @Dodatno, @Telefon, @Mail)", klijent);
            }
        }

        public static List<KlijentModel> UcitajKlijente()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<KlijentModel>("select * from Klijenti", new DynamicParameters());
                return output.ToList();
            }
        }


        public static void UrediKlijenta(int sifra, KlijentModel klijent)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("update Klijenti set Ime='"+klijent.Ime+ "', Adresa='" + klijent.Adresa + "', Posta='" + klijent.Posta + "', Oib='" + klijent.Oib + "', Dodatno='" + klijent.Dodatno + "', Telefon='" + klijent.Telefon + "', Mail='" + klijent.Mail + "' where Sifra='"+sifra+"'");
            }
        }

        public static void IzbrisiKlijenta(int sifra)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from Klijenti where Sifra='" + sifra + "'");
            }
        }



        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
