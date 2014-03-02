#FontAwesome.Xamarin

This is a simple library to help when using [FontAwesome](http://fortawesome.github.io/Font-Awesome/) with Xamarin.iOS. All v4.0.3 icons from the [cheatsheet](http://fortawesome.github.io/Font-Awesome/cheatsheet/) are included.

##Getting started

- Add dist/FontAwesome.Xamarin.dll to your project
- Add dist/FontAwesome.ttf to the Resources directory of your project
    - Set Build Action to "BundleResource"
    - Set Copy to output directory to "Always Copy"
- Open Info.plist
    - Click on the Source tab
    - Add a new property and select "Fonts provided by application" from the dropdown list
    - Add a new item to the array called FontAwesome.ttf
    
##Using it
###FontAwesome.cs
Once the library and font have been added, using FontAwesome is very simple. There is one static method `.Font(int size)` that returns the `UIFont` class with the specified size. Each icon is listed as a static method. The CSS class of `fa-lock` would become `FontAwesome.FALock`.

```csharp
using FontAwesomeXamarin;

UILabel lockLabel = new UILabel (new RectangleF (0, 30, 320, 100)) {
    Font = FontAwesome.Font(100), //100 is the font size we want to use
    Text = FontAwesome.FALock, //Here we're using the lock icon "fa-lock"
    TextColor = UIColor.White,
    TextAlignment = UITextAlignment.Center
};
```

Because FontAwesome is a font based icon library we can set the text color and size in the same way we would for any other regular font.

###FABarButtonItem.cs
This will create a `UIBarButtonItem` with a FontAwesome icon that can be used in a `UINavigationBar`. Internally it uses a `UIButton` for the font and click event and adds it as the `CustomView` of the `UIBarButtonItem`.

```csharp
NavigationItem.RightBarButtonItem = new FABarButtonItem (FontAwesome.FATrashO, UIColor.White, delegate {
    //Click event handler
});
```
