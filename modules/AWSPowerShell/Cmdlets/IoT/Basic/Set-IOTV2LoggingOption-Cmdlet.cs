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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Sets the logging options for the V2 logging service.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">SetV2LoggingOptions</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "IOTV2LoggingOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT SetV2LoggingOptions API operation.", Operation = new[] {"SetV2LoggingOptions"}, SelectReturnType = typeof(Amazon.IoT.Model.SetV2LoggingOptionsResponse))]
    [AWSCmdletOutput("None or Amazon.IoT.Model.SetV2LoggingOptionsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoT.Model.SetV2LoggingOptionsResponse) be returned by specifying '-Select *'."
    )]
    public partial class SetIOTV2LoggingOptionCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DefaultLogLevel
        /// <summary>
        /// <para>
        /// <para>The default logging level.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.LogLevel")]
        public Amazon.IoT.LogLevel DefaultLogLevel { get; set; }
        #endregion
        
        #region Parameter DisableAllLog
        /// <summary>
        /// <para>
        /// <para>If true all logs are disabled. The default is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DisableAllLogs")]
        public System.Boolean? DisableAllLog { get; set; }
        #endregion
        
        #region Parameter EventConfiguration
        /// <summary>
        /// <para>
        /// <para> The list of event configurations that override account-level logging. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventConfigurations")]
        public Amazon.IoT.Model.LogEventConfiguration[] EventConfiguration { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role that allows IoT to write to Cloudwatch logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.SetV2LoggingOptionsResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RoleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-IOTV2LoggingOption (SetV2LoggingOptions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.SetV2LoggingOptionsResponse, SetIOTV2LoggingOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DefaultLogLevel = this.DefaultLogLevel;
            context.DisableAllLog = this.DisableAllLog;
            if (this.EventConfiguration != null)
            {
                context.EventConfiguration = new List<Amazon.IoT.Model.LogEventConfiguration>(this.EventConfiguration);
            }
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.IoT.Model.SetV2LoggingOptionsRequest();
            
            if (cmdletContext.DefaultLogLevel != null)
            {
                request.DefaultLogLevel = cmdletContext.DefaultLogLevel;
            }
            if (cmdletContext.DisableAllLog != null)
            {
                request.DisableAllLogs = cmdletContext.DisableAllLog.Value;
            }
            if (cmdletContext.EventConfiguration != null)
            {
                request.EventConfigurations = cmdletContext.EventConfiguration;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.IoT.Model.SetV2LoggingOptionsResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.SetV2LoggingOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "SetV2LoggingOptions");
            try
            {
                #if DESKTOP
                return client.SetV2LoggingOptions(request);
                #elif CORECLR
                return client.SetV2LoggingOptionsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.IoT.LogLevel DefaultLogLevel { get; set; }
            public System.Boolean? DisableAllLog { get; set; }
            public List<Amazon.IoT.Model.LogEventConfiguration> EventConfiguration { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.IoT.Model.SetV2LoggingOptionsResponse, SetIOTV2LoggingOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
