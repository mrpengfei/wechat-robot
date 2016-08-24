using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Wechat.API.Http;
using Wechat.tools;

namespace WechatTest
{
    public class TuLingRobot
    {
        public static string Answer(string word)
        {
            string url = "http://www.tuling123.com/openapi/api";
            using (var client = UniversalTool.GetClient())
            {
                var obj = new
                {
                    key = "c733fc953aba4a06ae19f2cc9f026713",
                    info = word
                };
                var result = client.UploadString(url, JsonConvert.SerializeObject(obj));
                var json = JObject.Parse(result);

                var code = json["code"].ToObject<int>();
                var text = json["text"].ToObject<string>();

                if (code>4000 && code < 4010)
                {
                    text = "抱歉，没明白你什么意思";
                }

                return text;
            }

        }
    }
}