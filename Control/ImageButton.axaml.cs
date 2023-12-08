using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;

namespace AvaloniaImageButton.Control;

public class ImageButton : Button
{
    public static readonly StyledProperty<IImage> CurrentImageProperty =
    AvaloniaProperty.Register<ImageButton, IImage>(nameof(CurrentImage));

    public static readonly StyledProperty<IImage> UnCheckedImageProperty =
        AvaloniaProperty.Register<ImageButton, IImage>(nameof(UnCheckedImage));

    public static readonly StyledProperty<IImage> UnCheckedHoverImageProperty =
        AvaloniaProperty.Register<ImageButton, IImage>(nameof(UnCheckedHoverImage));

    public static readonly StyledProperty<IImage> UnCheckedPressedImageProperty =
        AvaloniaProperty.Register<ImageButton, IImage>(nameof(UnCheckedPressedImage));

    public static readonly StyledProperty<IImage> CheckedImageProperty =
        AvaloniaProperty.Register<ImageButton, IImage>(nameof(CheckedImage));

    public static readonly StyledProperty<IImage> CheckedHoverImageProperty =
        AvaloniaProperty.Register<ImageButton, IImage>(nameof(CheckedHoverImage));

    public static readonly StyledProperty<IImage> CheckedPressedImageProperty =
        AvaloniaProperty.Register<ImageButton, IImage>(nameof(CheckedPressedImage));

    public static readonly StyledProperty<IImage> DisabledImageProperty =
        AvaloniaProperty.Register<ImageButton, IImage>(nameof(DisabledImage));

    public IImage CurrentImage
    {
        get { return GetValue(CurrentImageProperty); }
        set { SetValue(CurrentImageProperty, value); }
    }

    public IImage UnCheckedImage
    {
        get => GetValue(UnCheckedImageProperty);
        set => SetValue(UnCheckedImageProperty, value);
    }

    public IImage UnCheckedHoverImage
    {
        get => GetValue(UnCheckedHoverImageProperty);
        set => SetValue(UnCheckedHoverImageProperty, value);
    }

    public IImage UnCheckedPressedImage
    {
        get => GetValue(UnCheckedPressedImageProperty);
        set => SetValue(UnCheckedPressedImageProperty, value);
    }

    public IImage CheckedImage
    {
        get => GetValue(CheckedImageProperty);
        set => SetValue(CheckedImageProperty, value);
    }

    public IImage CheckedHoverImage
    {
        get => GetValue(CheckedHoverImageProperty);
        set => SetValue(CheckedHoverImageProperty, value);
    }

    public IImage CheckedPressedImage
    {
        get => GetValue(UnCheckedPressedImageProperty);
        set => SetValue(UnCheckedPressedImageProperty, value);
    }

    public IImage DisabledImage
    {
        get => GetValue(DisabledImageProperty);
        set => SetValue(DisabledImageProperty, value);
    }

    private bool isHovering = false;

    private bool isChecked = false;
    public bool IsChecked
    {
        get { return isChecked; }
        set
        {
            if (!value)
            {
                if (!isHovering)
                    CurrentImage = UnCheckedImage;
                else
                    CurrentImage = UnCheckedHoverImage;
            }
            else
            {
                if (!isHovering)
                    CurrentImage = CheckedImage;
                else
                    CurrentImage = CheckedHoverImage;
            }
            isChecked = value;
        }
    }

    private bool isDisabled = false;
    public bool IsDisabled
    {
        get { return isDisabled; }
        set
        {
            if (value)
            {
                CurrentImage = DisabledImage;
            }
            else
            {
                if (IsChecked)
                {
                    if (CheckedImage != null)
                        CurrentImage = CheckedImage;
                }
                else
                {
                    if (UnCheckedImage != null)
                        CurrentImage = UnCheckedImage;
                }
            }

            isDisabled = value;
        }
    }

    public ImageButton()
    {
    }

    protected override void OnPointerEntered(PointerEventArgs e)
    {
        isHovering = true;

        if (IsChecked)
        {
            if (CheckedHoverImage != null)
                CurrentImage = CheckedHoverImage;
        }
        else
        {
            if (UnCheckedHoverImage != null)
                CurrentImage = UnCheckedHoverImage;
        }

        base.OnPointerEntered(e);
    }

    protected override void OnPointerExited(PointerEventArgs e)
    {
        isHovering = false;

        if (IsChecked)
        {
            if (CheckedImage != null)
                CurrentImage = CheckedImage;
        }
        else
        {
            if (UnCheckedImage != null)
                CurrentImage = UnCheckedImage;
        }

        base.OnPointerExited(e);
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        if (IsChecked)
        {
            if (CheckedPressedImage != null)
                CurrentImage = CheckedPressedImage;
        }
        else
        {
            if (UnCheckedPressedImage != null)
                CurrentImage = UnCheckedPressedImage;
        }

        base.OnPointerPressed(e);
    }

    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        if (IsChecked)
        {
            if (CheckedPressedImage != null)
                CurrentImage = CheckedImage;
        }
        else
        {
            if (UnCheckedPressedImage != null)
                CurrentImage = UnCheckedImage;
        }

        base.OnPointerReleased(e);
    }

}