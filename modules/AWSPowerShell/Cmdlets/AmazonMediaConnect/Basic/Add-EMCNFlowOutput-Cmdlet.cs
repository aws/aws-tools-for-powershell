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
    /// Adds outputs to an existing flow. You can create up to 20 outputs per flow.
    /// </summary>
    [Cmdlet("Add", "EMCNFlowOutput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.Output")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect AddFlowOutputs API operation.", Operation = new[] {"AddFlowOutputs"})]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.Output",
        "This cmdlet returns a collection of Output objects.",
        "The service call response (type Amazon.MediaConnect.Model.AddFlowOutputsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: FlowArn (type System.String)"
    )]
    public partial class AddEMCNFlowOutputCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        #region Parameter FlowArn
        /// <summary>
        /// <para>
        /// The flow that you want to add outputs to.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FlowArn { get; set; }
        #endregion
        
        #region Parameter Output
        /// <summary>
        /// <para>
        /// A list of outputs that you want to add.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Outputs")]
        public Amazon.MediaConnect.Model.AddOutputRequest[] Output { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FlowArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-EMCNFlowOutput (AddFlowOutputs)"))
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
            
            context.FlowArn = this.FlowArn;
            if (this.Output != null)
            {
                context.Outputs = new List<Amazon.MediaConnect.Model.AddOutputRequest>(this.Output);
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
            var request = new Amazon.MediaConnect.Model.AddFlowOutputsRequest();
            
            if (cmdletContext.FlowArn != null)
            {
                request.FlowArn = cmdletContext.FlowArn;
            }
            if (cmdletContext.Outputs != null)
            {
                request.Outputs = cmdletContext.Outputs;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Outputs;
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
        
        private Amazon.MediaConnect.Model.AddFlowOutputsResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.AddFlowOutputsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "AddFlowOutputs");
            try
            {
                #if DESKTOP
                return client.AddFlowOutputs(request);
                #elif CORECLR
                return client.AddFlowOutputsAsync(request).GetAwaiter().GetResult();
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
            public System.String FlowArn { get; set; }
            public List<Amazon.MediaConnect.Model.AddOutputRequest> Outputs { get; set; }
        }
        
    }
}
