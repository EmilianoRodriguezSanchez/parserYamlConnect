using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Reflection;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace YamlAPIConnectParser.Utils
{
    // The class derived from DynamicObject.
    public class DynamicDictionary : DynamicObject, INotifyPropertyChanged
    {

        /// <summary>
        /// This constructor just works off the internal dictionary and any 
        /// public properties of this object.
        /// 
        /// Note you can subclass Expando.
        /// </summary>
        public DynamicDictionary()
        {
            Initialize(this);
        }

        /// <summary>
        /// Allows passing in an existing instance variable to 'extend'.        
        /// </summary>
        /// <remarks>
        /// You can pass in null here if you don't want to 
        /// check native properties and only check the Dictionary!
        /// </remarks>
        /// <param name="instance"></param>
        public DynamicDictionary(object instance)
        {
            Initialize(instance);
        }


        protected virtual void Initialize(object instance)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            Instance = instance;
            if (instance != null)
                InstanceType = instance.GetType();
        }

        #region INotifyPropertyChanged support

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        #endregion        
        /// <summary>
        /// Returns the enumeration of all dynamic member names.
        /// </summary>
        /// <returns>
        /// A sequence that contains dynamic member names.
        /// </returns>
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            var properties = from f in Instance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public) 
                select f;
            return _cache.Keys;
        }


        /// <summary>
        /// Instance of object passed in
        /// </summary>
        public object Instance { get; set; }

        /// <summary>
        /// Cached type of the instance
        /// </summary>
        Type InstanceType;
        /// <summary>
        /// Gets the instance property information.
        /// </summary>
        /// <value>
        /// The instance property information.
        /// </value>
        public PropertyInfo[] InstancePropertyInfo
        {
            get
            {
                if (_InstancePropertyInfo == null && Instance != null)
                    _InstancePropertyInfo = Instance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                return _InstancePropertyInfo;
            }
        }
        private PropertyInfo[] _InstancePropertyInfo;
        
        // The inner dictionary.
       private Dictionary<string, object> _cache = new Dictionary<string, object>();
        public Dictionary<string, object> Properties = new Dictionary<string, object>();
        // This property returns the number of elements
        // in the inner dictionary.
        public int Count
        {
            get
            {
                return _cache.Count;
            }
        }

        public object this[string key]
        {
            get
            {
                try
                {
                     return Properties[key];
                }
                catch (KeyNotFoundException ex)
                {
                    // try reflection on instanceType
                    object result = null;
                    if (GetProperty(Instance, key, out result))
                        return result;

                    // nope doesn't exist
                    throw;
                }
            }
            set
            {
                object result = null;
                if (_cache.TryGetValue(key, out result))
                {
                   _cache[key] = value == null ? null : value;
                   // Properties[key] = SetDictionary(value);
                }
                
                // check instance for existance of type first
                var miArray = InstanceType.GetMember(key, BindingFlags.Public | BindingFlags.GetProperty);
                if (miArray != null && miArray.Length > 0)
                    SetProperty(Instance, key, value);
                else
                     _cache[key] = value;
                    //Properties[key] = SetDictionary(value);
    
            }
        }


        // If you try to get a value of a property 
        // not defined in the class, this method is called.
        public override bool TryGetMember( GetMemberBinder binder, out object result)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            string name = binder.Name.ToLower();
            result = null;
            // If the property name is found in a dictionary,
            // set the result parameter to the property value and return true.
            // Otherwise, return false.
            if (_cache.TryGetValue(name, out result))
            {
                return true;
            }

            // Next check for Public properties via Reflection
            if (Instance != null)
            {
                try
                {
                    return GetProperty(Instance, binder.Name, out result);
                }
                catch { }
            }

            // failed to retrieve a property
            result = null;
            return false;


        }

        // If you try to set a value of a property that is
        // not defined in the class, this method is called.
        public override bool TrySetMember( SetMemberBinder binder, object value)
        {
            // first check to see if there's a native property to set
            if (Instance != null)
            {
                try
                {
                    bool result = SetProperty(Instance, binder.Name, value);
                    if (result)
                        return true;
                }
                catch { }
            }


            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            _cache[binder.Name.ToLower()] = value;
            Properties[binder.Name.ToLower()] = SetDictionary(value);
            OnPropertyChanged(binder.Name.ToLower());
            // You can always add a value to a dictionary,
            // so this method always returns true.
            return true;
        }

        private object SetDictionary(object value)
        {

            if (!IsValidJson(value.ToString())) return value;

            

            var token = JToken.Parse(value.ToString());

            if (token is JObject)
            {
               // return ((JObject)value).ToDictionary();
               try
                {
                   
                    
                    // Dictionary<string, object> ValueList = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString());
                    var temp = ((JObject)JsonConvert.DeserializeObject<dynamic>(value.ToString()));
                    var resArray = ((JObject)temp).ToArray<dynamic>();
                    var ValueList = resArray.ToDictionary(jo => ((JProperty )jo).Name , jo => (object)((JProperty)jo).Value);
                    var result = ValueList.Where(kvp => kvp.Value != null && IsValidJson(kvp.Value.ToString())).ToDictionary(kvp => kvp.Key, kvp => SetDictionary(kvp.Value));
                    foreach (KeyValuePair<string, object> item in result)
                    {
                        ValueList[item.Key] = item.Value;
                    }

                    return ValueList;
                }
                catch (Exception)
                {
                    return value;
                }
               
            }

            else if (token is JArray)
            {
               
                var temp = ((JArray)JsonConvert.DeserializeObject<dynamic>(value.ToString()));
                var resArray = ((JArray)temp).ToArray<dynamic>();
                List<object> lst = new List<object>();
                foreach(object item in resArray)
                {
                    lst.Add ( SetDictionary(item));
                }

                return lst;
            }
            else return value;
            
        }

        bool IsValidJson(string json)
        {

            try
            {
                dynamic result = JToken.Parse(json);
                return true;
            }
            catch (JsonReaderException ex)
            {

                return false;
            }



        }


        /// <summary>
        /// Provides the implementation for operations that invoke a member. Classes derived from the <see cref="T:System.Dynamic.DynamicObject"></see> class can override this method to specify dynamic behavior for operations such as calling a method.
        /// </summary>
        /// <param name="binder">Provides information about the dynamic operation. The binder.Name property provides the name of the member on which the dynamic operation is performed. For example, for the statement sampleObject.SampleMethod(100), where sampleObject is an instance of the class derived from the <see cref="T:System.Dynamic.DynamicObject"></see> class, binder.Name returns "SampleMethod". The binder.IgnoreCase property specifies whether the member name is case-sensitive.</param>
        /// <param name="args">The arguments that are passed to the object member during the invoke operation. For example, for the statement sampleObject.SampleMethod(100), where sampleObject is derived from the <see cref="T:System.Dynamic.DynamicObject"></see> class, args[0] is equal to 100.</param>
        /// <param name="result">The result of the member invocation.</param>
        /// <returns>
        /// true if the operation is successful; otherwise, false. If this method returns false, the run-time binder of the language determines the behavior. (In most cases, a language-specific run-time exception is thrown.)
        /// </returns>
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (Instance != null)
            {
                try
                {
                    // check instance passed in for methods to invoke
                    if (InvokeMethod(Instance, binder.Name, args, out result))
                        return true;
                }
                catch { }
            }

            result = null;
            return false;
        }


        /// <summary>
        /// Reflection Helper method to retrieve a property
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="name"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        protected bool GetProperty(object instance, string name, out object result)
        {
            if (instance == null)
                instance = this;

            var miArray = InstanceType.GetMember(name, BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance);
            if (miArray != null && miArray.Length > 0)
            {
                var mi = miArray[0];
                if (mi.MemberType == MemberTypes.Property)
                {
                    result = ((PropertyInfo)mi).GetValue(instance, null);
                    return true;
                }
            }

            result = null;
            return false;
        }

        /// <summary>
        /// Reflection helper method to set a property value
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected bool SetProperty(object instance, string name, object value)
        {
            if (instance == null)
                instance = this;

            var miArray = InstanceType.GetMember(name, BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.Instance);
            if (miArray != null && miArray.Length > 0)
            {
                var mi = miArray[0];
                if (mi.MemberType == MemberTypes.Property)
                {
                    ((PropertyInfo)mi).SetValue(Instance, value, null);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Reflection helper method to invoke a method
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="name"></param>
        /// <param name="args"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        protected bool InvokeMethod(object instance, string name, object[] args, out object result)
        {
            if (instance == null)
                instance = this;

            // Look at the instanceType
            var miArray = InstanceType.GetMember(name,
                                    BindingFlags.InvokeMethod |
                                    BindingFlags.Public | BindingFlags.Instance);

            if (miArray != null && miArray.Length > 0)
            {
                var mi = miArray[0] as MethodInfo;
                result = mi.Invoke(Instance, args);
                return true;
            }

            result = null;
            return false;
        }


        /// <summary>
        /// Returns and the properties of 
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, object>> GetProperties(bool includeInstanceProperties = false)
        {
            if (includeInstanceProperties && Instance != null)
            {
                foreach (var prop in this.InstancePropertyInfo)
                    yield return new KeyValuePair<string, object>(prop.Name, prop.GetValue(Instance, null));
            }

            foreach (var key in this._cache.Keys)
                yield return new KeyValuePair<string, object>(key, this._cache[key]);

        }


        /// <summary>
        /// Checks whether a property exists in the Property collection
        /// or as a property on the instance
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(KeyValuePair<string, object> item, bool includeInstanceProperties = false)
        {
            bool res = _cache.ContainsKey(item.Key);
            if (res)
                return true;

            if (includeInstanceProperties && Instance != null)
            {
                foreach (var prop in this.InstancePropertyInfo)
                {
                    if (prop.Name == item.Key)
                        return true;
                }
            }

            return false;
        }


    }
}
