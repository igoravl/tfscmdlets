using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace TfsCmdlets.Cmdlets.GlobalList
{
    /// <summary>
    /// Represents a Team Foundation Server global lists
    /// </summary>
    public class GlobalList
    {
        /// <summary>
        /// Converts a GlobalList to an XElement
        /// </summary>
        public static explicit operator XElement(GlobalList gl) => gl.ToXml();
        
        /// <summary>
        /// Converts an XElement to a GlobalList
        /// </summary>
        public static explicit operator GlobalList(XElement el) => FromXml(el);

        /// <summary>
        /// Creates an instance of GlobalList from an XElement containing a &lt;GLOBALLIST&gt; element
        /// </summary>
        /// <param name="el">An XML element containing a global list definition</param>
        /// <returns>An instance of GlobalList</returns>
        public static GlobalList FromXml(XElement el)
        {
            return new GlobalList(el.Attribute("name").Value, 
                el.Descendants("LISTITEM").Select(li => li.Attribute("value").Value));
        }

        /// <summary>
        /// Gets the name of the global list.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the contents (items) of the global list.
        /// </summary>
        public IList<string> Items { get; internal set;} = new List<string>();
        
        internal GlobalList(string name, IEnumerable<string> items)
        {
            Name = name;
            Items = new List<string>(items);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override string ToString()
        {
            return $"{Name} ({Items.Count} item(s))";
        }

        /// <summary>
        /// Returns this global list in its original XML representation
        /// </summary>
        /// <returns>A XElement object representing a &lt;GLOBALLIST&gt; element</returns>
        public XElement ToXml()
        {
            return new XElement("GLOBALLIST", new XAttribute("name", Name), Items.Select(i => new XElement("LISTITEM", new XAttribute("value", i))));
        }
    }
}