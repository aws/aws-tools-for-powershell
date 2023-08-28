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
    /// Creates an Amazon Web Services organization. The account whose user is calling the
    /// <code>CreateOrganization</code> operation automatically becomes the <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_getting-started_concepts.html#account">management
    /// account</a> of the new organization.
    /// 
    ///  
    /// <para>
    /// This operation must be called using credentials from the account that is to become
    /// the new organization's management account. The principal must also have the relevant
    /// IAM permissions.
    /// </para><para>
    /// By default (or if you set the <code>FeatureSet</code> parameter to <code>ALL</code>),
    /// the new organization is created with all features enabled and service control policies
    /// automatically enabled in the root. If you instead choose to create the organization
    /// supporting only the consolidated billing features by setting the <code>FeatureSet</code>
    /// parameter to <code>CONSOLIDATED_BILLING</code>, no policy types are enabled by default
    /// and you can't use organization policies.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ORGOrganization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Organizations.Model.Organization")]
    [AWSCmdlet("Calls the AWS Organizations CreateOrganization API operation.", Operation = new[] {"CreateOrganization"}, SelectReturnType = typeof(Amazon.Organizations.Model.CreateOrganizationResponse))]
    [AWSCmdletOutput("Amazon.Organizations.Model.Organization or Amazon.Organizations.Model.CreateOrganizationResponse",
        "This cmdlet returns an Amazon.Organizations.Model.Organization object.",
        "The service call response (type Amazon.Organizations.Model.CreateOrganizationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewORGOrganizationCmdlet : AmazonOrganizationsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        #region Parameter FeatureSet
        /// <summary>
        /// <para>
        /// <para>Specifies the feature set supported by the new organization. Each feature set supports
        /// different levels of functionality.</para><ul><li><para><code>CONSOLIDATED_BILLING</code>: All member accounts have their bills consolidated
        /// to and paid by the management account. For more information, see <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_getting-started_concepts.html#feature-set-cb-only">Consolidated
        /// billing</a> in the <i>Organizations User Guide</i>.</para><para> The consolidated billing feature subset isn't available for organizations in the
        /// Amazon Web Services GovCloud (US) Region.</para></li><li><para><code>ALL</code>: In addition to all the features supported by the consolidated billing
        /// feature set, the management account can also apply any policy type to any member account
        /// in the organization. For more information, see <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_getting-started_concepts.html#feature-set-all">All
        /// features</a> in the <i>Organizations User Guide</i>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.Organizations.OrganizationFeatureSet")]
        public Amazon.Organizations.OrganizationFeatureSet FeatureSet { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Organization'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Organizations.Model.CreateOrganizationResponse).
        /// Specifying the name of a property of type Amazon.Organizations.Model.CreateOrganizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Organization";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FeatureSet parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FeatureSet' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FeatureSet' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FeatureSet), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ORGOrganization (CreateOrganization)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Organizations.Model.CreateOrganizationResponse, NewORGOrganizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FeatureSet;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FeatureSet = this.FeatureSet;
            
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
            var request = new Amazon.Organizations.Model.CreateOrganizationRequest();
            
            if (cmdletContext.FeatureSet != null)
            {
                request.FeatureSet = cmdletContext.FeatureSet;
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
        
        private Amazon.Organizations.Model.CreateOrganizationResponse CallAWSServiceOperation(IAmazonOrganizations client, Amazon.Organizations.Model.CreateOrganizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Organizations", "CreateOrganization");
            try
            {
                #if DESKTOP
                return client.CreateOrganization(request);
                #elif CORECLR
                return client.CreateOrganizationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Organizations.OrganizationFeatureSet FeatureSet { get; set; }
            public System.Func<Amazon.Organizations.Model.CreateOrganizationResponse, NewORGOrganizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Organization;
        }
        
    }
}
