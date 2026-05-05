/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using System.Threading;
using Amazon.MediaTailor;
using Amazon.MediaTailor.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EMT
{
    /// <summary>
    /// Creates or updates a function. A function defines reusable logic that MediaTailor
    /// executes at lifecycle hooks during ad insertion. For more information about functions,
    /// see <a href="https://docs.aws.amazon.com/mediatailor/latest/ug/monetization-functions.html">Working
    /// with functions</a> in the <i>MediaTailor User Guide</i>.
    /// </summary>
    [Cmdlet("Write", "EMTFunction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaTailor.Model.PutFunctionResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaTailor PutFunction API operation.", Operation = new[] {"PutFunction"}, SelectReturnType = typeof(Amazon.MediaTailor.Model.PutFunctionResponse))]
    [AWSCmdletOutput("Amazon.MediaTailor.Model.PutFunctionResponse",
        "This cmdlet returns an Amazon.MediaTailor.Model.PutFunctionResponse object containing multiple properties."
    )]
    public partial class WriteEMTFunctionCmdlet : AmazonMediaTailorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter HttpRequestConfiguration_Body
        /// <summary>
        /// <para>
        /// <para>An expression that evaluates to the request body. Used with <c>POST</c> requests.
        /// The maximum size after evaluation is 64 KB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HttpRequestConfiguration_Body { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FunctionId
        /// <summary>
        /// <para>
        /// <para>The identifier of the function. The identifier must be unique within your account.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FunctionId { get; set; }
        #endregion
        
        #region Parameter SequentialExecutorConfiguration_FunctionList
        /// <summary>
        /// <para>
        /// <para>An ordered list of 1 to 10 steps. Each step specifies a child function to execute
        /// and an optional run condition expression that controls whether the step runs. MediaTailor
        /// executes steps in order, passing data between steps through temporary data.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MediaTailor.Model.FunctionRef[] SequentialExecutorConfiguration_FunctionList { get; set; }
        #endregion
        
        #region Parameter FunctionType
        /// <summary>
        /// <para>
        /// <para>The type of the function. The function type determines what the function can do at
        /// runtime. Valid values: <c>CUSTOM_OUTPUT</c> evaluates expressions and produces output
        /// bindings with no external calls. <c>HTTP_REQUEST</c> makes an HTTP call to an external
        /// service and evaluates output expressions that can reference the response. <c>SEQUENTIAL_EXECUTOR</c>
        /// runs a sequence of child functions in order, passing data between steps through temporary
        /// data. For more information, see <a href="https://docs.aws.amazon.com/mediatailor/latest/ug/monetization-functions-types.html">Function
        /// types and composition</a> in the <i>MediaTailor User Guide</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.MediaTailor.FunctionType")]
        public Amazon.MediaTailor.FunctionType FunctionType { get; set; }
        #endregion
        
        #region Parameter HttpRequestConfiguration_Header
        /// <summary>
        /// <para>
        /// <para>A map of HTTP header names to expression values. MediaTailor evaluates each header
        /// value expression at runtime and includes the result in the outbound HTTP request.
        /// Maximum 50 headers.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HttpRequestConfiguration_Headers")]
        public System.Collections.Hashtable HttpRequestConfiguration_Header { get; set; }
        #endregion
        
        #region Parameter HttpRequestConfiguration_MethodType
        /// <summary>
        /// <para>
        /// <para>The HTTP method for the request. Valid values: <c>GET</c> and <c>POST</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaTailor.MethodType")]
        public Amazon.MediaTailor.MethodType HttpRequestConfiguration_MethodType { get; set; }
        #endregion
        
        #region Parameter CustomOutputConfiguration_Output
        /// <summary>
        /// <para>
        /// <para>A map of output bindings. Each key is a namespaced output path (such as <c>player_params.device_type</c>
        /// or <c>temp.variant</c>), and each value is an expression that MediaTailor evaluates
        /// at runtime against the current session state. For more information about expression
        /// syntax, see <a href="https://docs.aws.amazon.com/mediatailor/latest/ug/monetization-functions-jsonata.html">JSONata
        /// expression reference</a> in the <i>MediaTailor User Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable CustomOutputConfiguration_Output { get; set; }
        #endregion
        
        #region Parameter HttpRequestConfiguration_Output
        /// <summary>
        /// <para>
        /// <para>A map of output bindings. Each key is a namespaced output path (such as <c>player_params.device_type</c>
        /// or <c>temp.identity</c>), and each value is an expression that MediaTailor evaluates
        /// at runtime. Output expressions in an <c>HTTP_REQUEST</c> function can reference the
        /// <c>response</c> object returned by the HTTP call. For more information about expression
        /// syntax, see <a href="https://docs.aws.amazon.com/mediatailor/latest/ug/monetization-functions-jsonata.html">JSONata
        /// expression reference</a> in the <i>MediaTailor User Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable HttpRequestConfiguration_Output { get; set; }
        #endregion
        
        #region Parameter SequentialExecutorConfiguration_Output
        /// <summary>
        /// <para>
        /// <para>An optional map of output bindings that controls which bindings the sequence commits
        /// to the session state after all steps complete. If omitted, MediaTailor commits all
        /// accumulated output bindings from all child steps.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable SequentialExecutorConfiguration_Output { get; set; }
        #endregion
        
        #region Parameter HttpRequestConfiguration_RequestTimeoutMillisecond
        /// <summary>
        /// <para>
        /// <para>The maximum time, in milliseconds, that MediaTailor waits for a response from the
        /// external service. If the call exceeds this timeout, MediaTailor sets the response
        /// status code to <c>null</c> and proceeds with output expression evaluation. Valid values:
        /// <c>100</c> to <c>2000</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HttpRequestConfiguration_RequestTimeoutMilliseconds")]
        public System.Int32? HttpRequestConfiguration_RequestTimeoutMillisecond { get; set; }
        #endregion
        
        #region Parameter CustomOutputConfiguration_Runtime
        /// <summary>
        /// <para>
        /// <para>The expression language used to evaluate expressions in the function configuration.
        /// Set this to <c>JSONata</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaTailor.RuntimeType")]
        public Amazon.MediaTailor.RuntimeType CustomOutputConfiguration_Runtime { get; set; }
        #endregion
        
        #region Parameter HttpRequestConfiguration_Runtime
        /// <summary>
        /// <para>
        /// <para>The expression language used to evaluate expressions in the function configuration.
        /// Set this to <c>JSONata</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaTailor.RuntimeType")]
        public Amazon.MediaTailor.RuntimeType HttpRequestConfiguration_Runtime { get; set; }
        #endregion
        
        #region Parameter SequentialExecutorConfiguration_Runtime
        /// <summary>
        /// <para>
        /// <para>The expression language used to evaluate expressions in the function configuration.
        /// Set this to <c>JSONata</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaTailor.RuntimeType")]
        public Amazon.MediaTailor.RuntimeType SequentialExecutorConfiguration_Runtime { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the function. Tags are key-value pairs that you can associate
        /// with Amazon resources to help with organization, access control, and cost tracking.
        /// For more information, see <a href="https://docs.aws.amazon.com/mediatailor/latest/ug/tagging.html">Tagging
        /// AWS Elemental MediaTailor Resources</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter SequentialExecutorConfiguration_TimeoutMillisecond
        /// <summary>
        /// <para>
        /// <para>The maximum time, in milliseconds, for the entire sequence to complete. This timeout
        /// covers all steps, including any HTTP calls made by child functions. If the sequence
        /// exceeds this timeout, MediaTailor discards all output from the sequence and proceeds
        /// with default behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SequentialExecutorConfiguration_TimeoutMilliseconds")]
        public System.Int32? SequentialExecutorConfiguration_TimeoutMillisecond { get; set; }
        #endregion
        
        #region Parameter HttpRequestConfiguration_Url
        /// <summary>
        /// <para>
        /// <para>An expression that evaluates to the request URL. Use <c>{%...%}</c> delimiters for
        /// dynamic expressions. The maximum length after evaluation is 2,048 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HttpRequestConfiguration_Url { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaTailor.Model.PutFunctionResponse).
        /// Specifying the name of a property of type Amazon.MediaTailor.Model.PutFunctionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FunctionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EMTFunction (PutFunction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaTailor.Model.PutFunctionResponse, WriteEMTFunctionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CustomOutputConfiguration_Output != null)
            {
                context.CustomOutputConfiguration_Output = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CustomOutputConfiguration_Output.Keys)
                {
                    context.CustomOutputConfiguration_Output.Add((String)hashKey, (System.String)(this.CustomOutputConfiguration_Output[hashKey]));
                }
            }
            context.CustomOutputConfiguration_Runtime = this.CustomOutputConfiguration_Runtime;
            context.Description = this.Description;
            context.FunctionId = this.FunctionId;
            #if MODULAR
            if (this.FunctionId == null && ParameterWasBound(nameof(this.FunctionId)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FunctionType = this.FunctionType;
            #if MODULAR
            if (this.FunctionType == null && ParameterWasBound(nameof(this.FunctionType)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HttpRequestConfiguration_Body = this.HttpRequestConfiguration_Body;
            if (this.HttpRequestConfiguration_Header != null)
            {
                context.HttpRequestConfiguration_Header = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.HttpRequestConfiguration_Header.Keys)
                {
                    context.HttpRequestConfiguration_Header.Add((String)hashKey, (System.String)(this.HttpRequestConfiguration_Header[hashKey]));
                }
            }
            context.HttpRequestConfiguration_MethodType = this.HttpRequestConfiguration_MethodType;
            if (this.HttpRequestConfiguration_Output != null)
            {
                context.HttpRequestConfiguration_Output = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.HttpRequestConfiguration_Output.Keys)
                {
                    context.HttpRequestConfiguration_Output.Add((String)hashKey, (System.String)(this.HttpRequestConfiguration_Output[hashKey]));
                }
            }
            context.HttpRequestConfiguration_RequestTimeoutMillisecond = this.HttpRequestConfiguration_RequestTimeoutMillisecond;
            context.HttpRequestConfiguration_Runtime = this.HttpRequestConfiguration_Runtime;
            context.HttpRequestConfiguration_Url = this.HttpRequestConfiguration_Url;
            if (this.SequentialExecutorConfiguration_FunctionList != null)
            {
                context.SequentialExecutorConfiguration_FunctionList = new List<Amazon.MediaTailor.Model.FunctionRef>(this.SequentialExecutorConfiguration_FunctionList);
            }
            if (this.SequentialExecutorConfiguration_Output != null)
            {
                context.SequentialExecutorConfiguration_Output = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SequentialExecutorConfiguration_Output.Keys)
                {
                    context.SequentialExecutorConfiguration_Output.Add((String)hashKey, (System.String)(this.SequentialExecutorConfiguration_Output[hashKey]));
                }
            }
            context.SequentialExecutorConfiguration_Runtime = this.SequentialExecutorConfiguration_Runtime;
            context.SequentialExecutorConfiguration_TimeoutMillisecond = this.SequentialExecutorConfiguration_TimeoutMillisecond;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.MediaTailor.Model.PutFunctionRequest();
            
            
             // populate CustomOutputConfiguration
            var requestCustomOutputConfigurationIsNull = true;
            request.CustomOutputConfiguration = new Amazon.MediaTailor.Model.CustomOutputConfiguration();
            Dictionary<System.String, System.String> requestCustomOutputConfiguration_customOutputConfiguration_Output = null;
            if (cmdletContext.CustomOutputConfiguration_Output != null)
            {
                requestCustomOutputConfiguration_customOutputConfiguration_Output = cmdletContext.CustomOutputConfiguration_Output;
            }
            if (requestCustomOutputConfiguration_customOutputConfiguration_Output != null)
            {
                request.CustomOutputConfiguration.Output = requestCustomOutputConfiguration_customOutputConfiguration_Output;
                requestCustomOutputConfigurationIsNull = false;
            }
            Amazon.MediaTailor.RuntimeType requestCustomOutputConfiguration_customOutputConfiguration_Runtime = null;
            if (cmdletContext.CustomOutputConfiguration_Runtime != null)
            {
                requestCustomOutputConfiguration_customOutputConfiguration_Runtime = cmdletContext.CustomOutputConfiguration_Runtime;
            }
            if (requestCustomOutputConfiguration_customOutputConfiguration_Runtime != null)
            {
                request.CustomOutputConfiguration.Runtime = requestCustomOutputConfiguration_customOutputConfiguration_Runtime;
                requestCustomOutputConfigurationIsNull = false;
            }
             // determine if request.CustomOutputConfiguration should be set to null
            if (requestCustomOutputConfigurationIsNull)
            {
                request.CustomOutputConfiguration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FunctionId != null)
            {
                request.FunctionId = cmdletContext.FunctionId;
            }
            if (cmdletContext.FunctionType != null)
            {
                request.FunctionType = cmdletContext.FunctionType;
            }
            
             // populate HttpRequestConfiguration
            var requestHttpRequestConfigurationIsNull = true;
            request.HttpRequestConfiguration = new Amazon.MediaTailor.Model.HttpRequestConfiguration();
            System.String requestHttpRequestConfiguration_httpRequestConfiguration_Body = null;
            if (cmdletContext.HttpRequestConfiguration_Body != null)
            {
                requestHttpRequestConfiguration_httpRequestConfiguration_Body = cmdletContext.HttpRequestConfiguration_Body;
            }
            if (requestHttpRequestConfiguration_httpRequestConfiguration_Body != null)
            {
                request.HttpRequestConfiguration.Body = requestHttpRequestConfiguration_httpRequestConfiguration_Body;
                requestHttpRequestConfigurationIsNull = false;
            }
            Dictionary<System.String, System.String> requestHttpRequestConfiguration_httpRequestConfiguration_Header = null;
            if (cmdletContext.HttpRequestConfiguration_Header != null)
            {
                requestHttpRequestConfiguration_httpRequestConfiguration_Header = cmdletContext.HttpRequestConfiguration_Header;
            }
            if (requestHttpRequestConfiguration_httpRequestConfiguration_Header != null)
            {
                request.HttpRequestConfiguration.Headers = requestHttpRequestConfiguration_httpRequestConfiguration_Header;
                requestHttpRequestConfigurationIsNull = false;
            }
            Amazon.MediaTailor.MethodType requestHttpRequestConfiguration_httpRequestConfiguration_MethodType = null;
            if (cmdletContext.HttpRequestConfiguration_MethodType != null)
            {
                requestHttpRequestConfiguration_httpRequestConfiguration_MethodType = cmdletContext.HttpRequestConfiguration_MethodType;
            }
            if (requestHttpRequestConfiguration_httpRequestConfiguration_MethodType != null)
            {
                request.HttpRequestConfiguration.MethodType = requestHttpRequestConfiguration_httpRequestConfiguration_MethodType;
                requestHttpRequestConfigurationIsNull = false;
            }
            Dictionary<System.String, System.String> requestHttpRequestConfiguration_httpRequestConfiguration_Output = null;
            if (cmdletContext.HttpRequestConfiguration_Output != null)
            {
                requestHttpRequestConfiguration_httpRequestConfiguration_Output = cmdletContext.HttpRequestConfiguration_Output;
            }
            if (requestHttpRequestConfiguration_httpRequestConfiguration_Output != null)
            {
                request.HttpRequestConfiguration.Output = requestHttpRequestConfiguration_httpRequestConfiguration_Output;
                requestHttpRequestConfigurationIsNull = false;
            }
            System.Int32? requestHttpRequestConfiguration_httpRequestConfiguration_RequestTimeoutMillisecond = null;
            if (cmdletContext.HttpRequestConfiguration_RequestTimeoutMillisecond != null)
            {
                requestHttpRequestConfiguration_httpRequestConfiguration_RequestTimeoutMillisecond = cmdletContext.HttpRequestConfiguration_RequestTimeoutMillisecond.Value;
            }
            if (requestHttpRequestConfiguration_httpRequestConfiguration_RequestTimeoutMillisecond != null)
            {
                request.HttpRequestConfiguration.RequestTimeoutMilliseconds = requestHttpRequestConfiguration_httpRequestConfiguration_RequestTimeoutMillisecond.Value;
                requestHttpRequestConfigurationIsNull = false;
            }
            Amazon.MediaTailor.RuntimeType requestHttpRequestConfiguration_httpRequestConfiguration_Runtime = null;
            if (cmdletContext.HttpRequestConfiguration_Runtime != null)
            {
                requestHttpRequestConfiguration_httpRequestConfiguration_Runtime = cmdletContext.HttpRequestConfiguration_Runtime;
            }
            if (requestHttpRequestConfiguration_httpRequestConfiguration_Runtime != null)
            {
                request.HttpRequestConfiguration.Runtime = requestHttpRequestConfiguration_httpRequestConfiguration_Runtime;
                requestHttpRequestConfigurationIsNull = false;
            }
            System.String requestHttpRequestConfiguration_httpRequestConfiguration_Url = null;
            if (cmdletContext.HttpRequestConfiguration_Url != null)
            {
                requestHttpRequestConfiguration_httpRequestConfiguration_Url = cmdletContext.HttpRequestConfiguration_Url;
            }
            if (requestHttpRequestConfiguration_httpRequestConfiguration_Url != null)
            {
                request.HttpRequestConfiguration.Url = requestHttpRequestConfiguration_httpRequestConfiguration_Url;
                requestHttpRequestConfigurationIsNull = false;
            }
             // determine if request.HttpRequestConfiguration should be set to null
            if (requestHttpRequestConfigurationIsNull)
            {
                request.HttpRequestConfiguration = null;
            }
            
             // populate SequentialExecutorConfiguration
            var requestSequentialExecutorConfigurationIsNull = true;
            request.SequentialExecutorConfiguration = new Amazon.MediaTailor.Model.SequentialExecutorConfiguration();
            List<Amazon.MediaTailor.Model.FunctionRef> requestSequentialExecutorConfiguration_sequentialExecutorConfiguration_FunctionList = null;
            if (cmdletContext.SequentialExecutorConfiguration_FunctionList != null)
            {
                requestSequentialExecutorConfiguration_sequentialExecutorConfiguration_FunctionList = cmdletContext.SequentialExecutorConfiguration_FunctionList;
            }
            if (requestSequentialExecutorConfiguration_sequentialExecutorConfiguration_FunctionList != null)
            {
                request.SequentialExecutorConfiguration.FunctionList = requestSequentialExecutorConfiguration_sequentialExecutorConfiguration_FunctionList;
                requestSequentialExecutorConfigurationIsNull = false;
            }
            Dictionary<System.String, System.String> requestSequentialExecutorConfiguration_sequentialExecutorConfiguration_Output = null;
            if (cmdletContext.SequentialExecutorConfiguration_Output != null)
            {
                requestSequentialExecutorConfiguration_sequentialExecutorConfiguration_Output = cmdletContext.SequentialExecutorConfiguration_Output;
            }
            if (requestSequentialExecutorConfiguration_sequentialExecutorConfiguration_Output != null)
            {
                request.SequentialExecutorConfiguration.Output = requestSequentialExecutorConfiguration_sequentialExecutorConfiguration_Output;
                requestSequentialExecutorConfigurationIsNull = false;
            }
            Amazon.MediaTailor.RuntimeType requestSequentialExecutorConfiguration_sequentialExecutorConfiguration_Runtime = null;
            if (cmdletContext.SequentialExecutorConfiguration_Runtime != null)
            {
                requestSequentialExecutorConfiguration_sequentialExecutorConfiguration_Runtime = cmdletContext.SequentialExecutorConfiguration_Runtime;
            }
            if (requestSequentialExecutorConfiguration_sequentialExecutorConfiguration_Runtime != null)
            {
                request.SequentialExecutorConfiguration.Runtime = requestSequentialExecutorConfiguration_sequentialExecutorConfiguration_Runtime;
                requestSequentialExecutorConfigurationIsNull = false;
            }
            System.Int32? requestSequentialExecutorConfiguration_sequentialExecutorConfiguration_TimeoutMillisecond = null;
            if (cmdletContext.SequentialExecutorConfiguration_TimeoutMillisecond != null)
            {
                requestSequentialExecutorConfiguration_sequentialExecutorConfiguration_TimeoutMillisecond = cmdletContext.SequentialExecutorConfiguration_TimeoutMillisecond.Value;
            }
            if (requestSequentialExecutorConfiguration_sequentialExecutorConfiguration_TimeoutMillisecond != null)
            {
                request.SequentialExecutorConfiguration.TimeoutMilliseconds = requestSequentialExecutorConfiguration_sequentialExecutorConfiguration_TimeoutMillisecond.Value;
                requestSequentialExecutorConfigurationIsNull = false;
            }
             // determine if request.SequentialExecutorConfiguration should be set to null
            if (requestSequentialExecutorConfigurationIsNull)
            {
                request.SequentialExecutorConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.MediaTailor.Model.PutFunctionResponse CallAWSServiceOperation(IAmazonMediaTailor client, Amazon.MediaTailor.Model.PutFunctionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaTailor", "PutFunction");
            try
            {
                return client.PutFunctionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public Dictionary<System.String, System.String> CustomOutputConfiguration_Output { get; set; }
            public Amazon.MediaTailor.RuntimeType CustomOutputConfiguration_Runtime { get; set; }
            public System.String Description { get; set; }
            public System.String FunctionId { get; set; }
            public Amazon.MediaTailor.FunctionType FunctionType { get; set; }
            public System.String HttpRequestConfiguration_Body { get; set; }
            public Dictionary<System.String, System.String> HttpRequestConfiguration_Header { get; set; }
            public Amazon.MediaTailor.MethodType HttpRequestConfiguration_MethodType { get; set; }
            public Dictionary<System.String, System.String> HttpRequestConfiguration_Output { get; set; }
            public System.Int32? HttpRequestConfiguration_RequestTimeoutMillisecond { get; set; }
            public Amazon.MediaTailor.RuntimeType HttpRequestConfiguration_Runtime { get; set; }
            public System.String HttpRequestConfiguration_Url { get; set; }
            public List<Amazon.MediaTailor.Model.FunctionRef> SequentialExecutorConfiguration_FunctionList { get; set; }
            public Dictionary<System.String, System.String> SequentialExecutorConfiguration_Output { get; set; }
            public Amazon.MediaTailor.RuntimeType SequentialExecutorConfiguration_Runtime { get; set; }
            public System.Int32? SequentialExecutorConfiguration_TimeoutMillisecond { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.MediaTailor.Model.PutFunctionResponse, WriteEMTFunctionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
