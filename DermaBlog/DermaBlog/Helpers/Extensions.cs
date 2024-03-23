namespace DermaBlog.Helpers
{
    public static class Extensions
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }

        public static async Task<string> SaveFileAsync(this IFormFile file, string floder)
        {
            string filename =Guid.NewGuid().ToString() + file.FileName;
            string path = Path.Combine(floder, filename);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return filename;
        }
    }
}
