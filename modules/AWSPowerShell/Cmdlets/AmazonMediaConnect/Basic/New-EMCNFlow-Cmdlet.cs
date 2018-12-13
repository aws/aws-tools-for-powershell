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
    /// Creates a new flow. The request must include one source. The request optionally can
    /// include outputs (up to 20) and entitlements (up to 50).
    /// </summary>
    [Cmdlet("New", "EMCNFlow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.Flow")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect CreateFlow API operation.", Operation = new[] {"CreateFlow"})]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.Flow",
        "This cmdlet returns a Flow object.",
        "The service call response (type Amazon.MediaConnect.Model.CreateFlowResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEMCNFlowCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// The Availability Zone that you want to
        /// create the flow in. These options are limited to the Availability Zones within the
        /// current AWS Region.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter Entitlement
        /// <summary>
        /// <para>
        /// The entitlements that you want to grant on
        /// a flow.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Entitlements")]
        public Amazon.MediaConnect.Model.GrantEntitlementRequest[] Entitlement { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The name of the flow.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Output
        /// <summary>
        /// <para>
        /// The outputs that you want to add to this flow.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Outputs")]
        public Amazon.MediaConnect.Model.AddOutputRequest[] Output { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.MediaConnect.Model.SetSourceRequest Source { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMCNFlow (CreateFlow)"))
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
            
            context.AvailabilityZone = this.AvailabilityZone;
            if (this.Entitlement != null)
            {
                context.Entitlements = new List<Amazon.MediaConnect.Model.GrantEntitlementRequest>(this.Entitlement);
            }
            context.Name = this.Name;
            if (this.Output != null)
            {
                context.Outputs = new List<Amazon.MediaConnect.Model.AddOutputRequest>(this.Output);
            }
            context.Source = this.Source;
            
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
            var request = new Amazon.MediaConnect.Model.CreateFlowRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.Entitlements != null)
            {
                request.Entitlements = cmdletContext.Entitlements;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Outputs != null)
            {
                request.Outputs = cmdletContext.Outputs;
            }
            if (cmdletContext.Source != null)
            {
                request.Source = cmdletContext.Source;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Flow;
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
        
        private Amazon.MediaConnect.Model.CreateFlowResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.CreateFlowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "CreateFlow");
            try
            {
                #if DESKTOP
                return client.CreateFlow(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateFlowAsync(request);
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
            public System.String AvailabilityZone { get; set; }
            public List<Amazon.MediaConnect.Model.GrantEntitlementRequest> Entitlements { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.MediaConnect.Model.AddOutputRequest> Outputs { get; set; }
            public Amazon.MediaConnect.Model.SetSourceRequest Source { get; set; }
        }
        
    }
}
