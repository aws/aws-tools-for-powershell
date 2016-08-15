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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies attributes of a specified VPC endpoint. You can modify the policy associated
    /// with the endpoint, and you can add and remove route tables associated with the endpoint.
    /// </summary>
    [Cmdlet("Edit", "EC2VpcEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the ModifyVpcEndpoint operation against Amazon Elastic Compute Cloud.", Operation = new[] {"ModifyVpcEndpoint"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the VpcEndpointId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.EC2.Model.ModifyVpcEndpointResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2VpcEndpointCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AddRouteTableId
        /// <summary>
        /// <para>
        /// <para>One or more route tables IDs to associate with the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AddRouteTableIds")]
        public System.String[] AddRouteTableId { get; set; }
        #endregion
        
        #region Parameter PolicyDocument
        /// <summary>
        /// <para>
        /// <para>A policy document to attach to the endpoint. The policy must be in valid JSON format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PolicyDocument { get; set; }
        #endregion
        
        #region Parameter RemoveRouteTableId
        /// <summary>
        /// <para>
        /// <para>One or more route table IDs to disassociate from the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RemoveRouteTableIds")]
        public System.String[] RemoveRouteTableId { get; set; }
        #endregion
        
        #region Parameter ResetPolicy
        /// <summary>
        /// <para>
        /// <para>Specify <code>true</code> to reset the policy document to the default policy. The
        /// default policy allows access to the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ResetPolicy { get; set; }
        #endregion
        
        #region Parameter VpcEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String VpcEndpointId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the VpcEndpointId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VpcEndpointId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2VpcEndpoint (ModifyVpcEndpoint)"))
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
            
            if (this.AddRouteTableId != null)
            {
                context.AddRouteTableIds = new List<System.String>(this.AddRouteTableId);
            }
            context.PolicyDocument = this.PolicyDocument;
            if (this.RemoveRouteTableId != null)
            {
                context.RemoveRouteTableIds = new List<System.String>(this.RemoveRouteTableId);
            }
            if (ParameterWasBound("ResetPolicy"))
                context.ResetPolicy = this.ResetPolicy;
            context.VpcEndpointId = this.VpcEndpointId;
            
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
            var request = new Amazon.EC2.Model.ModifyVpcEndpointRequest();
            
            if (cmdletContext.AddRouteTableIds != null)
            {
                request.AddRouteTableIds = cmdletContext.AddRouteTableIds;
            }
            if (cmdletContext.PolicyDocument != null)
            {
                request.PolicyDocument = cmdletContext.PolicyDocument;
            }
            if (cmdletContext.RemoveRouteTableIds != null)
            {
                request.RemoveRouteTableIds = cmdletContext.RemoveRouteTableIds;
            }
            if (cmdletContext.ResetPolicy != null)
            {
                request.ResetPolicy = cmdletContext.ResetPolicy.Value;
            }
            if (cmdletContext.VpcEndpointId != null)
            {
                request.VpcEndpointId = cmdletContext.VpcEndpointId;
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
                    pipelineOutput = this.VpcEndpointId;
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
        
        private static Amazon.EC2.Model.ModifyVpcEndpointResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVpcEndpointRequest request)
        {
            #if DESKTOP
            return client.ModifyVpcEndpoint(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ModifyVpcEndpointAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> AddRouteTableIds { get; set; }
            public System.String PolicyDocument { get; set; }
            public List<System.String> RemoveRouteTableIds { get; set; }
            public System.Boolean? ResetPolicy { get; set; }
            public System.String VpcEndpointId { get; set; }
        }
        
    }
}
