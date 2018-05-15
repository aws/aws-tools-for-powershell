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
using Amazon.Organizations;
using Amazon.Organizations.Model;

namespace Amazon.PowerShell.Cmdlets.ORG
{
    /// <summary>
    /// Disables an organizational control policy type in a root. A policy of a certain type
    /// can be attached to entities in a root only if that type is enabled in the root. After
    /// you perform this operation, you no longer can attach policies of the specified type
    /// to that root or to any organizational unit (OU) or account in that root. You can undo
    /// this by using the <a>EnablePolicyType</a> operation.
    /// 
    ///  
    /// <para>
    /// This operation can be called only from the organization's master account.
    /// </para><note><para>
    /// If you disable a policy type for a root, it still shows as enabled for the organization
    /// if all features are enabled in that organization. Use <a>ListRoots</a> to see the
    /// status of policy types for a specified root. Use <a>DescribeOrganization</a> to see
    /// the status of policy types in the organization.
    /// </para></note>
    /// </summary>
    [Cmdlet("Disable", "ORGPolicyType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Organizations.Model.Root")]
    [AWSCmdlet("Calls the AWS Organizations DisablePolicyType API operation.", Operation = new[] {"DisablePolicyType"})]
    [AWSCmdletOutput("Amazon.Organizations.Model.Root",
        "This cmdlet returns a Root object.",
        "The service call response (type Amazon.Organizations.Model.DisablePolicyTypeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class DisableORGPolicyTypeCmdlet : AmazonOrganizationsClientCmdlet, IExecutor
    {
        
        #region Parameter PolicyType
        /// <summary>
        /// <para>
        /// <para>The policy type that you want to disable in this root.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.Organizations.PolicyType")]
        public Amazon.Organizations.PolicyType PolicyType { get; set; }
        #endregion
        
        #region Parameter RootId
        /// <summary>
        /// <para>
        /// <para>The unique identifier (ID) of the root in which you want to disable a policy type.
        /// You can get the ID from the <a>ListRoots</a> operation.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> for a root ID string
        /// requires "r-" followed by from 4 to 32 lower-case letters or digits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RootId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RootId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disable-ORGPolicyType (DisablePolicyType)"))
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
            
            context.PolicyType = this.PolicyType;
            context.RootId = this.RootId;
            
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
            var request = new Amazon.Organizations.Model.DisablePolicyTypeRequest();
            
            if (cmdletContext.PolicyType != null)
            {
                request.PolicyType = cmdletContext.PolicyType;
            }
            if (cmdletContext.RootId != null)
            {
                request.RootId = cmdletContext.RootId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Root;
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
        
        private Amazon.Organizations.Model.DisablePolicyTypeResponse CallAWSServiceOperation(IAmazonOrganizations client, Amazon.Organizations.Model.DisablePolicyTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Organizations", "DisablePolicyType");
            try
            {
                #if DESKTOP
                return client.DisablePolicyType(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DisablePolicyTypeAsync(request);
                return task.Result;
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
            public Amazon.Organizations.PolicyType PolicyType { get; set; }
            public System.String RootId { get; set; }
        }
        
    }
}
