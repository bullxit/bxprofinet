namespace S7.Net.Types
{
    /// <summary>
    /// Contains the methods to convert from S7 strings to C# strings
    /// </summary>
    public class String
    {
        /// <summary>
        /// Converts a string to S7 bytes
        /// </summary>
        public static byte[] ToByteArray(string value)
        {
            return System.Text.Encoding.ASCII.GetBytes(value);
        }
        
        /// <summary>
        /// Converts S7 bytes to a string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string FromByteArray(byte[] bytes)
        {
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

    }
}
