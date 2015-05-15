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
        "The service response (type ModifyVpcEndpointResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EditEC2VpcEndpointCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>One or more route tables IDs to associate with the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AddRouteTableIds")]
        public System.String[] AddRouteTableId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A policy document to attach to the endpoint. The policy must be in valid JSON format.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String PolicyDocument { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One or more route table IDs to disassociate from the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RemoveRouteTableIds")]
        public System.String[] RemoveRouteTableId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specify <code>true</code> to reset the policy document to the default policy. The
        /// default policy allows access to the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean ResetPolicy { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String VpcEndpointId { get; set; }
        
        /// <summary>
        /// Returns the value passed to the VpcEndpointId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
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
            
            if (this.AddRouteTableId != null)
            {
                context.AddRouteTableIds = new List<String>(this.AddRouteTableId);
            }
            context.PolicyDocument = this.PolicyDocument;
            if (this.RemoveRouteTableId != null)
            {
                context.RemoveRouteTableIds = new List<String>(this.RemoveRouteTableId);
            }
            if (ParameterWasBound("ResetPolicy"))
                context.ResetPolicy = this.ResetPolicy;
            context.VpcEndpointId = this.VpcEndpointId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ModifyVpcEndpointRequest();
            
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
                var response = client.ModifyVpcEndpoint(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<String> AddRouteTableIds { get; set; }
            public String PolicyDocument { get; set; }
            public List<String> RemoveRouteTableIds { get; set; }
            public Boolean? ResetPolicy { get; set; }
            public String VpcEndpointId { get; set; }
        }
        
    }
}
