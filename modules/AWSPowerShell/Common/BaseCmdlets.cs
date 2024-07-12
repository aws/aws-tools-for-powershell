/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text;
using Amazon.Runtime;
using System.Collections;
using Amazon.Util.Internal;
using Amazon.PowerShell.Common.Internal;
using Amazon.Runtime.CredentialManagement;
using Amazon.Util;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// Ultimate base class for the AWS cmdlet hierarchy; adds helper methods for error
    /// and progress reporting. Cmdlets that need region or credential handling, or
    /// communicate with AWS services in any way, should derive from ServiceCmdlet. 
    /// </summary>
    public abstract class BaseCmdlet : PSCmdlet
    {
        // path beneath user's appdata folder where we can store information
        protected const string AWSPowerShellAppDataSubPath = @"AWSPowerShell";

        // update user agent string for current process
        internal static bool AWSPowerShellUserAgentSet;

        // update user agent string for current process
        protected string UserAgentAddition = null;

        // the max number of items to use in a confirmation prompt, to avoid
        // a wall of text
        const int ArrayTruncationThreshold = 10;

        static readonly object[] EmptyObjectArray = new object[0];

        // True if request contain any sensitive data
        protected virtual bool IsSensitiveRequest { get; set; }

        // True if response contain any sensitive data
        protected virtual bool IsSensitiveResponse { get; set; }

        protected virtual bool IsGeneratedCmdlet { get; set; }

        private bool IsSanitizingRequestError { get; set; }
        private bool IsSanitizingResponseError { get; set; }


        #region Error calls

        /// <summary>
        /// Summary to throw error based on inspection of the exception type.
        /// </summary>
        /// <param name="e"></param>
        protected void ThrowError(Exception e)
        {
            if (e is ArgumentException)
                ThrowArgumentError(e.Message, this, e);
            else
                ThrowExecutionError(e.Message, this, e);
        }

        /// <summary>
        /// Helper to throw a terminating exception on detection of invalid argument(s)
        /// </summary>
        /// <param name="message">The message to emit to the error record</param>
        /// <param name="errorSource">The source (parameter or cmdlet) reporting the error</param>
        protected void ThrowArgumentError(string message, object errorSource)
        {
            ThrowArgumentError(message, errorSource, null);
        }

        /// <summary>
        /// Displays the specified warning message in the shell.
        /// </summary>
        /// <param name="message"></param>
        protected void DisplayWarning(string message)
        {
            this.WriteWarning(message);    
        }

        /// <summary>
        /// Helper to throw a terminating exception on detection of invalid argument(s)
        /// </summary>
        /// <param name="message">The message to emit to the error record</param>
        /// <param name="errorSource">The source (parameter or cmdlet) reporting the error</param>
        /// <param name="innerException">The exception that occurred processing the parameter, if any</param>
        protected void ThrowArgumentError(string message, object errorSource, Exception innerException)
        {
            this.ThrowTerminatingError(new ErrorRecord(new ArgumentException(message, innerException),
                                                        "ArgumentException",
                                                        ErrorCategory.InvalidArgument,
                                                        errorSource));
        }

        protected void ThrowExecutionError(string message, object errorSource)
        {
            ThrowExecutionError(message, errorSource, null);
        }

        /// <summary>
        /// Helper to throw an error occuring during service execution
        /// </summary>
        /// <param name="message">The message to emit to the error record</param>
        /// <param name="errorSource">The source (parameter or cmdlet) reporting the error</param>
        /// <param name="innerException">The exception that was caught, if any</param>
        protected void ThrowExecutionError(string message, object errorSource, Exception innerException)
        {
            this.ThrowTerminatingError(new ErrorRecord(new InvalidOperationException(message, innerException),
                                                        innerException == null
                                                            ? "InvalidOperationException"
                                                            : innerException.GetType().ToString(),
                                                        ErrorCategory.InvalidOperation,
                                                        errorSource));
        }

        #endregion

        /// <summary>
        /// Helper to call ShouldProcess, mixing in usage of a -Force flag (more commonly used with
        /// ShouldContinue, but we don't use that) to override prompting unless -WhatIf is specified.
        /// The switch settings -WhatIf and -Confirm are retrieved from the invocation, since they
        /// are added dynamically at runtime by the shell.
        /// </summary>
        /// <param name="force">True if the -Force switch has been set</param>
        /// <param name="resourceIdentifiersText">Formatted string containing the identifiers of the resources to be operated on.</param>
        /// <param name="operationName">The name of the operation to be run (usually cmdlet name plus service api name)</param>
        /// <returns>True if the operation should proceed</returns>
        protected bool ConfirmShouldProceed(bool force, string resourceIdentifiersText, string operationName)
        {
            //var confirm = false;
            var whatif = false;

            if (MyInvocation.BoundParameters.ContainsKey("WhatIf"))
                whatif = ((SwitchParameter)MyInvocation.BoundParameters["WhatIf"]).ToBool();

            // -WhatIf trumps -Force, trumps -Confirm; the interplay of these in the shell is a bit
            // complicated :-(. ShouldProcess always yields false if -WhatIf is set.
            if (whatif)
                return ShouldProcess(resourceIdentifiersText, operationName);
        
            // if -Confirm is not set, ShouldProcess here will not prompt unless the shell's
            // $ConfirmPreference level is equal or below the cmdlets declared impact level
            return force || ShouldProcess(resourceIdentifiersText, operationName);
        }

        /// <summary>
        /// Returns formatted string containing the target of the operation for use in
        /// confirmation messages. Collections are truncated to avoid message bloat.
        /// </summary>
        public string FormatParameterValuesForConfirmationMsg(string targetParameterName, IDictionary<string, object> boundParameters)
        {
            if (string.IsNullOrEmpty(targetParameterName) || boundParameters.Keys.Count == 0)
                return string.Empty;

            object paramValue;
            if (!boundParameters.TryGetValue(targetParameterName, out paramValue) || paramValue == null)
                return string.Empty;

            // probe to determine the data type and format accordingly - very few types will actually
            // be used as resource-identifier parameters (string and string[] are the most likely)
            var asString = paramValue as string;
            if (asString != null)
                return asString;

            var asEnumerable = paramValue as IEnumerable;
            if (asEnumerable != null)
            {
                // try and keep the set of items to a reasonable value, to avoid the
                // command line 'exploding' with a wall of text. Take() would work here
                // except we want to add a 'plus n more items' suffix, so we need the
                // overall count
                var sb = new StringBuilder();
                var itemCount = 0;
                foreach (var item in asEnumerable)
                {
                    if (itemCount < ArrayTruncationThreshold)
                    {
                        if (sb.Length != 0)
                            sb.Append(", ");
                        sb.Append(item);
                    }

                    itemCount++;
                }

                if (itemCount > ArrayTruncationThreshold)
                    sb.AppendFormat(" (plus {0} more)", itemCount - ArrayTruncationThreshold);

                return sb.ToString();
            }

            if (TypeFactory.GetTypeInfo(paramValue.GetType()).IsValueType) // unlikely but just in case...
                return paramValue.ToString();

            // otherwise give up and report the parameter name for x-checking purposes
            return string.Format("values bound to the parameter {0}", targetParameterName);
        }

        /// <summary>
        /// Inspects the bound parameters to return the first from the set that has a value.
        /// Used when we are overriding the output for otherwise-void output cmdlets for -PassThru 
        /// and the user had a choice of parameters to specify to mean the same underlying object
        /// (eg Beanstalk's EnvironmentId or EnvironmentName). If no bound parameter is found, the 
        /// routine yields null.
        /// </summary>
        /// <param name="parameterNames"></param>
        /// <returns></returns>
        protected object GetFirstAssignedParameterValue(params string[] parameterNames)
        {
            var boundParameters = MyInvocation.BoundParameters;
            if (boundParameters == null) // don't think this is ever the case but just in case...
                return null;

            return (from name in parameterNames 
                    where boundParameters.ContainsKey(name) 
                    select boundParameters[name]).FirstOrDefault();
        }

        /// <summary>
        /// Returns true if the supplied value type parameter, which corresponds to a nullable
        /// value type in the execution context, was bound in our current invocation and therefore
        /// is safe to take the value from.
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        protected bool ParameterWasBound(string parameterName)
        {
            return MyInvocation.BoundParameters.ContainsKey(parameterName);
        }

        /// <summary>
        /// Allows additional parameters to be added (manually)
        /// to generated cmdlets and to transform the parameter value into
        /// the equivalent generated parameter prior to populating the
        /// execution context.
        /// </summary>
        /// <param name="context">
        /// Newly constructed context. On entry to this routine, the Region
        /// and Credentials members may have been set but no further parameter
        /// load has occurred.
        /// </param>
        protected virtual void PreExecutionContextLoad(ExecutorContext context)
        {
        }

        /// <summary>
        /// Allows further transformation or manipulation of parameter values
        /// loaded into the context before we commence processing.
        /// </summary>
        /// <param name="context">
        /// The context with all parameters processed and ready for use in
        /// service calls (or whatever processing the cmdlet performs).
        /// </param>
        protected virtual void PostExecutionContextLoad(ExecutorContext context)
        {
        }

        #region Progress calls

        /// <summary>
        /// Writes progress record to the shell.
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="message"></param>
        /// <param name="percentComplete"></param>
        public void WriteProgressRecord(string activity, string message, int? percentComplete = null)
        {
            WriteProgressRecord(this.GetHashCode(), activity, message, percentComplete);
        }

        /// <summary>
        /// Writes progress completed record to the shell.
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="message"></param>
        public void WriteProgressCompleteRecord(string activity, string message)
        {
            WriteProgressRecord(this.GetHashCode(), activity, message, null, true);
        }

        private void WriteProgressRecord(int activityId, string activity, string message, int? percentComplete = null, bool isComplete = false)
        {
            var pr = new ProgressRecord(activityId, activity, message)
            {
                RecordType = isComplete ? ProgressRecordType.Completed : ProgressRecordType.Processing
            };
            if (percentComplete != null)
                pr.PercentComplete = percentComplete.Value;

            WriteProgress(pr);
        }

#endregion

        #region Processing helpers

        public IEnumerable SafeEnumerable(object value)
        {
            var s = value as string;
            if (s != null)
                return new string[] { s };

            var enumerable = value as IEnumerable;
            if (enumerable != null)
                return enumerable;
            else
                return new object[] { value };
        }

        protected AWSCmdletHistory ServiceCalls { get; private set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            if (!AWSPowerShellUserAgentSet)
            {
                Utils.Common.SetAWSPowerShellUserAgent(Host.Version);
                AWSPowerShellUserAgentSet = true;
            }

            // wanted to emit just the stack, or copy of it (to prevent modification) but if we do that,
            // we see only the Count of entries, not the actual content - need to figure out
            if (this.SessionState.PSVariable.Get(SessionKeys.AWSCallHistoryName) == null)
                this.SessionState.PSVariable.Set(SessionKeys.AWSCallHistoryName, new PSObject(AWSCmdletHistoryBuffer.Instance));

            ServiceCalls = AWSCmdletHistoryBuffer.Instance.StartCmdletHistory(this.MyInvocation.MyCommand.Name);
        }

        protected override void EndProcessing()
        {
            // if we get here, there were no terminating errors during ProcessRecord
            AWSCmdletHistoryBuffer.Instance.PushCmdletHistory(ServiceCalls);
            base.EndProcessing();
            
            // Writing Non-terminating error in EndProcessing since we should only write a single error message when commands are run in a pipeline
            // Moved this.WriteError from ResponseEventHandler to EndProcessing since Write Methods can be only called from BeginProcessing, ProcessRecord and EndProcessing
            if (IsSanitizingRequestError || IsSanitizingResponseError)
            {
                // Build error message
                string failedType = "";
                if (IsSanitizingRequestError && IsSanitizingResponseError)
                {
                    failedType = "Request and Response are";
                }
                else if (IsSanitizingRequestError) { 
                    failedType = "Request is";
                }
                else if (IsSanitizingResponseError) { 
                    failedType = "Response is";
                }

                string errorMessage = $"Error occurred in sensitive data redaction, as a result {failedType} being omitted from $AWSHistory. In case you rely on $AWSHistory, run Set-AWSHistoryConfiguration -IncludeSensitiveData command to skip sensitive data redaction. Please report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.";
                this.WriteError(new ErrorRecord(new Exception(errorMessage), "", ErrorCategory.InvalidOperation, this));
            }
        }

        protected virtual void ProcessOutput(CmdletOutput cmdletOutput)
        {
            if (cmdletOutput == null)
                return;

            if (cmdletOutput.ErrorResponse != null)
            {
                ServiceCalls.PushServiceResponse(cmdletOutput.ErrorResponse, null);
                // need to manually end the history data here, as once we throw the error we won't
                // get called to run EndProcessing...
                AWSCmdletHistoryBuffer.Instance.PushCmdletHistory(ServiceCalls);

                ThrowExecutionError(cmdletOutput.ErrorResponse.Message, this, cmdletOutput.ErrorResponse);
            }
            else
            {
                // pipe the output manually, so we can track the number of emitted objects to add
                // as a convenience note on the LastServiceResponse
                int emittedObjectCount = 0;
                if (cmdletOutput.PipelineOutput != null)
                {
                    IEnumerator enumerator = LanguagePrimitives.GetEnumerator(cmdletOutput.PipelineOutput);
                    if (enumerator == null)
                    {
                        WriteObject(cmdletOutput.PipelineOutput);
                        emittedObjectCount++;
                    }
                    else
                    {
                        while (enumerator.MoveNext())
                        {
                            WriteObject(enumerator.Current);
                            emittedObjectCount++;
                        }
                    }
                }

                ServiceCalls.EmittedObjectsCount += emittedObjectCount;
            }
        }

        protected void ResponseEventHandler(object sender, ResponseEventArgs args)
        {
            var wsrea = args as WebServiceResponseEventArgs;
            if (wsrea == null) return;

            var response = wsrea.Response;
            if (response == null) return;

            AmazonWebServiceResponse sanitizedResponse = GetSanitizedData(response);
            if (sanitizedResponse == null) return;

            ServiceCalls.PushServiceResponse(sanitizedResponse);

        }

        private AmazonWebServiceResponse GetSanitizedData(AmazonWebServiceResponse response)
        {
            var sanitizedResponse = response;

            try
            {
                if (!AWSCmdletHistoryBuffer.Instance.IncludeSensitiveData)
                {
                    if (!IsGeneratedCmdlet && !IsSensitiveResponse)
                    {
                        // Evaluate IsSensitiveResponse for Advanced Cmdlets if not already overridden
                        IsSensitiveResponse = SensitiveData.TypeContainsSensitiveData(response.GetType());
                    }

                    if (IsSensitiveResponse)
                    {
                        sanitizedResponse = SensitiveData.GetSanitizedData(response) as AmazonWebServiceResponse;
                    }
                }
            }
            catch (Exception ex)
            {
                IsSanitizingResponseError = true;
                return null;
            }

            return sanitizedResponse;
        }

        protected void RequestEventHandler(object sender, RequestEventArgs args)
        {
            var wsrea = args as WebServiceRequestEventArgs;
            if (wsrea == null)
            {  
                return; 
            }
            else
            {
                wsrea.Headers[AWSSDKUtils.UserAgentHeader] += $" {UserAgentAddition}";
            }

            var request = wsrea.Request;

            if (request == null) return;

            AmazonWebServiceRequest sanitizedRequest = GetSanitizedData(request);

            if (sanitizedRequest == null) return;

            ServiceCalls.PushServiceRequest(sanitizedRequest, this.MyInvocation);
        }

        private AmazonWebServiceRequest GetSanitizedData(AmazonWebServiceRequest request)
        {
            var sanitizedRequest = request;

            if (!AWSCmdletHistoryBuffer.Instance.RecordServiceRequests) return null;

            try
            {
                if (!AWSCmdletHistoryBuffer.Instance.IncludeSensitiveData)
                {
                    if (!IsGeneratedCmdlet && !IsSensitiveRequest)
                    {
                        // Evaluate IsSensitiveRequest for Advanced Cmdlets if not already overridden
                        IsSensitiveRequest = SensitiveData.TypeContainsSensitiveData(request.GetType());
                    }

                    if (IsSensitiveRequest)
                    {
                        sanitizedRequest = SensitiveData.GetSanitizedData(sanitizedRequest) as AmazonWebServiceRequest;
                    }
                }

            }
            catch (Exception ex)
            {
                IsSanitizingRequestError = true;
                return null;
            }
            return sanitizedRequest;
        }

        #endregion

        /// <summary>
        /// Safely emit a diagnostic message indicating where the credentials we are about to use
        /// originated from.
        /// </summary>
        /// <param name="awsPSCredentials"></param>
        protected void WriteCredentialSourceDiagnostic(AWSPSCredentials awsPSCredentials)
        {
            try
            {
                WriteCredentialSourceDiagnostic(FormatCredentialSourceForDisplay(awsPSCredentials));
            }
            catch
            {
            }
        }

        /// <summary>
        /// Emit a diagnostic message indicating where the credentials we are about to use
        /// originated from.
        /// </summary>
        /// <param name="credentialSource"></param>
        protected void WriteCredentialSourceDiagnostic(string credentialSource)
        {
            WriteDebug(string.Format("Credentials obtained from {0}", credentialSource));
        }

        /// <summary>
        /// Emit a diagnostic message indicating where the credentials we are about to use
        /// originated from.
        /// </summary>
        /// <param name="regionSource"></param>
        /// <param name="regionValue"></param>
        protected void WriteRegionSourceDiagnostic(RegionSource regionSource, string regionValue = null)
        {
            WriteRegionSourceDiagnostic(FormatRegionSourceForDisplay(regionSource), regionValue);
        }

        /// <summary>
        /// Emit a diagnostic message indicating where the credentials we are about to use
        /// originated from.
        /// </summary>
        /// <param name="regionSource"></param>
        /// <param name="regionValue"></param>
        protected void WriteRegionSourceDiagnostic(string regionSource, string regionValue = null)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Region obtained from {0}", regionSource);
            if (!String.IsNullOrEmpty(regionValue))
                sb.AppendFormat(" with value '{0}'", regionValue);

            WriteDebug(sb.ToString());
        }

