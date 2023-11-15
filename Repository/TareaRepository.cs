using System.Data.SQLite;
using EspacioTablero;

namespace EspacioRepositorios
{
    class TareaRepository: ITareaRepository{
    private string cadenaConexion = "Data Source=DB/;Cache=Shared";

        public void CrearTarea(int idTablero, Tarea tarea)
        {
            var query = $"INSERT INTO Tarea (id_tablero, nombre, estado, descripcion, color, id_usuario_asignado) VALUES (@id_tablero, @name, @estado, @descripcion, @color, @usuario)";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {

                connection.Open();
                var command = new SQLiteCommand(query, connection);

                command.Parameters.Add(new SQLiteParameter("@id_tablero", idTablero)); // porque le estamos mandando por parametro 
                command.Parameters.Add(new SQLiteParameter("@name", tarea.Nombre));
                command.Parameters.Add(new SQLiteParameter("@estado", (int)tarea.Estado)); 
                command.Parameters.Add(new SQLiteParameter("@descripcion", tarea.Descripcion));
                command.Parameters.Add(new SQLiteParameter("@color", tarea.Color));
                command.Parameters.Add(new SQLiteParameter("@usuario", tarea.Id_usuario_asignado));

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public void Update(int id, Tarea tarea)
        {
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            SQLiteCommand command = connection.CreateCommand();
            // No usar así usar, el AddParameter
            var query = $"UPDATE Tarea SET id_tablero = '{tarea.Id_tablero}', nombre = ('{tarea.Nombre}'), estado = '{tarea.Estado}', descripcion = '{tarea.Descripcion}', color = '{tarea.Color}', id_usuario_asignado = '{tarea.Id_usuario_asignado}' WHERE id_tarea = '{tarea.Id}';";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public Tarea GetById(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            var tarea = new Tarea();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Tarea WHERE id_tarea = @id";
            command.Parameters.Add(new SQLiteParameter("@id", id));
            connection.Open();
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tarea.Id = Convert.ToInt32(reader["id_tarea"]);
                    tarea.Id_tablero = Convert.ToInt32(reader["id_tablero"]);
                    tarea.Nombre = reader["nombre"].ToString();
                    tarea.Estado = (EstadoTarea)Enum.ToObject(typeof(EstadoTarea), Convert.ToInt32(reader["estado"])); // Hacer metodo por separado?
                    tarea.Descripcion = reader["descricion"].ToString();
                    tarea.Color = reader["color"].ToString();
                    tarea.Id_usuario_asignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                }
            }
            connection.Close();

            return tarea;
        }
        public List<Tarea> GetTareaUsuario(int idUsuario)
        {
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            List<Tarea> tareas = new List<Tarea>();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Tarea WHERE id_usuario_asignado = @asignado";
            command.Parameters.Add(new SQLiteParameter("@asignado", idUsuario));
            connection.Open();
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var tarea = new Tarea
                    {
                        Id = Convert.ToInt32(reader["id_tarea"]),
                        Id_tablero = Convert.ToInt32(reader["id_tablero"]),
                        Nombre = reader["nombre"].ToString(),
                        Estado = (EstadoTarea)Enum.ToObject(typeof(EstadoTarea), Convert.ToInt32(reader["estado"])), // Hacer metodo por separado?
                        Descripcion = reader["descricion"].ToString(),
                        Color = reader["color"].ToString(),
                        Id_usuario_asignado = Convert.ToInt32(reader["id_usuario_asignado"])
                    };
                    tareas.Add(tarea);
                }
            }
            connection.Close();

            return tareas;
        }
        public List<Tarea> GetTareaTablero(int idTablero)
        {
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            List<Tarea> tareas = new List<Tarea>();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Tarea WHERE id_tablero = @tablero";
            command.Parameters.Add(new SQLiteParameter("@tablero", idTablero));
            connection.Open();
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var tarea = new Tarea
                    {
                        Id = Convert.ToInt32(reader["id_tarea"]),
                        Id_tablero = Convert.ToInt32(reader["id_tablero"]),
                        Nombre = reader["nombre"].ToString(),
                        Estado = (EstadoTarea)Enum.ToObject(typeof(EstadoTarea), Convert.ToInt32(reader["estado"])), // Hacer metodo por separado?
                        Descripcion = reader["descricion"].ToString(),
                        Color = reader["color"].ToString(),
                        Id_usuario_asignado = Convert.ToInt32(reader["id_usuario_asignado"])
                    };
                    tareas.Add(tarea);
                }
            }
            connection.Close();

            return tareas;
        }
        public void RemoveTarea(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM Tarea WHERE id_tarea = @id;";
            command.Parameters.Add(new SQLiteParameter("@id", id));
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void AsignarUsuario(int idTarea, int idUsuario)
        {
            var query = $"UPDATE Tarea SET id_usuario_asignado = (@usuario) WHERE id_tarea = (@id);";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);

                command.Parameters.Add(new SQLiteParameter("@usuario", idUsuario));

                command.Parameters.Add(new SQLiteParameter("@id", idTarea));

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

    }
}        
