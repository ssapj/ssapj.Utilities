using BarTender;
using System;
using System.Runtime.InteropServices;

namespace ssapj.Utilities
{
	public class DesignObjectInformation
	{
		private IBtDesignObject _source;
		public (bool hasValue, string value) Name { get; }
		public (bool hasValue, string value) Value { get; }
		public (bool hasValue, DesignObjectType value) Type { get; }
		public (bool hasValue, double value) X { get; }
		public (bool hasValue, double value) Y { get; }
		public (bool hasValue, double value) RotationAngle { get; }
		public (bool hasValue, bool value) DoNotPrint { get; }
		public (bool hasValue, string value) Comment { get; }
		public (bool hasValue, double value) Width { get; }
		public (bool hasValue, double value) Height { get; }
		public (bool hasValue, double value) Length { get; }
		public (bool hasValue, double value) LineThickness { get; }
		public (bool hasValue, double value) LineStartX { get; }
		public (bool hasValue, double value) LineStartY { get; }
		public (bool hasValue, double value) LineEndX { get; }
		public (bool hasValue, double value) LineEndY { get; }
		public (bool hasValue, double value) CornerRadius { get; }
		public (bool hasValue, uint value) LineColor { get; }
		public (bool hasValue, uint value) FillColor { get; }
		public (bool hasValue, uint value) BarCodeColor { get; }
		public (bool hasValue, uint value) TextColor { get; }
		public (bool hasValue, uint value) TextBackgroundColor { get; }
		public (bool hasValue, string value) FontName { get; }
		public (bool hasValue, double value) FontSize { get; }
		public (bool hasValue, double value) FontScale { get; }
		public (bool hasValue, DesignObjectFontWeight value) FontWeight { get; }
		public (bool hasValue, bool value) FontBold { get; }
		public (bool hasValue, bool value) FontItalic { get; }
		public (bool hasValue, bool value) FontUnderline { get; }
		public (bool hasValue, bool value) FontStrikeout { get; }
		public (bool hasValue, DesignObjectFontScript value) FontScript { get; }
		public (bool hasValue, string value) HumanReadableValue { get; }
		public (bool hasValue, string value) EncodedValue { get; }
		public (bool hasValue, bool value) MirrorHorizontal { get; }
		public (bool hasValue, bool value) MirrorVertical { get; }
		public (bool hasValue, int value) PercentWidth { get; }
		public (bool hasValue, int value) PercentHeight { get; }
		public (bool hasValue, bool value) PreserveAspectRatio { get; }
		public (bool hasValue, string value) PicturePath { get; }

		public DesignObjectInformation(IBtDesignObject designObject)
		{
			this._source = designObject;

			try
			{
				this.Name = (true, designObject.Name);
			}
			catch (COMException)
			{
			}

			try
			{
				this.Value = (true, designObject.Value);
			}
			catch (COMException)
			{
			}

			try
			{
				this.Type = (true, (DesignObjectType)Enum.ToObject(typeof(DesignObjectType), designObject.Type));
			}
			catch (COMException)
			{
			}

			try
			{
				this.X = (true, designObject.X);
			}
			catch (COMException)
			{
			}

			try
			{
				this.Y = (true, designObject.Y);
			}
			catch (COMException)
			{
			}

			try
			{
				this.RotationAngle = (true, designObject.RotationAngle);
			}
			catch (COMException)
			{
			}

			try
			{
				this.DoNotPrint = (true, designObject.DoNotPrint);
			}
			catch (COMException)
			{
			}

			try
			{
				this.Comment = (true, designObject.Comment);
			}
			catch (COMException)
			{
			}

			try
			{
				this.Width = (true, designObject.Width);
			}
			catch (COMException)
			{
			}

			try
			{
				this.Height = (true, designObject.Height);
			}
			catch (COMException)
			{
			}

			try
			{
				this.Length = (true, designObject.Length);
			}
			catch (COMException)
			{
			}

			try
			{
				this.LineThickness = (true, designObject.LineThickness);
			}
			catch (COMException)
			{
			}

			try
			{
				this.LineStartX = (true, designObject.LineStartX);
			}
			catch (COMException)
			{
			}

			try
			{
				this.LineStartY = (true, designObject.LineStartY);
			}
			catch (COMException)
			{
			}

			try
			{
				this.LineEndX = (true, designObject.LineEndX);
			}
			catch (COMException)
			{
			}

			try
			{
				this.LineEndY = (true, designObject.LineEndY);
			}
			catch (COMException)
			{
			}

			try
			{
				this.CornerRadius = (true, designObject.CornerRadius);
			}
			catch (COMException)
			{
			}

			try
			{
				this.LineColor = (true, designObject.LineColor);
			}
			catch (COMException)
			{
			}

			try
			{
				this.FillColor = (true, designObject.FillColor);
			}
			catch (COMException)
			{
			}

			try
			{
				this.BarCodeColor = (true, designObject.BarCodeColor);
			}
			catch (COMException)
			{
			}

			try
			{
				this.TextColor = (true, designObject.TextColor);
			}
			catch (COMException)
			{
			}

			try
			{
				this.TextBackgroundColor = (true, designObject.TextBackgroundColor);
			}
			catch (COMException)
			{
			}

			try
			{
				this.FontName = (true, designObject.FontName);
			}
			catch (COMException)
			{
			}

			try
			{
				this.FontSize = (true, designObject.FontSize);
			}
			catch (COMException)
			{
			}

			try
			{
				this.FontScale = (true, designObject.FontScale);
			}
			catch (COMException)
			{
			}

			try
			{
				this.FontWeight = (true, (DesignObjectFontWeight)Enum.ToObject(typeof(DesignObjectFontWeight), designObject.FontWeight));
			}
			catch (COMException)
			{
			}

			try
			{
				this.FontBold = (true, designObject.FontBold);
			}
			catch (COMException)
			{
			}

			try
			{
				this.FontItalic = (true, designObject.FontItalic);
			}
			catch (COMException)
			{
			}

			try
			{
				this.FontUnderline = (true, designObject.FontUnderline);
			}
			catch (COMException)
			{
			}

			try
			{
				this.FontStrikeout = (true, designObject.FontStrikeout);
			}
			catch (COMException)
			{
			}

			try
			{
				this.FontScript = (true, (DesignObjectFontScript)Enum.ToObject(typeof(DesignObjectFontScript), designObject.FontScript));
			}
			catch (COMException)
			{
			}

			try
			{
				this.HumanReadableValue = (true, designObject.HumanReadableValue);
			}
			catch (COMException)
			{
			}

			try
			{
				this.EncodedValue = (true, designObject.EncodedValue);
			}
			catch (COMException)
			{
			}

			try
			{
				this.MirrorHorizontal = (true, designObject.MirrorHorizontal);
			}
			catch (COMException)
			{
			}

			try
			{
				this.MirrorVertical = (true, designObject.MirrorVertical);
			}
			catch (COMException)
			{
			}

			try
			{
				this.PercentWidth = (true, designObject.PercentWidth);
			}
			catch (COMException)
			{
			}

			try
			{
				this.PercentHeight = (true, designObject.PercentHeight);
			}
			catch (COMException)
			{
			}

			try
			{
				this.PreserveAspectRatio = (true, designObject.PreserveAspectRatio);
			}
			catch (COMException)
			{
			}

			try
			{
				this.PicturePath = (true, designObject.PicturePath);
			}
			catch (COMException)
			{
			}

		}

	}
}
