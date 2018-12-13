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
using Amazon.MediaConnect;
using Amazon.MediaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.EMCN
{
    /// <summary>
    /// You can change an entitlement's description, subscribers, and encryption. If you change
    /// the subscribers, the service will remove the outputs that are are used by the subscribers
    /// that are removed.
    /// </summary>
    [Cmdlet("Update", "EMCNFlowEntitlement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.Entitlement")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect UpdateFlowEntitlement API operation.", Operation = new[] {"UpdateFlowEntitlement"})]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.Entitlement",
        "This cmdlet returns a Entitlement object.",
        "The service call response (type Amazon.MediaConnect.Model.UpdateFlowEntitlementResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: FlowArn (type System.String)"
    )]
    public partial class UpdateEMCNFlowEntitlementCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// A description of the entitlement. This description
        /// appears only on the AWS Elemental MediaConnect console and will not be seen by the
        /// subscriber or end user.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Encryption
        /// <summary>
        /// <para>
        /// The type of encryption that will be used on
        /// the output associated with this entitlement.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.MediaConnect.Model.UpdateEncryption Encryption { get; set; }
        #endregion
        
        #region Parameter EntitlementArn
        /// <summary>
        /// <para>
        /// The ARN of the entitlement that you want
        /// to update.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String EntitlementArn { get; set; }
        #endregion
        
        #region Parameter Subscriber
        /// <summary>
        /// <para>
        /// The AWS account IDs that you want to share
        /// your content with. The receiving accounts (subscribers) will be allowed to create
        /// their own flow using your content as the source.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Subscribers")]
        public System.String[] Subscriber { get; set; }
        #endregion
        
        #region Parameter FlowArn
        /// <summary>
        /// <para>
        /// The flow that is associated with the entitlement
        /// that you want to update.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FlowArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("EntitlementArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMCNFlowEntitlement (UpdateFlowEntitlement)"))
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
            
            context.Description = this.Description;
            context.Encryption = this.Encryption;
            context.EntitlementArn = this.EntitlementArn;
            context.FlowArn = this.FlowArn;
            if (this.Subscriber != null)
            {
                context.Subscribers = new List<System.String>(this.Subscriber);
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
            var request = new Amazon.MediaConnect.Model.UpdateFlowEntitlementRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Encryption != null)
            {
                request.Encryption = cmdletContext.Encryption;
            }
            if (cmdletContext.EntitlementArn != null)
            {
                request.EntitlementArn = cmdletContext.EntitlementArn;
            }
            if (cmdletContext.FlowArn != null)
            {
                request.FlowArn = cmdletContext.FlowArn;
            }
            if (cmdletContext.Subscribers != null)
            {
                request.Subscribers = cmdletContext.Subscribers;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Entitlement;
                notes = new Dictionary<string, object>();
                notes["FlowArn"] = response.FlowArn;
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
        
        private Amazon.MediaConnect.Model.UpdateFlowEntitlementResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.UpdateFlowEntitlementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "UpdateFlowEntitlement");
            try
            {
                #if DESKTOP
                return client.UpdateFlowEntitlement(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateFlowEntitlementAsync(request);
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
            public System.String Description { get; set; }
            public Amazon.MediaConnect.Model.UpdateEncryption Encryption { get; set; }
            public System.String EntitlementArn { get; set; }
            public System.String FlowArn { get; set; }
            public List<System.String> Subscribers { get; set; }
        }
        
    }
}
