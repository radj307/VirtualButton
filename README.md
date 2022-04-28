# VirtualButton

***This was made for .NET Core 6***, but doesn't rely on anything specific to it - feel free to build it for .NET Framework or other .NET Core versions as needed.

## Getting Started

### Installation
#### A) Nuget

 1. If you're using Visual Studio, right-click on your project or solution & select _Manage Nuget Packages_.
    ![image](https://user-images.githubusercontent.com/1927798/164995108-0be2b831-5be5-4e48-8184-46fb5149c54a.png)
 2. Switch to the _Browse_ tab & search for `VirtualButton`, then click the install icon.
    ![image](https://user-images.githubusercontent.com/1927798/164995054-d7657482-1371-4a1c-9850-9d8a0d032ca5.png)  

#### B) From Source

 1. Clone the repository to a location of your choice *(for best results, use a git submodule)*, and add it to your solution.
 2. Add a project reference in the project you want to use the virtual button in:  
    ![Adding a Project Reference](https://user-images.githubusercontent.com/1927798/164982597-daf4e9ec-0268-4a22-b85a-af4fb755610f.png)

### Usage
*This assumes you already have a form or control, and know how to create them.*

In order for the virtual button's `Click` events to fire correctly, you must assign *(or reassign)* `Form.(...)Button` programmatically outside of the designer at least once.
```cs
public partial class Form1 : Form
{
  public Form1()
  {
    InitializeComponent();
    
    CancelButton = virtualButton1; //< this has to happen before Click events can fire. (thank microsoft)
  }
}
```
For more detail on implementations, see below.

#### Designer Usage

 1. If the installation was successful, you will have a `VirtualButton` item in the designer toolbox:  
    *(as of v2.0.0+ this is now named `VirtualButton.VButton`, which appears as `VButton`)*  
    ![image](https://user-images.githubusercontent.com/1927798/164983021-a89296ca-31ad-4080-af3b-d7c9aaad1637.png)
 2. Select the `VirtualButton` item, then click somewhere on your form/control. You will now have a new component:  
    ![image](https://user-images.githubusercontent.com/1927798/164983139-7f07d7e1-34d0-4c92-abd3-dbb3d51f2500.png)
    
##### Handling Virtual Click Events
- Define a handler for the click event by double-clicking in the `Click` dropdown, or by selecting an already-existing function.  
![image](https://user-images.githubusercontent.com/1927798/164983215-3385cb07-3abf-4693-8191-6cb9ca03b832.png)

##### Setting Built-In Form Buttons
- Now that you have a `VirtualButton` added to the form/control, you can select it from the `Form` `CancelButton`/`AcceptButton`/`HelpButton` dropdown boxes:  
![image](https://user-images.githubusercontent.com/1927798/164983539-d566ced2-9b96-4796-9cc9-63cba59b2202.png)


#### Programmatic Usage
```cs
public class Form1 : Form
{
     public Form1()
     {
         InitializeComponent();
         
         // Initialize the virtual button:
         vbCancelButton = new(delegate{ this.Close() });
         
         // Assign the virtual button as the form button handler:
         this.CancelButton = vbCancelButton;
     }
     
     private readonly VirtualButton vbCancelButton;
}
```
