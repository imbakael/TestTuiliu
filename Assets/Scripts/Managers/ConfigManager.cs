using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigManager {
    private static TuiliuConfig tuiliuConfig;
    public static TuiliuConfig TuiliuConfig {
        get {
            if (tuiliuConfig == null) {
                tuiliuConfig = Resources.Load<TuiliuConfig>("TuiliuConfig_" + "JL");
            }
            return tuiliuConfig;
        }
    }
}
