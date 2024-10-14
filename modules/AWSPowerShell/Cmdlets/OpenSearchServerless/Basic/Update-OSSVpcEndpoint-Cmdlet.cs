/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.OpenSearchServerless;
using Amazon.OpenSearchServerless.Model;

namespace Amazon.PowerShell.Cmdlets.OSS
{
    /// <summary>
    /// Updates an OpenSearch Serverless-managed interface endpoint. For more information,
    /// see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/serverless-vpc.html">Access
    /// Amazon OpenSearch Serverless using an interface endpoint</a>.
    /// </summary>
    [Cmdlet("Update", "OSSVpcEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchServerless.Model.UpdateVpcEndpointDetail")]
    [AWSCmdlet("Calls the OpenSearch Serverless UpdateVpcEndpoint API operation.", Operation = new[] {"UpdateVpcEndpoint"}, SelectReturnType = typeof(Amazon.OpenSearchServerless.Model.UpdateVpcEndpointResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchServerless.Model.UpdateVpcEndpointDetail or Amazon.OpenSearchServerless.Model.UpdateVpcEndpointResponse",
        "This cmdlet returns an Amazon.OpenSearchServerless.Model.UpdateVpcEndpointDetail object.",
        "The service call response (type Amazon.OpenSearchServerless.Model.UpdateVpcEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateOSSVpcEndpointCmdlet : AmazonOpenSearchServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AddSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The unique identifiers of the security groups to add to the endpoint. Security groups
        /// define the ports, protocols, and sources for inbound traffic that you are authorizing
        /// into your endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddSecurityGroupIds")]
        public System.String[] AddSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter AddSubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of one or more subnets to add to the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddSubnetIds")]
        public System.String[] AddSubnetId { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the interface endpoint to update.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter RemoveSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The unique identifiers of the security groups to remove from the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveSecurityGroupIds")]
        public System.String[] RemoveSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter RemoveSubnetId
        /// <summary>
        /// <para>
        /// <para>The unique identifiers of the subnets to remove from the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveSubnetIds")]
        public System.String[] RemoveSubnetId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier to ensure idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UpdateVpcEndpointDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchServerless.Model.UpdateVpcEndpointResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchServerless.Model.UpdateVpcEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UpdateVpcEndpointDetail";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OSSVpcEndpoint (UpdateVpcEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchServerless.Model.UpdateVpcEndpointResponse, UpdateOSSVpcEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AddSecurityGroupId != null)
            {
                context.AddSecurityGroupId = new List<System.String>(this.AddSecurityGroupId);
            }
            if (this.AddSubnetId != null)
            {
                context.AddSubnetId = new List<System.String>(this.AddSubnetId);
            }
            context.ClientToken = this.ClientToken;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RemoveSecurityGroupId != null)
            {
                context.RemoveSecurityGroupId = new List<System.String>(this.RemoveSecurityGroupId);
            }
            if (this.RemoveSubnetId != null)
            {
                context.RemoveSubnetId = new List<System.String>(this.RemoveSubnetId);
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
            var request = new Amazon.OpenSearchServerless.Model.UpdateVpcEndpointRequest();
            
            if (cmdletContext.AddSecurityGroupId != null)
            {
                request.AddSecurityGroupIds = cmdletContext.AddSecurityGroupId;
            }
            if (cmdletContext.AddSubnetId != null)
            {
                request.AddSubnetIds = cmdletContext.AddSubnetId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.RemoveSecurityGroupId != null)
            {
                request.RemoveSecurityGroupIds = cmdletContext.RemoveSecurityGroupId;
            }
            if (cmdletContext.RemoveSubnetId != null)
            {
                request.RemoveSubnetIds = cmdletContext.RemoveSubnetId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.OpenSearchServerless.Model.UpdateVpcEndpointResponse CallAWSServiceOperation(IAmazonOpenSearchServerless client, Amazon.OpenSearchServerless.Model.UpdateVpcEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "OpenSearch Serverless", "UpdateVpcEndpoint");
            try
            {
                #if DESKTOP
                return client.UpdateVpcEndpoint(request);
                #elif CORECLR
                return client.UpdateVpcEndpointAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AddSecurityGroupId { get; set; }
            public List<System.String> AddSubnetId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Id { get; set; }
            public List<System.String> RemoveSecurityGroupId { get; set; }
            public List<System.String> RemoveSubnetId { get; set; }
            public System.Func<Amazon.OpenSearchServerless.Model.UpdateVpcEndpointResponse, UpdateOSSVpcEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UpdateVpcEndpointDetail;
        }
        
    }
}
