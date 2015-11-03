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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    
    /// </summary>
    [Cmdlet("Update", "AGClientCertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.UpdateClientCertificateResponse")]
    [AWSCmdlet("Invokes the UpdateClientCertificate operation against Amazon API Gateway.", Operation = new[] {"UpdateClientCertificate"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.UpdateClientCertificateResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.UpdateClientCertificateResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateAGClientCertificateCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter ClientCertificateId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientCertificateId { get; set; }
        #endregion
        
        #region Parameter PatchOperation
        /// <summary>
        /// <para>
        /// <para>A list of operations describing the updates to apply to the specified resource. The
        /// patches are applied in the order specified in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PatchOperations")]
        public Amazon.APIGateway.Model.PatchOperation[] PatchOperation { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ClientCertificateId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AGClientCertificate (UpdateClientCertificate)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ClientCertificateId = this.ClientCertificateId;
            if (this.PatchOperation != null)
            {
                context.PatchOperations = new List<Amazon.APIGateway.Model.PatchOperation>(this.PatchOperation);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.APIGateway.Model.UpdateClientCertificateRequest();
            
            if (cmdletContext.ClientCertificateId != null)
            {
                request.ClientCertificateId = cmdletContext.ClientCertificateId;
            }
            if (cmdletContext.PatchOperations != null)
            {
                request.PatchOperations = cmdletContext.PatchOperations;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateClientCertificate(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
            public System.String ClientCertificateId { get; set; }
            public List<Amazon.APIGateway.Model.PatchOperation> PatchOperations { get; set; }
        }
        
    }
}
