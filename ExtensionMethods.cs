using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GodvilleAutoPlayer
{
	/// <summary>
	/// This is an extension class to handle some helper methods to keep the
	/// main source body clean.  Originally designed for working with two
	/// different methods of access IE: ActiveX and stand-alone.
	/// </summary>
	public static class ExtensionMethods
	{
		public static string ClassName(this HtmlElement element)
		{
			return ((mshtml.IHTMLElement)element.DomElement).className ?? "";
		}

		public static string Title(this HtmlElement element)
		{
			return ((mshtml.IHTMLElement)element.DomElement).title ?? "";
		}

		public static HtmlElement ChildElement(this HtmlElement Element, int index)
		{
			int elementCount = 0;
			List<HtmlElement> elements = new List<HtmlElement>();

			if (index > Element.Children.Count)
				return null;

			foreach (var item in Element.Children)
			{
				if (item.GetType().Equals(typeof(HtmlElement)))
				{
					elementCount++;
					elements.Add((HtmlElement)item);
				}
			}

			if ((elementCount == 0) && (index > elementCount - 1))
				return null;
			else
				return elements[index];
		}
	}
}
