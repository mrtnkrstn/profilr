using Android.Views;
using Android.Content;
using Android.Util;
using Android.Renderscripts;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace Profilr.Droid.Views
{
    public class BlurringView : View
    {
        private int _downsampleFactor;
        private Color _overlayColor;
        private bool _downsampleFactorChanged;
        private Canvas _blurringCanvas;

        private RenderScript _renderScript;
        private ScriptIntrinsicBlur _blurScript;
        private View _blurredView;
        private int _blurredViewWidth, _blurredViewHeight;

        private Bitmap _bitmapToBlur, _blurredBitmap;
        private Allocation _blurInput, _blurOutput;

        public BlurringView(Context context) : this(context, null)
        {
        }

        public BlurringView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            InitializeRenderScript(context);

            var typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.PxBlurringView);

            SetBlurRadius(typedArray.GetInt(Resource.Styleable.PxBlurringView_blurRadius, 15));
            SetDownsampleFactor(typedArray.GetInt(Resource.Styleable.PxBlurringView_downsampleFactor, 8));
            SetOverlayColor(typedArray.GetColor(Resource.Styleable.PxBlurringView_overlayColor, Color.ParseColor("#AAFFFFFF")));
            typedArray.Recycle();
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);

            if (_blurredView != null)
            {
                if (Prepare())
                {
                    // If the background of the blurred view is a color drawable, we use it to clear
                    // the blurring canvas, which ensures that edges of the child views are blurred
                    // as well; otherwise we clear the blurring canvas with a transparent color.
                    if (_blurredView.Background != null && _blurredView.Background is ColorDrawable) 
                    {
                        _bitmapToBlur.EraseColor(((ColorDrawable)_blurredView.Background).Color);
                    } 
                    else
                    {
                        _bitmapToBlur.EraseColor(Color.Transparent);
                    }

                    _blurredView.Draw(_blurringCanvas);
                    Blur();

                    canvas.Save();
                    canvas.Translate(_blurredView.GetX() - GetX(), _blurredView.GetY() - GetY());
                    canvas.Scale(_downsampleFactor, _downsampleFactor);
                    canvas.DrawBitmap(_blurredBitmap, 0, 0, null);
                    canvas.Restore();
                }

                canvas.DrawColor(_overlayColor);
            }
        }

        public void SetBlurredView(View blurredView)
        {
            _blurredView = blurredView;
        }

        public void SetBlurRadius(int radius)
        {
            _blurScript.SetRadius(radius);
        }

        public void SetDownsampleFactor(int factor)
        {
            if (_downsampleFactor != factor)
            {
                _downsampleFactor = factor;
                _downsampleFactorChanged = true;
            }
        }

        public void SetOverlayColor(Color color)
        {
            _overlayColor = color;
        }

        private void InitializeRenderScript(Context context)
        {
            _renderScript = RenderScript.Create(context);
            _blurScript = ScriptIntrinsicBlur.Create(_renderScript, Element.U8_4(_renderScript));
        }

        protected bool Prepare()
        {
            var width = _blurredView.Width;
            var height = _blurredView.Height;

            if (_blurringCanvas == null || _downsampleFactorChanged
                    || _blurredViewWidth != width || _blurredViewHeight != height)
            {
                _downsampleFactorChanged = false;

                _blurredViewWidth = width;
                _blurredViewHeight = height;

                int scaledWidth = width / _downsampleFactor;
                int scaledHeight = height / _downsampleFactor;

                // The following manipulation is to avoid some RenderScript artifacts at the edge.
                scaledWidth = scaledWidth - scaledWidth % 4 + 4;
                scaledHeight = scaledHeight - scaledHeight % 4 + 4;

                if (_blurredBitmap == null
                        || _blurredBitmap.Width != scaledWidth
                        || _blurredBitmap.Height != scaledHeight)
                {
                    _bitmapToBlur = Bitmap.CreateBitmap(scaledWidth, scaledHeight,
                            Bitmap.Config.Argb8888);
                    if (_bitmapToBlur == null)
                    {
                        return false;
                    }

                    _blurredBitmap = Bitmap.CreateBitmap(scaledWidth, scaledHeight,
                            Bitmap.Config.Argb8888);
                    if (_blurredBitmap == null)
                    {
                        return false;
                    }
                }

                _blurringCanvas = new Canvas(_bitmapToBlur);
                _blurringCanvas.Scale(1f / _downsampleFactor, 1f / _downsampleFactor);
                _blurInput = Allocation.CreateFromBitmap(_renderScript, _bitmapToBlur,
                        Allocation.MipmapControl.MipmapNone, AllocationUsage.Script);
                _blurOutput = Allocation.CreateTyped(_renderScript, _blurInput.Type);
            }
            return true;
        }

        protected void Blur()
        {
            _blurInput.CopyFrom(_bitmapToBlur);
            _blurScript.SetInput(_blurInput);
            _blurScript.ForEach(_blurOutput);
            _blurOutput.CopyTo(_blurredBitmap);
        }
    }
}
