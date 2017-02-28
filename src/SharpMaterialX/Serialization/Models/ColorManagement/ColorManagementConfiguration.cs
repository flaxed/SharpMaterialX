using System;

namespace SharpMaterialX.Serialization.Models.ColorManagement
{
    public class ColorManagementConfiguration
    {
        public ColorManagementConfiguration(Uri configurationFile, string cmsName)
        {
            this.ConfigurationFile = configurationFile;
            this.CmsName = cmsName;

            this.HasConfigurationFile = true;
            this.HasCms = true;
        }

        public ColorManagementConfiguration(string cmsName)
        {
            this.CmsName = cmsName;

            this.HasConfigurationFile = false;
            this.HasCms = true;
        }

        public ColorManagementConfiguration(Uri configurationFile)
        {
            this.ConfigurationFile = configurationFile;

            this.HasConfigurationFile = true;
            this.HasCms = false;
        }

        public ColorManagementConfiguration()
        {
            this.HasConfigurationFile = false;
            this.HasCms = false;
        }

        /// <summary>
        /// Gets the path to the color management system (CMS) configuration file
        /// </summary>
        public Uri ConfigurationFile { get; }

        /// <summary>
        /// Gets the name of the color management system (CMS)
        /// </summary>
        public string CmsName { get; }

        /// <summary>
        /// Returns true if a CMS configuration file was specified. False otherwise.
        /// </summary>
        public bool HasConfigurationFile { get; }

        /// <summary>
        /// Returns true if a CMS was specified. False otherwise.
        /// </summary>
        public bool HasCms { get; }
    }
}