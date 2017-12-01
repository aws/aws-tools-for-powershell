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
    /// Deletes a logging level.
    /// </summary>
    [Cmdlet("Remove", "IOTV2LoggingLevel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT DeleteV2LoggingLevel API operation.", Operation = new[] {"DeleteV2LoggingLevel"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.IoT.Model.DeleteV2LoggingLevelResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveIOTV2LoggingLevelCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter TargetName
        /// <summary>
        /// <para>
        /// <para>The name of the resource for which you are configuring logging.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetName { get; set; }
        #endregion
        
        #region Parameter TargetType
        /// <summary>
        /// <para>
        /// <para>The type of resource for which you are configuring logging. Must be <code>THING_Group</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.IoT.LogTargetType")]
        public Amazon.IoT.LogTargetType TargetType { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TargetName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-IOTV2LoggingLevel (DeleteV2LoggingLevel)"))
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
            
            context.TargetName = this.TargetName;
            context.TargetType = this.TargetType;
            
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
            var request = new Amazon.IoT.Model.DeleteV2LoggingLevelRequest();
            
            if (cmdletContext.TargetName != null)
            {
                request.TargetName = cmdletContext.TargetName;
            }
            if (cmdletContext.TargetType != null)
            {
                request.TargetType = cmdletContext.TargetType;
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
        
        private Amazon.IoT.Model.DeleteV2LoggingLevelResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.DeleteV2LoggingLevelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "DeleteV2LoggingLevel");
            try
            {
                #if DESKTOP
                return client.DeleteV2LoggingLevel(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteV2LoggingLevelAsync(request);
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
            public System.String TargetName { get; set; }
            public Amazon.IoT.LogTargetType TargetType { get; set; }
        }
        
    }
}
