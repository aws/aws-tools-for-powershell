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
using Amazon.Organizations;
using Amazon.Organizations.Model;

namespace Amazon.PowerShell.Cmdlets.ORG
{
    /// <summary>
    /// Creates an AWS organization. The account whose user is calling the CreateOrganization
    /// operation automatically becomes the <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/orgs_getting-started_concepts.html#account">master
    /// account</a> of the new organization.
    /// 
    ///  
    /// <para>
    /// This operation must be called using credentials from the account that is to become
    /// the new organization's master account. The principal must also have the relevant IAM
    /// permissions.
    /// </para><para>
    /// By default, a new organization is created in full-control mode and service control
    /// policies are automatically enabled in the root. If you instead choose to create the
    /// organization in billing mode by setting the <code>Mode</code> parameter to <code>BILLING"</code>,
    /// then no policy types are enabled by default.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ORGOrganization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Organizations.Model.Organization")]
    [AWSCmdlet("Invokes the CreateOrganization operation against AWS Organizations.", Operation = new[] {"CreateOrganization"})]
    [AWSCmdletOutput("Amazon.Organizations.Model.Organization",
        "This cmdlet returns a Organization object.",
        "The service call response (type Amazon.Organizations.Model.CreateOrganizationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewORGOrganizationCmdlet : AmazonOrganizationsClientCmdlet, IExecutor
    {
        
        #region Parameter Mode
        /// <summary>
        /// <para>
        /// <para>Specifies the mode that the new organization is in. Each mode supports different levels
        /// of functionality.</para><ul><li><para><i>BILLING</i>: All member accounts have their bills consolidated to and paid by
        /// the master account. For more information, see <a href="http://docs.aws.amazon.com/organizations/latest/userguide/orgs_getting-started_concepts.html#billing-mode">Billing
        /// mode</a> in the <i>AWS Organizations User Guide</i>.</para><note><para>If you use the AWS Organizations console, you can create an organization only in full-control
        /// mode. To create an organization in billing mode, you must call this API through a
        /// tool such as the AWS CLI or an AWS SDK.</para></note></li><li><para><i>FULL_CONTROL</i>: In addition to all the features of billing mode, the master
        /// account can apply any type of policy to any member account in the organization. For
        /// more information, see <a href="http://docs.aws.amazon.com/organizations/latest/userguide/orgs_getting-started_concepts.html#full-control-mode">Full-control
        /// mode</a> in the <i>AWS Organizations User Guide</i>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.Organizations.OrganizationMode")]
        public Amazon.Organizations.OrganizationMode Mode { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Mode", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ORGOrganization (CreateOrganization)"))
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
            
            context.Mode = this.Mode;
            
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
            
            if (cmdletContext.Mode != null)
            {
                request.Mode = cmdletContext.Mode;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Organization;
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
        
        private static Amazon.Organizations.Model.CreateOrganizationResponse CallAWSServiceOperation(IAmazonOrganizations client, Amazon.Organizations.Model.CreateOrganizationRequest request)
        {
            #if DESKTOP
            return client.CreateOrganization(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateOrganizationAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public Amazon.Organizations.OrganizationMode Mode { get; set; }
        }
        
    }
}
