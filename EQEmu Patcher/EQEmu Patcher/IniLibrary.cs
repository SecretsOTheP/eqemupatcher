using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.Windows.Forms;

namespace EQEmu_Patcher
{
    class IniLibrary
    {
        public static IniLibrary instance;
        public string AutoPatch { get; set; }
        public string AutoPlay { get; set; }
        public VersionTypes ClientVersion { get; set; }
        public string LastPatchedVersion { get; set; }


        public static void Save()
        {
            var serializerBuilder = new SerializerBuilder().WithNamingConvention(new CamelCaseNamingConvention());
            var serializer = serializerBuilder.Build();
            string body = serializer.Serialize(instance);

            Console.WriteLine(body);
            File.WriteAllText($"{System.IO.Path.GetDirectoryName(Application.ExecutablePath)}\\eqemupatcher.yml", body);
        }

        public static void Load()
        {
            try {
                using (var input = File.OpenText($"{System.IO.Path.GetDirectoryName(Application.ExecutablePath)}\\eqemupatcher.yml"))
                {
                    var deserializerBuilder = new DeserializerBuilder().WithNamingConvention(new CamelCaseNamingConvention());

                    var deserializer = deserializerBuilder.Build();

                    instance = deserializer.Deserialize<IniLibrary>(input);
                }

                if (instance == null) {
                    ResetDefaults();
                    Save();
                }
            } catch (FileNotFoundException e) {
                Console.WriteLine($"Failed loading config: {e.Message}");
                ResetDefaults();
                Save();
            }

            if (instance.AutoPatch == null) instance.AutoPatch = "false";
            if (instance.AutoPlay == null) instance.AutoPlay = "false";
        }

        public static void ResetDefaults()
        {
            instance = new IniLibrary();
            instance.AutoPlay = "false";
            instance.AutoPatch = "false";
        }
    }
}
