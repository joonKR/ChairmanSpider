using AxKHOpenAPILib;

namespace GloomySpider
{
    public class GloomyAPI
    {
        private static AxKHOpenAPI axKHOpenAPI;

        public static AxKHOpenAPI Instance
        {
            get
            {
                return axKHOpenAPI;
            }
        }

        public static void getInstance(AxKHOpenAPI axKHOpenAPI)
        {
            GloomyAPI.axKHOpenAPI = axKHOpenAPI;
        }
    }
}

    

    


