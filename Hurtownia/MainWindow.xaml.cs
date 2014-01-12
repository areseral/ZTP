using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace Hurtownia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Zaloguj(object sender, RoutedEventArgs e)
        {
            if(!textLogin.Text.Equals("") && !textHaslo.Text.Equals(""))
            {
                int sukces = 0;
                DataTable dt;
                SQLlite baza = new SQLlite();
                dt = baza.Read("SELECT * FROM Uzytkownik WHERE login ='"+ this.textLogin.Text +"' and haslo = '"+ this.textHaslo.Text +"'");
                
                if (dt != null)
                {
                    sukces = 0;
                    foreach(DataRow row in dt.Rows)
                    {
                        if (row["login"].ToString().Equals(textLogin.Text) && row["haslo"].ToString().Equals(textHaslo.Text))
                        {
                            if (row["rola"].ToString().Equals("admin"))
                            {
                                HurtPanel hurtOkno = new HurtPanel();
                                hurtOkno.Show();
                                this.Close();
                                sukces = 1;
                            }
                            else if (row["rola"].ToString().Equals("user"))
                            {
                                PlacPanel placOkno; // = new PlacPanel();
                                int k = 0;
                                Int32.TryParse(row["Id"].ToString(), out k);
                                placOkno = new PlacPanel(k);
                                placOkno.Show();
                                this.Close();
                                sukces = 1;
                            }
                            break;
                        }
                    }
                }
                //niepowodzenie
                if (sukces == 0)
                {
                    textLogin.Text = "";
                    textHaslo.Text = "";
                    MessageBox.Show("Login lub hasło są nieprawidłowe!");
                }

                /*try
                {
                    int sukces = 0;
                    SqlConnection conn;
                    SqlCommand cmd;
                    SqlParameter param;
                    SqlDataReader rdr;

                    //1. Stworzenie polaczenia
                    conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
                    conn.Open();

                    //2. Stworzenie polecenia
                    cmd = new SqlCommand("SELECT * FROM [User] WHERE login = @loginek AND haslo = @haslo2");
                    cmd.Connection = conn;

                    param = new SqlParameter("loginek", SqlDbType.VarChar);
                    param.Value = textLogin.Text;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("haslo2", SqlDbType.VarChar);
                    param.Value = textHaslo.Text;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    //3. Wykonanie polecenia
                    rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        sukces = 0;
                        while (rdr.Read())
                        {
                            if (rdr.GetString(1).Equals(textLogin.Text) && rdr.GetString(2).Equals(textHaslo.Text))
                            {
                                if (rdr.GetString(4).Equals("admin"))
                                {
                                    HurtPanel hurtOkno = new HurtPanel();
                                    hurtOkno.Show();
                                    this.Close();
                                    sukces = 1;
                                } else if (rdr.GetString(4).Equals("user"))
                                {
                                    PlacPanel placOkno = new PlacPanel();
                                    placOkno.Show();
                                    this.Close();
                                    sukces = 1;
                                }
                                break;
                            }
                        }

                    }
                    //niepowodzenie
                    if (sukces == 0)
                    {
                        textLogin.Text = "";
                        textHaslo.Text = "";
                        MessageBox.Show("Login lub hasło są nieprawidłowe!");
                    }
                    rdr.Close();
                    conn.Close();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                }*/
            }
        }

    }
}
