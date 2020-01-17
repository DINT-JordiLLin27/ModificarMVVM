using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    class MainWindowVM : INotifyPropertyChanged
    {

        private InformesEntities contexto;
        public CLIENTE CLIENTE_SELECCIONADO { get; set; }
        public ObservableCollection<CLIENTE> LISTA_CLIENTES { get; set; }
        public MainWindowVM()
        {
            contexto = new InformesEntities();
            contexto.CLIENTES.Load();
            LISTA_CLIENTES = contexto.CLIENTES.Local;
        }

        public void Modificar()
        {
            contexto.SaveChanges();
        }

        public string GetClienteNombreCompleto()
        {
            return CLIENTE_SELECCIONADO.nombre + " " + CLIENTE_SELECCIONADO.apellido;
        }

        public bool canExecute() {
            return CLIENTE_SELECCIONADO != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
