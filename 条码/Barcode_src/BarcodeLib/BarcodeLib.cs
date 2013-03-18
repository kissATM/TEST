using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.IO;

/* Barcode Library
 * 
 * Written by: Brad Barnhill
 *       Date: September 21, 2007
 * 
 * This library was designed to give developers an easy class to use when they need
 * to generate barcode images from a string of data.
 */
namespace BarcodeLib
{
    #region Enums
    public enum TYPE : int { UNSPECIFIED, UPCA, UPCE, UPC_SUPPLEMENTAL_2DIGIT, UPC_SUPPLEMENTAL_5DIGIT, EAN13, EAN8, Interleaved2of5, Standard2of5, Industrial2of5, CODE39, CODE39Extended, Codabar, PostNet, BOOKLAND, ISBN, JAN13, MSI_Mod10, MSI_2Mod10, MSI_Mod11, MSI_Mod11_Mod10, Modified_Plessey, CODE11, USD8, UCC12, UCC13, LOGMARS, CODE128, CODE128A, CODE128B, CODE128C, ITF14, CODE93 };
    public enum SaveTypes : int { JPG, BMP, PNG, GIF, TIFF, UNSPECIFIED };
    #endregion
    /// <summary>
    /// This class was designed to give developers and easy way to generate a barcode image from a string of data.
    /// </summary>
    public class Barcode
    {
        #region Variables
        private string Raw_Data = "";
        private string Formatted_Data = "";
        private string Encoded_Value = "";
        private string _Country_Assigning_Manufacturer_Code = "N/A";
        private TYPE Encoded_Type = TYPE.UNSPECIFIED;
        private Image Encoded_Image = null;
        private Color _ForeColor = Color.Black;
        private Color _BackColor = Color.White;
        private int _Width = 300;
        private int _Height = 150;
        private bool bEncoded = false;
        private bool _IncludeLabel = false;
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.  Does not populate the raw data.  MUST be done via the RawData property before encoding.
        /// </summary>
        public Barcode()
        {
            //constructor
        }//Barcode
        /// <summary>
        /// Constructor. Populates the raw data. No whitespace will be added before or after the barcode.
        /// </summary>
        /// <param name="data">String to be encoded.</param>
        public Barcode(string data)
        {
            //constructor
            this.Raw_Data = data;
        }//Barcode
        public Barcode(string data, TYPE iType)
        {
            this.Raw_Data = data;
            this.Encoded_Type = iType;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the formatted data.
        /// </summary>
        public string FormattedData
        {
            get { return Formatted_Data; }
        }//FormattedData
        /// <summary>
        /// Gets or sets the raw data to encode.
        /// </summary>
        public string RawData
        {
            get { return Raw_Data; }
            set { Raw_Data = value; bEncoded = false; }
        }//RawData
        /// <summary>
        /// Gets the encoded value.
        /// </summary>
        public string EncodedValue
        {
            get { return Encoded_Value; }
        }//EncodedValue
        /// <summary>
        /// Gets the Country that assigned the Manufacturer Code.
        /// </summary>
        public string Country_Assigning_Manufacturer_Code
        {
            get { return _Country_Assigning_Manufacturer_Code; }
        }//Country_Assigning_Manufacturer_Code
        /// <summary>
        /// Gets or sets the Encoded Type (ex. UPC-A, EAN-13 ... etc)
        /// </summary>
        public TYPE EncodedType
        {
            set { Encoded_Type = value; }
            get { return Encoded_Type;  }
        }//EncodedType
        /// <summary>
        /// Gets the Image of the generated barcode.
        /// </summary>
        public Image EncodedImage
        {
            get { if (bEncoded) return Encoded_Image; else return null; }
        }//EncodedImage
        /// <summary>
        /// Gets or sets the color of the bars. (Default is black)
        /// </summary>
        public Color ForeColor
        {
            get { return this._ForeColor; }
            set { this._ForeColor = value; }
        }//ForeColor
        /// <summary>
        /// Gets or sets the background color. (Default is white)
        /// </summary>
        public Color BackColor
        {
            get { return this._BackColor; }
            set { this._BackColor = value; }
        }//BackColor
        /// <summary>
        /// Gets or sets the width of the image to be drawn. (Default is 300 pixels)
        /// </summary>
        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        /// <summary>
        /// Gets or sets the height of the image to be drawn. (Default is 150 pixels)
        /// </summary>
        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }
        /// <summary>
        /// Gets or sets whether a label should be drawn below the image.
        /// </summary>
        public bool IncludeLabel
        {
            set { this._IncludeLabel = value; }
            get { return this._IncludeLabel; }
        }
        #endregion

