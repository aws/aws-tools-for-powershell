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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Sets the logging level.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">SetV2LoggingLevel</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "IOTV2LoggingLevel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT SetV2LoggingLevel API operation.", Operation = new[] {"SetV2LoggingLevel"}, SelectReturnType = typeof(Amazon.IoT.Model.SetV2LoggingLevelResponse))]
    [AWSCmdletOutput("None or Amazon.IoT.Model.SetV2LoggingLevelResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoT.Model.SetV2LoggingLevelResponse) be returned by specifying '-Select *'."
    )]
    public partial class SetIOTV2LoggingLevelCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LogLevel
        /// <summary>
        /// <para>
        /// <para>The log level.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoT.LogLevel")]
        public Amazon.IoT.LogLevel LogLevel { get; set; }
        #endregion
        
        #region Parameter LogTarget_TargetName
        /// <summary>
        /// <para>
        /// <para>The target name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogTarget_TargetName { get; set; }
        #endregion
        
        #region Parameter LogTarget_TargetType
        /// <summary>
        /// <para>
        /// <para>The target type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoT.LogTargetType")]
        public Amazon.IoT.LogTargetType LogTarget_TargetType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.SetV2LoggingLevelResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LogTarget_TargetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-IOTV2LoggingLevel (SetV2LoggingLevel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.SetV2LoggingLevelResponse, SetIOTV2LoggingLevelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LogLevel = this.LogLevel;
            #if MODULAR
            if (this.LogLevel == null && ParameterWasBound(nameof(this.LogLevel)))
            {
                WriteWarning("You are passing $null as a value for parameter LogLevel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LogTarget_TargetName = this.LogTarget_TargetName;
            context.LogTarget_TargetType = this.LogTarget_TargetType;
            #if MODULAR
            if (this.LogTarget_TargetType == null && ParameterWasBound(nameof(this.LogTarget_TargetType)))
            {
                WriteWarning("You are passing $null as a value for parameter LogTarget_TargetType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoT.Model.SetV2LoggingLevelRequest();
            
            if (cmdletContext.LogLevel != null)
            {
                request.LogLevel = cmdletContext.LogLevel;
            }
            
             // populate LogTarget
            var requestLogTargetIsNull = true;
            request.LogTarget = new Amazon.IoT.Model.LogTarget();
            System.String requestLogTarget_logTarget_TargetName = null;
            if (cmdletContext.LogTarget_TargetName != null)
            {
                requestLogTarget_logTarget_TargetName = cmdletContext.LogTarget_TargetName;
            }
            if (requestLogTarget_logTarget_TargetName != null)
            {
                request.LogTarget.TargetName = requestLogTarget_logTarget_TargetName;
                requestLogTargetIsNull = false;
            }
            Amazon.IoT.LogTargetType requestLogTarget_logTarget_TargetType = null;
            if (cmdletContext.LogTarget_TargetType != null)
            {
                requestLogTarget_logTarget_TargetType = cmdletContext.LogTarget_TargetType;
            }
            if (requestLogTarget_logTarget_TargetType != null)
            {
                request.LogTarget.TargetType = requestLogTarget_logTarget_TargetType;
                requestLogTargetIsNull = false;
            }
             // determine if request.LogTarget should be set to null
            if (requestLogTargetIsNull)
            {
                request.LogTarget = null;
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
        
        private Amazon.IoT.Model.SetV2LoggingLevelResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.SetV2LoggingLevelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "SetV2LoggingLevel");
            try
            {
                #if DESKTOP
                return client.SetV2LoggingLevel(request);
                #elif CORECLR
                return client.SetV2LoggingLevelAsync(request).GetAwaiter().GetResult();
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
            public Amazon.IoT.LogLevel LogLevel { get; set; }
            public System.String LogTarget_TargetName { get; set; }
            public Amazon.IoT.LogTargetType LogTarget_TargetType { get; set; }
            public System.Func<Amazon.IoT.Model.SetV2LoggingLevelResponse, SetIOTV2LoggingLevelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
