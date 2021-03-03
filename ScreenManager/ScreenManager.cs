using ScreenManager.Models;
using System.Collections.Generic;

namespace ScreenManager
{
    public class ScreenManager
    {
        private List<Screen> screens { get; } = new List<Screen>();

        // Método que añade una pantalla activa a la lista de pantallas
        public void AddScreen(Screen screen)
        {
            screens.Add(screen);
        }

        // Método que añade una pantalla activa y esconde todas las demas
        public void AddScreenUniqueFocus(Screen screen)
        {
            screens.ForEach(s => s.State = ScreenState.Hiden);
            screens.Add(screen);
        }

        // Método que borra una pantalla según el nombre
        public void RemoveScreen(string screenName)
        {
            screens.Find(s => s.Name == screenName).State = ScreenState.Shutdown;
        }

        // Método que borra una pantalla según la pantalla
        public void RemoveScreen(Screen removeScreen)
        {
            screens.Find(s => s.Name == removeScreen.Name).State = ScreenState.Shutdown;
        }

        // Devuelve una pantalla del estado hidden al estado activo
        public void ActivateScreen(string screenName)
        {
            screens.Find(s => s.Name == screenName).State = ScreenState.Active;
        }

        // Método que coge una pantalla y la pasa al estado hidden
        public void HideScreen(string screenName)
        {
            screens.Find(s => s.Name == screenName).State = ScreenState.Hiden;
        }

        // Método que borra una pantalla y situa el foco en una nueva
        public void RemoveWithFocus(string removeName, string focusScreen)
        {
            foreach (Screen screen in screens)
            {
                if (screen.Name == removeName)
                    screen.State = ScreenState.Shutdown;
                else if (screen.Name == focusScreen)
                    screen.State = ScreenState.Active;
            }
        }

        // Método necesario para actualizar y manejar todas las pantallas
        public void Update()
        {
            List<Screen> removeScreens = new List<Screen>();

            foreach (Screen screen in screens.FindAll(s => s.State == ScreenState.Shutdown))
                removeScreens.Add(screen);

            foreach (Screen screen in removeScreens)
                screens.Remove(screen);

            foreach (Screen screen in screens.FindAll(s => s.State == ScreenState.Active))
            {
                screen.HandleInput();
                screen.Update();
            }
        }

        // Método necesario para dibujar las pantallas. Sólo dibuja las pantallas activas
        public void Draw()
        {
            foreach (Screen screen in screens.FindAll(s => s.State == ScreenState.Active))
                screen.Draw();
        }


    }
}
