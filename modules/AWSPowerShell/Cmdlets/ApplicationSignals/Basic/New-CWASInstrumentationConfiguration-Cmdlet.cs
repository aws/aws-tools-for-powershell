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
using Amazon.ApplicationSignals;
using Amazon.ApplicationSignals.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWAS
{
    /// <summary>
    /// Creates a dynamic instrumentation configuration for a specific code or endpoint location
    /// within a service and environment. Configurations are immutable after creation.
    /// 
    ///  
    /// <para>
    /// For <c>BREAKPOINT</c> type configurations, they expire after 24 hours unless a shorter
    /// expiration is provided. For <c>PROBE</c> type configurations, they persist until explicitly
    /// deleted; an expiration cannot be set for <c>PROBE</c> configurations.
    /// </para><para>
    /// If a configuration already exists for the same service, environment, signal type,
    /// and location, this operation returns a conflict instead of overwriting it. Use attribute
    /// filters and capture settings to control where the instrumentation runs and which data
    /// is collected.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CWASInstrumentationConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApplicationSignals.Model.CreateInstrumentationConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Application Signals CreateInstrumentationConfiguration API operation.", Operation = new[] {"CreateInstrumentationConfiguration"}, SelectReturnType = typeof(Amazon.ApplicationSignals.Model.CreateInstrumentationConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ApplicationSignals.Model.CreateInstrumentationConfigurationResponse",
        "This cmdlet returns an Amazon.ApplicationSignals.Model.CreateInstrumentationConfigurationResponse object containing multiple properties."
    )]
    public partial class NewCWASInstrumentationConfigurationCmdlet : AmazonApplicationSignalsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AttributeFilter
        /// <summary>
        /// <para>
        /// <para>Client-side filters that target specific instances. Each object in the array is AND-matched
        /// on its keys, and multiple objects are OR-matched to decide where to apply the instrumentation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AttributeFilters")]
        public System.Collections.Hashtable[] AttributeFilter { get; set; }
        #endregion
        
        #region Parameter CaptureConfiguration_CodeCapture_CaptureArgument
        /// <summary>
        /// <para>
        /// <para>The function arguments to capture. Omit to capture defaults, use an empty list to
        /// capture none, use <c>["*"]</c> to capture all arguments, or specify argument names
        /// to capture selectively (up to 10 entries).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CaptureConfiguration_CodeCapture_CaptureArguments")]
        public System.String[] CaptureConfiguration_CodeCapture_CaptureArgument { get; set; }
        #endregion
        
        #region Parameter CaptureConfiguration_CodeCapture_CaptureLocal
        /// <summary>
        /// <para>
        /// <para>The local variables to capture by name. Omit or pass an empty list to capture none.
        /// You can specify up to 20 names.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CaptureConfiguration_CodeCapture_CaptureLocals")]
        public System.String[] CaptureConfiguration_CodeCapture_CaptureLocal { get; set; }
        #endregion
        
        #region Parameter CaptureConfiguration_CodeCapture_CaptureReturn
        /// <summary>
        /// <para>
        /// <para>Whether to capture the return value. Defaults to false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CaptureConfiguration_CodeCapture_CaptureReturn { get; set; }
        #endregion
        
        #region Parameter CaptureConfiguration_CodeCapture_CaptureStackTrace
        /// <summary>
        /// <para>
        /// <para>Whether to capture a stack trace when the instrumentation point is hit. Defaults to
        /// true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CaptureConfiguration_CodeCapture_CaptureStackTrace { get; set; }
        #endregion
        
        #region Parameter Location_CodeLocation_ClassName
        /// <summary>
        /// <para>
        /// <para>The class or type name that contains the method. This is required for Java and optional
        /// for Python module-level functions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Location_CodeLocation_ClassName { get; set; }
        #endregion
        
        #region Parameter Location_CodeLocation_CodeUnit
        /// <summary>
        /// <para>
        /// <para>The package, module, or namespace that contains the target code, for example <c>com.amazon.payment</c>
        /// or <c>payment_service</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Location_CodeLocation_CodeUnit { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional short description (up to 50 characters) that explains the purpose of this
        /// instrumentation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Environment
        /// <summary>
        /// <para>
        /// <para>The environment that the service is running in, such as <c>eks:cluster-prod/namespace</c>
        /// or <c>ec2:production</c>.</para>
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
        public System.String Environment { get; set; }
        #endregion
        
        #region Parameter ExpiresAt
        /// <summary>
        /// <para>
        /// <para>For BREAKPOINT: optional, defaults to 24 hours, must be between 5 min and 24 hours.
        /// For PROBE: not supported. PROBE configurations are permanent and persist until explicitly
        /// deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ExpiresAt { get; set; }
        #endregion
        
        #region Parameter Location_CodeLocation_FilePath
        /// <summary>
        /// <para>
        /// <para>The source file path relative to the project or source root, such as <c>src/payment/PaymentProcessor.java</c>
        /// or <c>src/payment/PaymentProcessor.py</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Location_CodeLocation_FilePath { get; set; }
        #endregion
        
        #region Parameter InstrumentationType
        /// <summary>
        /// <para>
        /// <para>Type of instrumentation: BREAKPOINT (temporary) or PROBE (permanent)</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ApplicationSignals.InstrumentationType")]
        public Amazon.ApplicationSignals.InstrumentationType InstrumentationType { get; set; }
        #endregion
        
        #region Parameter Location_CodeLocation_Language
        /// <summary>
        /// <para>
        /// <para>The programming language for this instrumentation point, such as Java, Python, or
        /// JavaScript.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApplicationSignals.ProgrammingLanguage")]
        public Amazon.ApplicationSignals.ProgrammingLanguage Location_CodeLocation_Language { get; set; }
        #endregion
        
        #region Parameter Location_CodeLocation_LineNumber
        /// <summary>
        /// <para>
        /// <para>The line number to instrument. Provide this to disambiguate overloaded methods and
        /// to target a specific line when needed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Location_CodeLocation_LineNumber { get; set; }
        #endregion
        
        #region Parameter CaptureConfiguration_CodeCapture_CaptureLimits_MaxCollectionDepth
        /// <summary>
        /// <para>
        /// <para>The maximum nesting depth to traverse inside collections. Defaults to 3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? CaptureConfiguration_CodeCapture_CaptureLimits_MaxCollectionDepth { get; set; }
        #endregion
        
        #region Parameter CaptureConfiguration_CodeCapture_CaptureLimits_MaxCollectionWidth
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to capture from any collection to prevent large payloads.
        /// Defaults to 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? CaptureConfiguration_CodeCapture_CaptureLimits_MaxCollectionWidth { get; set; }
        #endregion
        
        #region Parameter CaptureConfiguration_CodeCapture_CaptureLimits_MaxFieldsPerObject
        /// <summary>
        /// <para>
        /// <para>The maximum number of fields to capture for any object. Defaults to 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? CaptureConfiguration_CodeCapture_CaptureLimits_MaxFieldsPerObject { get; set; }
        #endregion
        
        #region Parameter CaptureConfiguration_CodeCapture_CaptureLimits_MaxHit
        /// <summary>
        /// <para>
        /// <para>The maximum number of times the instrumentation point can be hit before it is automatically
        /// disabled. Defaults to 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CaptureConfiguration_CodeCapture_CaptureLimits_MaxHits")]
        public System.Int32? CaptureConfiguration_CodeCapture_CaptureLimits_MaxHit { get; set; }
        #endregion
        
        #region Parameter CaptureConfiguration_CodeCapture_CaptureLimits_MaxObjectDepth
        /// <summary>
        /// <para>
        /// <para>The maximum depth for nested object traversal when capturing structured data. Defaults
        /// to 3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? CaptureConfiguration_CodeCapture_CaptureLimits_MaxObjectDepth { get; set; }
        #endregion
        
        #region Parameter CaptureConfiguration_CodeCapture_CaptureLimits_MaxStackFrame
        /// <summary>
        /// <para>
        /// <para>The maximum number of stack frames to capture in stack traces. Defaults to 2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CaptureConfiguration_CodeCapture_CaptureLimits_MaxStackFrames")]
        public System.Int32? CaptureConfiguration_CodeCapture_CaptureLimits_MaxStackFrame { get; set; }
        #endregion
        
        #region Parameter CaptureConfiguration_CodeCapture_CaptureLimits_MaxStackTraceSize
        /// <summary>
        /// <para>
        /// <para>The maximum total size, in bytes, of a captured stack trace. Defaults to 1000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? CaptureConfiguration_CodeCapture_CaptureLimits_MaxStackTraceSize { get; set; }
        #endregion
        
        #region Parameter CaptureConfiguration_CodeCapture_CaptureLimits_MaxStringLength
        /// <summary>
        /// <para>
        /// <para>The maximum length of captured string values in characters. Strings longer than this
        /// are truncated. Defaults to 128.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? CaptureConfiguration_CodeCapture_CaptureLimits_MaxStringLength { get; set; }
        #endregion
        
        #region Parameter Location_CodeLocation_MethodName
        /// <summary>
        /// <para>
        /// <para>The method or function name to instrument, such as <c>validateCreditCard</c> or <c>__init__</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Location_CodeLocation_MethodName { get; set; }
        #endregion
        
        #region Parameter Service
        /// <summary>
        /// <para>
        /// <para>The name of the service to instrument. This should match the <c>service.name</c> resource
        /// attribute reported by the application.</para>
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
        public System.String Service { get; set; }
        #endregion
        
        #region Parameter SignalType
        /// <summary>
        /// <para>
        /// <para>The telemetry signal type to emit for this instrumentation. The supported value is
        /// <c>SNAPSHOT</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ApplicationSignals.DynamicInstrumentationSignalType")]
        public Amazon.ApplicationSignals.DynamicInstrumentationSignalType SignalType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional list of key-value pairs to associate with the instrumentation configuration.
        /// Tags can help you organize and categorize your resources.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ApplicationSignals.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationSignals.Model.CreateInstrumentationConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ApplicationSignals.Model.CreateInstrumentationConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWASInstrumentationConfiguration (CreateInstrumentationConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationSignals.Model.CreateInstrumentationConfigurationResponse, NewCWASInstrumentationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AttributeFilter != null)
            {
                context.AttributeFilter = new List<Dictionary<System.String, System.String>>();
                foreach (var hashTable in this.AttributeFilter)
                {
                    var d = new Dictionary<System.String, System.String>();
                    foreach (var hashKey in hashTable.Keys)
                    {
                        d.Add((String)hashKey, (String)(hashTable[hashKey]));
                    }
                    context.AttributeFilter.Add(d);
                }
            }
            if (this.CaptureConfiguration_CodeCapture_CaptureArgument != null)
            {
                context.CaptureConfiguration_CodeCapture_CaptureArgument = new List<System.String>(this.CaptureConfiguration_CodeCapture_CaptureArgument);
            }
            context.CaptureConfiguration_CodeCapture_CaptureLimits_MaxCollectionDepth = this.CaptureConfiguration_CodeCapture_CaptureLimits_MaxCollectionDepth;
            context.CaptureConfiguration_CodeCapture_CaptureLimits_MaxCollectionWidth = this.CaptureConfiguration_CodeCapture_CaptureLimits_MaxCollectionWidth;
            context.CaptureConfiguration_CodeCapture_CaptureLimits_MaxFieldsPerObject = this.CaptureConfiguration_CodeCapture_CaptureLimits_MaxFieldsPerObject;
            context.CaptureConfiguration_CodeCapture_CaptureLimits_MaxHit = this.CaptureConfiguration_CodeCapture_CaptureLimits_MaxHit;
            context.CaptureConfiguration_CodeCapture_CaptureLimits_MaxObjectDepth = this.CaptureConfiguration_CodeCapture_CaptureLimits_MaxObjectDepth;
            context.CaptureConfiguration_CodeCapture_CaptureLimits_MaxStackFrame = this.CaptureConfiguration_CodeCapture_CaptureLimits_MaxStackFrame;
            context.CaptureConfiguration_CodeCapture_CaptureLimits_MaxStackTraceSize = this.CaptureConfiguration_CodeCapture_CaptureLimits_MaxStackTraceSize;
            context.CaptureConfiguration_CodeCapture_CaptureLimits_MaxStringLength = this.CaptureConfiguration_CodeCapture_CaptureLimits_MaxStringLength;
            if (this.CaptureConfiguration_CodeCapture_CaptureLocal != null)
            {
                context.CaptureConfiguration_CodeCapture_CaptureLocal = new List<System.String>(this.CaptureConfiguration_CodeCapture_CaptureLocal);
            }
            context.CaptureConfiguration_CodeCapture_CaptureReturn = this.CaptureConfiguration_CodeCapture_CaptureReturn;
            context.CaptureConfiguration_CodeCapture_CaptureStackTrace = this.CaptureConfiguration_CodeCapture_CaptureStackTrace;
            context.Description = this.Description;
            context.Environment = this.Environment;
            #if MODULAR
            if (this.Environment == null && ParameterWasBound(nameof(this.Environment)))
            {
                WriteWarning("You are passing $null as a value for parameter Environment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExpiresAt = this.ExpiresAt;
            context.InstrumentationType = this.InstrumentationType;
            #if MODULAR
            if (this.InstrumentationType == null && ParameterWasBound(nameof(this.InstrumentationType)))
            {
                WriteWarning("You are passing $null as a value for parameter InstrumentationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Location_CodeLocation_ClassName = this.Location_CodeLocation_ClassName;
            context.Location_CodeLocation_CodeUnit = this.Location_CodeLocation_CodeUnit;
            context.Location_CodeLocation_FilePath = this.Location_CodeLocation_FilePath;
            context.Location_CodeLocation_Language = this.Location_CodeLocation_Language;
            context.Location_CodeLocation_LineNumber = this.Location_CodeLocation_LineNumber;
            context.Location_CodeLocation_MethodName = this.Location_CodeLocation_MethodName;
            context.Service = this.Service;
            #if MODULAR
            if (this.Service == null && ParameterWasBound(nameof(this.Service)))
            {
                WriteWarning("You are passing $null as a value for parameter Service which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SignalType = this.SignalType;
            #if MODULAR
            if (this.SignalType == null && ParameterWasBound(nameof(this.SignalType)))
            {
                WriteWarning("You are passing $null as a value for parameter SignalType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ApplicationSignals.Model.Tag>(this.Tag);
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
            var request = new Amazon.ApplicationSignals.Model.CreateInstrumentationConfigurationRequest();
            
            if (cmdletContext.AttributeFilter != null)
            {
                request.AttributeFilters = cmdletContext.AttributeFilter;
            }
            
             // populate CaptureConfiguration
            var requestCaptureConfigurationIsNull = true;
            request.CaptureConfiguration = new Amazon.ApplicationSignals.Model.CaptureConfiguration();
            Amazon.ApplicationSignals.Model.CodeCaptureConfiguration requestCaptureConfiguration_captureConfiguration_CodeCapture = null;
            
             // populate CodeCapture
            var requestCaptureConfiguration_captureConfiguration_CodeCaptureIsNull = true;
            requestCaptureConfiguration_captureConfiguration_CodeCapture = new Amazon.ApplicationSignals.Model.CodeCaptureConfiguration();
            List<System.String> requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureArgument = null;
            if (cmdletContext.CaptureConfiguration_CodeCapture_CaptureArgument != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureArgument = cmdletContext.CaptureConfiguration_CodeCapture_CaptureArgument;
            }
            if (requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureArgument != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture.CaptureArguments = requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureArgument;
                requestCaptureConfiguration_captureConfiguration_CodeCaptureIsNull = false;
            }
            List<System.String> requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLocal = null;
            if (cmdletContext.CaptureConfiguration_CodeCapture_CaptureLocal != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLocal = cmdletContext.CaptureConfiguration_CodeCapture_CaptureLocal;
            }
            if (requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLocal != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture.CaptureLocals = requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLocal;
                requestCaptureConfiguration_captureConfiguration_CodeCaptureIsNull = false;
            }
            System.Boolean? requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureReturn = null;
            if (cmdletContext.CaptureConfiguration_CodeCapture_CaptureReturn != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureReturn = cmdletContext.CaptureConfiguration_CodeCapture_CaptureReturn.Value;
            }
            if (requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureReturn != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture.CaptureReturn = requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureReturn.Value;
                requestCaptureConfiguration_captureConfiguration_CodeCaptureIsNull = false;
            }
            System.Boolean? requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureStackTrace = null;
            if (cmdletContext.CaptureConfiguration_CodeCapture_CaptureStackTrace != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureStackTrace = cmdletContext.CaptureConfiguration_CodeCapture_CaptureStackTrace.Value;
            }
            if (requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureStackTrace != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture.CaptureStackTrace = requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureStackTrace.Value;
                requestCaptureConfiguration_captureConfiguration_CodeCaptureIsNull = false;
            }
            Amazon.ApplicationSignals.Model.CaptureLimitsConfig requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits = null;
            
             // populate CaptureLimits
            var requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimitsIsNull = true;
            requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits = new Amazon.ApplicationSignals.Model.CaptureLimitsConfig();
            System.Int32? requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxCollectionDepth = null;
            if (cmdletContext.CaptureConfiguration_CodeCapture_CaptureLimits_MaxCollectionDepth != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxCollectionDepth = cmdletContext.CaptureConfiguration_CodeCapture_CaptureLimits_MaxCollectionDepth.Value;
            }
            if (requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxCollectionDepth != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits.MaxCollectionDepth = requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxCollectionDepth.Value;
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimitsIsNull = false;
            }
            System.Int32? requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxCollectionWidth = null;
            if (cmdletContext.CaptureConfiguration_CodeCapture_CaptureLimits_MaxCollectionWidth != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxCollectionWidth = cmdletContext.CaptureConfiguration_CodeCapture_CaptureLimits_MaxCollectionWidth.Value;
            }
            if (requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxCollectionWidth != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits.MaxCollectionWidth = requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxCollectionWidth.Value;
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimitsIsNull = false;
            }
            System.Int32? requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxFieldsPerObject = null;
            if (cmdletContext.CaptureConfiguration_CodeCapture_CaptureLimits_MaxFieldsPerObject != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxFieldsPerObject = cmdletContext.CaptureConfiguration_CodeCapture_CaptureLimits_MaxFieldsPerObject.Value;
            }
            if (requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxFieldsPerObject != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits.MaxFieldsPerObject = requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxFieldsPerObject.Value;
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimitsIsNull = false;
            }
            System.Int32? requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxHit = null;
            if (cmdletContext.CaptureConfiguration_CodeCapture_CaptureLimits_MaxHit != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxHit = cmdletContext.CaptureConfiguration_CodeCapture_CaptureLimits_MaxHit.Value;
            }
            if (requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxHit != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits.MaxHits = requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxHit.Value;
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimitsIsNull = false;
            }
            System.Int32? requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxObjectDepth = null;
            if (cmdletContext.CaptureConfiguration_CodeCapture_CaptureLimits_MaxObjectDepth != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxObjectDepth = cmdletContext.CaptureConfiguration_CodeCapture_CaptureLimits_MaxObjectDepth.Value;
            }
            if (requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxObjectDepth != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits.MaxObjectDepth = requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxObjectDepth.Value;
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimitsIsNull = false;
            }
            System.Int32? requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxStackFrame = null;
            if (cmdletContext.CaptureConfiguration_CodeCapture_CaptureLimits_MaxStackFrame != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxStackFrame = cmdletContext.CaptureConfiguration_CodeCapture_CaptureLimits_MaxStackFrame.Value;
            }
            if (requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxStackFrame != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits.MaxStackFrames = requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxStackFrame.Value;
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimitsIsNull = false;
            }
            System.Int32? requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxStackTraceSize = null;
            if (cmdletContext.CaptureConfiguration_CodeCapture_CaptureLimits_MaxStackTraceSize != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxStackTraceSize = cmdletContext.CaptureConfiguration_CodeCapture_CaptureLimits_MaxStackTraceSize.Value;
            }
            if (requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxStackTraceSize != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits.MaxStackTraceSize = requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxStackTraceSize.Value;
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimitsIsNull = false;
            }
            System.Int32? requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxStringLength = null;
            if (cmdletContext.CaptureConfiguration_CodeCapture_CaptureLimits_MaxStringLength != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxStringLength = cmdletContext.CaptureConfiguration_CodeCapture_CaptureLimits_MaxStringLength.Value;
            }
            if (requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxStringLength != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits.MaxStringLength = requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits_captureConfiguration_CodeCapture_CaptureLimits_MaxStringLength.Value;
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimitsIsNull = false;
            }
             // determine if requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits should be set to null
            if (requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimitsIsNull)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits = null;
            }
            if (requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits != null)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture.CaptureLimits = requestCaptureConfiguration_captureConfiguration_CodeCapture_captureConfiguration_CodeCapture_CaptureLimits;
                requestCaptureConfiguration_captureConfiguration_CodeCaptureIsNull = false;
            }
             // determine if requestCaptureConfiguration_captureConfiguration_CodeCapture should be set to null
            if (requestCaptureConfiguration_captureConfiguration_CodeCaptureIsNull)
            {
                requestCaptureConfiguration_captureConfiguration_CodeCapture = null;
            }
            if (requestCaptureConfiguration_captureConfiguration_CodeCapture != null)
            {
                request.CaptureConfiguration.CodeCapture = requestCaptureConfiguration_captureConfiguration_CodeCapture;
                requestCaptureConfigurationIsNull = false;
            }
             // determine if request.CaptureConfiguration should be set to null
            if (requestCaptureConfigurationIsNull)
            {
                request.CaptureConfiguration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Environment != null)
            {
                request.Environment = cmdletContext.Environment;
            }
            if (cmdletContext.ExpiresAt != null)
            {
                request.ExpiresAt = cmdletContext.ExpiresAt.Value;
            }
            if (cmdletContext.InstrumentationType != null)
            {
                request.InstrumentationType = cmdletContext.InstrumentationType;
            }
            
             // populate Location
            var requestLocationIsNull = true;
            request.Location = new Amazon.ApplicationSignals.Model.Location();
            Amazon.ApplicationSignals.Model.CodeLocation requestLocation_location_CodeLocation = null;
            
             // populate CodeLocation
            var requestLocation_location_CodeLocationIsNull = true;
            requestLocation_location_CodeLocation = new Amazon.ApplicationSignals.Model.CodeLocation();
            System.String requestLocation_location_CodeLocation_location_CodeLocation_ClassName = null;
            if (cmdletContext.Location_CodeLocation_ClassName != null)
            {
                requestLocation_location_CodeLocation_location_CodeLocation_ClassName = cmdletContext.Location_CodeLocation_ClassName;
            }
            if (requestLocation_location_CodeLocation_location_CodeLocation_ClassName != null)
            {
                requestLocation_location_CodeLocation.ClassName = requestLocation_location_CodeLocation_location_CodeLocation_ClassName;
                requestLocation_location_CodeLocationIsNull = false;
            }
            System.String requestLocation_location_CodeLocation_location_CodeLocation_CodeUnit = null;
            if (cmdletContext.Location_CodeLocation_CodeUnit != null)
            {
                requestLocation_location_CodeLocation_location_CodeLocation_CodeUnit = cmdletContext.Location_CodeLocation_CodeUnit;
            }
            if (requestLocation_location_CodeLocation_location_CodeLocation_CodeUnit != null)
            {
                requestLocation_location_CodeLocation.CodeUnit = requestLocation_location_CodeLocation_location_CodeLocation_CodeUnit;
                requestLocation_location_CodeLocationIsNull = false;
            }
            System.String requestLocation_location_CodeLocation_location_CodeLocation_FilePath = null;
            if (cmdletContext.Location_CodeLocation_FilePath != null)
            {
                requestLocation_location_CodeLocation_location_CodeLocation_FilePath = cmdletContext.Location_CodeLocation_FilePath;
            }
            if (requestLocation_location_CodeLocation_location_CodeLocation_FilePath != null)
            {
                requestLocation_location_CodeLocation.FilePath = requestLocation_location_CodeLocation_location_CodeLocation_FilePath;
                requestLocation_location_CodeLocationIsNull = false;
            }
            Amazon.ApplicationSignals.ProgrammingLanguage requestLocation_location_CodeLocation_location_CodeLocation_Language = null;
            if (cmdletContext.Location_CodeLocation_Language != null)
            {
                requestLocation_location_CodeLocation_location_CodeLocation_Language = cmdletContext.Location_CodeLocation_Language;
            }
            if (requestLocation_location_CodeLocation_location_CodeLocation_Language != null)
            {
                requestLocation_location_CodeLocation.Language = requestLocation_location_CodeLocation_location_CodeLocation_Language;
                requestLocation_location_CodeLocationIsNull = false;
            }
            System.Int32? requestLocation_location_CodeLocation_location_CodeLocation_LineNumber = null;
            if (cmdletContext.Location_CodeLocation_LineNumber != null)
            {
                requestLocation_location_CodeLocation_location_CodeLocation_LineNumber = cmdletContext.Location_CodeLocation_LineNumber.Value;
            }
            if (requestLocation_location_CodeLocation_location_CodeLocation_LineNumber != null)
            {
                requestLocation_location_CodeLocation.LineNumber = requestLocation_location_CodeLocation_location_CodeLocation_LineNumber.Value;
                requestLocation_location_CodeLocationIsNull = false;
            }
            System.String requestLocation_location_CodeLocation_location_CodeLocation_MethodName = null;
            if (cmdletContext.Location_CodeLocation_MethodName != null)
            {
                requestLocation_location_CodeLocation_location_CodeLocation_MethodName = cmdletContext.Location_CodeLocation_MethodName;
            }
            if (requestLocation_location_CodeLocation_location_CodeLocation_MethodName != null)
            {
                requestLocation_location_CodeLocation.MethodName = requestLocation_location_CodeLocation_location_CodeLocation_MethodName;
                requestLocation_location_CodeLocationIsNull = false;
            }
             // determine if requestLocation_location_CodeLocation should be set to null
            if (requestLocation_location_CodeLocationIsNull)
            {
                requestLocation_location_CodeLocation = null;
            }
            if (requestLocation_location_CodeLocation != null)
            {
                request.Location.CodeLocation = requestLocation_location_CodeLocation;
                requestLocationIsNull = false;
            }
             // determine if request.Location should be set to null
            if (requestLocationIsNull)
            {
                request.Location = null;
            }
            if (cmdletContext.Service != null)
            {
                request.Service = cmdletContext.Service;
            }
            if (cmdletContext.SignalType != null)
            {
                request.SignalType = cmdletContext.SignalType;
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
        
        private Amazon.ApplicationSignals.Model.CreateInstrumentationConfigurationResponse CallAWSServiceOperation(IAmazonApplicationSignals client, Amazon.ApplicationSignals.Model.CreateInstrumentationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Application Signals", "CreateInstrumentationConfiguration");
            try
            {
                return client.CreateInstrumentationConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Dictionary<System.String, System.String>> AttributeFilter { get; set; }
            public List<System.String> CaptureConfiguration_CodeCapture_CaptureArgument { get; set; }
            public System.Int32? CaptureConfiguration_CodeCapture_CaptureLimits_MaxCollectionDepth { get; set; }
            public System.Int32? CaptureConfiguration_CodeCapture_CaptureLimits_MaxCollectionWidth { get; set; }
            public System.Int32? CaptureConfiguration_CodeCapture_CaptureLimits_MaxFieldsPerObject { get; set; }
            public System.Int32? CaptureConfiguration_CodeCapture_CaptureLimits_MaxHit { get; set; }
            public System.Int32? CaptureConfiguration_CodeCapture_CaptureLimits_MaxObjectDepth { get; set; }
            public System.Int32? CaptureConfiguration_CodeCapture_CaptureLimits_MaxStackFrame { get; set; }
            public System.Int32? CaptureConfiguration_CodeCapture_CaptureLimits_MaxStackTraceSize { get; set; }
            public System.Int32? CaptureConfiguration_CodeCapture_CaptureLimits_MaxStringLength { get; set; }
            public List<System.String> CaptureConfiguration_CodeCapture_CaptureLocal { get; set; }
            public System.Boolean? CaptureConfiguration_CodeCapture_CaptureReturn { get; set; }
            public System.Boolean? CaptureConfiguration_CodeCapture_CaptureStackTrace { get; set; }
            public System.String Description { get; set; }
            public System.String Environment { get; set; }
            public System.DateTime? ExpiresAt { get; set; }
            public Amazon.ApplicationSignals.InstrumentationType InstrumentationType { get; set; }
            public System.String Location_CodeLocation_ClassName { get; set; }
            public System.String Location_CodeLocation_CodeUnit { get; set; }
            public System.String Location_CodeLocation_FilePath { get; set; }
            public Amazon.ApplicationSignals.ProgrammingLanguage Location_CodeLocation_Language { get; set; }
            public System.Int32? Location_CodeLocation_LineNumber { get; set; }
            public System.String Location_CodeLocation_MethodName { get; set; }
            public System.String Service { get; set; }
            public Amazon.ApplicationSignals.DynamicInstrumentationSignalType SignalType { get; set; }
            public List<Amazon.ApplicationSignals.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ApplicationSignals.Model.CreateInstrumentationConfigurationResponse, NewCWASInstrumentationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
