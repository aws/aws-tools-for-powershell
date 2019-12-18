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
using Amazon.Organizations;
using Amazon.Organizations.Model;

namespace Amazon.PowerShell.Cmdlets.ORG
{
    /// <summary>
    /// Disables the integration of an AWS service (the service that is specified by <code>ServicePrincipal</code>)
    /// with AWS Organizations. When you disable integration, the specified service no longer
    /// can create a <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/using-service-linked-roles.html">service-linked
    /// role</a> in <i>new</i> accounts in your organization. This means the service can't
    /// perform operations on your behalf on any new accounts in your organization. The service
    /// can still perform operations in older accounts until the service completes its clean-up
    /// from AWS Organizations.
    /// 
    ///   <important><para>
    /// We recommend that you disable integration between AWS Organizations and the specified
    /// AWS service by using the console or commands that are provided by the specified service.
    /// Doing so ensures that the other service is aware that it can clean up any resources
    /// that are required only for the integration. How the service cleans up its resources
    /// in the organization's accounts depends on that service. For more information, see
    /// the documentation for the other AWS service.
    /// </para></important><para>
    /// After you perform the <code>DisableAWSServiceAccess</code> operation, the specified
    /// service can no longer perform operations in your organization's accounts. The only
    /// exception is when the operations are explicitly permitted by IAM policies that are
    /// attached to your roles. 
    /// </para><para>
    /// For more information about integrating other services with AWS Organizations, including
    /// the list of services that work with Organizations, see <a href="http://docs.aws.amazon.com/organizations/latest/userguide/orgs_integrate_services.html">Integrating
    /// AWS Organizations with Other AWS Services</a> in the <i>AWS Organizations User Guide.</i></para><para>
    /// This operation can be called only from the organization's master account.
    /// </para>
    /// </summary>
    [Cmdlet("Disable", "ORGAWSServiceAccess", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Organizations DisableAWSServiceAccess API operation.", Operation = new[] {"DisableAWSServiceAccess"}, SelectReturnType = typeof(Amazon.Organizations.Model.DisableAWSServiceAccessResponse))]
    [AWSCmdletOutput("None or Amazon.Organizations.Model.DisableAWSServiceAccessResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Organizations.Model.DisableAWSServiceAccessResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class DisableORGAWSServiceAccessCmdlet : AmazonOrganizationsClientCmdlet, IExecutor
    {
        
        #region Parameter ServicePrincipal
        /// <summary>
        /// <para>
        /// <para>The service principal name of the AWS service for which you want to disable integration
        /// with your organization. This is typically in the form of a URL, such as <code><i>service-abbreviation</i>.amazonaws.com</code>.</para>
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
        public System.String ServicePrincipal { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Organizations.Model.DisableAWSServiceAccessResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServicePrincipal parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServicePrincipal' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServicePrincipal' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServicePrincipal), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disable-ORGAWSServiceAccess (DisableAWSServiceAccess)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Organizations.Model.DisableAWSServiceAccessResponse, DisableORGAWSServiceAccessCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServicePrincipal;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ServicePrincipal = this.ServicePrincipal;
            #if MODULAR
            if (this.ServicePrincipal == null && ParameterWasBound(nameof(this.ServicePrincipal)))
            {
                WriteWarning("You are passing $null as a value for parameter ServicePrincipal which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Organizations.Model.DisableAWSServiceAccessRequest();
            
            if (cmdletContext.ServicePrincipal != null)
            {
                request.ServicePrincipal = cmdletContext.ServicePrincipal;
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
        
        private Amazon.Organizations.Model.DisableAWSServiceAccessResponse CallAWSServiceOperation(IAmazonOrganizations client, Amazon.Organizations.Model.DisableAWSServiceAccessRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Organizations", "DisableAWSServiceAccess");
            try
            {
                #if DESKTOP
                return client.DisableAWSServiceAccess(request);
                #elif CORECLR
                return client.DisableAWSServiceAccessAsync(request).GetAwaiter().GetResult();
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
            public System.String ServicePrincipal { get; set; }
            public System.Func<Amazon.Organizations.Model.DisableAWSServiceAccessResponse, DisableORGAWSServiceAccessCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
