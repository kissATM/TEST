using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace DeltaCat.BarCode
{
    public sealed class Code39
    {
        #region private variables
        /// <summary>
        /// The Space Between each of Title, BarCode, BarCodeString 
        /// </summary>
        private const int SPACE_HEIGHT = 3;
        SizeF _sizeLabel = SizeF.Empty;
        SizeF _sizeBarCodeValue = SizeF.Empty;
        SizeF _sizeBarCodeString = SizeF.Empty;
        SizeF _sizeAdditionalInfo = SizeF.Empty;

        #endregion

        #region Label
        private string _label = null;
        private Font _labelFont = null;
        /// <summary>
        /// BarCode Title (条码标签)
        /// </summary>
        public string Label
        {
            set { _label = value; }
        }
        /// <summary>
        /// BarCode Title Font (条码标签使用的字体)
        /// </summary>
        public Font LabelFont
        {
            get
            {
                if (_labelFont == null)
                    return new Font("Arial", 10);
                return _labelFont;
            }
            set { _labelFont = value; }
        }
        #endregion

        private string _additionalInfo = null;
        private Font _addtionalInfoFont = null;
        /// <summary>
        /// Additional Info Font (附加信息字体)
        /// </summary>
        public Font AdditionalInfoFont
        {
            set { _addtionalInfoFont = value; }
            get
            {
                if (_addtionalInfoFont == null) return new Font("Arial", 10);
                return _addtionalInfoFont;
            }
        }
        /// <summary>
        /// Additional Info Content, if "ShowBarCodeValue" is true, the info is unvisible
        /// 附加信息，如果设置ShowBarCodeValue为true,则此项不显示
        /// </summary>
        public string AdditionalInfo
        {
            set { _additionalInfo = value; }
        }

        #region BarCode Value and Font
        private string _barCodeValue = null;
        /// <summary>
        /// BarCode Value (条码值)
        /// </summary>
        public string BarCodeValue
        {
            get
            {
                if (string.IsNullOrEmpty(_barCodeValue))
                    throw new NullReferenceException("The BarCodeValue has not been set yet!");
                return _barCodeValue;
            }
            set { _barCodeValue = value.StartsWith("*") && value.EndsWith("*") ? value : "*" + value + "*"; }
        }

        private bool _showBarCodeValue = false;
        /// <summary>
        /// whether to show the original string of barcode value bellow the barcode
        /// 是否在条码下方显示条码值，默认为false
        /// </summary>
        public bool ShowBarCodeValue
        {
            set { _showBarCodeValue = value; }
        }

        private Font _barCodeValueFont = null;
        /// <summary>
        /// the font of the codestring to show
        /// 条码下方显示的条码值的字体
        /// </summary>
        public Font BarCodeValueFont
        {
            get
            {
                if (_barCodeValueFont == null)
                    return new Font("Arial", 10);
                return _barCodeValueFont;
            }
            set { _barCodeValueFont = value; }
        }

        private int _barCodeFontSize = 50;
        /// <summary>
        /// the font size of the barcode value to draw
        /// 条码绘制的大小，默认50
        /// </summary>
        public int BarCodeFontSzie
        {
            set { _barCodeFontSize = value; }
        }
        #endregion

        #region generate the barcode image
        private Bitmap BlankBackImage
        {
            get
            {
                int barCodeWidth = 0, barCodeHeight = 0;
                using (Bitmap bmp = new Bitmap(1, 1, PixelFormat.Format32bppArgb))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        if (!string.IsNullOrEmpty(_label))
                        {
                            _sizeLabel = g.MeasureString(_label, LabelFont);
                            barCodeWidth = (int)_sizeLabel.Width;
                            barCodeHeight = (int)_sizeLabel.Height + SPACE_HEIGHT;
                        }

                        _sizeBarCodeValue = g.MeasureString(BarCodeValue, new Font("Free 3 of 9 Extended", _barCodeFontSize));
                        barCodeWidth = Math.Max(barCodeWidth, (int)_sizeBarCodeValue.Width);
                        barCodeHeight += (int)_sizeBarCodeValue.Height;

                        if (_showBarCodeValue)
                        {
                            _sizeBarCodeString = g.MeasureString(_barCodeValue, BarCodeValueFont);
                            barCodeWidth = Math.Max(barCodeWidth, (int)_sizeBarCodeString.Width);
                            barCodeHeight += (int)_sizeBarCodeString.Height + SPACE_HEIGHT;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(_additionalInfo))
                            {
                                _sizeAdditionalInfo = g.MeasureString(_additionalInfo, AdditionalInfoFont);
                                barCodeWidth = Math.Max(barCodeWidth, (int)_sizeAdditionalInfo.Width);
                                barCodeHeight += (int)_sizeAdditionalInfo.Height + SPACE_HEIGHT;
                            }
                        }
                    }
                }

                return new Bitmap(barCodeWidth, barCodeHeight, PixelFormat.Format32bppArgb);
            }
        }

        /// <summary>
        /// Draw the barcode value to the blank back image and output it to the browser
        /// 绘制WebForm形式的条码
        /// </summary>
        /// <param name="ms">Recommand the "Response.OutputStream" 使用 Response.OutputStream</param>
        /// <param name="imageFormat">The Image format to the Browser 输出到浏览器到图片格式，建议GIF</param>
        public void CreateWebForm(Stream ms, ImageFormat imageFormat)
        {
            int barCodeWidth, barCodeHeight;
            using (Bitmap bmp = this.BlankBackImage)
            {
                barCodeHeight = bmp.Height;
                barCodeWidth = bmp.Width;
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    int vPos = 0;
                    ////Draw Label String
                    if (!string.IsNullOrEmpty(_label))
                    {
                        g.DrawString(_label, LabelFont, new SolidBrush(Color.Black),
                            XCenter((int)_sizeLabel.Width, barCodeWidth), vPos);
                        vPos += (int)_sizeLabel.Height + SPACE_HEIGHT;
                    }
                    else { vPos = SPACE_HEIGHT; }

                    ////Draw The Bar Value
                    g.DrawString(_barCodeValue, new Font("Free 3 of 9 Extended", _barCodeFontSize), new SolidBrush(Color.Black),
                        XCenter((int)_sizeBarCodeValue.Width, barCodeWidth), vPos);
                    ////Draw the BarValue String
                    if (_showBarCodeValue)
                    {
                        g.DrawString(_barCodeValue, BarCodeValueFont, new SolidBrush(Color.Black),
                            XCenter((int)_sizeBarCodeString.Width, barCodeWidth),
                            vPos + (int)_sizeBarCodeValue.Height);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(_additionalInfo))
                        {
                            g.DrawString(_additionalInfo, AdditionalInfoFont, new SolidBrush(Color.Black),
                            XCenter((int)_sizeAdditionalInfo.Width, barCodeWidth),
                            vPos + (int)_sizeBarCodeValue.Height);
                        }
                    }
                }

                bmp.Save(ms, imageFormat);
            }
        }
        /// <summary>
        /// 生成winform格式的条码
        /// </summary>
        /// <param name="imageFormat">图片格式，建议GIF</param>
        /// <returns>Stream类型</returns>
        public Stream CreateWinForm(ImageFormat imageFormat)
        {
            int barCodeWidth, barCodeHeight;
            using (Bitmap bmp = this.BlankBackImage)
            {
                barCodeHeight = bmp.Height;
                barCodeWidth = bmp.Width;
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    int vPos = 0;
                    ////Draw Label String
                    if (!string.IsNullOrEmpty(_label))
                    {
                        g.DrawString(_label, LabelFont, new SolidBrush(Color.Black),
                            XCenter((int)_sizeLabel.Width, barCodeWidth), vPos);
                        vPos += (int)_sizeLabel.Height + SPACE_HEIGHT;
                    }
                    else { vPos = SPACE_HEIGHT; }

                    ////Draw The Bar Value
                    g.DrawString(_barCodeValue, new Font("Free 3 of 9 Extended", _barCodeFontSize), new SolidBrush(Color.Black),
                        XCenter((int)_sizeBarCodeValue.Width, barCodeWidth), vPos);
                    ////Draw the BarValue String
                    if (_showBarCodeValue)
                    {
                        g.DrawString(_barCodeValue, BarCodeValueFont, new SolidBrush(Color.Black),
                            XCenter((int)_sizeBarCodeString.Width, barCodeWidth),
                            vPos + (int)_sizeBarCodeValue.Height);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(_additionalInfo))
                        {
                            g.DrawString(_additionalInfo, AdditionalInfoFont, new SolidBrush(Color.Black),
                            XCenter((int)_sizeAdditionalInfo.Width, barCodeWidth),
                            vPos + (int)_sizeBarCodeValue.Height);
                        }
                    }
                }

                Stream ms = new MemoryStream();
                bmp.Save(ms, imageFormat);
                return ms;
            }
        }
        #endregion

        private static int XCenter(int subWidth, int globalWidth)
        {
            return (globalWidth - subWidth) / 2;
        }

        #region copyright
        /// <summary>
        /// 版权信息，请保留
        /// </summary>
        public string CopyRight
        {
            get { return "JCTM"; }
        }
        #endregion
    }
}
