namespace backend.Core
{
    /// <summary>
    /// Represents a cat with an ID, a URL, and a score.
    /// </summary>
    public class Cat
    {
        /// <summary>
        /// Gets or sets the unique identifier of the cat.
        /// </summary>
        private string _id;

        public string Id
        {
            get => _id;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Id cannot be null or empty.");
                }
                _id = value;
            }
        }

        /// <summary>
        /// Gets or sets the URL associated with the cat.
        /// </summary>
        private string _url;

        public string Url
        {
            get => _url;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Url cannot be null or empty.");
                }
                _url = value;
            }
        }

        /// <summary>
        /// Gets or sets the score of the cat.
        /// </summary>
        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The Score cannot be less than zero.");
                }
                _score = value;
            }
        }
    }
}