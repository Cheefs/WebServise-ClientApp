using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;

namespace WebAPIClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IViev
    {
        public IEnumerable<Departament> DepTemp { get; set; }
        public IEnumerable<Employe> EmployeTemp { get; set; }
        string  ID { get => TbxId.Text; set => TbxId.Text = value; }
        
        static HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();

            ModelDepartament md = new ModelDepartament(this);
            ModelEmploye me = new ModelEmploye(this);
      
            client.BaseAddress = new Uri("http://localhost:59851/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new
            MediaTypeWithQualityHeaderValue("application/json"));

            BtnShowEmp.Click += delegate { listVievEmpl.ItemsSource = EmployeTemp;  me.GetIdEmpl(ID);};
            BtnShowDep.Click += delegate { listVievDep.ItemsSource = DepTemp; md.GetIdDep(ID);};


            btnInfo.Click += delegate 
            {
                MessageBox.Show( @"Введите нужный айди,
и дважды кликните на интересующий вас список либо оставьте пустую строку и щелкните дважды
на интересующий вас пункт,чтоб увидеть полный список","Info");
            };
        }

    }
}

     