        #region Functions
        #region General Encode
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="Width">Width of the resulting barcode.(pixels)</param>
        /// <param name="Height">Height of the resulting barcode.(pixels)</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(TYPE iType, string StringToEncode, int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            return Encode(iType, StringToEncode);
        }//Encode(TYPE, string, int, int)
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <param name="Width">Width of the resulting barcode.(pixels)</param>
        /// <param name="Height">Height of the resulting barcode.(pixels)</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(TYPE iType, string StringToEncode, Color ForeColor, Color BackColor, int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            return Encode(iType, StringToEncode, ForeColor, BackColor);
        }//Encode(TYPE, string, Color, Color, int, int)
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(TYPE iType, string StringToEncode, Color ForeColor, Color BackColor)
        {
            this.BackColor = BackColor;
            this.ForeColor = ForeColor;
            return Encode(iType, StringToEncode);
        }//(Image)Encode(Type, string, Color, Color)
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(TYPE iType, string StringToEncode)
        {
            Raw_Data = StringToEncode;
            return Encode(iType);
        }//(Image)Encode(TYPE, string)
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        internal Image Encode(TYPE iType)
        {
            Encoded_Type = iType;
            return Encode();
        }//Encode()
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.
        /// </summary>
        internal Image Encode()
        {
            //make sure there is something to encode
            if (Raw_Data.Trim() == "") 
                throw new Exception("EENCODE-1: Input data not allowed to be blank.");

            if (this.EncodedType == TYPE.UNSPECIFIED) 
                throw new Exception("EENCODE-2: Symbology type not allowed to be unspecified.");

            this.Encoded_Value = "";
            this._Country_Assigning_Manufacturer_Code = "N/A";

            IBarcode ibarcode;
            switch (this.Encoded_Type)
            {
                case TYPE.UCC12:
                case TYPE.UPCA: //Encode_UPCA();
                    ibarcode = new UPCA(Raw_Data);
                    break;
                case TYPE.UCC13:
                case TYPE.EAN13: //Encode_EAN13();
                    ibarcode = new EAN13(Raw_Data);
                    break;
                case TYPE.Interleaved2of5: //Encode_Interleaved2of5();
                    ibarcode = new Interleaved2of5(Raw_Data);
                    break;
                case TYPE.Industrial2of5:
                case TYPE.Standard2of5: //Encode_Standard2of5();
                    ibarcode = new Standard2of5(Raw_Data);
                    break;
                case TYPE.LOGMARS:
                case TYPE.CODE39: //Encode_Code39();
                    ibarcode = new Code39(Raw_Data);
                    break;
                case TYPE.CODE39Extended:
                    ibarcode = new Code39(Raw_Data, true);
                    break;
                case TYPE.Codabar: //Encode_Codabar();
                    ibarcode = new Codabar(Raw_Data);
                    break;
                case TYPE.PostNet: //Encode_PostNet();
                    ibarcode = new Postnet(Raw_Data);
                    break;
                case TYPE.ISBN:
                case TYPE.BOOKLAND: //Encode_ISBN_Bookland();
                    ibarcode = new ISBN(Raw_Data);
                    break;
                case TYPE.JAN13: //Encode_JAN13();
                    ibarcode = new JAN13(Raw_Data);
                    break;
                case TYPE.UPC_SUPPLEMENTAL_2DIGIT: //Encode_UPCSupplemental_2();
                    ibarcode = new UPCSupplement2(Raw_Data);
                    break;
                case TYPE.MSI_Mod10:
                case TYPE.MSI_2Mod10:
                case TYPE.MSI_Mod11:
                case TYPE.MSI_Mod11_Mod10:
                case TYPE.Modified_Plessey: //Encode_MSI();
                    ibarcode = new MSI(Raw_Data, Encoded_Type);
                    break;
                case TYPE.UPC_SUPPLEMENTAL_5DIGIT: //Encode_UPCSupplemental_5();
                    ibarcode = new UPCSupplement5(Raw_Data);
                    break;
                case TYPE.UPCE: //Encode_UPCE();
                    ibarcode = new UPCE(Raw_Data);
                    break;
                case TYPE.EAN8: //Encode_EAN8();
                    ibarcode = new EAN8(Raw_Data);
                    break;
                case TYPE.USD8:
                case TYPE.CODE11: //Encode_Code11();
                    ibarcode = new Code11(Raw_Data);
                    break;
                case TYPE.CODE128: //Encode_Code128();
                    ibarcode = new Code128(Raw_Data);
                    break;
                case TYPE.CODE128A:
                    ibarcode = new Code128(Raw_Data, Code128.TYPES.A);
                    break;
                case TYPE.CODE128B:
                    ibarcode = new Code128(Raw_Data, Code128.TYPES.B);
                    break;
                case TYPE.CODE128C:
                    ibarcode = new Code128(Raw_Data, Code128.TYPES.C);
                    break;
                case TYPE.ITF14:
                    ibarcode = new ITF14(Raw_Data);
                    break;
                case TYPE.CODE93:
                    ibarcode = new Code93(Raw_Data);
                    break;
                default: throw new Exception("EENCODE-2: Unsupported encoding type specified.");
            }//switch

            this.Encoded_Value = ibarcode.Encoded_Value;
            this.Raw_Data = ibarcode.RawData;
            this.Formatted_Data = ibarcode.FormattedData;

            return (Image)Generate_Image();
        }//Encode
        #endregion

        #region Image Functions
        /// <summary>
        /// Gets a bitmap representation of the encoded data.
        /// </summary>
        /// <returns>Bitmap of encoded value.</returns>
        private Bitmap Generate_Image()
        {
            if (Encoded_Value == "") throw new Exception("EGENERATE_IMAGE-1: Must be encoded first.");
            Bitmap b = null;

            switch(this.Encoded_Type)
            {
                case TYPE.ITF14:
                    {
                        b = new Bitmap(Width, Height);
                        
                        int bearerwidth = (int)((b.Width) / 12.05);
                        int iquietzone = Convert.ToInt32(b.Width * 0.05);
                        int iBarWidth = (b.Width - (bearerwidth * 2) - (iquietzone * 2)) / Encoded_Value.Length;
                        int shiftAdjustment = ((b.Width - (bearerwidth * 2) - (iquietzone * 2)) % Encoded_Value.Length) / 2;

                        if (iBarWidth <= 0 || iquietzone <= 0)
                            throw new Exception("EGENERATE_IMAGE-3: Image size specified not large enough to draw image. (Bar size determined to be less than 1 pixel or quiet zone determined to be less than 1 pixel)");

                        //draw image
                        int pos = 0;

                        using (Graphics g = Graphics.FromImage(b))
                        {
                            //fill background
                            g.Clear(BackColor);

                            //lines are fBarWidth wide so draw the appropriate color line vertically
                            Pen pen = new Pen(ForeColor, iBarWidth);
                            pen.Alignment = PenAlignment.Right;

                            while (pos < Encoded_Value.Length)
                            { 
                                //lines are 2px wide so draw the appropriate color line vertically
                                if (Encoded_Value[pos] == '1')
                                    g.DrawLine(pen, new Point((pos * iBarWidth) + shiftAdjustment + bearerwidth + iquietzone, 0), new Point((pos * iBarWidth) + shiftAdjustment + bearerwidth + iquietzone, Height));

                                pos++;
                            }//while

                            //bearer bars
                            pen = new Pen(ForeColor, (float)b.Height / 8);
                            pen.Alignment = PenAlignment.Inset;
                            g.DrawLine(pen, new Point(0, 0), new Point(b.Width, 0));//top
                            g.DrawLine(pen, new Point(0, b.Height), new Point(b.Width, b.Height));//bottom
                            g.DrawLine(pen, new Point(0, 0), new Point(0, b.Height));//left
                            g.DrawLine(pen, new Point(b.Width, 0), new Point(b.Width, b.Height));//right
                        }//using

                        if (IncludeLabel)
                            Label_ITF14((Image)b);

                        break;
                    }//case
                case TYPE.PostNet:
                    {
                        b = new Bitmap(Encoded_Value.Length * 4, 20);

                        //draw image
                        for (int y = b.Height-1; y > 0; y--)
                        {
                            int x = 0;
                            if (y < b.Height / 2)
                            { 
                                //top
                                while (x < b.Width)
                                {
                                    if (Encoded_Value[x/4] == '1')
                                    {
                                        //draw bar
                                        b.SetPixel(x, y, ForeColor);
                                        b.SetPixel(x + 1, y, ForeColor);
                                        b.SetPixel(x + 2, y, BackColor);
                                        b.SetPixel(x + 3, y, BackColor);
                                    }//if
                                    else
                                    { 
                                        //draw space
                                        b.SetPixel(x, y, BackColor);
                                        b.SetPixel(x + 1, y, BackColor);
                                        b.SetPixel(x + 2, y, BackColor);
                                        b.SetPixel(x + 3, y, BackColor);
                                    }//else
                                    x += 4;
                                }//while
                            }//if
                            else
                            { 
                               //bottom
                               while (x < b.Width)
                               {
                                   b.SetPixel(x, y, ForeColor);
                                   b.SetPixel(x + 1, y, ForeColor);
                                   b.SetPixel(x + 2, y, BackColor);
                                   b.SetPixel(x + 3, y, BackColor);
                                   x += 4;
                               }//while
                            }//else 
                        }//for

                        break;
                    }//case
                default:
                    {
                        b = new Bitmap(Width, Height);

                        int iBarWidth = Width / Encoded_Value.Length;
                        int shiftAdjustment = (Width % Encoded_Value.Length) / 2;

                        if (iBarWidth <= 0)
                            throw new Exception("EGENERATE_IMAGE-2: Image size specified not large enough to draw image. (Bar size determined to be less than 1 pixel)");

                        //draw image
                        int pos = 0;

                        using (Graphics g = Graphics.FromImage(b))
                        {
                            //clears the image and colors the entire background
                            g.Clear(BackColor);

                            //lines are fBarWidth wide so draw the appropriate color line vertically
                            Pen pen = new Pen(ForeColor, iBarWidth);
                            pen.Alignment = PenAlignment.Right;

                            while (pos < Encoded_Value.Length)
                            {
                                if (Encoded_Value[pos] == '1')
                                    g.DrawLine(pen, new Point(pos * iBarWidth + shiftAdjustment, 0), new Point(pos * iBarWidth + shiftAdjustment, Height));

                                pos++;
                            }//while
                        }//using

                        if (IncludeLabel)
                            Label_Generic((Image)b);

                        break;
                    }//case
            }//switch

            Encoded_Image = (Image)b;
            bEncoded = true;

            return b;
        }//Generate_Image
        /// <summary>
        /// Gets the bytes that represent the image.
        /// </summary>
        /// <param name="savetype">File type to put the data in before returning the bytes.</param>
        /// <returns>Bytes representing the encoded image.</returns>
        public byte[] GetImageData(SaveTypes savetype)
        {
            byte[] imageData = null;
              
            try
            {
                if (Encoded_Image != null)
                {
                    //Save the image to a memory stream so that we can get a byte array!      
                    using (MemoryStream ms = new MemoryStream())
                    {
                        SaveImage(ms, savetype);
                        imageData = ms.ToArray();
                        ms.Flush();
                        ms.Close();
                    }//using
                }//if
            }//try
            catch (Exception ex)
            {
                throw new Exception("EGETIMAGEDATA-1: Could not retrieve image data. " + ex.Message);
            }//catch  
            return imageData;
        }
        /// <summary>
        /// Saves an encoded image to a specified file and type.
        /// </summary>
        /// <param name="Filename">Filename to save to.</param>
        /// <param name="FileType">Format to use.</param>
        public void SaveImage(string Filename, SaveTypes FileType)
        {
            try
            {
                if (Encoded_Image != null)
                {
                    System.Drawing.Imaging.ImageFormat imageformat;
                    switch (FileType)
                    {
                        case SaveTypes.BMP: imageformat = System.Drawing.Imaging.ImageFormat.Bmp; break;
                        case SaveTypes.GIF: imageformat = System.Drawing.Imaging.ImageFormat.Gif; break;
                        case SaveTypes.JPG: imageformat = System.Drawing.Imaging.ImageFormat.Jpeg; break;
                        case SaveTypes.PNG: imageformat = System.Drawing.Imaging.ImageFormat.Png; break;
                        case SaveTypes.TIFF: imageformat = System.Drawing.Imaging.ImageFormat.Tiff; break;
                        default: imageformat = System.Drawing.Imaging.ImageFormat.Bmp; break;
                    }//switch
                    ((Bitmap)Encoded_Image).Save(Filename, imageformat);
                }//if
            }//try
            catch(Exception ex)
            {
                throw new Exception("ESAVEIMAGE-1: Could not save image.\n\n=======================\n\n" + ex.Message);
            }//catch
        }//SaveImage(string, SaveTypes)
        /// <summary>
        /// Saves an encoded image to a specified stream.
        /// </summary>
        /// <param name="stream">Stream to write image to.</param>
        /// <param name="FileType">Format to use.</param>
        public void SaveImage(Stream stream, SaveTypes FileType)
        {
            try
            {
                if (Encoded_Image != null)
                {
                    System.Drawing.Imaging.ImageFormat imageformat;
                    switch (FileType)
                    {
                        case SaveTypes.BMP: imageformat = System.Drawing.Imaging.ImageFormat.Bmp; break;
                        case SaveTypes.GIF: imageformat = System.Drawing.Imaging.ImageFormat.Gif; break;
                        case SaveTypes.JPG: imageformat = System.Drawing.Imaging.ImageFormat.Jpeg; break;
                        case SaveTypes.PNG: imageformat = System.Drawing.Imaging.ImageFormat.Png; break;
                        case SaveTypes.TIFF: imageformat = System.Drawing.Imaging.ImageFormat.Tiff; break;
                        default: imageformat = System.Drawing.Imaging.ImageFormat.Bmp; break;
                    }//switch
                    ((Bitmap)Encoded_Image).Save(stream, imageformat);
                }//if
            }//try
            catch (Exception ex)
            {
                throw new Exception("ESAVEIMAGE-2: Could not save image.\n\n=======================\n\n" + ex.Message);
            }//catch
        }//SaveImage(Stream, SaveTypes)
        #endregion
        
        #region Label Generation
        private Image Label_ITF14(Image img)
        {
            try
            {
                System.Drawing.Font font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

                using (Graphics g = Graphics.FromImage(img))
                {
                    g.DrawImage(img, (float)0, (float)0);

                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;

                    //color a white box at the bottom of the barcode to hold the string of data
                    g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, img.Height - 16, img.Width, 16));

                    //draw datastring under the barcode image
                    StringFormat f = new StringFormat();
                    f.Alignment = StringAlignment.Center;
                    g.DrawString(this.Raw_Data, font, new SolidBrush(this.ForeColor), (float)(img.Width / 2), img.Height - 16, f);

                    Pen pen = new Pen(ForeColor, (float)img.Height / 16);
                    pen.Alignment = PenAlignment.Inset;
                    g.DrawLine(pen, new Point(0, img.Height - 20), new Point(img.Width, img.Height - 20));//bottom

                    g.Save();
                }//using
                return img;
            }//try
            catch (Exception ex)
            {
                throw new Exception("ELABEL_ITF14-1: " + ex.Message);
            }//catch
        }
        private Image Label_Generic(Image img)
        {
            try
            {
                System.Drawing.Font font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

                using (Graphics g = Graphics.FromImage(img))
                {
                    g.DrawImage(img, (float)0, (float)0);

                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;

                    //color a background color box at the bottom of the barcode to hold the string of data
                    g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(0, img.Height - 16, img.Width, 16));

                    //draw datastring under the barcode image
                    StringFormat f = new StringFormat();
                    f.Alignment = StringAlignment.Center;

                    string strLabelText = (this.FormattedData.Trim() != "") ? this.FormattedData : this.RawData;

                    g.DrawString(strLabelText, font, new SolidBrush(this.ForeColor), (float)(img.Width / 2), img.Height - 16, f);

                    g.Save();
                }//using
                return img;
            }//try
            catch (Exception ex)
            {
                throw new Exception("ELABEL_GENERIC-1: " + ex.Message);
            }//catch
        }//Label_Generic
        #endregion
        #endregion

        #region Misc
        public static bool CheckNumericOnly(string Data)
        {
            //This function takes a string of data and breaks it into parts and trys to do Int64.TryParse
            //This will verify that only numeric data is contained in the string passed in.  The complexity below
            //was done to ensure that the minimum number of interations and checks could be performed.

            //9223372036854775808 is the largest number a 64bit number(signed) can hold so ... make sure its less than that by one place
            int STRING_LENGTHS = 18;
            
            string temp = Data;
            string [] strings = new string[(Data.Length / STRING_LENGTHS) + ((Data.Length % STRING_LENGTHS == 0) ? 0 : 1)];
            
            int i = 0;
            while (i < strings.Length)
                if (temp.Length >= STRING_LENGTHS)
                {
                    strings[i++] = temp.Substring(0, STRING_LENGTHS);
                    temp = temp.Substring(STRING_LENGTHS);
                }//if
                else
                    strings[i++] = temp.Substring(0);

            foreach (string s in strings)
            {
                long value = 0;
                if (!Int64.TryParse(s, out value))
                    return false;
            }//foreach

            return true;
        }//CheckNumericOnly
        #endregion

        #region Static Methods
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <returns>Image representing the barcode.</returns>
        public static Image DoEncode(TYPE iType, string data)
        {
            Barcode b = new Barcode();
            return b.Encode(iType, data);
        }
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="Width">Width of the resulting barcode.(pixels)</param>
        /// <param name="Height">Height of the resulting barcode.(pixels)</param>
        /// <returns>Image representing the barcode.</returns>
        public static Image DoEncode(TYPE iType, string data, int Width, int Height)
        {
            Barcode b = new Barcode();
            return b.Encode(iType, data, Width, Height);
        }
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <returns>Image representing the barcode.</returns>
        public static Image DoEncode(TYPE iType, string data, Color DrawColor, Color BackColor)
        {
            Barcode b = new Barcode();
            return b.Encode(iType, data, DrawColor, BackColor);
        }
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <param name="Width">Width of the resulting barcode.(pixels)</param>
        /// <param name="Height">Height of the resulting barcode.(pixels)</param>
        /// <returns>Image representing the barcode.</returns>
        public static Image DoEncode(TYPE iType, string data, Color DrawColor, Color BackColor, int Width, int Height)
        {
            Barcode b = new Barcode();
            return b.Encode(iType, data, DrawColor, BackColor, Width, Height);
        }
        #endregion
    }//Barcode Class
}//Barcode namespace
