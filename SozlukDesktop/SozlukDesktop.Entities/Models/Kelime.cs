namespace SozlukDesktop.Entities.Models
{
    /// <summary>
    /// Default summary for Kelime.cs
    /// </summary>
    public class Kelime
    {
        /// <summary>
        /// The Id of the word
        /// </summary>
        public int KelimeID { get; set; }

        /// <summary>
        /// Karachay meaning of the word
        /// </summary>
        public string KaracaycaAnlam { get; set; }

        /// <summary>
        /// Turkish meaning of the word
        /// </summary>
        public string TurkceAnlam { get; set; }
    }
}
