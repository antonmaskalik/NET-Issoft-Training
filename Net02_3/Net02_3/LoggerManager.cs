using System.IO;
using System.Reflection;
using System;
using NLog;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Net02_3
{
    internal class LoggerManager
    {
        const string APPSETTINGS_PATH = "Settings";
        const string LIBRARIES_PATH = "Libraries\\";
        const string APPSETTINGS_FILE = "appsettings.json";
        const string LISTENERS_SECTION = "Listeners";
        const string STRING_FORMAT = "{0}.{0}";
        readonly char[] _dll = new char[] { '.', 'd', 'l', 'l' };

        string _pathToAppsettingsFile = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).Parent.FullName, APPSETTINGS_PATH);
        string _pathToLibrariesListeners = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).Parent.FullName, LIBRARIES_PATH);

        List<FieldInfo> _fields = new List<FieldInfo>();
        List<PropertyInfo> _properties = new List<PropertyInfo>();
        List<string> _listeners;

        Logger logger;

        private void ReadAppSettingsFile()
        {
            var sections = GetConfiguration().GetSection(LISTENERS_SECTION).GetChildren();

            if (sections != null)
            {
                _listeners = new List<string>();

                foreach (IConfigurationSection section in sections)
                {
                    _listeners.Add(section.Value);
                }
            }
        }

        private IConfigurationRoot GetConfiguration()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                    .SetBasePath(_pathToAppsettingsFile)
                    .AddJsonFile(APPSETTINGS_FILE)
                    .Build();

            return config;
        }

        private void CallListener(string listen)
        {
            if (_listeners != null)
            {
                string FullNameType = string.Format(STRING_FORMAT, listen.TrimEnd(_dll));
                string path = Path.Combine(_pathToLibrariesListeners, listen);
                Assembly assembly = Assembly.LoadFrom(path);
                Type type = assembly.GetType(FullNameType);

                ConstructorInfo constructor = type.GetConstructor(new Type[] { });
                constructor.Invoke(new object[] { });

                logger = assembly.CreateInstance(type.FullName) as Logger;
                logger = LogManager.GetCurrentClassLogger();
            }
        }

        public void Track(object obj)
        {
            Type type = obj.GetType();

            ReadAppSettingsFile();
            SetFields(type);
            SetProperties(type);

            foreach (string listen in _listeners)
            {
                CallListener(listen);

                foreach (FieldInfo field in _fields)
                {
                    logger.Trace(field.Name + "=" + field.GetValue(obj));
                }

                foreach (PropertyInfo property in _properties)
                {
                    logger.Trace(property.Name + "=" + property.GetValue(obj));
                }
            }
        }

        private void SetFields(Type type)
        {
            if (type.GetCustomAttribute<TrackingEntityAttribute>() is TrackingEntityAttribute)
            {
                foreach (FieldInfo field in type.GetRuntimeFields())
                {
                    if (IfTrackingPropertyAttributeIsContained(field))
                    {
                        _fields.Add(field);
                    }
                }
            }
        }

        private void SetProperties(Type type)
        {
            if (type.GetCustomAttribute<TrackingEntityAttribute>() is TrackingEntityAttribute)
            {
                foreach (PropertyInfo property in type.GetRuntimeProperties())
                {
                    if (IfTrackingPropertyAttributeIsContained(property))
                    {
                        _properties.Add(property);
                    }
                }
            }
        }

        private bool IfTrackingPropertyAttributeIsContained(MemberInfo member)
        {
            return member.GetCustomAttribute(typeof(TrackingPropertyAttribute)) != null;
        }
    }
}
