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
    /// Retrieves the status history for a single instrumentation configuration during a specified
    /// time range. The response lists when the configuration was ACTIVE, READY, ERROR, or
    /// DISABLED.
    /// 
    ///  
    /// <para>
    /// If no status or time window is provided, the operation defaults to ACTIVE events from
    /// the last hour.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWASInstrumentationConfigurationStatus")]
    [OutputType("Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationStatusResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Application Signals GetInstrumentationConfigurationStatus API operation.", Operation = new[] {"GetInstrumentationConfigurationStatus"}, SelectReturnType = typeof(Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationStatusResponse))]
    [AWSCmdletOutput("Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationStatusResponse",
        "This cmdlet returns an Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationStatusResponse object containing multiple properties."
    )]
    public partial class GetCWASInstrumentationConfigurationStatusCmdlet : AmazonApplicationSignalsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LocationIdentifier_CodeLocation_ClassName
        /// <summary>
        /// <para>
        /// <para>The class or type name that contains the method. This is required for Java and optional
        /// for Python module-level functions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LocationIdentifier_CodeLocation_ClassName { get; set; }
        #endregion
        
        #region Parameter LocationIdentifier_CodeLocation_CodeUnit
        /// <summary>
        /// <para>
        /// <para>The package, module, or namespace that contains the target code, for example <c>com.amazon.payment</c>
        /// or <c>payment_service</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LocationIdentifier_CodeLocation_CodeUnit { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time range to retrieve status events for. <c>StartTime</c> and <c>EndTime</c>
        /// must both be provided together or both be omitted. When both are omitted, the time
        /// range defaults to the last hour.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter Environment
        /// <summary>
        /// <para>
        /// <para>Environment name for the instrumentation configuration.</para>
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
        
        #region Parameter LocationIdentifier_CodeLocation_FilePath
        /// <summary>
        /// <para>
        /// <para>The source file path relative to the project or source root, such as <c>src/payment/PaymentProcessor.java</c>
        /// or <c>src/payment/PaymentProcessor.py</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LocationIdentifier_CodeLocation_FilePath { get; set; }
        #endregion
        
        #region Parameter InstrumentationType
        /// <summary>
        /// <para>
        /// <para>Type of instrumentation configuration (BREAKPOINT or PROBE). Required to identify
        /// the configuration to retrieve.</para>
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
        
        #region Parameter LocationIdentifier_CodeLocation_Language
        /// <summary>
        /// <para>
        /// <para>The programming language for this instrumentation point, such as Java, Python, or
        /// JavaScript.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApplicationSignals.ProgrammingLanguage")]
        public Amazon.ApplicationSignals.ProgrammingLanguage LocationIdentifier_CodeLocation_Language { get; set; }
        #endregion
        
        #region Parameter LocationIdentifier_CodeLocation_LineNumber
        /// <summary>
        /// <para>
        /// <para>The line number to instrument. Provide this to disambiguate overloaded methods and
        /// to target a specific line when needed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LocationIdentifier_CodeLocation_LineNumber { get; set; }
        #endregion
        
        #region Parameter LocationIdentifier_LocationHash
        /// <summary>
        /// <para>
        /// <para>The pre-computed location hash (16-character hex string)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LocationIdentifier_LocationHash { get; set; }
        #endregion
        
        #region Parameter LocationIdentifier_CodeLocation_MethodName
        /// <summary>
        /// <para>
        /// <para>The method or function name to instrument, such as <c>validateCreditCard</c> or <c>__init__</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LocationIdentifier_CodeLocation_MethodName { get; set; }
        #endregion
        
        #region Parameter Service
        /// <summary>
        /// <para>
        /// <para>Service name for the instrumentation configuration.</para>
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
        /// <para>Signal type for the instrumentation configuration.</para>
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
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start of the time range to retrieve status events for. <c>StartTime</c> and <c>EndTime</c>
        /// must both be provided together or both be omitted. When both are omitted, the time
        /// range defaults to the last hour.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The single status to query for. If omitted, only <c>ACTIVE</c> status events are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApplicationSignals.InstrumentationConfigurationStatus")]
        public Amazon.ApplicationSignals.InstrumentationConfigurationStatus Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of status events to return in one call. The default is 60.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Use the token returned by a previous call to retrieve the next page of status events.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationStatusResponse).
        /// Specifying the name of a property of type Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationStatusResponse, GetCWASInstrumentationConfigurationStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            context.Environment = this.Environment;
            #if MODULAR
            if (this.Environment == null && ParameterWasBound(nameof(this.Environment)))
            {
                WriteWarning("You are passing $null as a value for parameter Environment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstrumentationType = this.InstrumentationType;
            #if MODULAR
            if (this.InstrumentationType == null && ParameterWasBound(nameof(this.InstrumentationType)))
            {
                WriteWarning("You are passing $null as a value for parameter InstrumentationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LocationIdentifier_CodeLocation_ClassName = this.LocationIdentifier_CodeLocation_ClassName;
            context.LocationIdentifier_CodeLocation_CodeUnit = this.LocationIdentifier_CodeLocation_CodeUnit;
            context.LocationIdentifier_CodeLocation_FilePath = this.LocationIdentifier_CodeLocation_FilePath;
            context.LocationIdentifier_CodeLocation_Language = this.LocationIdentifier_CodeLocation_Language;
            context.LocationIdentifier_CodeLocation_LineNumber = this.LocationIdentifier_CodeLocation_LineNumber;
            context.LocationIdentifier_CodeLocation_MethodName = this.LocationIdentifier_CodeLocation_MethodName;
            context.LocationIdentifier_LocationHash = this.LocationIdentifier_LocationHash;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
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
            context.StartTime = this.StartTime;
            context.Status = this.Status;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationStatusRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.Environment != null)
            {
                request.Environment = cmdletContext.Environment;
            }
            if (cmdletContext.InstrumentationType != null)
            {
                request.InstrumentationType = cmdletContext.InstrumentationType;
            }
            
             // populate LocationIdentifier
            var requestLocationIdentifierIsNull = true;
            request.LocationIdentifier = new Amazon.ApplicationSignals.Model.LocationIdentifier();
            System.String requestLocationIdentifier_locationIdentifier_LocationHash = null;
            if (cmdletContext.LocationIdentifier_LocationHash != null)
            {
                requestLocationIdentifier_locationIdentifier_LocationHash = cmdletContext.LocationIdentifier_LocationHash;
            }
            if (requestLocationIdentifier_locationIdentifier_LocationHash != null)
            {
                request.LocationIdentifier.LocationHash = requestLocationIdentifier_locationIdentifier_LocationHash;
                requestLocationIdentifierIsNull = false;
            }
            Amazon.ApplicationSignals.Model.CodeLocation requestLocationIdentifier_locationIdentifier_CodeLocation = null;
            
             // populate CodeLocation
            var requestLocationIdentifier_locationIdentifier_CodeLocationIsNull = true;
            requestLocationIdentifier_locationIdentifier_CodeLocation = new Amazon.ApplicationSignals.Model.CodeLocation();
            System.String requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_ClassName = null;
            if (cmdletContext.LocationIdentifier_CodeLocation_ClassName != null)
            {
                requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_ClassName = cmdletContext.LocationIdentifier_CodeLocation_ClassName;
            }
            if (requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_ClassName != null)
            {
                requestLocationIdentifier_locationIdentifier_CodeLocation.ClassName = requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_ClassName;
                requestLocationIdentifier_locationIdentifier_CodeLocationIsNull = false;
            }
            System.String requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_CodeUnit = null;
            if (cmdletContext.LocationIdentifier_CodeLocation_CodeUnit != null)
            {
                requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_CodeUnit = cmdletContext.LocationIdentifier_CodeLocation_CodeUnit;
            }
            if (requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_CodeUnit != null)
            {
                requestLocationIdentifier_locationIdentifier_CodeLocation.CodeUnit = requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_CodeUnit;
                requestLocationIdentifier_locationIdentifier_CodeLocationIsNull = false;
            }
            System.String requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_FilePath = null;
            if (cmdletContext.LocationIdentifier_CodeLocation_FilePath != null)
            {
                requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_FilePath = cmdletContext.LocationIdentifier_CodeLocation_FilePath;
            }
            if (requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_FilePath != null)
            {
                requestLocationIdentifier_locationIdentifier_CodeLocation.FilePath = requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_FilePath;
                requestLocationIdentifier_locationIdentifier_CodeLocationIsNull = false;
            }
            Amazon.ApplicationSignals.ProgrammingLanguage requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_Language = null;
            if (cmdletContext.LocationIdentifier_CodeLocation_Language != null)
            {
                requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_Language = cmdletContext.LocationIdentifier_CodeLocation_Language;
            }
            if (requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_Language != null)
            {
                requestLocationIdentifier_locationIdentifier_CodeLocation.Language = requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_Language;
                requestLocationIdentifier_locationIdentifier_CodeLocationIsNull = false;
            }
            System.Int32? requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_LineNumber = null;
            if (cmdletContext.LocationIdentifier_CodeLocation_LineNumber != null)
            {
                requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_LineNumber = cmdletContext.LocationIdentifier_CodeLocation_LineNumber.Value;
            }
            if (requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_LineNumber != null)
            {
                requestLocationIdentifier_locationIdentifier_CodeLocation.LineNumber = requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_LineNumber.Value;
                requestLocationIdentifier_locationIdentifier_CodeLocationIsNull = false;
            }
            System.String requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_MethodName = null;
            if (cmdletContext.LocationIdentifier_CodeLocation_MethodName != null)
            {
                requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_MethodName = cmdletContext.LocationIdentifier_CodeLocation_MethodName;
            }
            if (requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_MethodName != null)
            {
                requestLocationIdentifier_locationIdentifier_CodeLocation.MethodName = requestLocationIdentifier_locationIdentifier_CodeLocation_locationIdentifier_CodeLocation_MethodName;
                requestLocationIdentifier_locationIdentifier_CodeLocationIsNull = false;
            }
             // determine if requestLocationIdentifier_locationIdentifier_CodeLocation should be set to null
            if (requestLocationIdentifier_locationIdentifier_CodeLocationIsNull)
            {
                requestLocationIdentifier_locationIdentifier_CodeLocation = null;
            }
            if (requestLocationIdentifier_locationIdentifier_CodeLocation != null)
            {
                request.LocationIdentifier.CodeLocation = requestLocationIdentifier_locationIdentifier_CodeLocation;
                requestLocationIdentifierIsNull = false;
            }
             // determine if request.LocationIdentifier should be set to null
            if (requestLocationIdentifierIsNull)
            {
                request.LocationIdentifier = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.Service != null)
            {
                request.Service = cmdletContext.Service;
            }
            if (cmdletContext.SignalType != null)
            {
                request.SignalType = cmdletContext.SignalType;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationStatusResponse CallAWSServiceOperation(IAmazonApplicationSignals client, Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Application Signals", "GetInstrumentationConfigurationStatus");
            try
            {
                return client.GetInstrumentationConfigurationStatusAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime { get; set; }
            public System.String Environment { get; set; }
            public Amazon.ApplicationSignals.InstrumentationType InstrumentationType { get; set; }
            public System.String LocationIdentifier_CodeLocation_ClassName { get; set; }
            public System.String LocationIdentifier_CodeLocation_CodeUnit { get; set; }
            public System.String LocationIdentifier_CodeLocation_FilePath { get; set; }
            public Amazon.ApplicationSignals.ProgrammingLanguage LocationIdentifier_CodeLocation_Language { get; set; }
            public System.Int32? LocationIdentifier_CodeLocation_LineNumber { get; set; }
            public System.String LocationIdentifier_CodeLocation_MethodName { get; set; }
            public System.String LocationIdentifier_LocationHash { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String Service { get; set; }
            public Amazon.ApplicationSignals.DynamicInstrumentationSignalType SignalType { get; set; }
            public System.DateTime? StartTime { get; set; }
            public Amazon.ApplicationSignals.InstrumentationConfigurationStatus Status { get; set; }
            public System.Func<Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationStatusResponse, GetCWASInstrumentationConfigurationStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
