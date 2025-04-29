/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.Redshift;
using Amazon.Redshift.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Registers a cluster or serverless namespace to the Amazon Web Services Glue Data Catalog.
    /// </summary>
    [Cmdlet("Register", "RSNamespace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.NamespaceRegistrationStatus")]
    [AWSCmdlet("Calls the Amazon Redshift RegisterNamespace API operation.", Operation = new[] {"RegisterNamespace"}, SelectReturnType = typeof(Amazon.Redshift.Model.RegisterNamespaceResponse))]
    [AWSCmdletOutput("Amazon.Redshift.NamespaceRegistrationStatus or Amazon.Redshift.Model.RegisterNamespaceResponse",
        "This cmdlet returns an Amazon.Redshift.NamespaceRegistrationStatus object.",
        "The service call response (type Amazon.Redshift.Model.RegisterNamespaceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterRSNamespaceCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ProvisionedIdentifier_ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the provisioned cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NamespaceIdentifier_ProvisionedIdentifier_ClusterIdentifier")]
        public System.String ProvisionedIdentifier_ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter ConsumerIdentifier
        /// <summary>
        /// <para>
        /// <para>An array containing the ID of the consumer account that you want to register the namespace
        /// to.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ConsumerIdentifiers")]
        public System.String[] ConsumerIdentifier { get; set; }
        #endregion
        
        #region Parameter ServerlessIdentifier_NamespaceIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the serverless namespace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NamespaceIdentifier_ServerlessIdentifier_NamespaceIdentifier")]
        public System.String ServerlessIdentifier_NamespaceIdentifier { get; set; }
        #endregion
        
        #region Parameter ServerlessIdentifier_WorkgroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the workgroup associated with the serverless namespace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NamespaceIdentifier_ServerlessIdentifier_WorkgroupIdentifier")]
        public System.String ServerlessIdentifier_WorkgroupIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.RegisterNamespaceResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.RegisterNamespaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-RSNamespace (RegisterNamespace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.RegisterNamespaceResponse, RegisterRSNamespaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ConsumerIdentifier != null)
            {
                context.ConsumerIdentifier = new List<System.String>(this.ConsumerIdentifier);
            }
            #if MODULAR
            if (this.ConsumerIdentifier == null && ParameterWasBound(nameof(this.ConsumerIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ConsumerIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProvisionedIdentifier_ClusterIdentifier = this.ProvisionedIdentifier_ClusterIdentifier;
            context.ServerlessIdentifier_NamespaceIdentifier = this.ServerlessIdentifier_NamespaceIdentifier;
            context.ServerlessIdentifier_WorkgroupIdentifier = this.ServerlessIdentifier_WorkgroupIdentifier;
            
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
            var request = new Amazon.Redshift.Model.RegisterNamespaceRequest();
            
            if (cmdletContext.ConsumerIdentifier != null)
            {
                request.ConsumerIdentifiers = cmdletContext.ConsumerIdentifier;
            }
            
             // populate NamespaceIdentifier
            var requestNamespaceIdentifierIsNull = true;
            request.NamespaceIdentifier = new Amazon.Redshift.Model.NamespaceIdentifierUnion();
            Amazon.Redshift.Model.ProvisionedIdentifier requestNamespaceIdentifier_namespaceIdentifier_ProvisionedIdentifier = null;
            
             // populate ProvisionedIdentifier
            var requestNamespaceIdentifier_namespaceIdentifier_ProvisionedIdentifierIsNull = true;
            requestNamespaceIdentifier_namespaceIdentifier_ProvisionedIdentifier = new Amazon.Redshift.Model.ProvisionedIdentifier();
            System.String requestNamespaceIdentifier_namespaceIdentifier_ProvisionedIdentifier_provisionedIdentifier_ClusterIdentifier = null;
            if (cmdletContext.ProvisionedIdentifier_ClusterIdentifier != null)
            {
                requestNamespaceIdentifier_namespaceIdentifier_ProvisionedIdentifier_provisionedIdentifier_ClusterIdentifier = cmdletContext.ProvisionedIdentifier_ClusterIdentifier;
            }
            if (requestNamespaceIdentifier_namespaceIdentifier_ProvisionedIdentifier_provisionedIdentifier_ClusterIdentifier != null)
            {
                requestNamespaceIdentifier_namespaceIdentifier_ProvisionedIdentifier.ClusterIdentifier = requestNamespaceIdentifier_namespaceIdentifier_ProvisionedIdentifier_provisionedIdentifier_ClusterIdentifier;
                requestNamespaceIdentifier_namespaceIdentifier_ProvisionedIdentifierIsNull = false;
            }
             // determine if requestNamespaceIdentifier_namespaceIdentifier_ProvisionedIdentifier should be set to null
            if (requestNamespaceIdentifier_namespaceIdentifier_ProvisionedIdentifierIsNull)
            {
                requestNamespaceIdentifier_namespaceIdentifier_ProvisionedIdentifier = null;
            }
            if (requestNamespaceIdentifier_namespaceIdentifier_ProvisionedIdentifier != null)
            {
                request.NamespaceIdentifier.ProvisionedIdentifier = requestNamespaceIdentifier_namespaceIdentifier_ProvisionedIdentifier;
                requestNamespaceIdentifierIsNull = false;
            }
            Amazon.Redshift.Model.ServerlessIdentifier requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifier = null;
            
             // populate ServerlessIdentifier
            var requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifierIsNull = true;
            requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifier = new Amazon.Redshift.Model.ServerlessIdentifier();
            System.String requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifier_serverlessIdentifier_NamespaceIdentifier = null;
            if (cmdletContext.ServerlessIdentifier_NamespaceIdentifier != null)
            {
                requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifier_serverlessIdentifier_NamespaceIdentifier = cmdletContext.ServerlessIdentifier_NamespaceIdentifier;
            }
            if (requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifier_serverlessIdentifier_NamespaceIdentifier != null)
            {
                requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifier.NamespaceIdentifier = requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifier_serverlessIdentifier_NamespaceIdentifier;
                requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifierIsNull = false;
            }
            System.String requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifier_serverlessIdentifier_WorkgroupIdentifier = null;
            if (cmdletContext.ServerlessIdentifier_WorkgroupIdentifier != null)
            {
                requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifier_serverlessIdentifier_WorkgroupIdentifier = cmdletContext.ServerlessIdentifier_WorkgroupIdentifier;
            }
            if (requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifier_serverlessIdentifier_WorkgroupIdentifier != null)
            {
                requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifier.WorkgroupIdentifier = requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifier_serverlessIdentifier_WorkgroupIdentifier;
                requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifierIsNull = false;
            }
             // determine if requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifier should be set to null
            if (requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifierIsNull)
            {
                requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifier = null;
            }
            if (requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifier != null)
            {
                request.NamespaceIdentifier.ServerlessIdentifier = requestNamespaceIdentifier_namespaceIdentifier_ServerlessIdentifier;
                requestNamespaceIdentifierIsNull = false;
            }
             // determine if request.NamespaceIdentifier should be set to null
            if (requestNamespaceIdentifierIsNull)
            {
                request.NamespaceIdentifier = null;
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
        
        private Amazon.Redshift.Model.RegisterNamespaceResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.RegisterNamespaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "RegisterNamespace");
            try
            {
                return client.RegisterNamespaceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> ConsumerIdentifier { get; set; }
            public System.String ProvisionedIdentifier_ClusterIdentifier { get; set; }
            public System.String ServerlessIdentifier_NamespaceIdentifier { get; set; }
            public System.String ServerlessIdentifier_WorkgroupIdentifier { get; set; }
            public System.Func<Amazon.Redshift.Model.RegisterNamespaceResponse, RegisterRSNamespaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
