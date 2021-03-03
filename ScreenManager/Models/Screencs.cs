namespace ScreenManager.Models
{
    public abstract class Screen
    {
        //Nombre de la pantalla que es adaptado de su clase
        public string Name { get { return GetType().Name; } }

        //Estado de la pantalla
        public ScreenState State { get; set; } = ScreenState.Active;

        // Método que controla el input
        public abstract void HandleInput();

        // Método que controla las actualizaciones
        public abstract void Update();

        // Método que controla el dibujado de la pantalla
        public abstract void Draw();

    }
}
