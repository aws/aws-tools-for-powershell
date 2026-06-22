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
    /// Returns the details of a single instrumentation configuration identified by service,
    /// environment, signal type, and location. Use this to audit or display configuration
    /// details.
    /// </summary>
    [Cmdlet("Get", "CWASInstrumentationConfiguration")]
    [OutputType("Amazon.ApplicationSignals.Model.InstrumentationConfiguration")]
    [AWSCmdlet("Calls the Amazon CloudWatch Application Signals GetInstrumentationConfiguration API operation.", Operation = new[] {"GetInstrumentationConfiguration"}, SelectReturnType = typeof(Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ApplicationSignals.Model.InstrumentationConfiguration or Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationResponse",
        "This cmdlet returns an Amazon.ApplicationSignals.Model.InstrumentationConfiguration object.",
        "The service call response (type Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWASInstrumentationConfigurationCmdlet : AmazonApplicationSignalsClientCmdlet, IExecutor
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Configuration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Configuration";
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
                context.Select = CreateSelectDelegate<Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationResponse, GetCWASInstrumentationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationRequest();
            
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
            if (cmdletContext.Service != null)
            {
                request.Service = cmdletContext.Service;
            }
            if (cmdletContext.SignalType != null)
            {
                request.SignalType = cmdletContext.SignalType;
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
        
        private Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationResponse CallAWSServiceOperation(IAmazonApplicationSignals client, Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Application Signals", "GetInstrumentationConfiguration");
            try
            {
                return client.GetInstrumentationConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Environment { get; set; }
            public Amazon.ApplicationSignals.InstrumentationType InstrumentationType { get; set; }
            public System.String LocationIdentifier_CodeLocation_ClassName { get; set; }
            public System.String LocationIdentifier_CodeLocation_CodeUnit { get; set; }
            public System.String LocationIdentifier_CodeLocation_FilePath { get; set; }
            public Amazon.ApplicationSignals.ProgrammingLanguage LocationIdentifier_CodeLocation_Language { get; set; }
            public System.Int32? LocationIdentifier_CodeLocation_LineNumber { get; set; }
            public System.String LocationIdentifier_CodeLocation_MethodName { get; set; }
            public System.String LocationIdentifier_LocationHash { get; set; }
            public System.String Service { get; set; }
            public Amazon.ApplicationSignals.DynamicInstrumentationSignalType SignalType { get; set; }
            public System.Func<Amazon.ApplicationSignals.Model.GetInstrumentationConfigurationResponse, GetCWASInstrumentationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Configuration;
        }
        
    }
}
