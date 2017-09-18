using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using JsonFx.Json;

namespace Game
{
    class DefinitionsLoader
    {
        public static void LoadDefinitions(DefinitionsData definitionData)
        {
            TextAsset blockText = Resources.Load<TextAsset>("Ships");
            definitionData.ShipDefinitions = JsonReader.Deserialize<ShipDefinition[]>(blockText.text);
        }
    }
}
