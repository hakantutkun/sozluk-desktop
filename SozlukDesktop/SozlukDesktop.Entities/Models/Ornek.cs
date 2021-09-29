namespace SozlukDesktop.Entities.Models
{
    /// <summary>
    /// Default summary for Ornek.cs
    /// </summary>
    public class Ornek
    {
        /// <summary>
        /// The Id of the example
        /// </summary>
        public int OrnekID { get; set; }

        /// <summary>
        /// The Id of the word that owns this example
        /// </summary>
        public int OrnekKelimeID { get; set; }

        /// <summary>
        /// The title of the example
        /// </summary>
        public string OrnekBaslik { get; set; }

        /// <summary>
        /// The content of the example
        /// </summary>
        public string OrnekIcerik { get; set; }
    }
}
