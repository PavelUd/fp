using TagsCloud.App.Infrastructure;
using TagsCloud.CloudLayouter;
using TagsCloud.Infrastructure;
using TagsCloud.Infrastructure.UiActions;

namespace TagsCloud.App.Actions;

public class FlowerCloudAction : IUiAction
{
    private readonly FlowerSpiral flowerSpiral;
    private readonly IImageHolder imageHolder;
    private readonly TagCloudPainter painter;
    private readonly AppSettings settings;

    public FlowerCloudAction(
        IImageHolder imageHolder, TagCloudPainter painter, AppSettings settings, FlowerSpiral spiral)
    {
        flowerSpiral = spiral;
        this.settings = settings;
        this.imageHolder = imageHolder;
        this.painter = painter;
    }

    public void Perform()
    {
        if (settings.File == null)
        {
            ErrorHandler.HandleError("сначала загрузи файл");
            return;
        }
        painter.Paint(settings.File.FullName, flowerSpiral).OnFail(ErrorHandler.HandleError);
    }

    public MenuCategory Category => MenuCategory.Types;
    public string Name => "Цветок";
    public string Description => "";
}