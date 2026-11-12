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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Associates a Lightsail subdomain with a resource, disassociates it from a resource,
    /// or moves it from one resource to another resource.
    /// 
    ///  
    /// <para>
    /// Currently, you can associate a subdomain only with a Lightsail content delivery network
    /// (CDN) distribution. A resource can be associated with only one subdomain at a time.
    /// </para><para>
    /// When you associate a subdomain with a distribution, Lightsail attaches the subdomain's
    /// certificate to the distribution. You can't associate a subdomain with a distribution
    /// that uses a custom domain, which is a distribution that has a Lightsail certificate
    /// attached.
    /// </para><para>
    /// You can transfer each subdomain to another resource only once in a 24-hour period.
    /// </para><para>
    /// The update is asynchronous. The response returns the subdomain in the <c>ATTACHING</c>,
    /// <c>DETACHING</c>, or <c>TRANSFERRING</c> state, and an operation. To check when the
    /// update is complete, use the <c>GetSubdomains</c> action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LSSubdomainAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.UpdateSubdomainAssociationResponse")]
    [AWSCmdlet("Calls the Amazon Lightsail UpdateSubdomainAssociation API operation.", Operation = new[] {"UpdateSubdomainAssociation"}, SelectReturnType = typeof(Amazon.Lightsail.Model.UpdateSubdomainAssociationResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.UpdateSubdomainAssociationResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.UpdateSubdomainAssociationResponse object containing multiple properties."
    )]
    public partial class UpdateLSSubdomainAssociationCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The association change to make.</para><para>The following actions are possible:</para><ul><li><para><c>ASSOCIATE</c> – Associates the subdomain with the resource that you specify in
        /// the <c>targetResourceArn</c> parameter. The subdomain must be in the <c>UNATTACHED</c>
        /// state.</para></li><li><para><c>DISASSOCIATE</c> – Disassociates the subdomain from its current resource. The
        /// subdomain must be in the <c>ATTACHED</c> state.</para></li><li><para><c>TRANSFER</c> – Moves the subdomain from its current resource to the resource that
        /// you specify in the <c>targetResourceArn</c> parameter. The subdomain must be in the
        /// <c>ATTACHED</c> state. You can transfer each subdomain only once in a 24-hour period.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Lightsail.SubdomainAssociationAction")]
        public Amazon.Lightsail.SubdomainAssociationAction Action { get; set; }
        #endregion
        
        #region Parameter SubdomainName
        /// <summary>
        /// <para>
        /// <para>The subdomain to update (for example, <c>mysite</c> or <c>blog.mysite</c>), not its
        /// web address.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SubdomainName { get; set; }
        #endregion
        
        #region Parameter TargetResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the resource to associate the subdomain with. The
        /// resource must be in your account.</para><para>This parameter is required when the <c>action</c> is <c>ASSOCIATE</c> or <c>TRANSFER</c>.
        /// It's ignored when the <c>action</c> is <c>DISASSOCIATE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetResourceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.UpdateSubdomainAssociationResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.UpdateSubdomainAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SubdomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LSSubdomainAssociation (UpdateSubdomainAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.UpdateSubdomainAssociationResponse, UpdateLSSubdomainAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Action = this.Action;
            #if MODULAR
            if (this.Action == null && ParameterWasBound(nameof(this.Action)))
            {
                WriteWarning("You are passing $null as a value for parameter Action which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SubdomainName = this.SubdomainName;
            #if MODULAR
            if (this.SubdomainName == null && ParameterWasBound(nameof(this.SubdomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter SubdomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetResourceArn = this.TargetResourceArn;
            
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
            var request = new Amazon.Lightsail.Model.UpdateSubdomainAssociationRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Action = cmdletContext.Action;
            }
            if (cmdletContext.SubdomainName != null)
            {
                request.SubdomainName = cmdletContext.SubdomainName;
            }
            if (cmdletContext.TargetResourceArn != null)
            {
                request.TargetResourceArn = cmdletContext.TargetResourceArn;
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
        
        private Amazon.Lightsail.Model.UpdateSubdomainAssociationResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.UpdateSubdomainAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "UpdateSubdomainAssociation");
            try
            {
                return client.UpdateSubdomainAssociationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Lightsail.SubdomainAssociationAction Action { get; set; }
            public System.String SubdomainName { get; set; }
            public System.String TargetResourceArn { get; set; }
            public System.Func<Amazon.Lightsail.Model.UpdateSubdomainAssociationResponse, UpdateLSSubdomainAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
