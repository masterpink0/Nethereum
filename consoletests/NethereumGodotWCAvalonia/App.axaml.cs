using Avalonia;
using Avalonia.Markup.Xaml;

namespace NethereumGodotAvalonia;

public class App : Application {

	public override void Initialize()
		=> AvaloniaXamlLoader.Load(this);

}
