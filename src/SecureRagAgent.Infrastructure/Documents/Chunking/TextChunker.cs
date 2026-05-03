namespace SecureRagAgent.Infrastructure.Documents.Chunking
{
    public static class TextChunker
    {
        public static IReadOnlyList<string> Split(
            string text,
            int chunkSize = 500,
            int overlap = 50)
        {
            var chunks = new List<string>();

            for (int i = 0; i < text.Length; i += chunkSize - overlap)
            {
                var length = Math.Min(chunkSize, text.Length - i);
                var chunk = text.Substring(i, length);

                chunks.Add(chunk);
            }

            return chunks;
        }
    }
}
