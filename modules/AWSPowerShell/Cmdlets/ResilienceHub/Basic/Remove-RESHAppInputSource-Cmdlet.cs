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
using Amazon.ResilienceHub;
using Amazon.ResilienceHub.Model;

namespace Amazon.PowerShell.Cmdlets.RESH
{
    /// <summary>
    /// Deletes the input source and all of its imported resources from the Resilience Hub
    /// application.
    /// </summary>
    [Cmdlet("Remove", "RESHAppInputSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ResilienceHub.Model.DeleteAppInputSourceResponse")]
    [AWSCmdlet("Calls the AWS Resilience Hub DeleteAppInputSource API operation.", Operation = new[] {"DeleteAppInputSource"}, SelectReturnType = typeof(Amazon.ResilienceHub.Model.DeleteAppInputSourceResponse))]
    [AWSCmdletOutput("Amazon.ResilienceHub.Model.DeleteAppInputSourceResponse",
        "This cmdlet returns an Amazon.ResilienceHub.Model.DeleteAppInputSourceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveRESHAppInputSourceCmdlet : AmazonResilienceHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the Resilience Hub application. The format for this
        /// ARN is: arn:<code>partition</code>:resiliencehub:<code>region</code>:<code>account</code>:app/<code>app-id</code>.
        /// For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">
        /// Amazon Resource Names (ARNs)</a> in the <i>Amazon Web Services General Reference</i>
        /// guide.</para>
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
        public System.String AppArn { get; set; }
        #endregion
        
        #region Parameter EksSourceClusterNamespace_EksClusterArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the Amazon Elastic Kubernetes Service cluster. The format
        /// for this ARN is: arn:<code>aws</code>:eks:<code>region</code>:<code>account-id</code>:cluster/<code>cluster-name</code>.
        /// For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">
        /// Amazon Resource Names (ARNs)</a> in the <i>Amazon Web Services General Reference</i>
        /// guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EksSourceClusterNamespace_EksClusterArn { get; set; }
        #endregion
        
        #region Parameter EksSourceClusterNamespace_Namespace
        /// <summary>
        /// <para>
        /// <para>Name of the namespace that is located on your Amazon Elastic Kubernetes Service cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EksSourceClusterNamespace_Namespace { get; set; }
        #endregion
        
        #region Parameter TerraformSource_S3StateFileUrl
        /// <summary>
        /// <para>
        /// <para> The URL of the Terraform s3 state file you need to import. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TerraformSource_S3StateFileUrl { get; set; }
        #endregion
        
        #region Parameter SourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the imported resource you want to remove from the
        /// Resilience Hub application. For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">
        /// Amazon Resource Names (ARNs)</a> in the <i>Amazon Web Services General Reference</i>
        /// guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Used for an idempotency token. A client token is a unique, case-sensitive string of
        /// up to 64 ASCII characters. You should not reuse the same client token for other API
        /// requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResilienceHub.Model.DeleteAppInputSourceResponse).
        /// Specifying the name of a property of type Amazon.ResilienceHub.Model.DeleteAppInputSourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AppArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AppArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AppArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-RESHAppInputSource (DeleteAppInputSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResilienceHub.Model.DeleteAppInputSourceResponse, RemoveRESHAppInputSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AppArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AppArn = this.AppArn;
            #if MODULAR
            if (this.AppArn == null && ParameterWasBound(nameof(this.AppArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AppArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.EksSourceClusterNamespace_EksClusterArn = this.EksSourceClusterNamespace_EksClusterArn;
            context.EksSourceClusterNamespace_Namespace = this.EksSourceClusterNamespace_Namespace;
            context.SourceArn = this.SourceArn;
            context.TerraformSource_S3StateFileUrl = this.TerraformSource_S3StateFileUrl;
            
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
            var request = new Amazon.ResilienceHub.Model.DeleteAppInputSourceRequest();
            
            if (cmdletContext.AppArn != null)
            {
                request.AppArn = cmdletContext.AppArn;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate EksSourceClusterNamespace
            var requestEksSourceClusterNamespaceIsNull = true;
            request.EksSourceClusterNamespace = new Amazon.ResilienceHub.Model.EksSourceClusterNamespace();
            System.String requestEksSourceClusterNamespace_eksSourceClusterNamespace_EksClusterArn = null;
            if (cmdletContext.EksSourceClusterNamespace_EksClusterArn != null)
            {
                requestEksSourceClusterNamespace_eksSourceClusterNamespace_EksClusterArn = cmdletContext.EksSourceClusterNamespace_EksClusterArn;
            }
            if (requestEksSourceClusterNamespace_eksSourceClusterNamespace_EksClusterArn != null)
            {
                request.EksSourceClusterNamespace.EksClusterArn = requestEksSourceClusterNamespace_eksSourceClusterNamespace_EksClusterArn;
                requestEksSourceClusterNamespaceIsNull = false;
            }
            System.String requestEksSourceClusterNamespace_eksSourceClusterNamespace_Namespace = null;
            if (cmdletContext.EksSourceClusterNamespace_Namespace != null)
            {
                requestEksSourceClusterNamespace_eksSourceClusterNamespace_Namespace = cmdletContext.EksSourceClusterNamespace_Namespace;
            }
            if (requestEksSourceClusterNamespace_eksSourceClusterNamespace_Namespace != null)
            {
                request.EksSourceClusterNamespace.Namespace = requestEksSourceClusterNamespace_eksSourceClusterNamespace_Namespace;
                requestEksSourceClusterNamespaceIsNull = false;
            }
             // determine if request.EksSourceClusterNamespace should be set to null
            if (requestEksSourceClusterNamespaceIsNull)
            {
                request.EksSourceClusterNamespace = null;
            }
            if (cmdletContext.SourceArn != null)
            {
                request.SourceArn = cmdletContext.SourceArn;
            }
            
             // populate TerraformSource
            var requestTerraformSourceIsNull = true;
            request.TerraformSource = new Amazon.ResilienceHub.Model.TerraformSource();
            System.String requestTerraformSource_terraformSource_S3StateFileUrl = null;
            if (cmdletContext.TerraformSource_S3StateFileUrl != null)
            {
                requestTerraformSource_terraformSource_S3StateFileUrl = cmdletContext.TerraformSource_S3StateFileUrl;
            }
            if (requestTerraformSource_terraformSource_S3StateFileUrl != null)
            {
                request.TerraformSource.S3StateFileUrl = requestTerraformSource_terraformSource_S3StateFileUrl;
                requestTerraformSourceIsNull = false;
            }
             // determine if request.TerraformSource should be set to null
            if (requestTerraformSourceIsNull)
            {
                request.TerraformSource = null;
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
        
        private Amazon.ResilienceHub.Model.DeleteAppInputSourceResponse CallAWSServiceOperation(IAmazonResilienceHub client, Amazon.ResilienceHub.Model.DeleteAppInputSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resilience Hub", "DeleteAppInputSource");
            try
            {
                #if DESKTOP
                return client.DeleteAppInputSource(request);
                #elif CORECLR
                return client.DeleteAppInputSourceAsync(request).GetAwaiter().GetResult();
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
            public System.String AppArn { get; set; }
            public System.String ClientToken { get; set; }
            public System.String EksSourceClusterNamespace_EksClusterArn { get; set; }
            public System.String EksSourceClusterNamespace_Namespace { get; set; }
            public System.String SourceArn { get; set; }
            public System.String TerraformSource_S3StateFileUrl { get; set; }
            public System.Func<Amazon.ResilienceHub.Model.DeleteAppInputSourceResponse, RemoveRESHAppInputSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
