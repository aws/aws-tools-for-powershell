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
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Sets the logging level.
    /// </summary>
    [Cmdlet("Set", "IOTV2LoggingLevel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","Amazon.IoT.LogLevel")]
    [AWSCmdlet("Calls the AWS IoT SetV2LoggingLevel API operation.", Operation = new[] {"SetV2LoggingLevel"})]
    [AWSCmdletOutput("None or Amazon.IoT.LogLevel",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the LogLevel parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.IoT.Model.SetV2LoggingLevelResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetIOTV2LoggingLevelCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter LogLevel
        /// <summary>
        /// <para>
        /// <para>The log level.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.IoT.LogLevel")]
        public Amazon.IoT.LogLevel LogLevel { get; set; }
        #endregion
        
        #region Parameter LogTarget_TargetName
        /// <summary>
        /// <para>
        /// <para>The target name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LogTarget_TargetName { get; set; }
        #endregion
        
        #region Parameter LogTarget_TargetType
        /// <summary>
        /// <para>
        /// <para>The target type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.IoT.LogTargetType")]
        public Amazon.IoT.LogTargetType LogTarget_TargetType { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the LogLevel parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LogTarget_TargetName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-IOTV2LoggingLevel (SetV2LoggingLevel)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.LogLevel = this.LogLevel;
            context.LogTarget_TargetName = this.LogTarget_TargetName;
            context.LogTarget_TargetType = this.LogTarget_TargetType;
            
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
            bool requestLogTargetIsNull = true;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.LogLevel;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SetV2LoggingLevelAsync(request);
                return task.Result;
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
        }
        
    }
}
