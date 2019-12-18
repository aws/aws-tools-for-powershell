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
    /// Enables all features in an organization. This enables the use of organization policies
    /// that can restrict the services and actions that can be called in each account. Until
    /// you enable all features, you have access only to consolidated billing. You can't use
    /// any of the advanced account administration features that AWS Organizations supports.
    /// For more information, see <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_org_support-all-features.html">Enabling
    /// All Features in Your Organization</a> in the <i>AWS Organizations User Guide.</i><important><para>
    /// This operation is required only for organizations that were created explicitly with
    /// only the consolidated billing features enabled. Calling this operation sends a handshake
    /// to every invited account in the organization. The feature set change can be finalized
    /// and the additional features enabled only after all administrators in the invited accounts
    /// approve the change. Accepting the handshake approves the change.
    /// </para></important><para>
    /// After you enable all features, you can separately enable or disable individual policy
    /// types in a root using <a>EnablePolicyType</a> and <a>DisablePolicyType</a>. To see
    /// the status of policy types in a root, use <a>ListRoots</a>.
    /// </para><para>
    /// After all invited member accounts accept the handshake, you finalize the feature set
    /// change by accepting the handshake that contains <code>"Action": "ENABLE_ALL_FEATURES"</code>.
    /// This completes the change.
    /// </para><para>
    /// After you enable all features in your organization, the master account in the organization
    /// can apply policies on all member accounts. These policies can restrict what users
    /// and even administrators in those accounts can do. The master account can apply policies
    /// that prevent accounts from leaving the organization. Ensure that your account administrators
    /// are aware of this.
    /// </para><para>
    /// This operation can be called only from the organization's master account. 
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "ORGAllFeature", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Organizations.Model.Handshake")]
    [AWSCmdlet("Calls the AWS Organizations EnableAllFeatures API operation.", Operation = new[] {"EnableAllFeatures"}, SelectReturnType = typeof(Amazon.Organizations.Model.EnableAllFeaturesResponse), LegacyAlias="Enable-ORGAllFeatures")]
    [AWSCmdletOutput("Amazon.Organizations.Model.Handshake or Amazon.Organizations.Model.EnableAllFeaturesResponse",
        "This cmdlet returns an Amazon.Organizations.Model.Handshake object.",
        "The service call response (type Amazon.Organizations.Model.EnableAllFeaturesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EnableORGAllFeatureCmdlet : AmazonOrganizationsClientCmdlet, IExecutor
    {
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Handshake'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Organizations.Model.EnableAllFeaturesResponse).
        /// Specifying the name of a property of type Amazon.Organizations.Model.EnableAllFeaturesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Handshake";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-ORGAllFeature (EnableAllFeatures)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Organizations.Model.EnableAllFeaturesResponse, EnableORGAllFeatureCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.Organizations.Model.EnableAllFeaturesRequest();
            
            
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
        
        private Amazon.Organizations.Model.EnableAllFeaturesResponse CallAWSServiceOperation(IAmazonOrganizations client, Amazon.Organizations.Model.EnableAllFeaturesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Organizations", "EnableAllFeatures");
            try
            {
                #if DESKTOP
                return client.EnableAllFeatures(request);
                #elif CORECLR
                return client.EnableAllFeaturesAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Organizations.Model.EnableAllFeaturesResponse, EnableORGAllFeatureCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Handshake;
        }
        
    }
}
