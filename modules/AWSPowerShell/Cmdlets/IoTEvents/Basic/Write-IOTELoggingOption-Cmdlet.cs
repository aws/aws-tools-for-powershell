/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.IoTEvents;
using Amazon.IoTEvents.Model;

namespace Amazon.PowerShell.Cmdlets.IOTE
{
    /// <summary>
    /// Sets or updates the AWS IoT Events logging options.
    /// 
    ///  
    /// <para>
    /// If you update the value of any <code>loggingOptions</code> field, it takes up to one
    /// minute for the change to take effect. If you change the policy attached to the role
    /// you specified in the <code>roleArn</code> field (for example, to correct an invalid
    /// policy), it takes up to five minutes for that change to take effect.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "IOTELoggingOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT Events PutLoggingOptions API operation.", Operation = new[] {"PutLoggingOptions"}, SelectReturnType = typeof(Amazon.IoTEvents.Model.PutLoggingOptionsResponse))]
    [AWSCmdletOutput("None or Amazon.IoTEvents.Model.PutLoggingOptionsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoTEvents.Model.PutLoggingOptionsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteIOTELoggingOptionCmdlet : AmazonIoTEventsClientCmdlet, IExecutor
    {
        
        #region Parameter LoggingOptions_DetectorDebugOption
        /// <summary>
        /// <para>
        /// <para>Information that identifies those detector models and their detectors (instances)
        /// for which the logging level is given.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingOptions_DetectorDebugOptions")]
        public Amazon.IoTEvents.Model.DetectorDebugOption[] LoggingOptions_DetectorDebugOption { get; set; }
        #endregion
        
        #region Parameter LoggingOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>If TRUE, logging is enabled for AWS IoT Events.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? LoggingOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter LoggingOptions_Level
        /// <summary>
        /// <para>
        /// <para>The logging level.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTEvents.LoggingLevel")]
        public Amazon.IoTEvents.LoggingLevel LoggingOptions_Level { get; set; }
        #endregion
        
        #region Parameter LoggingOptions_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role that grants permission to AWS IoT Events to perform logging.</para>
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
        public System.String LoggingOptions_RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTEvents.Model.PutLoggingOptionsResponse).
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-IOTELoggingOption (PutLoggingOptions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTEvents.Model.PutLoggingOptionsResponse, WriteIOTELoggingOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.LoggingOptions_DetectorDebugOption != null)
            {
                context.LoggingOptions_DetectorDebugOption = new List<Amazon.IoTEvents.Model.DetectorDebugOption>(this.LoggingOptions_DetectorDebugOption);
            }
            context.LoggingOptions_Enabled = this.LoggingOptions_Enabled;
            #if MODULAR
            if (this.LoggingOptions_Enabled == null && ParameterWasBound(nameof(this.LoggingOptions_Enabled)))
            {
                WriteWarning("You are passing $null as a value for parameter LoggingOptions_Enabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoggingOptions_Level = this.LoggingOptions_Level;
            #if MODULAR
            if (this.LoggingOptions_Level == null && ParameterWasBound(nameof(this.LoggingOptions_Level)))
            {
                WriteWarning("You are passing $null as a value for parameter LoggingOptions_Level which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoggingOptions_RoleArn = this.LoggingOptions_RoleArn;
            #if MODULAR
            if (this.LoggingOptions_RoleArn == null && ParameterWasBound(nameof(this.LoggingOptions_RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LoggingOptions_RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTEvents.Model.PutLoggingOptionsRequest();
            
            
             // populate LoggingOptions
            var requestLoggingOptionsIsNull = true;
            request.LoggingOptions = new Amazon.IoTEvents.Model.LoggingOptions();
            List<Amazon.IoTEvents.Model.DetectorDebugOption> requestLoggingOptions_loggingOptions_DetectorDebugOption = null;
            if (cmdletContext.LoggingOptions_DetectorDebugOption != null)
            {
                requestLoggingOptions_loggingOptions_DetectorDebugOption = cmdletContext.LoggingOptions_DetectorDebugOption;
            }
            if (requestLoggingOptions_loggingOptions_DetectorDebugOption != null)
            {
                request.LoggingOptions.DetectorDebugOptions = requestLoggingOptions_loggingOptions_DetectorDebugOption;
                requestLoggingOptionsIsNull = false;
            }
            System.Boolean? requestLoggingOptions_loggingOptions_Enabled = null;
            if (cmdletContext.LoggingOptions_Enabled != null)
            {
                requestLoggingOptions_loggingOptions_Enabled = cmdletContext.LoggingOptions_Enabled.Value;
            }
            if (requestLoggingOptions_loggingOptions_Enabled != null)
            {
                request.LoggingOptions.Enabled = requestLoggingOptions_loggingOptions_Enabled.Value;
                requestLoggingOptionsIsNull = false;
            }
            Amazon.IoTEvents.LoggingLevel requestLoggingOptions_loggingOptions_Level = null;
            if (cmdletContext.LoggingOptions_Level != null)
            {
                requestLoggingOptions_loggingOptions_Level = cmdletContext.LoggingOptions_Level;
            }
            if (requestLoggingOptions_loggingOptions_Level != null)
            {
                request.LoggingOptions.Level = requestLoggingOptions_loggingOptions_Level;
                requestLoggingOptionsIsNull = false;
            }
            System.String requestLoggingOptions_loggingOptions_RoleArn = null;
            if (cmdletContext.LoggingOptions_RoleArn != null)
            {
                requestLoggingOptions_loggingOptions_RoleArn = cmdletContext.LoggingOptions_RoleArn;
            }
            if (requestLoggingOptions_loggingOptions_RoleArn != null)
            {
                request.LoggingOptions.RoleArn = requestLoggingOptions_loggingOptions_RoleArn;
                requestLoggingOptionsIsNull = false;
            }
             // determine if request.LoggingOptions should be set to null
            if (requestLoggingOptionsIsNull)
            {
                request.LoggingOptions = null;
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
        
        private Amazon.IoTEvents.Model.PutLoggingOptionsResponse CallAWSServiceOperation(IAmazonIoTEvents client, Amazon.IoTEvents.Model.PutLoggingOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Events", "PutLoggingOptions");
            try
            {
                #if DESKTOP
                return client.PutLoggingOptions(request);
                #elif CORECLR
                return client.PutLoggingOptionsAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public List<Amazon.IoTEvents.Model.DetectorDebugOption> LoggingOptions_DetectorDebugOption { get; set; }
            public System.Boolean? LoggingOptions_Enabled { get; set; }
            public Amazon.IoTEvents.LoggingLevel LoggingOptions_Level { get; set; }
            public System.String LoggingOptions_RoleArn { get; set; }
            public System.Func<Amazon.IoTEvents.Model.PutLoggingOptionsResponse, WriteIOTELoggingOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
