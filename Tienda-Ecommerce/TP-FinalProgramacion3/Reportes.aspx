<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8">
    <title>Reportes</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="d-flex" id="wrapper">        
            <!-- Contenido principal -->
            <div class="container-fluid p-4" id="content">

                <div class="row">
                    <div class="col-md-4">
                        <div class="card bg-primary text-white">
                            <div class="card-body">
                                <h5 class="card-title">Usuarios Registrados</h5>
                                <p class="card-text fs-2">150</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="card bg-success text-white">
                            <div class="card-body">
                                <h5 class="card-title">Ventas del Mes</h5>
                                <p class="card-text fs-2">$12,500</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="card bg-warning text-dark">
                            <div class="card-body">
                                <h5 class="card-title">Ventas Totales</h5>
                                <p class="card-text fs-2">8</p>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Sección de gráficos -->
                <div class="row mt-4">
                    <div class="col-md-6">
                        <h4>Ventas Mensuales</h4>
                        <canvas id="barChart"></canvas>
                    </div>
                    <div class="col-md-6">
                        <h4>Distribución de Ventas por Categoria</h4>
                        <canvas id="pieChart"></canvas>
                    </div>
                </div>

                <!-- Tabla de usuarios -->
                <div class="row mt-4">
                    <div class="col-md-12">
                        <h4>Últimos Usuarios Registrados</h4>
                        <table class="table table-striped table-bordered">
                            <thead class="table-dark">
                                <tr>
                                    <th>ID</th>
                                    <th>Nombre</th>
                                    <th>Email</th>
                                    <th>Rol</th>
                                    <th>Fecha Registro</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1</td>
                                    <td>Juan Pérez</td>
                                    <td>juan@example.com</td>
                                    <td>Admin</td>
                                    <td>2024-02-15</td>
                                </tr>
                                <tr>
                                    <td>2</td>
                                    <td>María López</td>
                                    <td>maria@example.com</td>
                                    <td>Usuario</td>
                                    <td>2024-02-18</td>
                                </tr>
                                <tr>
                                    <td>3</td>
                                    <td>Carlos Gómez</td>
                                    <td>carlos@example.com</td>
                                    <td>Editor</td>
                                    <td>2024-02-20</td>
                                </tr>
                                <tr>
                                    <td>4</td>
                                    <td>Laura Fernández</td>
                                    <td>laura@example.com</td>
                                    <td>Usuario</td>
                                    <td>2024-02-22</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>

        <!-- Scripts -->
        <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
        <script>
            // Gráfico de barras (Ventas mensuales)
            var ctxBar = document.getElementById('barChart').getContext('2d');
            var barChart = new Chart(ctxBar, {
                type: 'bar',
                data: {
                    labels: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo'],
                    datasets: [{
                        label: 'Ventas',
                        data: [1200, 1900, 3000, 5000, 2000],
                        backgroundColor: 'rgba(54, 162, 235, 0.6)'
                    }]
                }
            });

            // Gráfico de torta (Distribución de Ventas por Categoria)
            var ctxPie = document.getElementById('pieChart').getContext('2d');
            var pieChart = new Chart(ctxPie, {
                type: 'pie',
                data: {
                    labels: ['Admins', 'Usuarios', 'Editores'],
                    datasets: [{
                        data: [10, 30, 5],
                        backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56']
                    }]
                }
            });
        </script>
    </form>
</body>
</html>
