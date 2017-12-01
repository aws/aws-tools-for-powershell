/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Sets the logging options.
    /// </summary>
    [Cmdlet("Set", "IOTLoggingOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT SetLoggingOptions API operation.", Operation = new[] {"SetLoggingOptions"}, LegacyAlias="Set-IOTLoggingOptions")]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.IoT.Model.SetLoggingOptionsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetIOTLoggingOptionCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter LoggingOptionsPayload_LogLevel
        /// <summary>
        /// <para>
        /// <para>The log level.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.IoT.LogLevel")]
        public Amazon.IoT.LogLevel LoggingOptionsPayload_LogLevel { get; set; }
        #endregion
        
        #region Parameter LoggingOptionsPayload_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that grants access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LoggingOptionsPayload_RoleArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LoggingOptionsPayload_RoleArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-IOTLoggingOption (SetLoggingOptions)"))
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
            
            context.LoggingOptionsPayload_LogLevel = this.LoggingOptionsPayload_LogLevel;
            context.LoggingOptionsPayload_RoleArn = this.LoggingOptionsPayload_RoleArn;
            
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
            var request = new Amazon.IoT.Model.SetLoggingOptionsRequest();
            
            
             // populate LoggingOptionsPayload
            bool requestLoggingOptionsPayloadIsNull = true;
            request.LoggingOptionsPayload = new Amazon.IoT.Model.LoggingOptionsPayload();
            Amazon.IoT.LogLevel requestLoggingOptionsPayload_loggingOptionsPayload_LogLevel = null;
            if (cmdletContext.LoggingOptionsPayload_LogLevel != null)
            {
                requestLoggingOptionsPayload_loggingOptionsPayload_LogLevel = cmdletContext.LoggingOptionsPayload_LogLevel;
            }
            if (requestLoggingOptionsPayload_loggingOptionsPayload_LogLevel != null)
            {
                request.LoggingOptionsPayload.LogLevel = requestLoggingOptionsPayload_loggingOptionsPayload_LogLevel;
                requestLoggingOptionsPayloadIsNull = false;
            }
            System.String requestLoggingOptionsPayload_loggingOptionsPayload_RoleArn = null;
            if (cmdletContext.LoggingOptionsPayload_RoleArn != null)
            {
                requestLoggingOptionsPayload_loggingOptionsPayload_RoleArn = cmdletContext.LoggingOptionsPayload_RoleArn;
            }
            if (requestLoggingOptionsPayload_loggingOptionsPayload_RoleArn != null)
            {
                request.LoggingOptionsPayload.RoleArn = requestLoggingOptionsPayload_loggingOptionsPayload_RoleArn;
                requestLoggingOptionsPayloadIsNull = false;
            }
             // determine if request.LoggingOptionsPayload should be set to null
            if (requestLoggingOptionsPayloadIsNull)
            {
                request.LoggingOptionsPayload = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
        
        private Amazon.IoT.Model.SetLoggingOptionsResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.SetLoggingOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "SetLoggingOptions");
            try
            {
                #if DESKTOP
                return client.SetLoggingOptions(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SetLoggingOptionsAsync(request);
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
            public Amazon.IoT.LogLevel LoggingOptionsPayload_LogLevel { get; set; }
            public System.String LoggingOptionsPayload_RoleArn { get; set; }
        }
        
    }
}
