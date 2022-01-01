using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ShopSportShoes.Services
{
    public class ShoeConfigService
    {
        public ShoeConfig GetAll()
        {
            using (StreamReader file = File.OpenText("shoeConfig.json"))
            {
                using (JsonTextReader reader = new(file))
                {
                    var json = (JObject)JToken.ReadFrom(reader);
                    try
                    {
                        return JsonConvert.DeserializeObject<ShoeConfig>(json.ToString());
                    }
                    catch
                    {
                        //Nếu có json kiểu đối tượng thì làm theo mẫu
                        // var oldFixedPrice = json["TablePrice"];
                        //json.Property("TablePrice").Remove();
                        //Config config = JsonConvert.DeserializeObject<ShoeConfig>(json.ToString());
                        //config.TablePrice = new();
                        //for (int a = 0; a < oldFixedPrice.Count(); a++)
                        //{
                        //    TablePrices table = new()
                        //    {
                        //        Name = oldFixedPrice[a].ToString(),
                        //        FixedPrice = 0
                        //    };
                        //    config.TablePrice.Add(table);
                        //}
                        //string jsonData = JsonConvert.SerializeObject(config);
                        //File.WriteAllText("config.json", jsonData);
                    }
                    return JsonConvert.DeserializeObject<ShoeConfig>(json.ToString());
                }
            }
        }

        public async Task WriteToObjects(ShoeConfig config, string propName, List<string> data)
        {
            config.SetValueByPropName(propName, data);
            string jsonData = JsonConvert.SerializeObject(config);
            await File.WriteAllTextAsync("shoeConfig.json", jsonData);
        }
    }

    public class ShoeConfig
    {
        public List<string> Trademarks { get; set; }
        public List<string> PriceRanges { get; set; }

        public void SetValueByPropName(string propName, object data)
        {
            Type type = this.GetType();
            PropertyInfo propertyInfo = type.GetProperty(propName);
            propertyInfo.SetValue(this, data, null);
        }
    }
}
