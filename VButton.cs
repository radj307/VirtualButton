using System.ComponentModel;

namespace VirtualButton
{
    /// <summary>
    /// Virtual Button Click Event.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">Event arguments.</param>
    public delegate void VirtualClickEventHandler(object? sender, EventArgs e);

    /// <summary>
    /// Virtual button component that implements <see cref="IButtonControl"/> and uses a virtualized click event of type <see cref="VirtualClickEventHandler"/> that enabled custom behaviour.
    /// </summary>
    /// <remarks>This provides an easy implementation for <see cref="Form.CancelButton"/>, <see cref="Form.AcceptButton"/>, and <see cref="Form.HelpButton"/>.</remarks>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Bindable(true)]
    [Browsable(true)]
    public partial class VButton : Component, IButtonControl
    {
        #region Constructors
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public VButton()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor that adds this component to a container.
        /// </summary>
        /// <param name="container">The container to add this component to.</param>
        public VButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        /// <summary>
        /// Constructor that accepts an event handler.
        /// </summary>
        /// <param name="clickHandler">An event handler to call whenever the button is 'clicked'</param>
        public VButton(VirtualClickEventHandler clickHandler)
        {
            InitializeComponent();

            Click += clickHandler;
        }
        #endregion Constructors

        #region Properties
        /// <summary>Gets or sets a value that is returned to the parent form when the button is clicked./// </summary>
        /// <remarks>One of the System.Windows.Forms.DialogResult values. The default value is None.</remarks>
        /// <exception cref="InvalidEnumArgumentException">The value assigned is not one of the System.Windows.Forms.DialogResult values.</exception>
        [DefaultValue(DialogResult.None)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)] // ensure this is shown in the designer
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        [Browsable(true)]
        public DialogResult DialogResult { get; set; }
        #endregion Properties

        #region Events

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)] // ensure this is shown in the designer
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        [Browsable(true)]
        public event VirtualClickEventHandler? Click = null;
        private void NotifyClick(EventArgs e)
            => Click?.Invoke(this, e);
        #endregion Events

        #region ControlEventHandlers
        public virtual void NotifyDefault(bool value) { }
        public void PerformClick() => NotifyClick(EventArgs.Empty);
        #endregion ControlEventHandlers
    }
}
