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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies a connection notification for VPC endpoint or VPC endpoint service. You can
    /// change the SNS topic for the notification, or the events for which to be notified.
    /// </summary>
    [Cmdlet("Edit", "EC2VpcEndpointConnectionNotification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud ModifyVpcEndpointConnectionNotification API operation.", Operation = new[] {"ModifyVpcEndpointConnectionNotification"})]
    [AWSCmdletOutput("System.Boolean",
        "This cmdlet returns a Boolean object.",
        "The service call response (type Amazon.EC2.Model.ModifyVpcEndpointConnectionNotificationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2VpcEndpointConnectionNotificationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter ConnectionEvent
        /// <summary>
        /// <para>
        /// <para>One or more events for the endpoint. Valid values are <code>Accept</code>, <code>Connect</code>,
        /// <code>Delete</code>, and <code>Reject</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ConnectionEvents")]
        public System.String[] ConnectionEvent { get; set; }
        #endregion
        
        #region Parameter ConnectionNotificationArn
        /// <summary>
        /// <para>
        /// <para>The ARN for the SNS topic for the notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConnectionNotificationArn { get; set; }
        #endregion
        
        #region Parameter ConnectionNotificationId
        /// <summary>
        /// <para>
        /// <para>The ID of the notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ConnectionNotificationId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ConnectionNotificationId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2VpcEndpointConnectionNotification (ModifyVpcEndpointConnectionNotification)"))
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
            
            if (this.ConnectionEvent != null)
            {
                context.ConnectionEvents = new List<System.String>(this.ConnectionEvent);
            }
            context.ConnectionNotificationArn = this.ConnectionNotificationArn;
            context.ConnectionNotificationId = this.ConnectionNotificationId;
            
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
            var request = new Amazon.EC2.Model.ModifyVpcEndpointConnectionNotificationRequest();
            
            if (cmdletContext.ConnectionEvents != null)
            {
                request.ConnectionEvents = cmdletContext.ConnectionEvents;
            }
            if (cmdletContext.ConnectionNotificationArn != null)
            {
                request.ConnectionNotificationArn = cmdletContext.ConnectionNotificationArn;
            }
            if (cmdletContext.ConnectionNotificationId != null)
            {
                request.ConnectionNotificationId = cmdletContext.ConnectionNotificationId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ReturnValue;
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
        
        private Amazon.EC2.Model.ModifyVpcEndpointConnectionNotificationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVpcEndpointConnectionNotificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "ModifyVpcEndpointConnectionNotification");
            try
            {
                #if DESKTOP
                return client.ModifyVpcEndpointConnectionNotification(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ModifyVpcEndpointConnectionNotificationAsync(request);
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
            public List<System.String> ConnectionEvents { get; set; }
            public System.String ConnectionNotificationArn { get; set; }
            public System.String ConnectionNotificationId { get; set; }
        }
        
    }
}
