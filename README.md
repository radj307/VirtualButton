<br/><p align="center"><img alt="Virtual Button" src="https://i.imgur.com/cDHvGW9.png"/><br/><b>▼ NuGet ▼</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>▼ Github ▼</b><br/>
<a href="https://www.nuget.org/packages/VirtualButton"><img alt="Nuget" src="https://img.shields.io/nuget/dt/VirtualButton?color=7B4CB5&label=Downloads&labelColor=4C277A&logo=nuget&logoColor=ECECEC&style=for-the-badge"/></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="https://github.com/radj307/VirtualButton"><img alt="GitHub tag (latest by date)" src="https://img.shields.io/github/v/tag/radj307/VirtualButton?color=4C277A&label=Version&labelColor=7B4CB5&logo=github&logoColor=ECECEC&style=for-the-badge"/></a>
</p>

***

<p align="center"><b>Lightweight WinForms component that makes implementing handlers for the built-in form buttons a breeze!</b><br/>Of course, you can use it for whatever you want to - it is compatible with anything that accepts <code>IButtonControl</code> interfaces.</p>

# Installation
*Visual Studio*
 
 1. Right-Click on a `.csproj` or `.sln` file in the solution explorer, then click the ![***Manage NuGet Packages...***](https://user-images.githubusercontent.com/1927798/164995108-0be2b831-5be5-4e48-8184-46fb5149c54a.png) button.  
      
 2. Switch to the ***Browse*** tab and search for '__Virtual Button__'

 3. Click on the ***Install*** button next to the package description:  
    ![](https://i.imgur.com/8TkTbup.png)  
    The code is open-sourced under the [GPLv3](https://github.com/radj307/VirtualButton/blob/main/LICENSE) license.

# Usage

You can add virtual buttons using the designer, or entirely programmatically.  
`VButton` appears at the bottom alongside other components, such as `NotifyIcon`, `Timer`, `BindingSource`, etc.

## Designer

1. Once you have the NuGet package installed, open the designer toolbox *(You may have to recompile the project for it to appear.)* and add the `VButton` component somewhere.  
2. In the properties window, create a handler for the `Click` event, and put whatever code you want to execute when the associated key is pressed in the handler.
3. Re-assign the button property at least once before attempting to use it.  
    Common places to do this are the form's constructor or `Form.Load` event, for example:
```cs
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
		
        // Even though we set this in the designer, we have
        //  to set it again manually for it to work correctly:
        this.CancelButton = vButton1;
    }
}
```

## Programmatic

You can create VButtons with ad-hoc delegates:
```cs
this.CancelButton = new VButton(delegate{
    // Do something
});
```

Or with any event handler compatible with `HandledEventHandler`:
```cs
private void HandlerOfHandledEvents(object sender, HandledEventArgs e)
{
    // ...
}

private void Form1_Load(object sender, EventArgs e)
{
    vButton1.Click += HandlerOfHandledEvents!;
}
```
