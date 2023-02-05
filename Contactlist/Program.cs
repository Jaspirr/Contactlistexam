
using Contactlist.Services;

var menu = new MenuService();
menu.FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\content.json";


while (true)
{
    menu.WelcomeMenu();
    
}