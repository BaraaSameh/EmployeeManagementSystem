namespace EmployeeManagementSystem.Helpers
{
    public static class ImageHelper
    {
        public static byte[]? ImageToByteArray(Image? image)
        {
            if (image == null) return null;
            using var ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }

        public static Image? ByteArrayToImage(byte[]? byteArray)
        {
            if (byteArray == null || byteArray.Length == 0) return null;
            using var ms = new MemoryStream(byteArray);
            return Image.FromStream(ms);
        }
    }
}