#if DESKTOP
        protected IEnumerable<PSObject> ExecuteCmdlet(string cmdletName, Dictionary<string, object> parameters, string moduleName = "AWSPowerShell")
        {
            using (var pipeline = System.Management.Automation.Runspaces.Runspace.DefaultRunspace.CreateNestedPipeline())
            {
                System.Management.Automation.Runspaces.Command command = new System.Management.Automation.Runspaces.Command($"{moduleName}\\{cmdletName}");
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter.Key, parameter.Value);
                    }
                }
                pipeline.Commands.Add(command);
                return pipeline.Invoke();
            }
        }
#else
        protected IEnumerable<PSObject> ExecuteCmdlet(CmdletInfo cmdlet, Dictionary<string, object> parameters)
        {
            using (var powerShell = System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace))
            {
                powerShell.AddCommand(cmdlet);
                if (parameters != null)
                {
                    powerShell.AddParameters(parameters);
                }
                return powerShell.Invoke();
            }
        }
#endif

        /// <summary>
        /// Translates enum into a friendlier 'from xxx' display string
        /// </summary>
        /// <param name="creds"></param>
        /// <returns></returns>
        internal static string FormatCredentialSourceForDisplay(AWSPSCredentials creds)
        {
            switch (creds.Source)
            {
                case CredentialsSource.CredentialsObject:
                    return "supplied credentials object";
                case CredentialsSource.Container:
                    return "container environment";
                case CredentialsSource.InstanceProfile:
                    return "instance profile";
                case CredentialsSource.Profile:
                    return String.Format("stored profile named '{0}'", creds.Name);
                case CredentialsSource.Session:
                    return "shell variable $" + SessionKeys.AWSCredentialsVariableName;
                case CredentialsSource.Strings:
                    return "the supplied key parameters";
            }

            // fallback
            return Enum.GetName(typeof(CredentialsSource), creds.Source);
        }
        /// <summary>
        /// Translates enum into a friendlier 'from xxx' display string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        internal static string FormatRegionSourceForDisplay(RegionSource source)
        {
            switch (source)
            {
                case RegionSource.RegionObject:
                    return "supplied region object";
                case RegionSource.Saved:
                    return "stored region";
                case RegionSource.Session:
                    return "shell variable $" + SessionKeys.AWSRegionVariableName;
                case RegionSource.String:
                    return "region parameter";
            }

            // fallback
            return Enum.GetName(typeof(RegionSource), source);
        }

        protected static Func<TResponse, TCmdlet, object> CreateSelectDelegate<TResponse, TCmdlet>(string selectString) where TCmdlet : BaseCmdlet
        {
            switch(selectString)
            {
                case null:
                case "":
                    return null;
                case "*":
                    return (response, cmdlet) => response;
                case var s when s.StartsWith("^"):
                {
                    var type = typeof(TCmdlet);
                    var parameterName = selectString.Substring(1);

                    PropertyInfo selectedProperty = null;
                    foreach (var property in type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance))
                    {
                        if (property.Name.Equals(parameterName, StringComparison.OrdinalIgnoreCase))
                        {
                            selectedProperty = property;
                            break;
                        }
                        else
                        {
                            foreach (var attributeAlias in property
                                .GetCustomAttributes(typeof(AliasAttribute), false)
                                .Cast<AliasAttribute>()
                                .SelectMany(attribute => attribute.AliasNames))
                            {
                                if (attributeAlias.Equals(parameterName, StringComparison.OrdinalIgnoreCase))
                                {
                                    selectedProperty = property;
                                    break;
                                }
                            }
                            if (selectedProperty != null)
                            {
                                break;
                            }
                        }
                    }
                    var getter = selectedProperty?.GetGetMethod();
                    if (getter == null)
                    {
                        return null;
                    }
                    return (response, cmdlet) => getter.Invoke(cmdlet, EmptyObjectArray);
                }
                default:
                {
                    var type = typeof(TResponse);
                    var selectors = new List<Func<IEnumerable<object>, IEnumerable<object>>>();
                    foreach (var propertyName in selectString.Split('.'))
                    {
                        var properties = type
                            .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                            .Where(property => property.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase))
                            .ToArray();
                        if (properties.Length != 1)
                        {
                            return null;
                        }
                        var getter = properties[0].GetGetMethod();
                        if (getter == null)
                        {
                            return null;
                        }
                        type = properties[0].PropertyType;
                        var iEnumerableInterface = type.GetInterface("System.Collections.Generic.IEnumerable`1");
                        if (iEnumerableInterface != null && type != typeof(string))
                        {
                            selectors.Add(enumerable => enumerable
                                .Select(item => ((IEnumerable)getter.Invoke(item, EmptyObjectArray)).Cast<object>())
                                .Where(collection => collection != null)
                                .SelectMany(collection => collection)
                                .Where(item => item != null));
                            type = iEnumerableInterface.GetGenericArguments()[0];
                        }
                        else
                        {
                            selectors.Add(enumerable => enumerable
                                .Select(item => getter.Invoke(item, EmptyObjectArray))
                                .Where(item => item != null));
                        }
                    }
                    return (response, cmdlet) =>
                    {
                        if (response == null)
                        {
                            return null;
                        }
                        IEnumerable<object> current = new object[] { response };
                        foreach (var selector in selectors)
                        {
                            current = selector(current);
                        }
                        return current.ToArray();
                    };
                }
            }
        }
    }

    /// <summary>
    /// Base class for all AWS cmdlets that interact with an AWS service in some way and
    /// thus need region and credential support.
    /// </summary>
    public abstract class ServiceCmdlet : AWSCommonArgumentsCmdlet
    {
        protected AWSCredentials _CurrentCredentials { get; private set; }
        public RegionEndpoint _RegionEndpoint { get; private set; }
        protected bool _ExecuteWithAnonymousCredentials { get; set; }
        protected ClientConfig _ClientConfig { get; set; }
        protected string _AWSSignerType { get; set; }

        /// <summary>
        /// <para>
        /// The endpoint to make the call against.
        /// </para>
        /// <para>
        /// <b>Note:</b> This parameter is primarily for internal AWS use and is not required/should not be specified for 
        /// normal usage. The cmdlets normally determine which endpoint to call based on the region specified to the -Region
        /// parameter or set as default in the shell (via Set-DefaultAWSRegion). Only specify this parameter if you must
        /// direct the call to a specific custom endpoint.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointUrl { get; set; }

        protected virtual string _DefaultRegion
        {
            get
            {
                return null;
            }
        }

        protected virtual void CustomizeClientConfig(ClientConfig config)
        {
            // if user passes $null as value, we see a bound parameter
            if (ParameterWasBound("EndpointUrl") && !string.IsNullOrEmpty(this.EndpointUrl))
            {
                if(_AWSSignerType != "bearer" || (_AWSSignerType == "bearer" && config?.AWSTokenProvider == null))
                {
                    // To allow use of urls that do not contain region info, swap any region
                    // we've already detected for the command into AuthRegion for the config;
                    // setting ServiceUrl will clear RegionEndpoint on the config.
                    config.AuthenticationRegion = config.RegionEndpoint.SystemName;
                }

                config.ServiceURL = this.EndpointUrl.ToString();
            }
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (this._ExecuteWithAnonymousCredentials)
            {
                _CurrentCredentials = new AnonymousAWSCredentials();
                WriteCredentialSourceDiagnostic("anonymous credentials");
            }
            else
            {
                AWSPSCredentials awsPSCredentials;
                if (!this.TryGetCredentials(Host, out awsPSCredentials, SessionState))
                    ThrowExecutionError("No credentials specified or obtained from persisted/shell defaults.", this);

                _CurrentCredentials = awsPSCredentials.Credentials;
                WriteCredentialSourceDiagnostic(awsPSCredentials);
                if (_CurrentCredentials is SSOAWSCredentials ssoAWSCredentials)
                {
                    // Setting SupportsGettingNewToken to false ensures that the sso login flow is not initiated when
                    // sso token has expired.
                    ssoAWSCredentials.Options.SupportsGettingNewToken = false;
                    ValidateSSOToken(ssoAWSCredentials);
                }
            }

            this.TryGetRegion(useInstanceMetadata: true, out var region, out var regionSource, SessionState);

            _RegionEndpoint = region;

            // At this point. if user explicitly passes Region parameter, the source is set as String. Next preference in order is explicitly passed region in ClientConfig.
            if (_RegionEndpoint == null || regionSource != RegionSource.String)
            {
                if (_ClientConfig?.RegionEndpoint != null)
                {
                    RegionEndpoint regionFactoryValue = FallbackRegionFactory.GetRegionEndpoint();

                    // Set region from explicitly passed value in ClientConfig only if it is different from region resolved by .NET SDK.
                    if (regionFactoryValue == null || _ClientConfig.RegionEndpoint.SystemName != regionFactoryValue.SystemName)
                    {
                        _RegionEndpoint = _ClientConfig.RegionEndpoint;
                        regionSource = RegionSource.String;
                    }
                }
            }

            if(_AWSSignerType == "bearer")
            {
                //Bearer tokens using AWSTokenProvider/Profiles do not require a region as it will be resolved by the .NET SDK.

                //AWSTokenProvider is set as:
                //  1. $config.AWSTokenProvider = New-Object -TypeName Amazon.Runtime.ProfileTokenProvider("SOME_PROFILE")
                //  2. $config.AWSTokenProvider = New-Object -TypeName Amazon.Runtime.StaticTokenProvider("SOME_TOKEN")

                _RegionEndpoint = null;
                regionSource = RegionSource.String;
                WriteRegionSourceDiagnostic("bearer-token", null);
            }
            else if (_RegionEndpoint == null)
            {
                if (String.IsNullOrEmpty(_DefaultRegion))
                    ThrowExecutionError("No region specified or obtained from persisted/shell defaults.", this);
                else
                {
                    _RegionEndpoint = RegionEndpoint.GetBySystemName(_DefaultRegion);
                    WriteRegionSourceDiagnostic("built-in-default", _DefaultRegion);
                }
            }
            else
            {
                WriteRegionSourceDiagnostic(regionSource, region.SystemName);
            }
        }

        private void ValidateSSOToken(SSOAWSCredentials ssoAWSCredentials)
        {
            var ssoTokenManagerGetTokenOptions = SSOUtils.BuildSSOTokenManagerGetTokenOptions(ssoAWSCredentials, supportsGettingNewToken: false, ssoVerificationCallback: null);

            bool isLoginRequired = SSOUtils.IsSsoLoginRequiredAsync(ssoTokenManagerGetTokenOptions).GetAwaiter().GetResult();
            if (isLoginRequired)
            {
                string message = $"SSO Token has expired. Please login by running Invoke-AWSSSOLogin.";
                this.ThrowTerminatingError(new ErrorRecord(new UnauthorizedAccessException(message),
                                                            "UnauthorizedAccessException",
                                                            ErrorCategory.PermissionDenied,
                                                            this));
            }
        }
    }

    /// <summary>
    /// Base class for all AWS cmdlets that interact with an AWS service in some way but can call
    /// with anonymous user credentials.
    /// </summary>
    public abstract class AnonymousServiceCmdlet : AWSRegionArgumentsCmdlet
    {
        protected RegionEndpoint _RegionEndpoint { get; private set; }
        protected ClientConfig _ClientConfig { get; set; }
        protected string _AWSSignerType { get; set; }

        #region Parameter EndpointURL
        /// <summary>
        /// <para>
        /// The endpoint to make the call against.
        /// </para>
        /// <para>
        /// <b>Note:</b> This parameter is primarily for internal AWS use and is not required/should not be specified for 
        /// normal usage. The cmdlets normally determine which endpoint to call based on the region specified to the -Region
        /// parameter or set as default in the shell (via Set-DefaultAWSRegion). Only specify this parameter if you must
        /// direct the call to a specific custom endpoint.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointUrl { get; set; }
#endregion

        protected virtual string _DefaultRegion
        {
            get
            {
                return null;
            }
        }

        protected virtual void CustomizeClientConfig(ClientConfig config)
        {
            // if user passes $null as value, we see a bound parameter
            if (ParameterWasBound("EndpointUrl") && !string.IsNullOrEmpty(this.EndpointUrl))
            {
                config.ServiceURL = this.EndpointUrl.ToString();
            }
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            this.TryGetRegion(useInstanceMetadata: true, out var region, out var regionSource, SessionState);
            _RegionEndpoint = region;

            // At this point. if user explicitly passes Region parameter, the source is set as String. Next preference in order is explicitly passed region in ClientConfig.
            if (_RegionEndpoint == null || regionSource != RegionSource.String)
            {
                if (_ClientConfig?.RegionEndpoint != null)
                {
                    RegionEndpoint regionFactoryValue = FallbackRegionFactory.GetRegionEndpoint();

                    // Set region from explicitly passed value in ClientConfig only if it is different from region resolved by .NET SDK.
                    if (regionFactoryValue == null || _ClientConfig.RegionEndpoint.SystemName != regionFactoryValue.SystemName)
                    {
                        _RegionEndpoint = _ClientConfig.RegionEndpoint;
                        regionSource = RegionSource.String;
                    }
                }
            }

            if (_RegionEndpoint == null)
            {
                if (String.IsNullOrEmpty(_DefaultRegion))
                    ThrowExecutionError("No region specified or obtained from persisted/shell defaults.", this);
                else
                {
                    _RegionEndpoint = RegionEndpoint.GetBySystemName(_DefaultRegion);
                    WriteRegionSourceDiagnostic("built-in-default", _DefaultRegion);
                }
            }
            else
            {
                WriteRegionSourceDiagnostic(regionSource, region.SystemName);
            }
        }
    }

    public class CmdletOutput
    {
        public object PipelineOutput { get; set; }
        public object ServiceResponse { get; set; }
        public Exception ErrorResponse { get; set; }

        /// <summary>
        /// True if the output data is an enumerable collection that we should
        /// emit object-by-object to the pipe. Note that strings are enumerable
        /// so we must test for that specific case.
        /// </summary>
        public bool IsEnumerableOutput
        {
            get
            {
                if (this.PipelineOutput == null)
                    return false;

                return !(this.PipelineOutput is string) && (this.PipelineOutput is IEnumerable);
            }
        }
    }

    internal class CmdletContext
    {
    }

    public class ExecutorContext
    {
    }

    public interface IExecutor
    {
        object Execute(ExecutorContext context);
        ExecutorContext CreateContext();
    }
}