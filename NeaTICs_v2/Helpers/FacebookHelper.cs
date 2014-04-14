using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Facebook;

namespace NeaTICs_v2.Helpers
{
    public static class FacebookHelper
    {
        /// <summary>
        /// El access token de mi app en Facebook
        /// </summary>
        public static string accessToken = "250212775143996|UQ9mfNr4EFzIsrFECW9y2TcMjt8";

        public static FacebookClient client = new FacebookClient(accessToken);

        /// <summary>
        /// Método que devuelve en una lista de diccionarios todas las noticias con imagenes y mensajes adheridos
        /// </summary>
        /// <param name="limit"> El límite de noticias que se desea. Por defecto, 100 </param>
        /// <returns>Lista de diccionarios. El diccionario tiene: From, Message, Caption, ImageUrl, Date...</returns>
        public static List<Dictionary<string, object>> GetNewsWithImages(int limit = 100)
        {
            try
            {
                dynamic info = client.Batch(new FacebookBatchParameter(HttpMethod.Get, "poloitchaco/feed?limit=" + limit.ToString()), new FacebookBatchParameter(HttpMethod.Get, "informatorio/feed?limit=" + limit.ToString()));

                List<Dictionary<string, object>> Result = new List<Dictionary<string, object>>();

                foreach (var item in info)
                {
                    foreach (var post in item.data)
                    {
                        Dictionary<string, object> New = new Dictionary<string, object>();
                        string temp = Convert.ToString(post);
                        if (post.type == "photo" & (post.status_type == "added_photos" | post.status_type == "shared_story") & temp.Contains("message") & !temp.Contains("Informatorio shared POLO IT CHACO's photo"))
                        {
                            New.Add("ID", post.id);
                            New.Add("From", post.from.name);
                            New.Add("Message", post.message);
                            New.Add("Caption", post.caption);
                            string ImageURL = GetImageUrl(post.object_id);
                            New.Add("ImageUrl", GetImageUrl(post.object_id));
                            New.Add("Link", post.link);
                            New.Add("Date", post.created_time);
                            Result.Add(New);
                        }
                    }
                }

                Result.OrderByDescending(x => x["Date"]);
                return Result;
            }
            catch (Facebook.WebExceptionWrapper fe)
            {
                throw fe;
            }
        }

        public static List<Dictionary<string, object>> GetEventsWithImages(int limit = 100)
        {
            try
            {
                dynamic info = client.Batch(new FacebookBatchParameter(HttpMethod.Get, "poloitchaco/events?fields=id,name,description,picture,start_time"), new FacebookBatchParameter(HttpMethod.Get, "informatorio/events?fields=id,name,description,picture,start_time"));

                List<Dictionary<string, object>> Result = new List<Dictionary<string, object>>();

                foreach (var item in info)
                {
                    foreach (var post in item.data)
                    {
                        if (post != null)
                        {
                            Dictionary<string, object> Event = new Dictionary<string, object>();
                            Event.Add("ID", post.id);
                            Event.Add("Name", post.name);
                            Event.Add("Description", post.description);
                            Event.Add("ImageUrl", post.picture.data.url);
                            Event.Add("Link", "https://www.facebook.com/events/" + post.id);
                            Event.Add("Date", post.start_time);
                            Result.Add(Event);
                        }
                    }
                }
                if (Result != null)
                    Result.OrderByDescending(x => x["Date"]);
                return Result;
            }
            catch (Facebook.WebExceptionWrapper fe)
            {
                throw fe;
            }
        }

        public static Dictionary<string, object> GetNewWithImageByID(string ID)
        {
            dynamic info = client.Get(ID);
            var temp = Convert.ToString(info);
            Dictionary<string, object> New = new Dictionary<string, object>();
            //if (info.type == "photo" & (info.status_type == "added_photos" | info.status_type == "shared_story") & temp.Contains("message") & !temp.Contains("Informatorio shared POLO IT CHACO's photo"))
            //{
            New.Add("ID", info.id);
            New.Add("From", info.from.name);
            New.Add("Message", info.message);
            New.Add("Caption", info.caption);
            string ImageURL = GetImageUrl(info.object_id);
            New.Add("ImageUrl", GetImageUrl(info.object_id));
            New.Add("Link", info.link);
            New.Add("Date", info.created_time);
            //}
            return New;
        }

        /// <summary>
        /// Método para traer la url de una imagen mediante el id del objeto en Facebook
        /// </summary>
        /// <param name="objectId"> El Id de la imágen </param>
        /// <returns>String</returns>
        public static string GetImageUrl(string objectId)
        {
            dynamic info = client.Get(objectId);
            return info.images[0].source;
        }

        /// <summary>
        /// Método que devuelve una lista de diccionarios con datos de los albums (NO FOTOS!)
        /// </summary>
        /// <returns>Lista de diccionarios. El diccionario tiene: ID, Name, Link, Date...</returns>
        public static List<Dictionary<string, string>> GetAlbums()
        {
            dynamic info = client.Get("informatorio/albums");
            List<Dictionary<string, string>> Result = new List<Dictionary<string, string>>();

            foreach (var item in info.data)
            {
                if (item.type == "normal")
                {
                    Dictionary<string, string> Album = new Dictionary<string, string>();
                    Album.Add("ID", item.id);
                    Album.Add("Name", item.name);
                    Album.Add("Link", item.link);
                    Album.Add("Date", item.created_time);
                    Result.Add(Album);
                }
            }

            return Result;
        }

        /// <summary>
        /// Método que extrae todas las url de todas las imágenes de todos los álbumes
        /// </summary>
        /// <returns>Lista de string. Cada elemento de la lista es la url de cada imagen en formato string</returns>
        public static List<string> GetAllImagesAlbumsUrl()
        {
            List<string> Result = new List<string>();

            foreach (Dictionary<string, string> Album in GetAlbums())
            {
                dynamic info = client.Get(Album["ID"] + "/photos");
                foreach (var data in info.data)
                {
                    Result.Add(GetImageUrl(data.id));
                }
            }

            return Result;
        }
    }
}