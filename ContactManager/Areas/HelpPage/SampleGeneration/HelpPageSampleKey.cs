using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Headers;

namespace ContactManager.Areas.HelpPage
{
   
    public class HelpPageSampleKey
    {
       
        public HelpPageSampleKey(MediaTypeHeaderValue mediaType, Type type)
        {
            if (mediaType == null)
            {
                throw new ArgumentNullException("mediaType");
            }
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            ControllerName = String.Empty;
            ActionName = String.Empty;
            ParameterNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            ParameterType = type;
            MediaType = mediaType;
        }

       
        public HelpPageSampleKey(SampleDirection sampleDirection, string controllerName, string actionName, IEnumerable<string> parameterNames)
        {
            if (!Enum.IsDefined(typeof(SampleDirection), sampleDirection))
            {
                throw new InvalidEnumArgumentException("sampleDirection", (int)sampleDirection, typeof(SampleDirection));
            }
            if (controllerName == null)
            {
                throw new ArgumentNullException("controllerName");
            }
            if (actionName == null)
            {
                throw new ArgumentNullException("actionName");
            }
            if (parameterNames == null)
            {
                throw new ArgumentNullException("parameterNames");
            }
            ControllerName = controllerName;
            ActionName = actionName;
            ParameterNames = new HashSet<string>(parameterNames, StringComparer.OrdinalIgnoreCase);
            SampleDirection = sampleDirection;
        }

        public HelpPageSampleKey(MediaTypeHeaderValue mediaType, SampleDirection sampleDirection, string controllerName, string actionName, IEnumerable<string> parameterNames)
        {
            if (mediaType == null)
            {
                throw new ArgumentNullException("mediaType");
            }
            if (!Enum.IsDefined(typeof(SampleDirection), sampleDirection))
            {
                throw new InvalidEnumArgumentException("sampleDirection", (int)sampleDirection, typeof(SampleDirection));
            }
            if (controllerName == null)
            {
                throw new ArgumentNullException("controllerName");
            }
            if (actionName == null)
            {
                throw new ArgumentNullException("actionName");
            }
            if (parameterNames == null)
            {
                throw new ArgumentNullException("parameterNames");
            }
            ControllerName = controllerName;
            ActionName = actionName;
            MediaType = mediaType;
            ParameterNames = new HashSet<string>(parameterNames, StringComparer.OrdinalIgnoreCase);
            SampleDirection = sampleDirection;
        }

      
        public string ControllerName { get; private set; }

        public string ActionName { get; private set; }

       
        public MediaTypeHeaderValue MediaType { get; private set; }

        public HashSet<string> ParameterNames { get; private set; }

        public Type ParameterType { get; private set; }

       
        public SampleDirection? SampleDirection { get; private set; }

        public override bool Equals(object obj)
        {
            HelpPageSampleKey otherKey = obj as HelpPageSampleKey;
            if (otherKey == null)
            {
                return false;
            }

            return String.Equals(ControllerName, otherKey.ControllerName, StringComparison.OrdinalIgnoreCase) &&
                String.Equals(ActionName, otherKey.ActionName, StringComparison.OrdinalIgnoreCase) &&
                (MediaType == otherKey.MediaType || (MediaType != null && MediaType.Equals(otherKey.MediaType))) &&
                ParameterType == otherKey.ParameterType &&
                SampleDirection == otherKey.SampleDirection &&
                ParameterNames.SetEquals(otherKey.ParameterNames);
        }

        public override int GetHashCode()
        {
            int hashCode = ControllerName.ToUpperInvariant().GetHashCode() ^ ActionName.ToUpperInvariant().GetHashCode();
            if (MediaType != null)
            {
                hashCode ^= MediaType.GetHashCode();
            }
            if (SampleDirection != null)
            {
                hashCode ^= SampleDirection.GetHashCode();
            }
            if (ParameterType != null)
            {
                hashCode ^= ParameterType.GetHashCode();
            }
            foreach (string parameterName in ParameterNames)
            {
                hashCode ^= parameterName.ToUpperInvariant().GetHashCode();
            }

            return hashCode;
        }
    }
}
