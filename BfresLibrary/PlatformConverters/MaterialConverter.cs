﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syroot.NintenTools.Bfres.PlatformConverters
{
    /// <summary>
    /// The conversion handler to process how to convert shaders and other data per game profile.
    /// </summary>
    public enum ConverterHandle
    {
        /// <summary>
        /// Defaults to not using a game preset.
        /// </summary>
        DEFAULT,
        /// <summary>
        /// Uses BOTW game preset.
        /// </summary>
        BOTW,
        /// <summary>
        /// Uses MK8 game preset.
        /// </summary>
        MK8,
    }

    class MaterialConverter
    {
        internal static void ConvertToSwitchMaterial(Material material, ConverterHandle handler)
        {
            MaterialConverterBase converter= GetConverter(handler);
            converter.ConvertToSwitchMaterial(material);
        }

        internal static void ConvertToWiiUMaterial(Material material, ConverterHandle handler)
        {
            MaterialConverterBase converter = GetConverter(handler);
            converter.ConvertToWiiUMaterial(material);
        }

        static MaterialConverterBase GetConverter(ConverterHandle handler)
        {
            switch (handler)
            {
                case ConverterHandle.BOTW:  return new MaterialConverterBOTW();
                case ConverterHandle.MK8: return new MaterialConverterMK8();
                default: return new MaterialConverterBase();
            }
        }
    }
}
