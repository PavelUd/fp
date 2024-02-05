using System.Drawing.Text;
using System.Windows.Forms;
using TagsCloud.App.Infrastructure;
using TagsCloud.App.Settings;
using TagsCloud.Infrastructure;
using TagsCloud.Infrastructure.UiActions;

namespace TagsCloud.App.Actions;

public class TagSettingsAction : IUiAction
{
    private readonly TagSettings tag;
    private readonly HashSet<string> fonts;

    public TagSettingsAction(TagSettings tag)
    {
        this.tag = tag;
        fonts = new InstalledFontCollection().Families.Select(f => f.Name.ToLower()).ToHashSet();
    }

    public MenuCategory Category => MenuCategory.Settings;
    public string Name => "Облако тегов...";
    public string Description => "";

    public void Perform()
    {
        SettingsForm.For(tag).ShowDialog();
        
        if (!fonts.Contains(tag.FontFamily.ToLower())){
            ErrorHandler.HandleError($"Шрифт {tag.FontFamily} не найден");
        }

        if (tag.Size < 0){
            ErrorHandler.HandleError($"Размер шрифта не должен быть отрицательным");
        }
    }
}