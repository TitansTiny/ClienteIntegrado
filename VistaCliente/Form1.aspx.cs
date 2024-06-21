using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaCliente.ProductosServiceReference;

namespace VistaCliente
{
    public partial class Form1 : Page
    {
        private ProductosServiceSoapClient _serviceClient;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verificar autenticación simple (esto es solo un ejemplo, en producción usar métodos más seguros)
                if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
                {
                    Response.Redirect("Login.aspx");
                }

                InitializeServiceClient();
                ListarProductos();
            }
        }

        private void InitializeServiceClient()
        {
            if (_serviceClient == null)
            {
                _serviceClient = new ProductosServiceSoapClient();
            }
        }

        private void ListarProductos()
        {
            try
            {
                DTOProductos[] productosArray = _serviceClient.ListarProductos();
                List<DTOProductos> productos = new List<DTOProductos>(productosArray);
                dgvProductos.DataSource = productos;
                dgvProductos.DataBind();
            }
            catch (Exception ex)
            {
                lblResultado.Text = $"Error: {ex.Message}";
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            ListarProductos();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                InitializeServiceClient();
                DTOProductos producto = new DTOProductos
                {
                    Id = int.Parse(txtId.Text),
                    Name = txtNombre.Text,
                    Desc = txtDescripcion.Text,
                    Imagen = txtImagen.Text,
                    Tienda = txtTienda.Text
                };

                string result = _serviceClient.AgregarProducto(producto);
                lblResultado.Text = result;
                ListarProductos();
            }
            catch (Exception ex)
            {
                lblResultado.Text = $"Error: {ex.Message}";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                InitializeServiceClient();
                DTOProductos producto = new DTOProductos
                {
                    Id = int.Parse(txtId.Text),
                    Name = txtNombre.Text,
                    Desc = txtDescripcion.Text,
                    Imagen = txtImagen.Text,
                    Tienda = txtTienda.Text
                };

                string result = _serviceClient.ActualizarProducto(producto);
                lblResultado.Text = result;
                ListarProductos();
            }
            catch (Exception ex)
            {
                lblResultado.Text = $"Error: {ex.Message}";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                InitializeServiceClient();
                DTOProductos producto = new DTOProductos
                {
                    Id = int.Parse(txtId.Text)
                };

                string result = _serviceClient.EliminarProducto(producto);
                lblResultado.Text = result;
                ListarProductos();
            }
            catch (Exception ex)
            {
                lblResultado.Text = $"Error: {ex.Message}";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                InitializeServiceClient();
                string nombre = txtNombreBuscar.Text;
                DTOProductos[] productosArray = _serviceClient.BuscarProductoPorNombre(nombre);
                List<DTOProductos> productos = new List<DTOProductos>(productosArray);
                dgvProductos.DataSource = productos;
                dgvProductos.DataBind();
            }
            catch (Exception ex)
            {
                lblResultado.Text = $"Error: {ex.Message}";
            }
        }

        protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            InitializeServiceClient();
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                try
                {
                    // Asumimos que tienes un método para obtener un producto por ID, si no existe, este código necesitará ser ajustado.
                    DTOProductos producto = _serviceClient.ListarProductos().FirstOrDefault(p => p.Id == id);
                    if (producto != null)
                    {
                        txtId.Text = producto.Id.ToString();
                        txtNombre.Text = producto.Name;
                        txtDescripcion.Text = producto.Desc;
                        txtImagen.Text = producto.Imagen;
                        txtTienda.Text = producto.Tienda;
                    }
                }
                catch (Exception ex)
                {
                    lblResultado.Text = $"Error: {ex.Message}";
                }
            }
            else if (e.CommandName == "Eliminar")
            {
                try
                {
                    DTOProductos producto = new DTOProductos { Id = id };
                    string result = _serviceClient.EliminarProducto(producto);
                    lblResultado.Text = result;
                    ListarProductos();
                }
                catch (Exception ex)
                {
                    lblResultado.Text = $"Error: {ex.Message}";
                }
            }
        }
    }
}